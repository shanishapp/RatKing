﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 using UnityEngine.SceneManagement;


 public class ratMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float mRatSpeed;
    public int numOfBalls;
    private int numOfBallsCollected = 0;
    public GameObject hole;
    public SpriteRenderer innerLight;
    public SpriteRenderer outerLight;
    public int level = 0;

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
        if (other.gameObject.CompareTag("ball"))
        {
            transform.DOScale(transform.localScale.y + 0.01f, 1);
            Destroy(other.gameObject);
            numOfBallsCollected++;
            hole.GetComponent<Collider2D>().enabled = true;
            StartCoroutine(flickerLights());

        }
        else if (other.gameObject.CompareTag("cat"))
        {
            SceneManager.LoadScene(2);
        } else if (other.gameObject.CompareTag("hole"))
        {
            level++;
        }
    }

    IEnumerator flickerLights()
    {
        Color innerColor = innerLight.color;
        Color outerColor = outerLight.color;
        while(true)
        {
            innerLight.color = new Color(innerColor.r,innerColor.g, innerColor.b,255);
            yield return new WaitForSeconds (0.1f); 
            outerLight.color = new Color(outerColor.r,outerColor.g, outerColor.b,255);
            yield return new WaitForSeconds (0.1f);
            innerLight.color = innerColor;
            yield return new WaitForSeconds (0.1f);
            outerLight.color = outerColor;
            yield return new WaitForSeconds (0.1f);
        }
    }
}
