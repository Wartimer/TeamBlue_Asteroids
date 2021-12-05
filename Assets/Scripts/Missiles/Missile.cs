using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class Missile : MonoBehaviour, IDisposable
    {
        internal event Action<Missile> MissileDestroyed;
        
        private float _speed = 5f;
        private float _damage = 10f;

        internal float Speed => _speed;
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            Dispose();
        }

        public void Dispose()
        {
            MissileDestroyed?.Invoke(this);
            Destroy(gameObject);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            
            
        }
    }
}