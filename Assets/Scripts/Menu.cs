﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class Menu : MonoBehaviour
{
    public GameObject menuScene;
    public GameObject gameScene;
    public GameObject gameOverScene;
    public Camera camera;

    private GameObject currentGO;


    private void Start()
    {
        currentGO = menuScene;
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__GAME_OVER,gameOver);
    }

    public void gameOver(Object obj)
    {
        StartCoroutine(loadGameOver());
    }

    public void playGame()
    {
        camera.DOOrthoSize(3, 1f);
        currentGO.SetActive(false);
        gameScene.transform.DORewind();
        currentGO = Instantiate(gameScene);
    }

    public void quitGame()
    {
        Debug.Log("quit pressed");
        Application.Quit();
    }

    IEnumerator loadGameOver()
    {
        
        var temp = currentGO;
        temp.SetActive(false);
        gameOverScene.SetActive(true);
        currentGO = gameOverScene;
        yield return new WaitForSeconds(1f);
        Destroy(temp);


    }
}
