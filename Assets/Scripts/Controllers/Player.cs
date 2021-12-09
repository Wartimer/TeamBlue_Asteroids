using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        private float _speed = 8.0f;
        private PlayerMove _playerMove;
        private float xRange = 10.0f;


        private void Start()
        {
            _playerMove = new PlayerMove(transform, _speed);
        }

        private void Update()
        {
            _playerMove.Move(Input.GetAxis("Horizontal"), Time.deltaTime);
            PlayerMovementRestriction();

        }

        private void PlayerMovementRestriction()
        {
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
        }

    }
}
