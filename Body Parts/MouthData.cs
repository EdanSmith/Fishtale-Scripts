using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Mouth Data")]
public class MouthData : ScriptableObject
{
    public string id;
    public Sprite frontMouth;
    public Sprite sideMouth;
    public Gender gender;
}
