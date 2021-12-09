using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class EffectFactory : IEffectFactory
    {
        private readonly Data _data;

        internal EffectFactory(Data data)
        {
            _data = data;
        }
    
        public GameObject CreateEffect(EffectType type)
        {
            return _data.Explosion;
        }
    }
}