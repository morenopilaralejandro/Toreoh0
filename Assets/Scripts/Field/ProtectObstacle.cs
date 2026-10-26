public class ProtectObstacle 
{
    public ProtectObstacleComponentAttributes AttributesComponent;
    public ProtectObstacleComponentAppearance AppearanceComponent;

    public ProtectObstacle(ProtectObstacleData data)
    {
        AttributesComponent = new ProtectObstacleComponentAttributes(data);
        AppearanceComponent = new ProtectObstacleComponentAppearance(data);
    }
}
