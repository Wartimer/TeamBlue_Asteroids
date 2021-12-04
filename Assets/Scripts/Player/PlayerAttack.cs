using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerAttack : MonoBehaviour
    {

        private float _speed = 13.0f;
        public GameObject[] Rockets;
        private float timeRate = 1.0f;
        private float repeatRate = 1.0f;


        private void Start()
        {
            InvokeRepeating("Shoot", timeRate, repeatRate);
            
        }


        public void Shoot()
        {
                int rocketIndex = Random.Range(0, Rockets.Length);
                var temAmmunition = Instantiate(Rockets[rocketIndex], transform.position, Rockets[rocketIndex].transform.rotation);
                temAmmunition.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
            
        }

      
    }
}
