public class FieldComponentAttributes
{
    public string FieldId;
    public string BarrierId;
    public string ProtectObstacleId;

    public FieldComponentAttributes(FieldData data) 
    {
        FieldId = data.FieldId;
        BarrierId = data.BarrierId;
        ProtectObstacleId = data.ProtectObstacleId;
    }
}
