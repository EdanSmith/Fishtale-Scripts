using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.EventSystems;

[Description("Checks player inventory for an item.")]
public class CheckInventoryItem : ConditionTask {

    public string itemId = "";

    protected override bool OnCheck()
    {
        return false;
    }

}
