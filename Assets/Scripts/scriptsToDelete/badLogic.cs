using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badLogic : MonoBehaviour
{

    private Transform ratTransform;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindWithTag("rat");
        ratTransform = go.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, ratTransform.position) > 0.1f)
        {

            transform.position = Vector3.MoveTowards(transform.position, ratTransform.position,
                movementSpeed * Time.deltaTime);
        }
    }
}
