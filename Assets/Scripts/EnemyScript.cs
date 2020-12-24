using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public static int speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0.0f, 0.0f), step);
    }
}
