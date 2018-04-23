using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Body Type Data")]
public class BodyTypeData : ScriptableObject
{
    public string id;
    public Sprite frontChest;
    public Sprite sideChest;
    public Sprite frontHead;
    public Sprite sideHead;
    public Sprite arm;
    public Sprite leg;
    public Gender gender;
}