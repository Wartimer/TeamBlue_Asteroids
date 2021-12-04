using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamBlue_Asteroids
{

    public class StageBackgroundView : MonoBehaviour, IMove
    {
        private float _speed = 5f;
        private Vector3 startPos;
        private float repeatWidth;
        public float Speed => _speed;

        private void Start()
        {
            startPos = transform.position; // Establish the default starting position 
            repeatWidth = GetComponent<BoxCollider2D>().size.y/2; // Set repeat width to half of the background
        }


        internal void Execute(float time)
        {
            Move(time);
        }
        
        
        public void Move(float time)
        {
            transform.Translate(Vector3.down * Speed * time, Space.World);
            // If background moves left by its repeat width, move it back to start position
            if (transform.position.y < startPos.y - repeatWidth)
            {
                transform.position = startPos;
            }
        }
  
    }
}