using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour
{
    private float time = 0f;

    public float timeFactor = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*10*timeFactor;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, time));
    }
}
