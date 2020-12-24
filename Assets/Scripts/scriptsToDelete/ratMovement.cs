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
    public int level = 1;
    public GameObject mSpawner;
    private Vector3 initialPlace;
    public Camera MCamera;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        initialPlace = transform.position;
        Scorer.need = numOfBalls + 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float oldX = transform.localPosition.x;
        float oldy = transform.localPosition.y;
        
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
        else
        {
            return;
        }
        float angle = Mathf.Atan2(transform.position.y-oldy, 
                                    transform.position.x-oldX) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision detected ");
        if (other.gameObject.CompareTag("ball"))
        {
            transform.DOScale(transform.localScale.y + 0.005f, 1);
            Destroy(other.gameObject);
            numOfBallsCollected++;
            Scorer.have++;
            if (numOfBallsCollected == Scorer.need)
            {
                hole.GetComponent<Collider2D>().enabled = true;
                StartCoroutine("flickerLights");
            }
        }
        else if (other.gameObject.CompareTag("cat"))
        {
            SceneManager.LoadScene(2);
        } else if (other.gameObject.CompareTag("hole"))
        {
            hole.GetComponent<Collider2D>().enabled = false;
            level++;
            MCamera.DOOrthoSize(3 + (0.5f*level), 1);

            StopCoroutine("flickerLights");
            outerLight.color = new Color(outerLight.color.r,
                                        outerLight.color.g, 
                                        outerLight.color.b,0);            
            innerLight.color = new Color(innerLight.color.r,
                                        innerLight.color.g, 
                                        innerLight.color.b,0);
            numOfBallsCollected = 0;
            Scorer.have = 0;
            numOfBalls += level;
            Scorer.need = numOfBalls + 1;

            transform.position = initialPlace;

            mSpawner.GetComponent<spawner>().numOfGoods = Scorer.need;
            mSpawner.GetComponent<spawner>().respawn();
        }
        else if (other.gameObject.CompareTag("badBall"))
        {
            Destroy(other.gameObject);
            StartCoroutine(flickerPlayer());
            transform.DOJump(transform.position, 1, 1, 1);
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
    
    IEnumerator flickerPlayer()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //sr.color = new Color(2,0,0);
        Color tmp = sr.color;
        for(int i =0; i<10;i++)
        {
            sr.color = new Color(tmp.r,tmp.g, tmp.b,0);
            yield return new WaitForSeconds (0.1f);
            sr.color = tmp;
            yield return new WaitForSeconds (0.1f);
        }
    }
}
