using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateScripts : MonoBehaviour
{
    // Global variables
    int currentPylons;
    public Text winMessage;
    float timer = 0.0f;
    bool canCount = false;
    AudioSource[] audios;
    public GameObject CockpitCamera, ThirdPersonCamera;

    // Use this for initialization
    void Start()
    {
        // Add all the audio sources to the array of audios
        audios = CockpitCamera.GetComponents<AudioSource>();

        //Play the audio
        audios[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Set Timer
        GameObject.Find("GameStateScripts").transform.GetComponent<Score>().SetTime();

        // Get the number of current pylons
        currentPylons = GameObject.Find("GameStateScripts").transform.GetComponent<Score>().getCurrentPylons();

        // When player wins
        if (currentPylons == 16)
        {
            // Active the win message
            winMessage.gameObject.SetActive(true);

            // Freeze the game
            Time.timeScale = 0;

            // Active the timer counter
            canCount = true;

            // Send the score to ranking (PlayerPrefs)
            float time = GameObject.Find("GameStateScripts").transform.GetComponent<Score>().GetTime();
            if (PlayerPrefs.HasKey("Score"))
            {
                if (PlayerPrefs.GetFloat("Score") > time)
                {
                    PlayerPrefs.SetFloat("Score", time);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                PlayerPrefs.SetFloat("Score", time);
                PlayerPrefs.Save();
            }

            // Stop the plane audio
            if (audios[0].isPlaying)
            {
                audios[0].Stop();
            }

            // Play the win audio
            if (!audios[1].isPlaying)
            {
                audios[1].Play();
            }
        }

        // If timer counter is activated
        if (canCount)
        {
            // Increase timer value
            timer += Time.unscaledDeltaTime;

            // When timer reaches the 3f
            if (timer >= 3f)
            {
                // Disable the timer counter
                canCount = false;

                // Reset the timer
                timer = 0;

                // Load the scene
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

                // Unfreeze the game
                Time.timeScale = 1;
            }

        }
    }

}
