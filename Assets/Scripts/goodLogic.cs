using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class goodLogic : MonoBehaviour
{
    private int _angle;
    private Random _random;
    public float mGoodSpeed;
    private void Start()
    {
        _random = new Random();
        _angle = _random.Next(0, 360);
        float xPosition = Mathf.Cos(_angle);
        float zPosition = Mathf.Sin(_angle);
        transform.rotation = Quaternion.Euler(Vector3.forward * _angle);
    }

    private void FixedUpdate()
    {
        transform.position += (transform.up * mGoodSpeed);
    }
}
