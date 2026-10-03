using Aremoreno.Enums.Animation;

public static class CharacterDirectionUtils 
{
    public static Vector3 EnumToVector2(CharacterDirection characterDirection)
    {
        switch (characterDirection) 
        {
            case CharacterDirection.Down:
                return Vector2.down;
            case CharacterDirection.Up:
                return Vector2.up;
            case CharacterDirection.Left:
                return Vector2.left;
            case CharacterDirection.Right:
                return Vector2.right;
        }
    }
}
