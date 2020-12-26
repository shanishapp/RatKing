using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class earthLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<Collider2D>().enabled = false;
        transform.DOScale(0, 1);
        StartCoroutine(loadGameOver());
    }

   

    IEnumerator loadGameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);

    }
}
