using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public List<GameObject> scenes = new List<GameObject>();

    private int activeIndex;

    private void Start()
    {
        activeIndex = 0;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("scene"))
        {
            scenes.Add(go);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeIndex++;
            
            if (activeIndex > scenes.Count - 1)
            {
                activeIndex = 0;
            }

            this.transform.position = scenes[activeIndex].transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.Rotate(0.0f, 90.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.Rotate(0.0f, -90.0f, 0.0f);
        }
    }
}
