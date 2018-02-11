using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonTrigger : MonoBehaviour
{
    // Global variables
    float timeToIncrease = 3f;

    // Trigger with the pylon
    void OnTriggerEnter(Collider other)
    {
        // Increase the timer
        GameObject.Find("GameStateScripts").transform.GetComponent<Score>().IncreaseTime(timeToIncrease);
    }
}
