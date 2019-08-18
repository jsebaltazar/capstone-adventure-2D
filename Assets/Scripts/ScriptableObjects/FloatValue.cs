using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]                   
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    //unload after the game
    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }


    //load obj before the game
    public void OnBeforeSerialize() { }


}
