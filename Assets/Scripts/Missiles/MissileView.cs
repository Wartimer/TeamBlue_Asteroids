using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


namespace TeamBlue_Asteroids
{
    internal class MissileView : MonoBehaviour, IDisposable
    {
        internal event Action<MissileView> MissileDestroyed;
        
        private float _routeSpeed = 2f;
        private float _toTargetSpeed = 8f;
        private int _damage = 40;
        private float _time;
        private int _routeNumber;
        private AudioSource _audioSource;
        private AudioClip _asteroidShoot;
        private SoundFactory _soundFactory;


        private Vector3 _forward;

        private bool _onStartingRoute = true;

        private Transform _route;
        [SerializeField] private Transform _target;
        
        private TrailRenderer _trail;
        
        private Vector3 _p0;
        private Vector3 _p1;
        private Vector3 _p2;
        private Vector3 _p3;
        private Vector3 _missilePosition;
        
        internal AudioClip Sound
        {
            set => _asteroidShoot = value;
        }

        internal Transform Target
        {
            set => _target = value;
        }
      

        internal Transform Route
        {
            set => _route = value;
        }

        internal void PlayAsteroidSound()
        {
            _audioSource.PlayOneShot(_asteroidShoot);
        }
     
        
        private void Awake()
        {
            _forward = transform.TransformDirection(Vector3.down);
            _trail = GetComponentInChildren<TrailRenderer>();
            _audioSource = GetComponent<AudioSource>();
            
        }
        

        private void OnTriggerEnter(Collider other)
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
            _route.gameObject.GetComponent<Route>().Dispose();
            MissileDestroyed?.Invoke(this);
        }

        private void OnEnable()
        {
            _onStartingRoute = true;
            _trail.Clear();
            _time = 0f;
        }
        
        internal void Move(float deltaTime)
        {
            if (_onStartingRoute)
            {
                FollowRoute(deltaTime);
            }
            
            if (transform.position.y >= _p3.y) _onStartingRoute = false;
            
            
            
            
            
                if (_target)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _target.position,  _toTargetSpeed * deltaTime );
                    //transform.localPosition += Vector3.forward * _toTargetSpeed * deltaTime;
                    transform.LookAt(_target);
                    
                }
                else
                {
                     transform.Translate(_forward * _toTargetSpeed * deltaTime);
                }
            
           
            // if(transform.position.z > _p3.z && _target == null)
            //     transform.Translate(_forward * _toTargetSpeed * deltaTime);

        }

        internal void GetPoints()
        {
            _p0 = _route.GetChild(0).position;
            _p1 = _route.GetChild(1).position;
            _p2 = _route.GetChild(2).position;
            _p3 = _route.GetChild(3).position;
            
            Debug.Log($"{_p0}");
            Debug.Log($"{_p1}");
            Debug.Log($"{_p2}");
            Debug.Log($"{_p3}");
        }

        private void FollowRoute(float deltaTime)
        {
                        
            _time += deltaTime * _routeSpeed;
            _missilePosition = Mathf.Pow(1 - _time, 3) * _p0 +
                               3 * Mathf.Pow(1 - _time, 2) * _time * _p1 +
                               3 * (1 - _time) * Mathf.Pow(_time, 2) * _p2 +
                               Mathf.Pow(_time, 3) * _p3;
            
            //transform.LookAt(_missilePosition);
            transform.position = _missilePosition;
            Debug.Log($"{_missilePosition}");
            
        }

    }

}