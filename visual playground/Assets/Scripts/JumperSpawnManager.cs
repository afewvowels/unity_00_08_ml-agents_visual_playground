using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperSpawnManager : MonoBehaviour
{
    public GameObject[] jumperSpawns;
    public GameObject[] platformByWallSpawns;
    public GameObject[] platformSpawns;
    public GameObject[] goalSpawns;

    public GameObject GetJumperSpawn()
    {
        int index = Random.Range(0, jumperSpawns.Length);

        if (index > jumperSpawns.Length - 1)
        {
            index = 0;
        }

        return jumperSpawns[index];
    }

    public GameObject GetPlatformByWallSpawn()
    {
        int index = Random.Range(0, platformByWallSpawns.Length);

        if (index > platformByWallSpawns.Length - 1)
        {
            index = 0;
        }

        return platformByWallSpawns[index];
    }

    public GameObject GetPlatformSpawn()
    {
        int index = Random.Range(0, platformSpawns.Length);

        if (index > platformSpawns.Length - 1)
        {
            index = 0;
        }

        return platformSpawns[index];
    }

    public GameObject GetGoalSpawn()
    {
        int index = Random.Range(0, goalSpawns.Length);

        if (index > goalSpawns.Length - 1)
        {
            index = 0;
        }

        return goalSpawns[index];
    }
}
