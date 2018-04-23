using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAttractor : MonoBehaviour
{

    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;
    public Transform origin;
    public Transform destiny;

    //// Use this for initialization
    void Start()
    {
        transform.position = origin.position;
        //GetComponent<ParticleSystem>().trigger.SetCollider(0, GameManager.instance.playerMovement.transform);
    }

    private void LateUpdate()
    {
        transform.position = origin.position;
        InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            //m_Particles[i].position = Vector2.Lerp(m_Particles[i].position, GameManager.instance.playerMovement.transform.position, Time.deltaTime / 0.5f);
            m_Particles[i].position = Vector2.MoveTowards(m_Particles[i].position, destiny.position, 10f * Time.deltaTime);
        }
        //UIGameManager.instance.mainCamera.ScreenToWorldPoint(UIGameManager.instance.goldPanel.goldIcon.transform.position)
        // Apply the particle changes to the particle system
        m_System.SetParticles(m_Particles, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
        {
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
            int numParticlesAlive = m_System.GetParticles(m_Particles);
            //for (int i = 0; i < numParticlesAlive; i++)
                //m_Particles[i].position = origin.position;
            //m_System.SetParticles(m_Particles, numParticlesAlive);
        }
    }

    void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        int numEnter = GetComponent<ParticleSystem>().GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(255, 0, 0, 255);
            p.remainingLifetime = 0;
            SoundManager.instance.PlaySound2D("Purchase Item", GameManager.instance.playerMovement.transform.position);
            enter[i] = p;
        }
        GetComponent<ParticleSystem>().SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}
