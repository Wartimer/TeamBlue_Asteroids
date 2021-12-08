using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class MissileFactory : IMissileFactory
    {
        private readonly Data _data;

        internal MissileFactory(Data data)
        {
            _data = data;
        }
        
        public MissileView CreateMissile()
        {
            return _data.Rocket;
        }
    }
}