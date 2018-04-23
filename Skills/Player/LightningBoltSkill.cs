using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoltSkill : MonoBehaviour
{

    private FishMovement fish;
    private float counter;

    void Start()
    {
        counter = 8;
    }

    void Update()
    {
        if (counter <= 8)
            counter += Time.deltaTime;

        if (GameManager.instance.fish != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && counter >= 8)
            {
                //Instantiate(Resources.Load("Prefabs/Particles/Lightning Bolt Skill"), GameManager.instance.aim.transform.position, Quaternion.identity);
                Instantiate(Resources.Load("Prefabs/Animation/Lightning Bolt Animation"), GameManager.instance.hook.transform.position, Quaternion.identity);
                SoundManager.instance.PlaySound2D("Weak Thunder", GameManager.instance.hook.transform.position);
                counter = 0;
            }
        }
        UIGameManager.instance.lightningBoltSkillImage.fillAmount = counter / 8;
    }

    public IEnumerator lightningBoltSkill(float seconds)
    {
        fish = GameManager.instance.fish;
        fish.moveForce = 0;
        fish.currentDrag += 3;
        yield return new WaitForSeconds(seconds);
        if (fish != null)
        {
            fish.moveForce = GameManager.instance.GetFishDataById(GameManager.instance.currentSpawnedFish.id).moveForce;
            fish.currentDrag -= 3;
        }
    }

    public void activateSkill()
    {
        StartCoroutine(lightningBoltSkill(2f));
    }

}
