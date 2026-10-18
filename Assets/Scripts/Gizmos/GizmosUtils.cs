using UnityEngine;
using System.Collections.Generic;

public static class GizmosUtils 
{
    private static Stack<(Matrix4x4 matrix, Color color)> stackState = new();

    private static void Push() 
    {
        stackState.Push((Gizmos.matrix, Gizmos.color));
    }

    private static void Pop() 
    {
        if (stackState.Count <= 0) return;
        var state = stackState.Pop();
        Gizmos.matrix = state.matrix;
        Gizmos.color = state.color;
    }

    public static void DrawCollider2D<T>(T collider, Color color, bool isSolid = true) where T : Collider2D
    {
        if (collider == null) return;
        Push();
        Gizmos.matrix = collider.transform.localToWorldMatrix;
        switch(collider)
        {
            case BoxCollider2D box:
                Gizmos.color = color;
                if (isSolid)
                    Gizmos.DrawCube(box.offset, box.size);
                else
                    Gizmos.DrawWireCube(box.offset, box.size);
                break;
        }
        Pop();
    }

    public static void DrawCube(Color color, Vector3 center, Vector3 size, bool isSolid = true) 
    {
        Push();
        Gizmos.color = color;
        if (isSolid)
            Gizmos.DrawCube(center, size);
        else
            Gizmos.DrawWireCube(center, size);
        Pop();
    }

    public static void DrawSphere(Color color, Vector3 center, float radius, bool isSolid = true) 
    {
        Push();
        Gizmos.color = color;
        if (isSolid)
            Gizmos.DrawSphere(center, radius);
        else
            Gizmos.DrawWireSphere(center, radius);
        Pop();
    }

    public static void DrawLine(Color color, Vector3 from, Vector3 to)
    {
        Push();
        Gizmos.color = color;
        Gizmos.DrawLine(from, to);
        Pop();
    }

    public static void DrawRay(Color color, Vector3 from, Vector3 direction)
    {
        Push();
        Gizmos.color = color;
        Gizmos.DrawRay(from, direction);
        Pop();
    }
}
