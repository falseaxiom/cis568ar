using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class TargetScript : MonoBehaviour
    {

        public int pointValue;

        // Start is called before the first frame update
        void Start()
        {
            pointValue = pointValue + 0;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Debug.Log("ProjectileBehavior: Hit target");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
