using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class playerLogic : MonoBehaviour
    {
        public float time = 0;
        public float radius;
        public float mCatSpeed;
        public float timeFactor = 1f;
        public GameObject beam;


        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                timeFactor = 1f;
                time += (Time.deltaTime / 7 * timeFactor);
                float x = Mathf.Cos(time * mCatSpeed) * radius;
                float y = Mathf.Sin(time * mCatSpeed) * radius;
                float oldX = transform.localPosition.x;
                float oldy = transform.localPosition.y;

                float angle = Mathf.Atan2(oldy-y, oldX-x) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                transform.localPosition = new Vector3(x,y,0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                timeFactor = -1f;
                time += (Time.deltaTime / 7 * timeFactor);
                float x = Mathf.Cos(time * mCatSpeed) * radius;
                float y = Mathf.Sin(time * mCatSpeed) * radius;
                float oldX = transform.localPosition.x;
                float oldy = transform.localPosition.y;

                float angle = Mathf.Atan2(y-oldy, x-oldX) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                transform.localPosition = new Vector3(x,y,0);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject go = Instantiate(beam);
                go.transform.localRotation = transform.localRotation;
                go.transform.position = transform.position;
            }

            
            
            

        }
    }
}