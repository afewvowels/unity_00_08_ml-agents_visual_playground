using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody agentRB;

    public void MoveForward()
    {
        agentRB.AddRelativeForce(new Vector3(0.5f, 0.0f, 0.0f), ForceMode.VelocityChange);
    }

    public void MoveForwardFast()
    {
        agentRB.AddRelativeForce(new Vector3(2.0f, 0.0f, 0.0f), ForceMode.VelocityChange);
    }

    public void MoveBackwards()
    {
        agentRB.AddRelativeForce(new Vector3(-0.5f, 0.0f, 0.0f), ForceMode.VelocityChange);
    }

    public void RotateLeft()
    {
        transform.Rotate(0.0f, -3.0f, 0.0f);
    }

    public void RotateRight()
    {
        transform.Rotate(0.0f, 3.0f, 0.0f);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            MoveForwardFast();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackwards();
        }
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
    }
}
