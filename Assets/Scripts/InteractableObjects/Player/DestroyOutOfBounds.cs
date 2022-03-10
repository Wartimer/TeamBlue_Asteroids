using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        private float topBound = 6.5f;


        void Update()
        {
            if (transform.position.y > topBound)
            {
                Destroy(gameObject);
            }
        }
    }
}
