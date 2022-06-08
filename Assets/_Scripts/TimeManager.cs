using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    

    public float slowDownFactor = 0.05f;
    public float slowDownDuration = 2f;

    void Update() {
        Time.timeScale += (1f / slowDownDuration) * Time.unscaledDeltaTime;
        Time.fixedDeltaTime += (0.01f / slowDownDuration) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0f, 0.01f);
    }

    public void DoSlowMotion() {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
    }
}
