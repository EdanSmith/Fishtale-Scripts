using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumSkill : MonoBehaviour
{

    public bool vacuum;
    public float counter;

    private GameObject p;

    void Start()
    {
        vacuum = false;
        counter = 6;
    }

    void Update()
    {
        if (counter < 6)
            counter += Time.deltaTime;

        if (GameManager.instance.fish != null)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1) && counter >= 6)
            {
                StartCoroutine(vacuumSkill(3f));
            }

            if (vacuum)
            {
                GameManager.instance.fish.transform.position = Vector2.MoveTowards(GameManager.instance.fish.transform.position, GameManager.instance.aim.transform.position, 1.5f * Time.deltaTime);
                p.transform.position = GameManager.instance.aim.transform.position;
            }
        }
        UIGameManager.instance.vacuumSkillImage.fillAmount = counter / 6;
    }
    private IEnumerator vacuumSkill(float seconds)
    {
        p = (GameObject)Instantiate(Resources.Load("Prefabs/Particles/Vacuum Skill"), GameManager.instance.aim.transform.position, Quaternion.identity);
        SoundManager.instance.PlaySound2D("Whirlpool", GameManager.instance.aim.transform.position);
        vacuum = true;
        counter = 0f;
        yield return new WaitForSeconds(seconds);
        vacuum = false;
        p.GetComponent<ParticleSystem>().Clear();
    }
}
