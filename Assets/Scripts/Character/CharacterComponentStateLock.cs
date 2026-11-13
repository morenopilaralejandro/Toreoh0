using UnityEngine;
using System.Collections;

public class CharacterComponentStateLock : MonoBehaviour
{
    [SerializeField] private CharacterEntityBattle entity;
    private Coroutine coroutine;
    public bool IsStateLocked;

    public void StartStateLock(float frameCount) 
    {
        StopStateLock();
        IsStateLocked = true;
        coroutine = StartCoroutine(ExecuteStateLock(frameCount));
    }

    public void StopStateLock() 
    {
        IsStateLocked = false;
        if (coroutine == null) return;
        StopCoroutine(coroutine);
        coroutine = null;
    }

    private IEnumerator ExecuteStateLock(float frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            yield return null;
        }
        StopStateLock();
    }
}
