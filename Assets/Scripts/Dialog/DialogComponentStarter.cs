using UnityEngine;

public class DialogComponentStarter : MonoBehaviour
{
    [SerializeField] private string knotName;

    public void StartDialog() => DialogManager.Instance.InkStoryComponent.StartDialog(knotName);
}
