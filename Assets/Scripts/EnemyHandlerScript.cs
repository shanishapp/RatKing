using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class EnemyHandlerScript : MonoBehaviour
{
    public int level = 1;
    public GameObject[] shapes;
    private float radius = 5f;
    public Camera camera;
    private float radiusFactor = 0f;        
    public TMP_Text tmpLEVEL;



    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_RIGHT, OnShootRight);
        spawnShapes();
    }

    
    private void OnShootRight(object arg0)
    {
        StartCoroutine(nextLevel());
    }


    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(2f);
        radiusFactor += 0.1f;
        level++;
        tmpLEVEL.text = level.ToString();
        EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__NEXT_LEVEL,null);
        spawnShapes();

    }

    private void spawnShapes()
    {
        camera.DOOrthoSize(camera.orthographicSize+0.1f,1f);
        radius += 0.5f;
        int numOfShapes = level + 3;
        Random random = new Random();
        int different = random.Next(0, numOfShapes - 1);

        float fraction = 1f / (level + 3);
        float angle = (fraction * 2 * Mathf.PI);
        Debug.Log(fraction);
        Debug.Log(angle);
            
        for (int index = 0; index < level + 3; index++)
        {
            GameObject enemyi;
            if (index == different)
            {
                enemyi= Instantiate(shapes[(level+3) % 9]) as GameObject;
                enemyi.tag = "differentShape";
            }
            else
            {
                enemyi= Instantiate(shapes[level%9]) as GameObject;
            }

            enemyi.GetComponent<EnemyScript>().radiusFactor = radiusFactor;
            float xPosition = radius * Mathf.Cos(angle * index);
            float yPosition = radius * Mathf.Sin(angle * index);

            enemyi.transform.position = new Vector2(xPosition, yPosition);
        }
    }
}
