using UnityEngine;

public static class ColorUtils
{
    public static string ColorToHex(Color color, bool hasAlpha = false)
    {
        int r = Mathf.RoundToInt(color.r * 255f);
        int g = Mathf.RoundToInt(color.g * 255f);
        int b = Mathf.RoundToInt(color.b * 255f);
        int a = Mathf.RoundToInt(color.a * 255f);

        if(hasAlpha)
            return $"#{r:X2}{g:X2}{b:X2}{a:X2}";
        else
            return $"#{r:X2}{g:X2}{b:X2}";
    }
}
