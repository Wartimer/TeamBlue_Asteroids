using System;
using System.Collections.Generic;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class InteractiveObjectsController : IFixedExecute
    {
        internal event Action<Vector3> EnemyRemoved;
        
        private List<EnemyView> _executeObjects;
        
        internal InteractiveObjectsController()
        {
            _executeObjects = new List<EnemyView>();
        }
        
        public void FixedExecute(float deltaTime)
        {
            for (int i = 0; i < _executeObjects.Count; i++)
            {
                if (_executeObjects[i] is IRotation rotation)
                {
                    rotation.Rotation(deltaTime);
                }
                var speed = _executeObjects[i].EnemyStats.Speed * deltaTime;
                var position = Vector3.down * speed;
                _executeObjects[i].Move(position);
            }
        }

        internal void AddObject(EnemyView obj)
        {
            obj.EnemyDead += RemoveObject;
            _executeObjects.Add(obj);
        }

        private void RemoveObject(EnemyView obj)
        {
            EnemyRemoved?.Invoke(obj.transform.position);
            obj.EnemyDead -= RemoveObject;
            _executeObjects.Remove(obj);
        }
    }
    
}