using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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
    public TMP_Text tmpLEVEL;
    private Camera camera;
    public GameObject player;
    public Transform gameScene;

    private float radius = 5f;
    private float radiusFactor = 0f;
    private int waveIndex = 0;




    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_RIGHT, OnShootRight);
        spawnShapes();
    }

    
    private void OnShootRight(object arg0)
    {
        int wave = (int) arg0;
        if(wave%2 == 1)
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
        yield return new WaitForSeconds(2f);
        spawnShapes();

    }

    private void spawnShapes()
    {
        waveIndex++;
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
                enemyi= Instantiate(shapes[(level+3) % 7]) as GameObject;
                enemyi.tag = "differentShape";
            }
            else
            {
                enemyi= Instantiate(shapes[level%7]) as GameObject;
            }

            enemyi.GetComponent<EnemyScript>().radiusFactor = radiusFactor;
            enemyi.GetComponent<EnemyScript>().waveIndex = waveIndex;
            enemyi.transform.SetParent(gameScene);
            float xPosition = radius * Mathf.Cos(angle * index);
            float yPosition = radius * Mathf.Sin(angle * index);

            enemyi.transform.position = new Vector2(xPosition, yPosition);
            float DegAngle = Mathf.Atan2(yPosition, xPosition) * Mathf.Rad2Deg;
            enemyi.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, DegAngle-45)); 
            if (index == 0)
            {
                //set the angle the player can use
                player.GetComponent<playerLogic>().angle = angle;
                player.GetComponent<playerLogic>().numOfShapes = numOfShapes;
            }
        }
    }
}
