using System.Collections.Generic;

public class FieldComponentFormationBarrier
{
    private Field field;
    public string FormationBarrierId;
    public Formation Formation;
    public List<string> ListBarrierId = new ();

    public FieldComponentFormationBarrier(FieldData fieldData, Field field)
    {
        this.field = field;
        FormationBarrierId = fieldData.FormationBarrierId;
        Formation = new Formation();
        
        var formationBarrierData = DatabaseManager.Instance.DatabaseRegistry.FormationBarrierData.Get(FormationBarrierId);
        Add(formationBarrierData.BarrierId0, formationBarrierData.CoordId0, formationBarrierData.RotationZ0);
        Add(formationBarrierData.BarrierId1, formationBarrierData.CoordId1, formationBarrierData.RotationZ1);
        Add(formationBarrierData.BarrierId2, formationBarrierData.CoordId2, formationBarrierData.RotationZ2);
        Add(formationBarrierData.BarrierId3, formationBarrierData.CoordId3, formationBarrierData.RotationZ3);
    }

    private void Add(string barrierId, string formationCoordId, float rotZ)
    {
        ListBarrierId.Add(barrierId);
        var formationCoordData = DatabaseManager.Instance.DatabaseRegistry.FormationCoordData.Get(formationCoordId);
        var coord = new FormationCoord(formationCoordData);
        coord.RotationComponent.SetRotationEuler(0f, 0f, rotZ);
        Formation.CoordsComponent.ListFormationCoord.Add(coord);
    }
}
