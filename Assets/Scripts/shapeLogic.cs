using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Random = System.Random;

public class shapeLogic : MonoBehaviour
{
    public Light2D light;

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
            yield return new WaitForSeconds (0.1f);
            sr.color = Color.HSVToRGB(r1, 1, 1);
            light.color =  Color.HSVToRGB(r1, 1, 1);
            yield return new WaitForSeconds (0.1f); 
            sr.color = new Color(r2,b2, g2,0);
            yield return new WaitForSeconds (0.1f);
            sr.color = Color.HSVToRGB(r1, 1, 1);
            light.color =  Color.HSVToRGB(r1, 1, 1);
            yield return new WaitForSeconds (0.1f); 
            sr.color = new Color(r2,b2, g2,0);
            
        }
    }

}
