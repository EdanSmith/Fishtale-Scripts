using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItemInfo : MonoBehaviour, IEquipmentDataProvider
{
    ItemData itemData;

    public DisplayItemInfo(ItemData itemData)
    {
        this.itemData = itemData;
    }

    public EquipmentData[] GetEquipmentData()
    {
        EquipmentData[] data = null;

        if (itemData.equipmentSlot == Equipment_Slot.Bag)
        {
            data = new EquipmentData[3];
            data[0].label = "<b>" + TranslatorManager.instance.GetTranslationById("equipable_bag_name_" + itemData.id) + "</b>";//"Bag Name:";
            data[0]._value = "";//itemData.itemName;
            data[1].label = TranslatorManager.instance.GetTranslationById("equipment_bag_description_1");
            data[1]._value = itemData.bagCapacity.ToString();
            data[1]._starAmount = 3;
            data[2].label = "<br><b>" + TranslatorManager.instance.GetTranslationById("equipment_bag_description_2") + "</b> " + TranslatorManager.instance.GetTranslationById("equipable_bag_description_" + itemData.id);
            data[2]._value = "";
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Bait)
        {
            data = new EquipmentData[4];
            data[0].label = "<b>" + TranslatorManager.instance.GetTranslationById("equipable_bait_name_" + itemData.id) + "</b>";//"Bait Name:";
            data[0]._value = "";//itemData.itemName;
            data[1].label = TranslatorManager.instance.GetTranslationById("equipment_bait_description_1");
            data[1]._value = baitRarityIncreaseMeasure(itemData.baitFishRarityIncrease);
            data[1]._starAmount = 2;
            data[2].label = TranslatorManager.instance.GetTranslationById("equipment_bait_description_2");
            data[2]._value = baitTimeReductionMeasure(itemData.baitMinTimeBiteReduction);
            data[2]._starAmount = 1;
            data[3].label = "<br><b>" + TranslatorManager.instance.GetTranslationById("equipment_bait_description_3") + "</b> " + TranslatorManager.instance.GetTranslationById("equipable_bait_description_" + itemData.id);
            data[3]._value = "";
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Lure)
        {
            data = new EquipmentData[8];
            data[0].label = "<b>" + TranslatorManager.instance.GetTranslationById("equipable_lure_name_" + itemData.id) + "</b>";//"Lure Name:";
            data[0]._value = "";//itemData.itemName;
            data[1].label = TranslatorManager.instance.GetTranslationById("equipment_lure_description_1");
            data[1]._value = itemData.lureAimSizeModifier.ToString();
            data[1]._starAmount = 2;
            data[2].label = TranslatorManager.instance.GetTranslationById("equipment_lure_description_2");
            data[2]._value = itemData.lureAimSpeedModifier.ToString();
            data[2]._starAmount = 4;
            data[3].label = TranslatorManager.instance.GetTranslationById("equipment_lure_description_3"); // Fish ability reduction %
            data[3]._value = itemData.lureFishAbilityChanceModifier.ToString();
            data[3]._starAmount = 1;
            data[4].label = TranslatorManager.instance.GetTranslationById("equipment_lure_description_4");
            data[4]._value = itemData.lureFishSpeedModifier.ToString();
            data[4]._starAmount = 1;
            data[5].label = TranslatorManager.instance.GetTranslationById("equipment_lure_description_5");
            data[5]._value = itemData.lureUnfillSpeedModifier.ToString();
            data[5]._starAmount = 0;
            data[6].label = TranslatorManager.instance.GetTranslationById("equipment_lure_description_6");
            data[6]._value = itemData.lureMinMaxTimeBiteModifier.ToString();
            data[6]._starAmount = 3;
            data[7].label = "<br><b>" + TranslatorManager.instance.GetTranslationById("equipment_lure_description_7") + "</b> " + TranslatorManager.instance.GetTranslationById("equipable_lure_description_" + itemData.id);
            data[7]._value = "";
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Reel)
        {
            data = new EquipmentData[5];
            data[0].label = "<b>" + TranslatorManager.instance.GetTranslationById("equipable_reel_name_" + itemData.id) + "</b>";//"Reel Name:";
            data[0]._value = "";//itemData.itemName;
            data[1].label = TranslatorManager.instance.GetTranslationById("equipment_reel_description_1");
            data[1]._value = itemData.reelFillSpeedModifier.ToString();
            data[1]._starAmount = 2;
            data[2].label = TranslatorManager.instance.GetTranslationById("equipment_reel_description_2");
            data[2]._value = itemData.reelUnfillSpeedModifier.ToString();
            data[2]._starAmount = 1;
            data[3].label = TranslatorManager.instance.GetTranslationById("equipment_reel_description_3");
            data[3]._value = itemData.reelStrongReelingCharges.ToString();
            data[3]._starAmount = 0;
            data[4].label = "<br><b>" + TranslatorManager.instance.GetTranslationById("equipment_reel_description_4") + "</b> " + TranslatorManager.instance.GetTranslationById("equipable_reel_description_" + itemData.id);
            data[4]._value = "";
        }
        else if (itemData.equipmentSlot == Equipment_Slot.Rod)
        {
            data = new EquipmentData[3];
            data[0].label = "<b>" + TranslatorManager.instance.GetTranslationById("equipable_rod_name_" + itemData.id) + "</b>";//"Rod Name:";
            data[0]._value = "";//itemData.itemName;
            data[1].label = TranslatorManager.instance.GetTranslationById("equipment_rod_description_1");
            data[1]._value = itemData.rodCastMaxDistance.ToString();
            data[1]._starAmount = 1;
            data[2].label = "<br><b>" + TranslatorManager.instance.GetTranslationById("equipment_rod_description_2") + "</b> " + TranslatorManager.instance.GetTranslationById("equipable_rod_description_" + itemData.id);
            data[2]._value = "";
        }

        return data;
    }

    private string baitRarityIncreaseMeasure(float value)
    {
        if (value < 10f)
            return "Very low";
        else
            return "Low";
    }
    private string baitTimeReductionMeasure(float value)
    {
        if (value < 10f)
            return "Very low";
        else if (value < 20f)
            return "Low";
        else if (value < 35f)
            return "Average";
        else
            return "High";
    }
}