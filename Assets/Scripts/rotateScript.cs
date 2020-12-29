using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class rotateScript : MonoBehaviour
{
    private float time = 0f;

    public float timeFactor = 1f;
    public int circleIndex = 1;
    private bool firstCrash = true;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*10*timeFactor;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, time));

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__CROSSED_CIRCLE,circleIndex);
        GameObject.FindWithTag("MainCamera").transform.DORewind();
        GameObject.FindWithTag("MainCamera").transform.DOShakePosition(0.5f, Vector3.one * 0.1f);
            //firstCrash = true;
    }
}
