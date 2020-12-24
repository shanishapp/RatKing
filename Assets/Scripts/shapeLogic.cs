using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class shapeLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flickerPlayer());
    }

    IEnumerator flickerPlayer()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        System.Random random = new Random();
        float r1 = (float) random.NextDouble();
        float r2 = (float) random.NextDouble();
        float g1 = (float) random.NextDouble();
        float g2 = (float) random.NextDouble();
        float b1 = (float) random.NextDouble();
        float b2 = (float) random.NextDouble();
        Color tmp = sr.color;
        while(true)
        {
            sr.color = new Color(tmp.r,tmp.g, tmp.b,0);
            yield return new WaitForSeconds (0.1f);
            sr.color = new Color(r1,g1, b1,1f);
            yield return new WaitForSeconds (1f); 
            sr.color = new Color(r2,b2, g2,0);
            yield return new WaitForSeconds (0.1f);
            sr.color = new Color(r1,g1, b1,1f);
            yield return new WaitForSeconds (1f);
        }
    }

}
