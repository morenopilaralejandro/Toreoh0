using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

[CreateAssetMenu(fileName = "InputConfig", menuName = "ScriptableObject/Input/InputConfig")]
public class InputConfig : ScriptableObject
{
    [Header("ControlScheme")]
    public List<InputControlSchemeMapping> ControlSchemeMappings;
}
