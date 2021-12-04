using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class StarsView : MonoBehaviour
    {
        private float _speed = 5f;
        private Vector3 _startPos;
        private float _repeatHeight;


        private void Start()
        {
            _startPos = transform.position; // Establish the default starting position 
            _repeatHeight = GetComponent<BoxCollider2D>().size.y/2; // Set repeat width to half of the background
        }


        internal void Execute(float time)
        {
            Move(time);
        }

        private void Move(float time)
        {
            transform.Translate(Vector3.down * _speed * time, Space.World);
            Debug.Log(transform.position);
            // If background moves left by its repeat width, move it back to start position
            if (transform.position.y < _startPos.y - _repeatHeight)
            {
                transform.position = _startPos;
            }
        }
    }
}