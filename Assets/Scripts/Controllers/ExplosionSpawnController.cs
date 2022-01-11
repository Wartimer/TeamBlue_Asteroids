using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace TeamBlue_Asteroids
{
    internal sealed class ExplosionSpawnController : IInitialization, IExecute, IDisposable
    {
        private readonly Data _data;
        private EffectFactory _effectFactory;
        private EffectsPool _effectsPool;
        private List<EffectView> _explosions;
        private InteractiveObjectsController _interObjsController;

        internal ExplosionSpawnController(Data data, InteractiveObjectsController interObjsController)
        {
            _data = data;
            _interObjsController = interObjsController;
            _interObjsController.EnemyRemoved += SpawnExplosion;
            _effectFactory = new EffectFactory(_data);
            _effectsPool = new EffectsPool(_effectFactory);
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

        public void Initialization()
        {
        }

        public void Dispose()
        {
            _interObjsController.EnemyRemoved -= SpawnExplosion;
        }
    }
}