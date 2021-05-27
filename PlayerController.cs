using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//TODO: Create the yaw code to rotate on its Y-axis

public class PlayerController : MonoBehaviour
{
    //Movement and Direction Variables
    float xHorizontalDirection;
    float yVerticalDirection;
    float zDepthDirection;

    //Rotation Variables
    float xPitchDegree = -10f;
    float zRollDegree = -10f;
    
    //Movement Speed Variables
    private float movementLeftRightSpeed = 60f;
    private float movementForwardBackSpeed = 60f;
    private float movementUpDownSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
    }

    //This allows the ship to move based on the user input
    private void PlayerMovement()
    {
        //These access the input manager in Unity
        xHorizontalDirection = Input.GetAxis("Horizontal");
        yVerticalDirection = Input.GetAxis("Vertical");
        zDepthDirection = Input.GetAxis("ForwardBack");

        //These calcuates the movement in the left, right, up and down direction
        transform.Translate(Vector3.right * Time.deltaTime * xHorizontalDirection * movementLeftRightSpeed);
        transform.Translate(Vector3.up * Time.deltaTime * yVerticalDirection * movementUpDownSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * zDepthDirection * movementForwardBackSpeed);
    }

    private void PlayerRotation()
    {
        //This measures the pitch (X-axis rotation) by the amount of degrees
        float pitchXRotation = yVerticalDirection * xPitchDegree;
        float pitch = pitchXRotation;

        //This measures the roll (z-axis rotation) by the amount of degrees
        float rollZRotation = xHorizontalDirection * zRollDegree;
        float roll = rollZRotation;

        //This rotates the object in local space
        transform.localRotation = Quaternion.Euler(pitch, -48.75f, roll);
    }

}
