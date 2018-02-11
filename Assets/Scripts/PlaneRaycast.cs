using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRaycast : MonoBehaviour
{
    // Global variable
    RaycastHit hit;

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        // Check the raycast on that position (down)
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            // Handle and manage the altitude value (with 2 decimal places)
            float altitude = Mathf.Round(hit.distance * 100f) / 100f;

            // Set the altitude with the current value
            GameObject.Find("GameStateScripts").transform.GetComponent<Score>().SetAltitude(altitude);
        }

    }
}
