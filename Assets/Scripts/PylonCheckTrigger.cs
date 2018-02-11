using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonCheckTrigger : MonoBehaviour
{
    // Global variables
    bool[] pylonCheck = new bool[17]; // Array of booleans to check if the pylon is passed already
    string[] pylonNames = new string[17]; // Array of strings with all the pylon names

    // Use this for initialization
    void Start()
    {
        // For all pylons initialize with false on check variable
        for (int i = 0; i < pylonCheck.Length; i++)
        {
            pylonCheck[i] = false;
        }

        // Save all pylon names to the array
        for (int i = 0; i < pylonNames.Length; ++i)
        {
            pylonNames[i] = transform.parent.gameObject.transform.GetChild(i).name;
        }

    }

    // Trigger with the 'check' space of the pylon
    void OnTriggerEnter(Collider other)
    {
        // Get triggered pylon name
        string pylonName = this.name;

        // Go to all the pylon names
        for (int i = 0; i < pylonNames.Length; i++)
        {
            // Verify if the triggered pylon name exists on current pylon names array and get the position
            if (pylonName == pylonNames[i])
            {
                // We now that index i is the position, so if pylon check array on that position is false we turn the variable to true and activate the score to add one more pylon
                if (!pylonCheck[i])
                {
                    pylonCheck[i] = true;
                    GameObject.Find("GameStateScripts").transform.GetComponent<Score>().AddScore(1);
                }
            }
        }

    }
}
