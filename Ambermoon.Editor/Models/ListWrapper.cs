using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Util;

namespace Ambermoon.Editor.Models {
  internal class ListWrapper<T> : IDisposable where T : class, IIndexed {
    #region --- properties ------------------------------------------------------------------------
    internal SortableBindingList<T> ForDisplay   { get; private set; } = [];
    internal DictionaryList<T>      InRepository { get; private set; } = [];
    internal bool                   IsDirty      { get; private set; } = false;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    internal ListWrapper(DictionaryList<T> entries) {
      InRepository = entries;

      foreach (T entry in entries) {
        ForDisplay.Add(entry);
      }
    }
    #endregion
    #region --- add -------------------------------------------------------------------------------
    internal void Add(T entry) {
      if (!InRepository.ContainsKey(entry.Index)) {
        ForDisplay.Add(entry);
        InRepository.Add(entry);
        IsDirty = true;
      }
    }
    #endregion
    #region --- clear -----------------------------------------------------------------------------
    internal void Clear() {
      if (InRepository.Count > 0) {
        ForDisplay.Clear();
        InRepository.Clear();
        IsDirty = true;
      }
    }
    #endregion
    #region --- dispose ---------------------------------------------------------------------------
    public void Dispose() { }
    #endregion
    #region --- get -------------------------------------------------------------------------------
    internal T? Get(uint index) {
      if (InRepository.TryGetValue(index, out T? result)) { 
        return result;
      };

      return null;
    }
    #endregion
    #region --- get first free index --------------------------------------------------------------
    internal uint GetFirstFreeIndex() {
      if (InRepository.Count == 0) {
        return 1;
      }

      for (uint i = 1; i < InRepository.Count; i++) {
        if (!InRepository.ContainsKey(i)) {
          return i;
        }
      }

      return InRepository.Keys.Max() + 1;
    }
    #endregion
    #region --- get highest index -----------------------------------------------------------------
    internal uint GetHighestIndex() {
      return InRepository.Keys.Max();
    }
    #endregion
    #region --- has been changed ------------------------------------------------------------------
    internal void HasBeenChanged() {
      IsDirty = true;
    }
    #endregion
    #region --- remove ----------------------------------------------------------------------------
    internal void Remove(T entry) {
      if (InRepository.TryGetValue(entry.Index, out _)) {
        ForDisplay.Remove(entry);
        InRepository.Remove(entry);
        IsDirty = true;
      }
    }
    #endregion
  }
}