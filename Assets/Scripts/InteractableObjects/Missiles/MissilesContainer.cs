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

        internal void AddMissile(MissileView missile)
        {
            _missiles.Add(missile);
        }

        internal void RemoveMissile(MissileView missile)
        {
            _missiles.Remove(missile);
        }
    }
}