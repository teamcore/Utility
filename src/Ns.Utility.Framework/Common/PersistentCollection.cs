using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ns.Utility.Framework.Common
{
    public class PersistentCollection<T> : IPersistentCollection<T>
         where T : class
    {
        private readonly ICollection<T> actual;
        private Action<ICollection<T>> afterAdd;
        private Action<ICollection<T>> afterRemove;
        private Func<ICollection<T>, T, bool> beforeAdd;
        private Func<ICollection<T>, T, bool> beforeRemove;

        public PersistentCollection(ICollection<T> actual)
        {
            this.actual = actual;
        }

        /// <summary>
        ///     perform actions on one or more list items after an item is
        ///     added.
        /// </summary>
        public Action<ICollection<T>> AfterAdd
        {
            get { return afterAdd ?? (afterAdd = l => { }); }
            set { afterAdd = value; }
        }

        /// <summary>
        ///     perform actions on one or more list items after an item is
        ///     removed.
        /// </summary>
        public Action<ICollection<T>> AfterRemove
        {
            get { return afterRemove ?? (afterRemove = l => { }); }
            set { afterRemove = value; }
        }

        /// <summary>
        ///     perform a check on the item being added before adding it.
        ///     Return true if it should be added, false if it should not be
        ///     added.
        /// </summary>
        public Func<ICollection<T>, T, bool> BeforeAdd
        {
            get { return beforeAdd ?? (beforeAdd = (l, x) => true); }
            set { beforeAdd = value; }
        }

        /// <summary>
        ///     perform a check on the item being removed before removing
        ///     it. Return true if it should be removed, false if it should not
        ///     be removed.
        /// </summary>
        public Func<ICollection<T>, T, bool> BeforeRemove
        {
            get { return beforeRemove ?? (beforeRemove = (l, x) => true); }
            set { beforeRemove = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return actual.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int Count
        {
            get { return actual.Count; }
        }
        public bool IsReadOnly
        {
            get { return actual.IsReadOnly; }
        }

        public void Add(T item)
        {
            if (BeforeAdd(this, item))
            {
                actual.Add(item);
                AfterAdd(this);
            }
        }

        public void Clear()
        {
            while (actual.Any())
            {
                Remove(actual.First());
            }
        }

        public bool Contains(T item)
        {
            return actual.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            actual.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (BeforeRemove(this, item))
            {
                bool toReturn = actual.Remove(item);
                AfterRemove(this);
                return toReturn;
            }
            return true;
        }

        void ICollection.CopyTo(Array array, int index)
        {
            var copy = new T[actual.Count];
            actual.CopyTo(copy, 0);
            Array.Copy(copy, 0, array, index, actual.Count);
        }

        int ICollection.Count
        {
            get { return actual.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        object ICollection.SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}
