using System;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal sealed class RocketPool : IDisposable
    {
        private readonly Stack<MissileView> _stack = new Stack<MissileView>();
        private Transform _root;
        private MissileFactory _missileFactory;
        private RouteFactory _routeFactory;
        private Vector3 _forward;
        private Vector3 _routePosition;
        private MissileView _currentMissile;

        internal RocketPool(Transform root, MissileFactory missileFactory, RouteFactory routeFactory)
        {
            _root = root;
            _routeFactory = routeFactory;
            _missileFactory = missileFactory;
            _forward = _root.TransformDirection(Vector3.forward);
        }

        internal GameObject Pop()
        {
            var rnd = Random.Range(0, 2);
            GameObject missile;
            if (_stack.Count == 0)
            {
                missile = Object.Instantiate(_missileFactory.CreateMissile(), _root.position, Quaternion.LookRotation(_forward)).gameObject;
            }
            else
            {
                missile = _stack.Pop().gameObject;
            }

            _currentMissile = missile.GetComponent<MissileView>();
            _currentMissile.gameObject.SetActive(true);
            _routePosition = _root.position;
            var route = _routeFactory.CreateRoute(rnd, _routePosition);
            _currentMissile.Route = route;

            missile.transform.SetParent(null);
            return missile;
        }

        internal void Push(MissileView missile)
        {
            _stack.Push(missile);
            missile.transform.position = _root.position;
            missile.transform.SetParent(_root);
            missile.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            for (var i = 0; i < _stack.Count; i++)
            {
                var gameObject = _stack.Pop();
                Object.Destroy(gameObject);
            }
            Object.Destroy(_root.gameObject);
        }
        
        
    }
}