using System;
using System.Linq;

using UnityEngine;

public static class ReflectionUtils 
{
    public static Type GetTypeByName(string typeName)
    {
        Type type = Type.GetType(typeName);
        if (type != null) return type;
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assembly.GetName().Name != "Assembly-CSharp") continue;
            foreach (var t in assembly.GetTypes()) 
                if (t.Name == typeName) return t;
        }
        return null;
    }
}
