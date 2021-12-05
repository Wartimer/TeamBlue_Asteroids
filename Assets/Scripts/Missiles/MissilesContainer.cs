using System.Collections.Generic;

namespace TeamBlue_Asteroids
{
    internal sealed class MissilesContainer
    {
        private List<Missile> _missiles;

        internal List<Missile> Missiles => _missiles;

        internal MissilesContainer()
        {
            _missiles = new List<Missile>();
        }

        internal void AddMissile(Missile obj)
        {
            _missiles.Add(obj);
        }

        internal void RemoveMissile(Missile obj)
        {
            obj.MissileDestroyed -= RemoveMissile;
            _missiles.Remove(obj);
        }
    }
}