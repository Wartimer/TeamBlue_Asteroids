using System;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal class PlayerShootController : IExecute
    {
        private PlayerView _player;
        private float _firstShot = 0f;
        private Data _data;
        private float repeatRate = 1.0f;
        private LayerMask _layerMask= 6;
        private Vector3 fwd;
        
        //TEmporary container
        private MissilesContainer _missiles;
        

        internal PlayerShootController(PlayerView player, Data data)
        {
            _player = player;
            _missiles = new MissilesContainer();
            _data = data;
            
        }

        public void Execute(float time)
        {
            _firstShot += time;
            if (_player.EnemyInSight())
            {
                Shoot();
            }
            
        }

        private void Shoot()
        {
            if (_firstShot > repeatRate)
            {
                //int rocketIndex = Random.Range(0, _rockets.Length);
                var temAmmunition = CreateRocket();
                temAmmunition.transform.position = _player.transform.position;
                temAmmunition.GetComponent<Missile>().MissileDestroyed += _missiles.RemoveMissile;
                _missiles.AddMissile(temAmmunition.GetComponent<Missile>());
                _firstShot = 0f;
            }
        }

        private GameObject CreateRocket()
        {
            return _data.Rocket;
        }
    }
}
