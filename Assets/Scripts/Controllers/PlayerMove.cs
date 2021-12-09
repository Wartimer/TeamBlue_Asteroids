
using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerMove
    {
        private readonly Transform _transform;
        private readonly float _speed;
        private Vector3 _move;


        public PlayerMove(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(float horizontal, float deltatime)
        {
            var speed = deltatime * _speed;
            _move.Set(horizontal * speed, 0.0f, 0.0f);
            _transform.localPosition += _move;
            
        }
    }
}

