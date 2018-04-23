using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Pants Data")]
public class PantsData : ScriptableObject
{
    public string id;
    public Sprite pants;
    public Gender gender;
}
