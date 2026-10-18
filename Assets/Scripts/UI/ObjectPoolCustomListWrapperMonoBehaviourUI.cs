using UnityEngine;
using System;

[Serializable]
public class ObjectPoolCustomListWrapperMonoBehaviourUI
{
    [SerializeField] public GameObject Prefab;
    [SerializeField] public Transform TransformParent;
    [SerializeField] public int DefaultCapacity;
}
