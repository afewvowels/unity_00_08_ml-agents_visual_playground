using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGuyWorld : MonoBehaviour
{
    public SpawnPointsManager spawnPoints;
    public GameObject obstaclePrefab;
    public GameObject goalPrefab;
    public GameObject cubeGuy;

    public void ResetWorld()
    {
        obstaclePrefab.transform.position = spawnPoints.GetObstacleSpawn().transform.position;
        goalPrefab.transform.position = spawnPoints.GetGoalSpawn().transform.position;
        cubeGuy.transform.position = spawnPoints.GetCubeSpawn().transform.position;

        cubeGuy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cubeGuy.transform.Rotate(0.0f, 360.0f * Random.value, 0.0f);
    }
}
