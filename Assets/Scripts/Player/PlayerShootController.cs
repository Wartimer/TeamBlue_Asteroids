using System;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal enum ScanState
    {
        SCAN = 0,
        STOP = 1,
    }
    
    internal class PlayerShootController : IExecute
    {
        private float _firstScan = 0f;
        private float _scanRepeatRate = 0.1f;
        private float _firstShot = 0f;
        private float _repeatRate = 0.3f;
        private Data _data;
        private Transform _currentTarget;
        private Vector3 _forward;
        private ScanState _scanState = ScanState.STOP;
        private bool _targetSet = false;
        
        
        //TEmporary container
        private PlayerView _player;
        private MissilesContainer _missiles;
        private MissileFactory _missileFactory;

        internal PlayerShootController(PlayerView player, MissileFactory missileFactory, MissilesContainer missilesContainer)
        {
            _player = player;
            _missiles = missilesContainer;
            _missileFactory = missileFactory;

        }

        public void Execute(float time)
        {
            _firstShot += time;
            _firstScan += time;
            if (_firstScan > _scanRepeatRate)
            {
                _scanState = ScanState.SCAN;
                _targetSet = false;
            }
            else
            {
                _scanState = ScanState.STOP;
            }

            if (_scanState == ScanState.SCAN)
            {
                ScanForTargets();
            }

            if (CanShoot() && _targetSet)
            {
                Shoot(_player.transform.position);
            }

        }

        private void Shoot(Vector3 position)
        {
            var temAmmunition = _missileFactory.CreateMissile(_player.transform.position, _forward);
            temAmmunition.GetComponent<MissileView>().Target = _currentTarget;
            _missiles.AddMissile(temAmmunition.GetComponent<MissileView>());
            
            _firstShot = 0f;
        }
        
        internal void ScanForTargets()
        {
            var playerTransform = _player.transform;
            _forward = playerTransform.TransformDirection(Vector3.forward);
            var hit = new RaycastHit();
            Debug.DrawRay(playerTransform.position, _forward * 11, Color.red);

            if (Physics.Raycast(playerTransform.position, _forward, out hit, 11))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    
                    SetTarget(hit.collider.transform);
                    Debug.Log(hit);
                }
            }
            
        }

        private void SetTarget(Transform newTarget)
        {
            _currentTarget = newTarget;
            _targetSet = true;
        }

        private bool CanShoot()
        {
            if (_firstShot > _repeatRate) return true;
            return false;
        }
        
        private GameObject CreateRocket()
        {
            return _data.Rocket;
        }
    }
}
