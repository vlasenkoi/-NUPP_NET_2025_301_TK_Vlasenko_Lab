using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Shop.Common
{
    public class AsyncCrudService<T> : ICrudServiceAsync<T> where T : Product
    {
        private List<T> data = new List<T>();
        private readonly object _lock = new object();
        private string FilePath = "data.json";

        public async Task<bool> CreateAsync(T element)
        {
            lock (_lock)
            {
                data.Add(element);
            }
            return true;
        }

        public async Task<T> ReadAsync(Guid id)
        {
            return data.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return data;
        }

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            return data.Skip((page - 1) * amount).Take(amount);
        }

        public async Task<bool> UpdateAsync(T element)
        {
            lock (_lock)
            {
                var old = data.FirstOrDefault(x => x.Id == element.Id);
                if (old != null)
                {
                    data.Remove(old);
                    data.Add(element);
                }
            }
            return true;
        }

        public async Task<bool> RemoveAsync(T element)
        {
            lock (_lock)
            {
                data.Remove(element);
            }
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            var json = JsonSerializer.Serialize(data);
            await File.WriteAllTextAsync(FilePath, json);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}