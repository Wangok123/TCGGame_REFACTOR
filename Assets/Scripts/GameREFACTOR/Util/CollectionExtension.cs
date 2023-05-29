
using System.Collections.Generic;
using UnityEngine;

namespace GameREFACTOR.Util
{
    public static class CollectionExtension
    {
        public static void Shuffle<T>(this List<T> list)
        {
            // NOTE: Fisher Yates shuffle -> https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int r = Random.Range(i, n);
                
                (list[r], list[i]) = (list[i], list[r]);
            }
        }
    }
}