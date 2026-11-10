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
            hashSet.Add(random.Next(min, max));
        return hashSet;
    }

    public static int GenerateRandomNext(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }

    public static bool GenerateRandomBool() {
        return UnityEngine.Random.value <= 0.5f;
    }
}
