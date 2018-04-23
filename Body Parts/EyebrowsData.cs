using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Eyebrows Data")]
public class EyebrowsData : ScriptableObject
{
    public string id;
    public Sprite eyebrow;
    public Gender gender;
}
