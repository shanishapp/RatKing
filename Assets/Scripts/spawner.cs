using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;


public class spawner : MonoBehaviour
{
    public float spawnGoodsSpeed;
    public int numOfGoods;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnGoods());
    }

    IEnumerator spawnGoods()
    {
        for (int i=0; i<numOfGoods; i++)
        {
            yield return new WaitForSeconds(spawnGoodsSpeed);
            GameObject goodGO = Instantiate(Resources.Load("goodBall")) as GameObject;
            goodGO.transform.localPosition = Vector3.zero;
        }
    }



    public void respawn()
    {
        var foundGameObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject go in foundGameObjects)
        {
            if (go.CompareTag("ball"))
            {
                Destroy(go);
            }
        }
        StartCoroutine(spawnGoods());
    }
}
