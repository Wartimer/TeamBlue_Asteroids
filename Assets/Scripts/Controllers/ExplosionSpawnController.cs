using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamBlue_Asteroids
{
    internal sealed class ExplosionSpawnController : IExecute
    {
        private readonly EffectsPool _effectsPool;
        private List<EffectView> _explosions; 
        
        internal ExplosionSpawnController(EffectsPool effectsPool)
        {
            _effectsPool = effectsPool;
            _explosions = new List<EffectView>();
        }

        internal void SpawnExplosion(Vector3 point)
        {
            var obj = _effectsPool.Pop(point);
            obj.ExplosionEnd += RemoveExplosion;
            _explosions.Add(obj);
        }

        private void RemoveExplosion(EffectView obj)
        {
            obj.ExplosionEnd -= RemoveExplosion;
            _explosions.Remove(obj);
        }

        public void Execute(float deltaTime)
        {
            foreach (var explosion in _explosions.ToList())
            {
                explosion.CheckState(deltaTime);
            }
        }
    }
}