using System;
using System.Linq;

public static class ReflectionUtils 
{
    public static Type GetTypeByName(string typeName)
    {
        Type type = Type.GetType(typeName);
        if (type != null) return type;
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = assembly.GetType(typeName);
            if (type != null) return type;
            type = assembly.GetTypes().FirstOrDefault(t => t.Name == typeName);
            if (type != null) return type;
        }
        return null;
    }
}
