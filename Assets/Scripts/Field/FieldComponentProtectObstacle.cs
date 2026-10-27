public class FieldComponentProtectObstacle
{
    private Field field;

    binding

    turn this into a mono behaviour and crear the binding on destroy
    this is a task


    public FieldComponentProtectObstacle(Field field)
    {
        this.field = field;
        
        var listFormationCoord = field.FormationComponent.Formation.CoordsComponent.ListFormationCoord;

        for (int i = 1; i < listFormationCoord.Count; i++) 
        {
            //Instance() ProtectObstacle
            Instance
            await protectObstacleEntity LoadAsync
        }
    }
}
