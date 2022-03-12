using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class MissileView : InteractiveObject, IDisposable
    {
        internal event Action<MissileView> MissileDestroyed;
        
        private int _damage = 40;
        private float _routeSpeed = 2f;
        private float _toTargetSpeed = 8f;
        private float _time;
        private bool _onStartingRoute = true;

        private Vector3 _forward;
        private Vector3 _p0;
        private Vector3 _p1;
        private Vector3 _p2;
        private Vector3 _p3;
        private Vector3 _missilePosition;
        
        private EnemyView _enemyView;
        
        private AudioSource _audioSource;
        private AudioClip _asteroidShoot;
        
        private Transform _route;
        private TrailRenderer _trail;
        
        
        internal AudioClip Sound
        {
            set => _asteroidShoot = value;
        }
        
        internal Transform Route
        {
            set => _route = value;
        }

        private void PlaySound()
        {
            _audioSource.PlayOneShot(_asteroidShoot);
        }
     
        
        private void Awake()
        {
            _forward = transform.TransformDirection(Vector3.down);
            _trail = GetComponentInChildren<TrailRenderer>();
            _audioSource = GetComponent<AudioSource>();
        }
        

        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            _enemyView = other.GetComponent<EnemyView>();
            Interaction();
            Dispose();
        }

        protected override void Interaction()
        {
            _enemyView.EnemyStats.TakeDamage(_damage);
        }
        
        public void Dispose()
        {
            
            MissileDestroyed?.Invoke(this);
        }

        private void OnEnable()
        {
            PlaySound();
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

            if (transform.position.y >= _p3.y && _onStartingRoute)
            {
                _onStartingRoute = false;
                _route.GetComponent<Route>().Dispose();
            }

            // if (_target)
            // {
            //     transform.position = Vector3.MoveTowards(transform.position, _target.position,  _toTargetSpeed * deltaTime );
            //     transform.LookAt(_target);
            //     
            // }
            
            transform.Translate(_forward * (_toTargetSpeed * deltaTime));
        }

        internal void GetPoints()
        {
            _p0 = _route.GetChild(0).position;
            _p1 = _route.GetChild(1).position;
            _p2 = _route.GetChild(2).position;
            _p3 = _route.GetChild(3).position;
        }

        private void FollowRoute(float deltaTime)
        {
                        
            _time += deltaTime * _routeSpeed;
            _missilePosition = Mathf.Pow(1 - _time, 3) * _p0 +
                               3 * Mathf.Pow(1 - _time, 2) * _time * _p1 +
                               3 * (1 - _time) * Mathf.Pow(_time, 2) * _p2 +
                               Mathf.Pow(_time, 3) * _p3;
            
            transform.position = _missilePosition;
            
        }

    }

}