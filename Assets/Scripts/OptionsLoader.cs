using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsLoader : MonoBehaviour
{
    // Global variables
    public GameObject optionsPanel, menuPanel, highScorePanel, Game, Menu;
    public Toggle toggle_sound;
    public Dropdown dropdown_plane;

    // Method to show the options panel
    public void ShowOptions(bool enable)
    {
        optionsPanel.SetActive(enable);
        menuPanel.SetActive(!enable);
    }

    // Method to back to menu panel
    public void BackOptions()
    {
        optionsPanel.SetActive(false);
        highScorePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    // Method to apply all changes made on the options panel
    public void ApplyChanges()
    {
        // Save the prefs
        bool enable = toggle_sound.isOn;
        SetSound(enable);
        SetPlane();

        // Activate the prefs
        Menu.transform.GetComponent<LoadPrefs>().PrefsHandler();

        // Hide the options menu
        ShowOptions(false);
    }

    // Method to set default all the prefs
    public void setDefault()
    {
        int singletonSound = SettingsSingleton.Instance.sound;
        if (singletonSound == 1)
        {
            toggle_sound.isOn = true;

        }
        else
        {
            toggle_sound.isOn = false;
        }
        dropdown_plane.value = SettingsSingleton.Instance.plane;

    }

    // Method to set the sound (Singleton and PlayerPrefs)
    public void SetSound(bool enable)
    {
        // Save to PlayerPrefs
        int boolToInt;
        if (enable == true)
        {
            boolToInt = 1;

        }
        else
        {
            boolToInt = 0;
        }

        PlayerPrefs.SetInt("Sound", boolToInt);
        PlayerPrefs.Save();
        SettingsSingleton.Instance.sound = boolToInt;
    }

    // Method to set the plane (Singleton and PlayerPrefs)
    public void SetPlane()
    {
        PlayerPrefs.SetInt("Plane", dropdown_plane.value);
        PlayerPrefs.Save();
        SettingsSingleton.Instance.plane = dropdown_plane.value;
    }

    // Method to play the game (disable the menu panel and open the game)
    public void PlayGame()
    {
        Game.SetActive(true);
        Menu.SetActive(false);
    }

}
