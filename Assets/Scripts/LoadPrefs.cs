using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoadPrefs : MonoBehaviour
{
    // Global variables
    public GameObject GameStateScripts, plane1, plane2, highScorePanel, menuPanel;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        // Load prefs of sound and plane on start (PlayerPrefs)
        if (PlayerPrefs.HasKey("Sound"))
        {
            SettingsSingleton.Instance.sound = PlayerPrefs.GetInt("Sound");
        }
        if (PlayerPrefs.HasKey("Plane"))
        {
            SettingsSingleton.Instance.plane = PlayerPrefs.GetInt("Plane");
        }

        // Set the prefs on the UI
        GameStateScripts.transform.GetComponent<OptionsLoader>().setDefault();

        // Handle the prefs
        PrefsHandler();
    }

    // Method to handle the preferences of the player on the game (sound and plane)
    public void PrefsHandler()
    {
        // Enabled or disabled the sound, based on the PlayerPrefs
        if (SettingsSingleton.Instance.sound == 0)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }

        // Enabled the player plane, based on the PlayerPrefs
        if (SettingsSingleton.Instance.plane == 0)
        {
            plane1.SetActive(true);
            plane2.SetActive(false);
        }
        else
        {
            plane1.SetActive(false);
            plane2.SetActive(true);
        }
    }

    // Method to get the high scores
    public void getHighScores()
    {
        string score;

        if (PlayerPrefs.HasKey("Score"))
        {
            float time = PlayerPrefs.GetFloat("Score");
            int intTime = (int)time;
            int minutes = intTime / 60;
            int seconds = intTime % 60;
            float fraction = time * 1000;
            fraction = (fraction % 1000);
            score = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
            scoreText.text = score;

            highScorePanel.SetActive(true);
            menuPanel.SetActive(false);
        }
    }
}
