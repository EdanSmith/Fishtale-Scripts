using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Shirt Data")]
public class ShirtData : ScriptableObject
{
    public string id;
    public Sprite backShirt;
    public Sprite frontShirt;
    public Sprite sideShirt;
    public Sprite frontSleeve;
    public Sprite sideSleeve;
    public Gender gender;
}
