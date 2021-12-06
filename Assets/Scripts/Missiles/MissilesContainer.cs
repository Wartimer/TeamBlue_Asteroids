using System.Collections.Generic;

namespace TeamBlue_Asteroids
{
    internal sealed class MissilesContainer
    {
        private List<MissileView> _missiles;

        internal List<MissileView> Missiles => _missiles;

        internal MissilesContainer()
        {
            _missiles = new List<MissileView>();
        }

        internal void AddMissile(MissileView obj)
        {
            obj.MissileDestroyed += RemoveMissile;
            _missiles.Add(obj);
        }

        internal void RemoveMissile(MissileView obj)
        {
            obj.MissileDestroyed -= RemoveMissile;
            _missiles.Remove(obj);
        }
    }
}