using UnityEngine;
using Unity.Cinemachine;

public class CameraTargerWorld : MonoBehaviour 
{
    [SerializeField] private CinemachineCamera cam;
    
    private WorldManager worldManager;

    private void Start() 
    {
        worldManager = WorldManager.Instance;
        cam.Follow = worldManager.CharacterMain.transform;
    }

    /*
    private CinemachineBrain brain;
    brain = Camera.main.GetComponent<CinemachineBrain>();
    private void OnEnable() 
    {
        WorldEvents.OnCharacterTeleported += OnCharacterTeleported;
    }

    private void OnDisable() 
    {
        WorldEvents.OnCharacterTeleported += OnCharacterTeleported;
    }

    private void OnCharacterTeleported(Vector3 pos) 
    {
        transform.position = pos;
        cam.PreviousStateIsValid = false;
    }
    */
}
