using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Butterfly Data")]
public class ButterflyData : ScriptableObject
{
    public string id;
    public List<Sprite> butterflySprite;
}
