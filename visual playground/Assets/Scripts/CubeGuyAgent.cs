using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAgents;

public class CubeGuyAgent : Agent
{
    public int goals;
    public int obstacles;
    public int actions;
    public CubeGuyAcademy academy;
    public Rigidbody agentRB;
    public CubeGuyWorld world;
    public Text goalsText;
    public Text obstaclesText;
    public Text actionsText;

    public void Start()
    {
        academy = FindObjectOfType<CubeGuyAcademy>();
        world.ResetWorld();
        goals = 0;
        obstacles = 0;
        actions = 0;
    }

    public override void InitializeAgent()
    {
        base.InitializeAgent();
    }

    public override void AgentAction(float[] vectorAction)
    {
        MoveAgent(vectorAction);
    }

    public void MoveAgent(float[] act)
    {
        var action = Mathf.FloorToInt(act[0]);

        switch(action)
        {
            case 1:
                agentRB.AddRelativeForce(new Vector3(0.5f, 0.0f, 0.0f), ForceMode.VelocityChange);
                break;
            case 2:
                agentRB.AddRelativeForce(new Vector3(2.0f, 0.0f, 0.0f), ForceMode.VelocityChange);
                break;
            case 3:
                agentRB.AddRelativeForce(new Vector3(-0.5f, 0.0f, 0.0f), ForceMode.VelocityChange);
                break;
            case 4:
                transform.Rotate(0.0f, -5.0f, 0.0f);
                break;
            case 5:
                transform.Rotate(0.0f, 5.0f, 0.0f);
                break;
            case 6:
                break;
        }
        actions++;
        actionsText.text = actions.ToString();
    }

    public override void AgentReset()
    {
        world.ResetWorld();
        actions = 0;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("goal"))
        {
            AddReward(1.0f);
            goals++;
            goalsText.text = goals.ToString();
            Done();
        }

        if (c.gameObject.CompareTag("obstacle"))
        {
            AddReward(-1.0f / 10.0f);
            obstacles++;
            obstaclesText.text = obstacles.ToString();
            Done();
        }
    }
}
