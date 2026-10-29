public class FormationCoord 
{
    public FormationCoordComponentAttributes AttributesComponent;
    public FormationCoordComponentPosition PositionComponent;
    public FormationCoordComponentRotation RotationComponent;

    public FormationCoord(FormationCoordData data)
    {
        AttributesComponent = new FormationCoordComponentAttributes(data);
        PositionComponent = new FormationCoordComponentPosition(data);
        RotationComponent = new FormationCoordComponentRotation(data);
    }
}
