using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class playerLogic : MonoBehaviour
    {
        private float time = 0;
        public GameObject beam;
        public Transform CircleTransform;
        public float mPlayerSpeed;
        private SpriteRenderer _sr;
        public float shootTimer = 0.3f;


        private void Start()
        {
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                time += (Time.deltaTime * mPlayerSpeed );
                float angle = Mathf.Atan(time) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, time));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                time -= (Time.deltaTime * mPlayerSpeed );
                float angle = Mathf.Atan(time) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, time));
            }
            if (Input.GetButtonDown("Jump"))
            {
                transform.DORewind ();
                transform.DOPunchScale (new Vector3 (0.1f, 0.1f, 0.1f), .25f);
                CircleTransform.DOShakeScale(0.1f,Vector3.one*0.1f);
                Instantiate(beam, transform.position, transform.localRotation);
                StopCoroutine("punchPlayer");
                StartCoroutine("punchPlayer");

            }

        }

        IEnumerator punchPlayer()
        {
            while (true)
            {
                for (float i = 1f; i >= 0f; i -= 0.05f)
                {
                    transform.DORewind ();
                    transform.DOPunchScale (new Vector3 (0.1f, 0.1f, 0.1f), .25f);
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
                Instantiate(beam, transform.position, transform.localRotation);

            }

        }
    }
}