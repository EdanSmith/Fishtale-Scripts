using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Bird Data")]
public class BirdData : ScriptableObject
{
    public string id;
    public List<Sprite> birdSprite;
}
