using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Global variables
    float analogSensitivity = 0.5f;
    float leftAnalogVertical;
    float leftAnalogHorizontal;
    float rightAnalogHorizontal;
    float rightAnalog;

    // Update is called once per frame
    void Update()
    {

        // Square Button
        if (Input.GetKeyDown("joystick button 3"))
        {
            transform.GetComponent<PlaneActions>().ChangeCamera();
        }

        // R1 Button (increment speed)
        if (Input.GetKey("joystick button 5"))
        {
            transform.GetComponent<PlaneActions>().planeSpeed = 500f;
        }
        else
        {
            transform.GetComponent<PlaneActions>().planeSpeed = 300f;
        }

        // Move forward
        transform.GetComponent<PlaneActions>().MoveForward();


        //Right Analog Horizontal
        rightAnalogHorizontal = Input.GetAxis("Right Analog Horizontal");
        if (rightAnalogHorizontal < -analogSensitivity || rightAnalogHorizontal > analogSensitivity)
        {
            transform.GetComponent<PlaneActions>().Roll(rightAnalogHorizontal);
        }


        // Left Analog Vertical
        leftAnalogVertical = Input.GetAxis("Left Analog Vertical");
        if (leftAnalogVertical < -analogSensitivity || leftAnalogVertical > analogSensitivity)
        {
            transform.GetComponent<PlaneActions>().Pitch(leftAnalogVertical);
        }

        //Left Analog Horizontal
        leftAnalogHorizontal = Input.GetAxis("Left Analog Horizontal");
        if (leftAnalogHorizontal < -analogSensitivity || leftAnalogHorizontal > analogSensitivity)
        {
            transform.GetComponent<PlaneActions>().Yaw(leftAnalogHorizontal);
        }

    }











}
