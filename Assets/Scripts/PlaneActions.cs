using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneActions : MonoBehaviour
{
    // Global variables
    public float planeSpeed = 500f;
    public float rollSpeed = 100f;
    public float pitchSpeed = 100f;
    public float yawSpeed = 100f;
    public GameObject cockpitCamera;
    public GameObject thirdPersonCamera;

    // Forward plane movement
    public void MoveForward()
    {
        transform.Translate(0, 0, planeSpeed / 20 * Time.deltaTime);
    }

    // Roll
    public void Roll(float rightAnalogHorizontal)
    {
        if (rightAnalogHorizontal < 0)
        {
            transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
        }
        else if (rightAnalogHorizontal > 0)
        {
            transform.Rotate(Vector3.back * rollSpeed * Time.deltaTime);
        }
    }

    // Pitch
    public void Pitch(float leftAnalogVertical)
    {
        if (leftAnalogVertical < 0)
        {
            transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime);
        }
        else if (leftAnalogVertical > 0)
        {
            transform.Rotate(Vector3.left * pitchSpeed * Time.deltaTime);
        }
    }

    // Yaw
    public void Yaw(float leftAnalogHorizontal)
    {
        if (leftAnalogHorizontal < 0)
        {
            transform.Rotate(Vector3.down * yawSpeed * Time.deltaTime);
        }
        else if (leftAnalogHorizontal > 0)
        {
            transform.Rotate(Vector3.up * yawSpeed * Time.deltaTime);
        }
    }

    // Change plane camera
    public void ChangeCamera()
    {

        if (cockpitCamera.GetComponent<Camera>().enabled)
        {
            cockpitCamera.GetComponent<Camera>().enabled = false;
            thirdPersonCamera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            thirdPersonCamera.GetComponent<Camera>().enabled = false;
            cockpitCamera.GetComponent<Camera>().enabled = true;
        }
    }

}





