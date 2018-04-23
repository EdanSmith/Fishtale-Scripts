using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Create New Fish Data")]
public class FishData : ScriptableObject
{
    public string id;
    public string fishName;
    public string itemId;
    public string rarity;
    public string[] spawnableSeason;
    public string[] spawnableWeather;
    public List<Sprite> fishSprite;
    //gravity pattern
    public float moveForce;
    public float maxSpeed;
    public float timeBetweenMove;
    public float timeToMove;
    public float decelerateSpeed;
    //circle pattern
    public float radius;
    public float circleSpeed;
    public float fillBarModifier;
    public float unfillBarModifier;
    // Spawn with specific baits only
    public float abilityChance;
    public List<FishPattern> patterns;
}
