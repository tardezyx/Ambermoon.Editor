using System.Collections;

namespace Ambermoon.Editor.Models {
  internal class DropOutStack<T>(int capacity) : IEnumerable<T> where T : class {
    #region --- local class: stack enumerator -----------------------------------------------------
    private class StackEnumerator<T2>(DropOutStack<T2> stack) : IEnumerator<T2>, IEnumerator where T2 : class {
      private int position = -1;

      object IEnumerator.Current => Current;

      public T2 Current {
        get {
          try {
            return stack._items[position];
          } catch (IndexOutOfRangeException) {
            throw new InvalidOperationException("Stack enumerator points to invalid item.");
          }
        }
      }

      public void Dispose() { }

      public bool MoveNext() {
        if (position == -1) {
          int peekTop = stack.Count == 0 ? 0 : (stack._items.Length + stack._top - 1) % stack._items.Length;
          position = peekTop;
          return stack.Count != 0;
        } else {
          position = (stack._items.Length + position - 1) % stack._items.Length;
          while (stack._items[position] == null) {
            position = (stack._items.Length + position - 1) % stack._items.Length;
          }
          return ((position + 1) % stack._items.Length) != stack._top;
        }
      }

      public void Reset() {
        position = -1;
      }
    }
    #endregion

    #region --- fields ----------------------------------------------------------------------------
    private T[] _items = new T[capacity];
    private int _top = 0;
    #endregion
    #region --- properties ------------------------------------------------------------------------
    public int Count { get; private set; } = 0;
    #endregion

    #region --- clear -----------------------------------------------------------------------------
    public void Clear() {
      _items = new T[_items.Length];
      _top = 0;
      Count = 0;
    }
    #endregion
    #region --- get enumerator --------------------------------------------------------------------
    IEnumerator IEnumerable.GetEnumerator() => new StackEnumerator<T>(this); // generic
    public IEnumerator<T> GetEnumerator() => new StackEnumerator<T>(this);   // non-generic
    #endregion
    #region --- peek ------------------------------------------------------------------------------
    public T? Peek() {
      if (Count == 0) {
        return null;
      }

      int peekTop = (_items.Length + _top - 1) % _items.Length;

      return _items[peekTop];
    }
    #endregion
    #region --- pop -------------------------------------------------------------------------------
    public T Pop() {
      if (Count == 0) {
        throw new InvalidOperationException("Pop on an empty stack");
      }

      _top = (_items.Length + _top - 1) % _items.Length;
      T item = _items[_top];
      _items[_top] = null!;
      --Count;

      return item;
    }
    #endregion
    #region --- push ------------------------------------------------------------------------------
    public bool Push(T item) {
      bool result = Count == _items.Length;

      _items[_top] = item;
      _top = (_top + 1) % _items.Length;
      Count = Math.Min(Count + 1, _items.Length);

      return result;
    }
    #endregion
  }
}