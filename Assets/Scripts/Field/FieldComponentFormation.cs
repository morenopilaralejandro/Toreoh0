public class FieldComponentFormation
{
    private Field field;
    public Formation Formation;
    public int ProtectObstacleCountStart;
    //public int CountCapturePortalStart;
    
    public FieldComponentFormation(Field field)
    {
        this.field = field;
        BattleConfig config = field.ConfigComponent.BattleConfig;
        //CountCapturePortalStart = config.CountCapturePortal;
        ProtectObstacleCountStart = config.CountProtectObstacle;
        Formation = new Formation();
        int min = 0;
        int max = config.ListCoordProtectObstacles.Count;
        int count = config.CountCapturePortal + config.CountProtectObstacle;
        foreach (var randomNumber in RandomUtils.GenerateRandomEnumerableUnique(min, max, count))
            Formation.CoordsComponent.Add(config.ListCoordProtectObstacles[(int) randomNumber]);
    }
}
