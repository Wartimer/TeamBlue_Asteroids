using System;
using UnityEngine;
using Object = System.Object;

namespace TeamBlue_Asteroids
{
    internal class StarsView : MonoBehaviour
    {
        private Vector3 _move;
        private float _speed = 7f;


        internal void Execute(float time)
        {
            Move(time);
        }
    
        internal void Move(float time)
        {
            transform.Translate(Vector3.down * _speed * time, Space.World);
            // var speed = deltaTime * _speed;
            // _move.Set(0.0f, -1f * speed, 0.0f);
            // transform.position += _move;
        }
        
    }
}