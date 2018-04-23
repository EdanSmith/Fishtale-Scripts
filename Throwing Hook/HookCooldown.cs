using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCooldown {

    public bool hookOnCooldown;
    public float cooldownCountedSeconds;
    public bool cooldownTimerEnabled;
    public float hookCooldownTime;

    public void setHookOnCooldown()
    {
        hookOnCooldown = true;
    }

    public void startHookCooldownTimer()
    {
        cooldownTimerEnabled = true;
        countHookCooldownTimer(hookCooldownTime);
    }

    private void countHookCooldownTimer(float cooldownTimer)
    {
        cooldownCountedSeconds += Time.deltaTime;
        if (cooldownCountedSeconds >= cooldownTimer)
        {
            cooldownReset();
        }
    }

    private void cooldownReset()
    {
        hookOnCooldown = false;
        cooldownTimerEnabled = false;
        cooldownCountedSeconds = 0;
    }
}
