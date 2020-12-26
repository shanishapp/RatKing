using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Random = System.Random;

public class shapeLogic : MonoBehaviour
{
    public Light2D light;
    static Random random = new Random();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flickerPlayer());
    }

    IEnumerator flickerPlayer()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float r1 = (float)random.Next(0,255) / 255f;
        float r2 = (float)random.Next(0,255) / 255f;
       
        while(true)
        {
            yield return new WaitForSeconds (0.1f);
            sr.color = Color.HSVToRGB(r1, 1, 1);
            light.color =  Color.HSVToRGB(r1, 1, 1);
            yield return new WaitForSeconds (0.1f); 
            sr.color = new Color(0,0, 0,0);
            yield return new WaitForSeconds (0.1f);
            sr.color = Color.HSVToRGB(r2, 1, 1);
            light.color =  Color.HSVToRGB(r2, 1, 1);
            yield return new WaitForSeconds (0.1f); 
            sr.color = new Color(0,0, 0,0);
            
        }
    }

}
