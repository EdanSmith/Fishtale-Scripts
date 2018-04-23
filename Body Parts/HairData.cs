using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Hair Data")]
public class HairData : ScriptableObject
{
    public string id;
    public Sprite backHair;
    public Sprite frontHair;
    public Sprite sideHair;
    public Gender gender;
}
