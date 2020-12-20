using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float mRatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += (Vector3.up * (mRatSpeed ));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += (Vector3.down * (mRatSpeed ));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += (Vector3.left * (mRatSpeed ));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += (Vector3.right * (mRatSpeed));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision detected ");
        if(other.gameObject.CompareTag("ball"))
            Destroy(other.gameObject);
        else if (other.gameObject.CompareTag("cat"))
        {
              //GAME OVER
        }
    }
}
