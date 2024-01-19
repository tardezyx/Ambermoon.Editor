using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Util;

namespace Ambermoon.Editor.Models {
  internal class ListWrapper<T> : IDisposable where T : class, IIndexedData {
    #region --- properties ------------------------------------------------------------------------
    internal SortableBindingList<T> ForDisplay   { get; private set; } = [];
    internal DictionaryList<T>      InRepository { get; private set; } = [];
    internal bool                   IsDirty      { get; private set; } = false;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    internal ListWrapper(DictionaryList<T> entities) {
      InRepository = entities;

      foreach (T entity in entities) {
        ForDisplay.Add(entity);
      }
    }
    #endregion
    #region --- add -------------------------------------------------------------------------------
    internal void Add(T entity) {
      if (!InRepository.TryGetValue(entity.Index, out _)) {
        ForDisplay.Add(entity);
        InRepository.Add(entity);
        IsDirty = true;
      }
    }
    #endregion
    #region --- change ----------------------------------------------------------------------------
    internal void Change(T entity) {
      if (
        InRepository.TryGetValue(entity.Index, out T? entityInRepositoryList)
        && entityInRepositoryList != entity) {
        entityInRepositoryList = entity;

        T entityInDisplayList = ForDisplay.First(x => x.Index == entity.Index);
        entityInDisplayList = entity;

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
    #region --- remove ----------------------------------------------------------------------------
    internal void Remove(T entity) {
      if (InRepository.TryGetValue(entity.Index, out _)) {
        ForDisplay.Remove(entity);
        InRepository.Remove(entity);
        IsDirty = true;
      }
    }
    #endregion
  }
}