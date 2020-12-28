using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class earthLogic : MonoBehaviour
{
    public GameObject gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<Collider2D>().enabled = false;
        transform.DOScale(0, 1);
        EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__GAME_OVER,null);
    }

   

    
}
