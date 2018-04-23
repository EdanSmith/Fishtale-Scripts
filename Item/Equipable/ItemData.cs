using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Item Data")]
public class ItemData : ScriptableObject
{

    public string id;
    public int slotId;
    public string itemName;
    public int price;
    //public string itemType;
    public Equipment_Slot equipmentSlot;
    public GameObject bagButtonIcon;
    public int bagCapacity;
    public GameObject bagInventory;
    public float baitFishRarityIncrease;
    public float baitMinTimeBiteReduction;
    public float baitMaxTimeBiteReduction;
    public float lureAimSizeModifier;
    public float lureAimSpeedModifier;
    public float lureFishAbilityChanceModifier;
    public float lureFishSpeedModifier;
    public float lureUnfillSpeedModifier;
    public float lureMinMaxTimeBiteModifier;
    public Sprite lureIcon;
    public float reelFillSpeedModifier;
    public float reelUnfillSpeedModifier;
    public int reelStrongReelingCharges;
    public float rodCastMaxDistance;

}
