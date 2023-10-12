using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Data", fileName = "SO_Data")]
public class SO_Data : ScriptableObject
{
    public string tag;
    [Header("Data")] 
    public float baseValue;
    public float maxValue;
}
