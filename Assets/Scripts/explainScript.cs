using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explainScript : MonoBehaviour
{

    public void show()
    {
        gameObject.SetActive(true);
    }

    public void unshow()
    {
        gameObject.SetActive(false);
    }
}
