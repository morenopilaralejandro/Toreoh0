public class ProtectObstacle 
{
    public ProtectObstacleComponentAttributes AttributesComponent;
    public ProtectObstacleComponentAppearance AppearanceComponent;
    public ProtectObstacleComponentStateMachine StateMachineComponent;
    public ProtectObstacleComponentSfx ProtectObstacleComponentSfx;

    public ProtectObstacle(ProtectObstacleData data)
    {
        AttributesComponent = new ProtectObstacleComponentAttributes(data);
        AppearanceComponent = new ProtectObstacleComponentAppearance(data);
        StateMachineComponent = new ProtectObstacleComponentStateMachine();
        ProtectObstacleComponentSfx = new ProtectObstacleComponentSfx(data);
    }
}
