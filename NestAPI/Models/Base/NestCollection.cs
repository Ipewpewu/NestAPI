using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Base
{
    public abstract class NestCollection<S> : NestObject, IList<S> where S : NestObject, new()
    {
        private List<S> collection;

        public NestCollection()
        {
            collection = new List<S>();
        }

        protected static new T To<T>(JObject jsonList) where T : NestCollection<S>, new()
        {
            try
            {
                var collection = new T();

                var list = jsonList as IEnumerable<dynamic>;
                if (list == null) return collection;

                foreach (var item in list)
                {
                    var obj = new S();

                    obj = item.Value;

                    if (obj != null)
                        collection.Add(obj);
                }

                return collection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public S this[int index]
        {
            get
            {
                return collection[index];
            }

            set
            {
                collection[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return collection.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }



        public void Add(S item)
        {
            collection.Add(item);
        }

        public void Clear()
        {
            collection.Clear();
        }

        public bool Contains(S item)
        {
            return collection.Contains(item);
        }

        public void CopyTo(S[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<S> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        public int IndexOf(S item)
        {
            return collection.IndexOf(item);
        }

        public void Insert(int index, S item)
        {
            collection.Insert(index, item);
        }

        public bool Remove(S item)
        {
            return collection.Remove(item);
        }

        public void RemoveAt(int index)
        {
            collection.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }


    }
}
