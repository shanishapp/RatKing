using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class beamLogic : MonoBehaviour
{
    public float mBeamSpeed;
    private Rigidbody2D _rb;
    private void Start()
    { 
        //StartCoroutine(flickerPlayer());
        transform.DOShakeScale(1f,Vector3.one*0.01f);

        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * mBeamSpeed;
    }

   

   
}
