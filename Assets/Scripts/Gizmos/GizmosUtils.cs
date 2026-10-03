public static class GizmosUtils 
{
    private static Matrix4x4 matrixOriginal;
    private static Color colorOriginal;

    private static void CacheMatrix() 
    {
        matrixOriginal = Gizmos.matrix;
        colorOriginal = Gizmos.color;
    }

    private static void CacheColor() 
    {
        matrixOriginal = Gizmos.matrix;
        colorOriginal = Gizmos.color;
    }

    private static void RestoreMatrix() 
    {
        Gizmos.matrix = matrixOriginal;
        Gizmos.color = colorOriginal;
    }

    private static void RestoreColor() 
    {
        Gizmos.matrix = matrixOriginal;
        Gizmos.color = colorOriginal;
    }

    public static void DrawCollider2D<T>(T collider, Color color, bool isSolid = true) where T : Collider2D
    {
        if (collider == null) return;
        CacheMatrix();
        CacheColor();
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
        RestoreMatrix();
        RestoreColor();
    }

    public static void DrawCube(Color color, Vector3 center, Vector3 size, bool isSolid = true) 
    {
        CacheColor();
        Gizmos.color = color;
        if (isSolid)
            Gizmos.DrawCube(center, size);
        else
            Gizmos.DrawWireCube(center, size);
        RestoreColor();
    }

    public static void DrawSphere(Color color, Vector3 center, Vector3 size, bool isSolid = true) 
    {
        CacheColor();
        Gizmos.color = color;
        if (isSolid)
            Gizmos.DrawSphere(center, size);
        else
            Gizmos.DrawWireSphere(center, vsize);
        RestoreColor();
    }

    public static void DrawLine(Color color, Vector3 from, Vector3 to)
    {
        CacheColor();
        Gizmos.color = color;
        Gizmos.DrawLine(from, to);
        RestoreColor();
    }

    public static void DrawRay(Color color, Vector3 from, Vector3 direction)
    {
        CacheColor();
        Gizmos.color = color;
        Gizmos.DrawRay(from, direction);
        RestoreColor();
    }
}
