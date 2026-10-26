using System;
using System.Collections;
using System.Collections.Generic;

public static class RandomUtils 
{
    public static IEnumerable GenerateRandomEnumerableUnique(int min, int max, int count)
    {
        var random = new Random();
        HashSet<int> hashSet = new HashSet<int>(count);
        while (hashSet.Count < count) 
        {
            hashSet.Add(random.Next(min, max));
        }
        return hashSet;
    }
}
