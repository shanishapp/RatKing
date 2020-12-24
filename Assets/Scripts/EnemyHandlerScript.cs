using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandlerScript : MonoBehaviour
{
    public static int level = 2;
    
    // Start is called before the first frame update
    void Start()
        {
            
            float radius = 5;
    
            float fraction = 1f / (level + 3);
            float angle = (fraction * 2 * Mathf.PI);
            Debug.Log(fraction);
            Debug.Log(angle);
            
            for (int index = 0; index < level + 3; index++)
            {
                GameObject enemyi = Instantiate(Resources.Load("Enemy")) as GameObject;
    
                float xPosition = radius * Mathf.Cos(angle * index);
                float yPosition = radius * Mathf.Sin(angle * index);
    
                enemyi.transform.position = new Vector2(xPosition, yPosition);
            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
