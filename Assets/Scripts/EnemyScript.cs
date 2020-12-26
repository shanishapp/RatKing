using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    private bool noWait = true;
    private bool dontWait = false;
    private bool gameOver = false;
    private Vector2 target;
    private Vector3 initialPosition;
    private bool passedLevel = false; 
    
    public float radiusFactor = 0f;
    public static int speed = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        initialPosition = transform.position;
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_RIGHT, OnShootRight);
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_WRONG, OnShootWrong);
    }

    private void OnShootWrong(object arg0)
    {
        gameOver = true;
        speed = 8;
    }

    private void OnShootRight(object arg0)
    {
        passedLevel = true;
        noWait = true;
        target = initialPosition+initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target) < 3f+radiusFactor)
        {
            if (passedLevel)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target, step/10f);
            }
        }
        else if(Vector3.Distance(transform.position, target) >= 3f+radiusFactor || noWait || gameOver)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        } 
    }




}
