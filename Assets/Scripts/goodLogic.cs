using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class goodLogic : MonoBehaviour
{
    private int _angle;
    private int comeback;
    private Random _random;
    public float mGoodSpeed;
    private bool wentOut = false;
    private Transform holeTransform;
    private void Start()
    {
        _random = new Random();
        _angle = _random.Next(0, 360);
        comeback = 1;
        transform.rotation = Quaternion.Euler(Vector3.forward * _angle);
        StartCoroutine(flickerPlayer());
        holeTransform = GameObject.FindWithTag("hole").transform;
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * (comeback * mGoodSpeed * Time.deltaTime);
        if (wentOut == false && Vector3.Distance(transform.position, holeTransform.position) > 1f)
        {
            wentOut = true;
        }

        
    }
    
    IEnumerator flickerPlayer()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Random random = new Random();
        int r1 = random.Next(0, 255);
        int r2 = random.Next(0, 255);
        int g1 = random.Next(0, 255);
        int g2 = random.Next(0, 255);
        int b1 = random.Next(0, 255);
        int b2 = random.Next(0, 255);
        Color tmp = sr.color;
        while(true)
        {
            sr.color = new Color(tmp.r,tmp.g, tmp.b,0);
            yield return new WaitForSeconds (0.1f);
            sr.color = new Color(r1,g1, b1,255);
            yield return new WaitForSeconds (0.1f); 
            sr.color = new Color(r2,b2, g2,0);
            yield return new WaitForSeconds (0.1f);
            sr.color = new Color(r1,g1, b1,255);
            yield return new WaitForSeconds (0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("hole") && wentOut)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward *  (_angle+180));
        }
        else if(other.gameObject.CompareTag("cat"))
        {
            comeback = 1;
            transform.rotation = Quaternion.Euler(Vector3.forward *  (_angle-180));
        }        
    }
}
