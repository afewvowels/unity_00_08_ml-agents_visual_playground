using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAgents;

public class JumperAgent : Agent
{
    public JumperAcademy academy;
    public Rigidbody jumperRB;
    public float forceToApply;
    public GameObject wallRoot;
    public GameObject goalRoot;
    public GameObject platform;
    public JumperSpawnManager spawnManager;
    public Text goalsText;
    public Text actionsText;
    public Text jumpsText;
    private int goals;
    private int actions;
    private int jumps;

    public void Start()
    {
        academy = FindObjectOfType<JumperAcademy>();
        goals = 0;
        actions = 0;
        jumps = 0;
    }

    public void Update()
    {
        if(jumperRB.velocity.magnitude < 0.01f)
        {
            Debug.Log("Somebody got stuck!");
            jumperRB.AddRelativeForce(new Vector3(15.0f, 15.0f, 0.0f), ForceMode.Impulse);
        }
    }

    public override void AgentAction(float[] vectorAction)
    {
        var moveAction = (int)vectorAction[0];
        var rotateAction = (int)vectorAction[1];
        var jumpAction = (int)vectorAction[2];

        switch(moveAction)
        {
            case 1:
                if (IsGrounded())
                {
                    jumperRB.AddRelativeForce(new Vector3(forceToApply, 0.0f, 0.0f), ForceMode.Impulse);
                }
                else
                {
                    jumperRB.AddRelativeForce(new Vector3(forceToApply / 3.0f, 0.0f, 0.0f), ForceMode.Impulse);
                }
                break;
            case 2:
                if (IsGrounded())
                {
                    jumperRB.AddRelativeForce(new Vector3(forceToApply * 2.0f, 0.0f, 0.0f), ForceMode.Impulse);
                }
                break;
            case 3:
                if (IsGrounded())
                {
                    jumperRB.AddRelativeForce(new Vector3(-forceToApply, 0.0f, 0.0f), ForceMode.Impulse);
                }
                else
                {
                    jumperRB.AddRelativeForce(new Vector3(-forceToApply / 3.0f, 0.0f, 0.0f), ForceMode.Impulse);
                }
                break;
        }

        switch(rotateAction)
        {
            case 1:
                transform.Rotate(0.0f, -5.0f, 0.0f);
                break;
            case 2:
                transform.Rotate(0.0f, 5.0f, 0.0f);
                break;
        }

        if (jumpAction == 1)
        {
            if (IsGrounded())
            {
                jumperRB.AddRelativeForce(new Vector3(forceToApply * 10.0f, forceToApply * 33.0f, 0.0f), ForceMode.Impulse);
                jumps++;
                jumpsText.text = jumps.ToString();
            }
        }

        actions++;
        actionsText.text = actions.ToString();
    }

    public override float[] Heuristic()
    {
        var action = new float[3];

        if (Input.GetKey(KeyCode.W))
        {
            action[0] = 1.0f;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            action[0] = 2.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            action[0] = 3.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            action[1] = 1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            action[1] = 2.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            action[2] = 1.0f;
        }

        return action;
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1.15f) ||
            Physics.Raycast(transform.position + new Vector3(0.75f, 0.0f, 0.0f), Vector3.down, 1.15f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void AgentReset()
    {
        if (academy.resetParameters["platform_near_wall"] == 0)
        {
            platform.transform.position = spawnManager.GetPlatformByWallSpawn().transform.position;
        }
        else if (academy.resetParameters["platform_near_wall"] == 1)
        {
            platform.transform.position = spawnManager.GetPlatformSpawn().transform.position;
        }

        float wallYPos = Random.Range(academy.resetParameters["wall_min_height"], academy.resetParameters["wall_max_height"]);

        wallRoot.transform.localPosition = new Vector3 (0.0f, wallYPos, 0.0f);

        goalRoot.transform.position = spawnManager.GetGoalSpawn().transform.position;
        goalRoot.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        transform.position = spawnManager.GetJumperSpawn().transform.position;
        transform.Rotate(0.0f, 360.0f * Random.value, 0.0f);

        actions = 0;
        actionsText.text = actions.ToString();

        jumps = 0;
        jumpsText.text = jumps.ToString();
    }

    public void OnTriggerStay(Collider c)
    {
        if (c.gameObject.CompareTag("goal"))
        {
            AddReward(1.0f);
            
            if (actions < 500)
            {
                AddReward(1.0f);
            }
            else if (actions < 1500)
            {
                AddReward(0.5f);
            }
            else if (actions < 3000)
            {
                AddReward(0.25f);
            }

            goals++;
            goalsText.text = goals.ToString();
            Done();
        }
    }
}
