using System.ComponentModel;

namespace Ambermoon.Editor.Models {
  public class SortableBindingList<T> : BindingList<T> where T : class {
    #region --- fields ----------------------------------------------------------------------------
    private bool                _isSorted;
    private ListSortDirection   _sortDirection = ListSortDirection.Ascending;
    private PropertyDescriptor? _sortProperty;
    #endregion
    #region --- properties ------------------------------------------------------------------------
    protected override bool                IsSortedCore        { get { return _isSorted; } }
    protected override ListSortDirection   SortDirectionCore   { get { return _sortDirection; } }
    protected override PropertyDescriptor? SortPropertyCore    { get { return _sortProperty; } }
    protected override bool                SupportsSortingCore { get { return true; } }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public SortableBindingList() { }

    public SortableBindingList(IList<T> list) : base() {
      foreach (T item in list) {
        Add(item);
      }
    }
    #endregion
    #region --- apply sort core -------------------------------------------------------------------
    protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction) {
      _sortProperty  = property;
      _sortDirection = direction;

      if (Items is not List<T> list) {
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
    private int Compare(T lhs, T rhs) {
      int result = OnComparison(lhs, rhs);
      
      if (_sortDirection == ListSortDirection.Descending) {
        result = -result; // invert if descending
      }

      return result;
    }
    #endregion
    #region --- on comparison ---------------------------------------------------------------------
    private int OnComparison(T lhs, T rhs) {
      object? lhsValue = lhs == null
        ? null
        : _sortProperty?.GetValue(lhs);

      object? rhsValue = rhs == null
        ? null
        : _sortProperty?.GetValue(rhs);

      if (lhsValue == null) {
        return rhsValue == null
          ? 0   // both null
          : -1; // first null, second has value
      }

      if (rhsValue == null) {
        return 1; // first has value, second null
      }

      if (lhsValue is IComparable comparable) {
        return comparable
          .CompareTo(rhsValue);
      }

      if (lhsValue.Equals(rhsValue)) {
        return 0; // both are the same
      }

      // not comparable, compare ToString
      return lhsValue
        .ToString()!
        .CompareTo(rhsValue.ToString());
    }
    #endregion
    #region --- remove sort core ------------------------------------------------------------------
    protected override void RemoveSortCore() {
      _isSorted      = false;
      _sortDirection = ListSortDirection.Ascending;
      _sortProperty  = null;
    }
    #endregion
    #region --- set sort --------------------------------------------------------------------------
    public void SetSort(SortableBindingList<T> sortableBindingList) {
      _sortDirection = sortableBindingList._sortDirection;
      _sortProperty  = sortableBindingList._sortProperty;
    }
    #endregion
    #region --- sort ------------------------------------------------------------------------------
    public void Sort() {
      if (_sortProperty is not null) {
        ApplySortCore(
          _sortProperty,
          _sortDirection
        );
      }
    }
    #endregion
    #region --- sort by ---------------------------------------------------------------------------
    public void SortBy(string propertyName, ListSortDirection direction) {
      ApplySortCore(
        TypeDescriptor.GetProperties(typeof(T))[propertyName]!,
        direction
      );
    }
    #endregion
  }
}