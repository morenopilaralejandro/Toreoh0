using UnityEngine;

public class SceneRootInterior : SceneRoot
{
    public ZoneData ZoneData;

    protected override Vector3 size => 
        new Vector3(
            WorldConstants.INTERIOR_SIZE,
            WorldConstants.INTERIOR_SIZE,
            1f
        );

    protected override Vector3 center => 
        new Vector3(
            WorldConstants.TILE_OFFSET * WorldConstants.INTERIOR_SIZE,
            WorldConstants.TILE_OFFSET * WorldConstants.INTERIOR_SIZE,
            0f
        );

}
