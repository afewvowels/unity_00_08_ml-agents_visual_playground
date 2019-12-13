using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public GameObject[] cubeSpawnPoints;
    public GameObject[] obstacleSpawnPoints;
    public GameObject[] goalSpawnPoints;
    public GameObject[] letterBlockSpawnPoints;

    public GameObject GetCubeSpawn()
    {
        int index = Mathf.FloorToInt(cubeSpawnPoints.Length * Random.value);

        if (index == cubeSpawnPoints.Length)
        {
            index--;
        }

        return cubeSpawnPoints[index];
    }

    public GameObject GetObstacleSpawn()
    {
        int index = Mathf.FloorToInt(obstacleSpawnPoints.Length * Random.value);

        if (index == obstacleSpawnPoints.Length)
        {
            index--;
        }

        return obstacleSpawnPoints[index];
    }

    public GameObject GetGoalSpawn()
    {
        int index = Mathf.FloorToInt(goalSpawnPoints.Length * Random.value);

        if (index == goalSpawnPoints.Length)
        {
            index--;
        }

        return goalSpawnPoints[index];
    }

    public GameObject GetLetterSpawn()
    {
        int index = Mathf.FloorToInt(letterBlockSpawnPoints.Length * Random.value);

        if (index == letterBlockSpawnPoints.Length)
        {
            index--;
        }

        return letterBlockSpawnPoints[index];
    }
}
