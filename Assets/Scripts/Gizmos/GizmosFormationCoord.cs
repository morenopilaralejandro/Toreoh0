using UnityEngine;

public class GizmosFormationCoord : MonoBehaviour 
{
    private float calcValue = 7.5f;

    #if UNITY_EDITOR 
    private void OnDrawGizmos() 
    {
        string stringX = GetHexValue(this.transform.position.x + calcValue);
        string stringY = GetHexValue(Mathf.Abs(this.transform.position.y - calcValue));
        Debug.Log($"{stringY}{stringX}");
    }
    #endif

    private string GetHexValue(float floatValue)
    {
        switch(floatValue) 
        {
            case 10f:
                return "A";
            case 11f:
                return "B";
            case 12f:
                return "C";
            case 13f:
                return "D";
            case 14f:
                return "E";
            case 15f:
                return "F";
            default:
                return floatValue.ToString();
        }
    }
}
