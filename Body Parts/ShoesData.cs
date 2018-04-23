using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Shoes Data")]
public class ShoesData : ScriptableObject
{
    public string id;
    public Sprite backShoes;
    public Sprite frontShoes;
    public Sprite sideShoes;
    public Gender gender;
}
