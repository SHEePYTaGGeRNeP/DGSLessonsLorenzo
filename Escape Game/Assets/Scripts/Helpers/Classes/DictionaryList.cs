using System.Collections.Generic;

namespace Assets.Scripts.Helpers.Classes
{
    /// <summary>
    /// Dictionary with a list as values.
    /// http://stackoverflow.com/questions/17887407/dictionary-with-list-of-strings-as-value
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionaryList<TKey, TValue>
    {
        private readonly Dictionary<TKey, List<TValue>> _dictionary = new Dictionary<TKey, List<TValue>>();

        public void Add(TKey key, TValue value)
        {
            if (this._dictionary.ContainsKey(key))
                this._dictionary[key].Add(value);
            else
            {
                List<TValue> list = new List<TValue> { value };
                this._dictionary.Add(key, list);
            }
        }

        public void Remove(TKey key)
        {
            this._dictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out IEnumerable<TValue> value)
        {
            bool result = this._dictionary.TryGetValue(key, out var tmp);
            value = tmp;
            return result;
        }

        public IEnumerable<TValue> Get(TKey key) => this._dictionary[key];


        public bool ContainsKey(TKey key) => this._dictionary.ContainsKey(key);

        public TValue GetRandom(TKey key, out bool found)
        {
            if (!this._dictionary.ContainsKey(key))
            {
                found = false;
                return default(TValue);
            }
            found = true;
            int count = this._dictionary[key].Count;
            return this._dictionary[key][UnityEngine.Random.Range(0, count)];
        }
    }
}
