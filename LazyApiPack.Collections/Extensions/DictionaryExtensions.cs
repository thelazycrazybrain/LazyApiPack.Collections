using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyApiPack.Collections.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Inserts or Updates a value in this dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key to insert or update.</param>
        /// <param name="value">The value for the key.</param>
        /// <returns>True, if the key was newly created, if updated, returns false.</returns>
        public static bool Upsert<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
                return false;
            }
            else
            {
                dictionary.Add(key, value);
                return true;
            }
        }
    }
}
