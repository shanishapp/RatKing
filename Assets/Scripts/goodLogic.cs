using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class goodLogic : MonoBehaviour
{
    private int _angle;
    private int comeback;
    private Random _random;
    public float mGoodSpeed;
    private void Start()
    {
        _random = new Random();
        _angle = _random.Next(0, 360);
        comeback = 1;
        transform.rotation = Quaternion.Euler(Vector3.forward * _angle);
    }

    private void FixedUpdate()
    {
        
        transform.position += comeback * mGoodSpeed * transform.up;
    
        if (Mathf.Abs(transform.position.x) > 3 || Mathf.Abs(transform.position.y) > 3)
        {
            comeback = -1;
        }
        else
        {
            if (Mathf.Abs(transform.position.x) < 0.5 || Mathf.Abs(transform.position.y) < 0.5)           {
                comeback = 1;
            }
        }        
    }
}
