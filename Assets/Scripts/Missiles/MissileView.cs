using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


namespace TeamBlue_Asteroids
{
    internal class MissileView : MonoBehaviour, IDisposable
    {
        internal event Action<MissileView> MissileDestroyed;
        
        private float _speed = 6f;
        private int _damage = 40;
        private float _ejectForce = 2.5f;
        [SerializeField] private float _firstEjected = 0;
        private float _timeToStartMove = 0.2f;
        [SerializeField] private Transform _target;
        private Vector3 _ejectDirection;
        private Rigidbody _rigidBody;
        private TrailRenderer _trail;
       
        internal float Speed => _speed;

        internal Transform Target
        {
            set => _target = value;
        }


        private void Awake()
        {
            _trail = GetComponentInChildren<TrailRenderer>();
            _rigidBody = GetComponent<Rigidbody>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            other.GetComponent<IDamagable>().TakeDamage(_damage);
            Dispose();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Boundaries"))
            {
                    Dispose();
            }
        }

        public void Dispose()
        {
            MissileDestroyed?.Invoke(this);
        }

        private void OnEnable()
        {
            _trail.Clear();
            var rnd = Random.Range(-1, 2);
            _ejectDirection.Set(rnd, 1, 0);
            
            
            _rigidBody.AddForce(_ejectDirection * _ejectForce, ForceMode.Impulse);
            transform.LookAt(_target);
        }

        private void OnDisable()
        {
            _firstEjected = 0.0f;
        }

        private void SearchTargets()
        {
            Collider[] tmp = new Collider[20]; 
                Physics.OverlapSphereNonAlloc(transform.position, 50, tmp);
            
            var targets = new HashSet<Transform>();
            
            foreach (Collider c in tmp)
            {
                if (c.transform != transform && c.transform.GetComponent<EnemyView>())
                {
                    targets.Add(c.transform);
                }
            }

            
            _target = targets.FirstOrDefault().transform;

        }

        internal void Move(float deltaTime)
        {
            _firstEjected += deltaTime;

            if (!(_firstEjected > _timeToStartMove))
            {
                return;
            }

            _rigidBody.Sleep();
            
            if (_target == null)
            {
                transform.Translate(Vector3.forward * _speed * deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position,  _speed * deltaTime );
                transform.LookAt(_target);
            }
        }
        
    }
}