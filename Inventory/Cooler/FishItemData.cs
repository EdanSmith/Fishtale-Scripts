using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Fish Item Data")]
public class FishItemData : ScriptableObject
{
    public string id;
    public string fishName;
    public string seasonType;
    public string weatherType;
    public string dayTime;
    public double length;
    public double weight;
    public float valuePerLb; // value per pounds
    public string rarity;
    public Sprite fishPortraitImage;
    public Sprite fishHiddenPortraitImage;
    public string description;
}
