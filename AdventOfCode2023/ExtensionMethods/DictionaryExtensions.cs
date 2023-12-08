using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.ExtensionMethods
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<T> GetValueListByKeyFilter<T>(this Dictionary<string, T> dictionary, Func<string, bool> predicate)
        {
            var startingNodeKeys = dictionary.Keys.Where(predicate);
            var returnList = new List<T>();
            foreach(var startingNodeKey in startingNodeKeys)
            {
                returnList.Add(dictionary[startingNodeKey]);
            }
            return returnList;
        }
    }
}
