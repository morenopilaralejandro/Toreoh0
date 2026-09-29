using UnityEngine;
using System;

public class ObjectPoolCustomListWrapperMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int defaultCapacity;

    public ObjectPoolCustomList<T> Pool { get; private set; }

    public void Initialize(Action<T> actionOnGet, Action<T> actionOnRelease)
    {
        Pool = new ObjectPoolCustomList<T>(CreateElement, actionOnGet, actionOnRelease, OnDestroyElement, defaultCapacity);
    }

    private T CreateElement()
    {
        var go = Instantiate(prefab, parent);
        var element = go.GetComponent<T>();
        go.SetActive(false);
        return element;
    }

    private void OnDestroyElement(T element) 
    {
        Destroy(element.gameObject);
    }
}
