using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloorTrigger : MonoBehaviour
{
    // Global variables
    public Text gameOverMessage;
    float timer = 0.0f;
    bool canCount = false;
    public GameObject CockpitCamera, ThirdPersonCamera;
    AudioSource[] audios;

    // Use this for initialization
    void Start()
    {
        // Add all the audio sources to the array of audios
        audios = CockpitCamera.GetComponents<AudioSource>();
        audios[0].Play();
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is the player
        if (other.gameObject.name == "Player")
        {
            // Active the game over message
            gameOverMessage.gameObject.SetActive(true);

            // Freeze the game
            Time.timeScale = 0;

            // Active the timer counter
            canCount = true;

            // Stop the plane audio
            if (audios[0].isPlaying)
            {
                audios[0].Stop();
            }
            // Play the game over audio
            if (!audios[2].isPlaying)
            {
                audios[2].Play();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
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
