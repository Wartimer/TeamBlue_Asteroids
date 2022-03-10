using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class EffectView : MonoBehaviour
    {
        private float _duration = 1f;
        private float _startLifeTime = 0f;

        internal float Duration => _duration;

        internal float StartLifeTime
        {
            get => _startLifeTime;
            set => _startLifeTime = value;
        }
        
        private void OnEnable()
        {
            _startLifeTime = 0;
        }
    }
}