using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = System.Object;

namespace DefaultNamespace
{
    public class playerLogic : MonoBehaviour
    {
        public GameObject beam;
        public float mPlayerSpeed;
        public float shootTimer = 0.3f;
        public Transform shootingTransform;
        public Transform shootingAnimTransform;
        public GameObject shootAnim;
        public float radius = 0.5f;
        public float angle = 0.1f;
        public int numOfShapes;
        
        private float time = 0;
        private SpriteRenderer _sr;
        private float stepIndex = 0;

        private void Start()
        {
            EventManagerScript.Instance.StartListening(EventManagerScript.EVENT__NEXT_LEVEL,startNextLevel);
            _sr = GetComponent<SpriteRenderer>();
            StartCoroutine("punchPlayer");
            Color c = _sr.color;

            // Setting initial values for Green and Blue channels
            c.g = 1f;
            c.b = 1f;

            // Set sprite colors
            _sr.color = c;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                stepIndex = stepIndex + 1;
                float x = Mathf.Cos(angle * ((int)stepIndex % numOfShapes)) * radius;
                float y = Mathf.Sin(angle * ((int)stepIndex % numOfShapes) ) * radius;
                float oldx = transform.position.x;
                float oldy = transform.position.y;

                transform.localPosition = new Vector3(x,y,0);
                float DegAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, DegAngle-90)); 

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                stepIndex = stepIndex - 1;
                float x = Mathf.Cos(angle * ((int)stepIndex % numOfShapes)) * radius;
                float y = Mathf.Sin(angle * ((int)stepIndex % numOfShapes) ) * radius;
                float oldx = transform.position.x;
                float oldy = transform.position.y;

                transform.localPosition = new Vector3(x,y,0);
                float DegAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, DegAngle-90));
            }
            if (Input.GetButtonDown("Jump"))
            {
                StopCoroutine("punchPlayer");
                StartCoroutine("punchPlayer");
                StartCoroutine(shootOnce());
            }

        }

        private void startNextLevel(Object obj)
        {
            StopCoroutine("punchPlayer");
            StartCoroutine("punchPlayer");
            stepIndex = 0;
            float x = Mathf.Cos(angle * stepIndex) * radius;
            float y = Mathf.Sin(angle * stepIndex ) * radius;

            transform.localPosition = new Vector3(x,y,0);
            float DegAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, DegAngle-90));
        }

        IEnumerator shootOnce()
        {
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.3f);
            var localRotation = transform.localRotation;
            transform.DORewind ();
            transform.DOPunchScale (new Vector3 (0.01f, 0.01f, 0.01f), .25f);
            var position = shootingTransform.position + (Vector3.forward );
            Instantiate(beam, position, localRotation);
            Quaternion shootRotation = Quaternion.AngleAxis(90, Vector3.forward) * localRotation;
            GameObject go = Instantiate(shootAnim, shootingAnimTransform.position, shootRotation);
            yield return new WaitForSeconds(0.5f);
            GetComponent<AudioSource>().Stop();
            Destroy(go);
        }

        IEnumerator punchPlayer()
        {
            while (true)
            {
                for (float i = 1f; i >= 0f; i -= 0.05f)
                {
                    transform.DORewind ();
                    transform.DOPunchScale (new Vector3 (0.01f, 0.01f, 0.01f), .25f);
                    // Getting access to Color options
                    Color c = _sr.color;

                    // Setting values for Green and Blue channels
                    c.g = i;
                    c.b = i;

                    // Set color to Sprite Renderer
                    _sr.color = c;

                    // Pause to make color be changed slowly
                    yield return new WaitForSeconds (shootTimer);
                }

                transform.DOShakePosition(1f,Vector3.one*0.2f,50);
                yield return new WaitForSeconds (0.2f);
                Instantiate(beam, shootingTransform.position, transform.localRotation);
                StartCoroutine(shootOnce());

            }

        }
    }
}