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
    public static DuctTapeDictionaryItem<T1,T2> FindFirst(List<DuctTapeDictionaryItem<T1, T2>> dictionary, T1 key)
    {
        foreach (DuctTapeDictionaryItem<T1, T2> item in dictionary) {
            if (item.key.Equals(key)) {
                return item;
            }
        }
        return null;
    }

    public static List<DuctTapeDictionaryItem<T1, T2>> FindAll(T1 key)
    {
        // TODO: THIS DOES NOTHING YET! MAKE IT RETURN ALL THE ITEMS IN THE LIST
        return null;
    }
}
