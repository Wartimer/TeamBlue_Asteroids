using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal class MissileView : MonoBehaviour, IDisposable
    {
        internal event Action<MissileView> MissileDestroyed;
        
        private float _speed = 5f;
        private float _damage = 10f;
        private float _ejectForce = 1.2f;
        private float _firstEjected = 0;
        private float _timeToStartMove = 0.2f;
        private Transform _target;
        private Vector3 _ejectDirection;


        internal float Speed => _speed;

        internal Transform Target
        {
            set => _target = value;
        }
        
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

        // private void Update()
        // {
        //     transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        //     
        //     
        // }

        private void OnEnable()
        {
            var rnd = Random.Range(-1f, 1f);
            _ejectDirection.Set(rnd, 1, 0);

            gameObject.GetComponent<Rigidbody>().AddForce(_ejectDirection * _ejectForce, ForceMode.Impulse);
        }

        internal void Move(float deltaTime)
        {
            _firstEjected += deltaTime;
            if(_firstEjected > _timeToStartMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * deltaTime);
                //transform.position = Vector3.Lerp(transform.position, _target.position, _speed * deltaTime);
                transform.LookAt(_target);
            }
        }
    }
}