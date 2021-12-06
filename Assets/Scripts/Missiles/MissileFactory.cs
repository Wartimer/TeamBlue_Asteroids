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
        
        public MissileView CreateMissile(Vector3 position, Vector3 lookDirection)
        {
            return Object.Instantiate(_data.Rocket, position, Quaternion.LookRotation(lookDirection)).AddComponent<MissileView>();
        }
    }
}