using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Common
{
    public class CrudService<T> : ICrudService<T> where T : Product
    {
        private List<T> data = new List<T>();

        public static int Count = 0;

        public void Create(T element)
        {
            data.Add(element);
            Count++;
        }

        public T Read(Guid id)
        {
            return data.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> ReadAll()
        {
            return data;
        }

        public void Update(T element)
        {
            var old = Read(element.Id);
            if (old != null)
            {
                data.Remove(old);
                data.Add(element);
            }
        }

        public void Remove(T element)
        {
            data.Remove(element);
        }
    }
}