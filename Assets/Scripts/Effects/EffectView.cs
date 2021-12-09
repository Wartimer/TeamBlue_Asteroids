using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class EffectView : MonoBehaviour, IDisposable
    {
        internal event Action<EffectView> ExplosionEnd;
        private float _duration = 1f;
        private float _startLifeTime = 0f;

        private EffectsPool _pool;
        internal EffectsPool Pool
        {
            set => _pool = value;
        }

        internal void CheckState(float deltaTime)
        {
            transform.position += Vector3.down * 1 * deltaTime;
            _startLifeTime += deltaTime;
            if (_startLifeTime > _duration)
            {
                Dispose();
            }
            
        }

        public void Dispose()
        {
            ExplosionEnd?.Invoke(this);
            _pool.Push(this);
        }

        private void OnEnable()
        {
            _startLifeTime = 0;

        }
    }
}