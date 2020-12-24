using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class beamLogic : MonoBehaviour
{
    public float mGoodSpeed;
    private void Start()
    { 
        StartCoroutine(flickerPlayer());
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * (mGoodSpeed * Time.deltaTime);


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

   
}
