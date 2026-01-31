using UnityEngine;
using System.Collections.Generic;

    [System.Serializable]
    public class DuctTapeDictionaryItem<T1, T2>
    {
        public T1 key;
        public T2 value;
    }

[System.Serializable]
public class DuctTapeDictionary<T1, T2>
{
    public List<DuctTapeDictionaryItem<T1, T2>> dictionary;

    // OhMy this is ugly, non-performant code. But it works! Duct Tape and Rubberbands!
    public T2 FindFirst(T1 key)
    {
        foreach (DuctTapeDictionaryItem<T1, T2> item in dictionary) {
            if (item.key.Equals(key)) {
                return item.value;
            }
        }
        return default(T2);
    }

    public List<T2> FindAll(T1 key)
    {
        List<T2> values = new List<T2>();
        foreach (DuctTapeDictionaryItem<T1, T2> item in dictionary) {
            if (item.key.Equals(key)) {
                values.Add(item.value);
            }
        }
        if (values.Count > 0) 
        { 
            return values;
        }

        return null;
    }
}
