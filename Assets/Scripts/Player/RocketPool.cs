using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TeamBlue_Asteroids
{
    internal sealed class RocketPool : IDisposable
    {
        private readonly Stack<MissileView> _stack = new Stack<MissileView>();
        private Transform _root;
        private MissileFactory _missileFactory;
        private Vector3 _forward;

        internal RocketPool(Transform root, MissileFactory missileFactory)
        {
            _root = root;
            _missileFactory = missileFactory;
            _forward = _root.TransformDirection(Vector3.forward);
        }

        internal GameObject Pop()
        {
            GameObject missile;
            if (_stack.Count == 0)
            {
                missile = Object.Instantiate(_missileFactory.CreateMissile(), _root.position, Quaternion.LookRotation(_forward)).gameObject;
            }
            else
            {
                missile = _stack.Pop().gameObject;
            }
            missile.gameObject.SetActive(true);
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