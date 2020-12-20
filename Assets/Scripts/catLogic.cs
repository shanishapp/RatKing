using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class catLogic : MonoBehaviour
    {
        public float time = 0;
        public float radius;
        public float mCatSpeed;
        public float timeFactor = 1f;


        private void Start()
        {
        }

        private void FixedUpdate()
        {
            time += (Time.deltaTime / 7 * timeFactor);
            float x = Mathf.Cos(time * mCatSpeed) * radius;
            float y = Mathf.Sin(time * mCatSpeed) * radius;
            transform.localPosition = new Vector3(x,y,0);
        }
    }
}