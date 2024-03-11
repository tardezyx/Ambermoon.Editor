using System.ComponentModel;

namespace Ambermoon.Editor.Models
{
	public class FilterProperty<T>(string name, Func<T, object?>? valueProvider = null)
	{
		public string Name { get; set; } = name;
		public Func<T, object?>? ValueProvider { get; set; } = valueProvider;

		public static implicit operator FilterProperty<T>(string name) => new(name);
	}

	public class SortableBindingList<T>(params FilterProperty<T>[] filterableProperties) : BindingList<T>, IBindingListView where T : new()
	{
		#region --- fields ----------------------------------------------------------------------------
		private bool _isSorted;
		private ListSortDirection _sortDirection = ListSortDirection.Ascending;
		private PropertyDescriptor? _sortProperty;
		private string? _filter;
		private readonly Dictionary<string, FilterProperty<T>> _filterProperties = filterableProperties.ToDictionary(f => f.Name, f => f);
		private readonly List<T> _unfilteredList = [];
		private bool _isFiltering = false;
		#endregion
		#region --- properties ------------------------------------------------------------------------
		protected override bool IsSortedCore { get { return _isSorted; } }
		protected override ListSortDirection SortDirectionCore { get { return _sortDirection; } }
		protected override PropertyDescriptor? SortPropertyCore { get { return _sortProperty; } }
		protected override bool SupportsSortingCore { get { return true; } }
		public string? Filter
		{
			get => _filter;
			set
			{
				if (_filter == value) return;

				_filter = value;
				ApplyFilter();
			}
		}
		public ListSortDescriptionCollection SortDescriptions => SortPropertyCore is null ? [] : new ListSortDescriptionCollection([new ListSortDescription(SortPropertyCore, SortDirectionCore)]);
		public bool SupportsAdvancedSorting => false;
		public bool SupportsFiltering => true;

		#endregion
		#region --- constructor -----------------------------------------------------------------------
		public SortableBindingList(IList<T> list, params FilterProperty<T>[] filterableProperties)
			: this(filterableProperties)
		{
			foreach (T item in list)
			{
				Add(item);
			}

			_unfilteredList = new(list);
		}
		#endregion
		#region --- apply sort core -------------------------------------------------------------------
		protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
		{
			_sortProperty = property;
			_sortDirection = direction;

			if (Items is not List<T> list)
			{
				return;
			}

			list.Sort(Compare);

			_isSorted = true;

			OnListChanged(
			  new ListChangedEventArgs(
				ListChangedType.Reset,
				-1
			  )
			);
		}
		#endregion
		#region --- compare ---------------------------------------------------------------------------
		private int Compare(T lhs, T rhs)
		{
			int result = OnComparison(lhs, rhs);

			if (_sortDirection == ListSortDirection.Descending)
			{
				result = -result; // invert if descending
			}

			return result;
		}
		#endregion
		#region --- on comparison ---------------------------------------------------------------------
		private int OnComparison(T lhs, T rhs)
		{
			object? lhsValue = lhs == null
			  ? null
			  : _sortProperty?.GetValue(lhs);

			object? rhsValue = rhs == null
			  ? null
			  : _sortProperty?.GetValue(rhs);

			if (lhsValue == null)
			{
				return rhsValue == null
				  ? 0   // both null
				  : -1; // first null, second has value
			}

			if (rhsValue == null)
			{
				return 1; // first has value, second null
			}

			if (lhsValue is IComparable comparable)
			{
				return comparable
				  .CompareTo(rhsValue);
			}

			if (lhsValue.Equals(rhsValue))
			{
				return 0; // both are the same
			}

			// not comparable, compare ToString
			return lhsValue
			  .ToString()!
			  .CompareTo(rhsValue.ToString());
		}
		#endregion
		#region --- remove sort core ------------------------------------------------------------------
		protected override void RemoveSortCore()
		{
			_isSorted = false;
			_sortDirection = ListSortDirection.Ascending;
			_sortProperty = null;
		}
		#endregion
		#region --- set sort --------------------------------------------------------------------------
		public void SetSort(SortableBindingList<T> sortableBindingList)
		{
			_sortDirection = sortableBindingList._sortDirection;
			_sortProperty = sortableBindingList._sortProperty;
		}
		#endregion
		#region --- sort ------------------------------------------------------------------------------
		public void Sort()
		{
			if (_sortProperty is not null)
			{
				ApplySortCore(
				  _sortProperty,
				  _sortDirection
				);
			}
		}
		#endregion
		#region --- sort by ---------------------------------------------------------------------------
		public void SortBy(string propertyName, ListSortDirection direction)
		{
			ApplySortCore(
			  TypeDescriptor.GetProperties(typeof(T))[propertyName]!,
			  direction
			);
		}
		#endregion
		#region --- apply sort ------------------------------------------------------------------------
		public void ApplySort(ListSortDescriptionCollection sorts)
		{
			if (sorts.Count != 0 && sorts[0] is ListSortDescription sort && sort.PropertyDescriptor is not null)
				ApplySortCore(sort.PropertyDescriptor, sort.SortDirection);
		}
		#endregion
		#region --- remove filter ---------------------------------------------------------------------
		public void RemoveFilter()
		{
			Filter = null;
		}
		#endregion
		#region --- apply filter ----------------------------------------------------------------------
		public void ApplyFilter()
		{
			if (_filterProperties.Count == 0)
				return;

			var properties = _filterProperties.Select(propertyInfo =>
			{
				Func<T, object?>? property = propertyInfo.Value?.ValueProvider ?? ((T item) => typeof(T).GetProperty(propertyInfo.Key)?.GetValue(item));

				return property is null
					? throw new Exception($"Property {propertyInfo.Key} is not accessible in type {typeof(T).FullName} and there is no value provider.")
					: property;
			}).ToList();

			List<T> filteredList = [];
			_isFiltering = true;

			try
			{
				if (!string.IsNullOrWhiteSpace(Filter))
				{
					string filter = Filter.ToLower();

					foreach (var item in _unfilteredList)
					{
						var foo = properties.First()(item);

						if (properties.Any(property => property(item)?.ToString()?.ToLower()?.Contains(filter) == true))
							filteredList.Add(item);
					}
				}
				else
				{
					filteredList.AddRange(_unfilteredList);
				}

				ClearItems();

				foreach (var item in filteredList)
				{
					Add(item);
				}

				OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
			}
			finally
			{
				_isFiltering = false;
			}
		}
		#endregion
		#region --- list changed ----------------------------------------------------------------------
		protected override void OnListChanged(ListChangedEventArgs e)
		{
			base.OnListChanged(e);

			if (_isFiltering)
				return;

			_unfilteredList.Clear();
			_unfilteredList.AddRange(this);
		}
		#endregion
	}
}