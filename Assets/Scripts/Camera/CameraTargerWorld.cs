using UnityEngine;
using Unity.Cinemachine;

public class CameraTargerWorld : MonoBehaviour 
{
    [SerializeField] private CinemachineCamera cam;
    private CinemachineBrain brain;
    private WorldManager worldManager;


    private void Start() 
    {
        worldManager = WorldManager.Instance;
        cam.Follow = worldManager.CharacterMain.transform;
        brain = Camera.main.GetComponent<CinemachineBrain>();
    }
}
