using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;
using Random = System.Random;

public class beamLogic : MonoBehaviour
{
    public float mBeamSpeed;
    private Rigidbody2D _rb;
    public GameObject explodeAnim;

    private void Start()
    {
        //StartCoroutine(flickerPlayer());
        transform.DOShakeScale(1f,Vector3.one*0.01f);

        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * mBeamSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("differentShape"))
        {
            StartCoroutine(killEnemy(other.gameObject));
        } 
        else if (!other.transform.CompareTag("cat"))
        {
            EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__SHOOT_WRONG,null);
            Destroy(gameObject);
        }
    }

  

    IEnumerator killEnemy(GameObject other)
    {
        transform.DOScale(0, 0.5f);
        GameObject go = Instantiate(explodeAnim,other.transform.position,other.transform.rotation);
        //explodeAnim.transform.position = other.transform.position;
        go.GetComponent<Animator>().ResetTrigger("startShoot");
        go.GetComponent<Animator>().SetTrigger("stopShoot");
        Destroy(other);
        EventManagerScript.Instance.TriggerEvent(EventManagerScript.EVENT__SHOOT_RIGHT,null);
        yield return new WaitForSeconds(0.5f);
        Destroy(go);
        Destroy(gameObject);
    }

}
