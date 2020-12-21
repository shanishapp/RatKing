using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    private int currentLevel = 0;

    private GameObject go;
    // Start is called before the first frame update
    private void Start()
    {
       go = GameObject.FindWithTag("rat");
    }

    void FixedUpdate()
    {
        int newLevel = go.GetComponent<ratMovement>().level;
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
            gameObject.GetComponent<spawner>().numOfBads += currentLevel;
            gameObject.GetComponent<spawner>().numOfGoods += currentLevel;
            gameObject.GetComponent<spawner>().numOfCircles += 1;
            gameObject.GetComponent<spawner>().respawn();
        }
    }

    
}
