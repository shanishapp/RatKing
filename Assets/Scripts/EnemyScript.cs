using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool noWait = true;
    private bool dontWait = false;
    private bool gameOver = false;
    private Vector2 target;
    private Vector3 initialPosition;
    private bool passedLevel = false;

    public static int speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        initialPosition = transform.position;
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_RIGHT, OnShootRight);
        EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__SHOOT_WRONG, OnShootWrong);
    }

    private void OnShootWrong(object arg0)
    {
        gameOver = true;
    }

    private void OnShootRight(object arg0)
    {
        passedLevel = true;
        noWait = true;
        target = initialPosition+initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime;
        if (noWait && Vector3.Distance(transform.position, target) < 2f)
        {
            if (passedLevel)
            {
                Destroy(gameObject);
            }
            else
            {
                noWait = false;
                StartCoroutine(idle());
            }
        }
        else if(Vector3.Distance(transform.position, target) >= 2f || noWait || gameOver)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        } 
    }

    IEnumerator idle()
    {
        yield return new WaitForSeconds(2f);
        noWait = true;
    }

}
