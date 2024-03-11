using Ambermoon.Data.GameDataRepository.Collections;
using Ambermoon.Data.GameDataRepository.Data;

namespace Ambermoon.Editor.Models
{
	internal class ListWrapper<T> : IDisposable where T : class, IIndexed, new()
	{
		#region --- fields -----------------------------------------------------------------------------
		private readonly SortableBindingList<T> _entries = [];
		#endregion
		#region --- properties ------------------------------------------------------------------------
		internal BindingSource ForDisplay { get; } = [];
		internal DictionaryList<T> InRepository { get; } = [];
		internal bool IsDirty { get; private set; } = false;
		#endregion
		#region --- constructor -----------------------------------------------------------------------
		internal ListWrapper(DictionaryList<T>? entries, params FilterProperty<T>[] filterableProperties)
		{
			if (entries is null)
			{
				return;
			}

			InRepository = entries;
			_entries = new(filterableProperties);

			foreach (T entry in entries)
			{
				_entries.Add(entry);
			}

			ForDisplay.DataSource = _entries;
		}
		#endregion
		#region --- add -------------------------------------------------------------------------------
		internal void Add(T entry)
		{
			if (!InRepository.ContainsKey(entry.Index))
			{
				_entries.Add(entry);
				InRepository.Add(entry);
				IsDirty = true;
			}
		}
		#endregion
		#region --- clear -----------------------------------------------------------------------------
		internal void Clear()
		{
			if (InRepository.Count > 0)
			{
				_entries.Clear();
				InRepository.Clear();
				IsDirty = true;
			}
		}
		#endregion
		#region --- dispose ---------------------------------------------------------------------------
		public void Dispose() { }
		#endregion
		#region --- get -------------------------------------------------------------------------------
		internal T? Get(uint index)
		{
			if (InRepository.TryGetValue(index, out T? result))
			{
				return result;
			};

			return null;
		}
		#endregion
		#region --- get first free index --------------------------------------------------------------
		internal uint GetFirstFreeIndex()
		{
			if (InRepository.Count == 0)
			{
				return 1;
			}

			for (uint i = 1; i < InRepository.Count; i++)
			{
				if (!InRepository.ContainsKey(i))
				{
					return i;
				}
			}

			return InRepository.Keys.Max() + 1;
		}
		#endregion
		#region --- get highest index -----------------------------------------------------------------
		internal uint GetHighestIndex()
		{
			return InRepository.Keys.Max();
		}
		#endregion
		#region --- has been changed ------------------------------------------------------------------
		internal void HasBeenChanged()
		{
			IsDirty = true;
		}
		#endregion
		#region --- remove ----------------------------------------------------------------------------
		internal void Remove(T entry)
		{
			if (InRepository.TryGetValue(entry.Index, out _))
			{
				_entries.Remove(entry);
				InRepository.Remove(entry);
				IsDirty = true;
			}
		}
		#endregion
	}
}