using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal class EnemyAsteroidView : EnemyView
    {
        private float _rotationSpeed;

        private void Rotation(float time)
        {
            transform.Rotate(Vector3.up * (time * _rotationSpeed),
                Space.World);
            transform.Rotate(Vector3.forward * (time * _rotationSpeed),
                Space.World);
        }
        
        protected override void EnemyInit()
        {
            base.EnemyInit();
            _rotationSpeed = Random.Range(-20, 20);
        }

    }
}
