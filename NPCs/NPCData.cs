using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New NPC Data")]
public class NPCData : ScriptableObject
{
    public string id;
    public string npcName;
    public List<string> dialog;
}
