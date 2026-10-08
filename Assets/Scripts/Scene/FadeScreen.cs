using UnityEngine;
using System.Threading.Tasks;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroupTop;
    [SerializeField] private CanvasGroup canvasGroupBottom;
    [SerializeField] private float duration;
    private SceneLoaderManager sceneLoaderManager;
    
    public void Initialize(SceneLoaderManager sceneLoaderManager) 
    {
        this.sceneLoaderManager = sceneLoaderManager;
    }

    public async Task FadeIn()
    {
        await FadeCanvasGroups(1f);
    }

    public async Task FadeOut()
    {
        await FadeCanvasGroups(0f);
    }

    private async Task FadeCanvasGroups(float toValue) 
    {
        Task taskTop = sceneLoaderManager.StartCoroutineAsync(UIUtils.FadeCanvasGroup(canvasGroupTop, canvasGroupTop.alpha, toValue, duration, null));
        Task taskBottom = sceneLoaderManager.StartCoroutineAsync(UIUtils.FadeCanvasGroup(canvasGroupBottom, canvasGroupBottom.alpha, toValue, duration, null));
        await Task.WhenAll(taskTop, taskBottom);
    }
}
