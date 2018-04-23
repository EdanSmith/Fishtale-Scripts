using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Eyes Data")]
public class EyesData : ScriptableObject
{
    public string id;
    public Sprite frontEye;
    public Sprite sideEye;
    public Gender gender;
}

