using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public Transform parent;
    public float spawnGoodsSpeed;
    public float spawnBadsSpeed;
    public float spawncatsWait;
    public float yInitialRadius;
    public float xInitialRadius;
    public float spaceBetweenCircles;


    public int numOfCircles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnGoods());
        StartCoroutine(spawnBads());
        StartCoroutine(spawnCats());
    }

    IEnumerator spawnGoods()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnGoodsSpeed);
            GameObject goodGO = Instantiate(Resources.Load("goodBall")) as GameObject;
            goodGO.transform.localPosition = Vector3.zero;
        }
    }
    IEnumerator spawnBads()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnBadsSpeed);
            GameObject badGO = Instantiate(Resources.Load("badBall")) as GameObject;
            badGO.transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator spawnCats()
    {

        for (int i = 0; i < numOfCircles; i++)
        {                                        
            float numOfCats = Mathf.Pow(2, i+2)* 2 /3;
            float angle = (2 * Mathf.PI) / (float)numOfCats;

            for (int index = 0; index < numOfCats; index++)
            {
                GameObject catGO = Instantiate(Resources.Load("cat")) as GameObject;

                float xPosition = (xInitialRadius +  spaceBetweenCircles * (i+1)) * Mathf.Cos(angle * index);
                float yPosition = (yInitialRadius + (spaceBetweenCircles * (i+1))) * Mathf.Sin(angle * index);

                if (index > numOfCats/2)
                {
                    catGO.GetComponent<catLogic>().time = angle * index ;
                }
                else
                {
                    catGO.GetComponent<catLogic>().time = angle * index;
                }

                if (i % 2 == 1)
                {
                    catGO.GetComponent<catLogic>().timeFactor = -1;

                }

                catGO.GetComponent<catLogic>().radius = (xInitialRadius + spaceBetweenCircles * (i + 1));
                
                catGO.transform.SetParent(parent);
                catGO.transform.localPosition = new Vector3(xPosition, yPosition, 0);
            }
            
        }
        yield return new WaitForSeconds(spawnBadsSpeed);
    }
}
