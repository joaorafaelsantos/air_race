using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    // Global variables
    public Text totalPylons;
    public Text totalTime;
    public Text altitude;
    public int currentPylons;
    float timer;
    string timeText;

    // Method to increase the current pylons number
    public void AddScore(int addPylon)
    {
        currentPylons += addPylon;
        totalPylons.text = currentPylons + "/16".ToString();
    }


    // Method to set the timer
    public void SetTime()
    {
        timer += Time.deltaTime;
        int intTime = (int)timer;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = timer * 1000;
        fraction = (fraction % 1000);
        timeText = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        totalTime.text = timeText;
    }

    // Method to return the timer
    public float GetTime()
    {
        return timer;
    }

    // Method to increase the timer
    public void IncreaseTime(float timeToIncrease)
    {
        timer += timeToIncrease;
    }

    // Method to set the current altitude in meters
    public void SetAltitude(float currentAltitude)
    {
        altitude.text = currentAltitude + " meters".ToString();
    }

    // Method to return the current pylons number
    public int getCurrentPylons()
    {
        return currentPylons;
    }

}
