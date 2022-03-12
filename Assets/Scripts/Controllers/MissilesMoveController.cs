using System.Collections.Generic;
using System.Linq;

namespace TeamBlue_Asteroids
{
    internal class MissilesMoveController : IFixedExecute
    {
        private List<MissileView> _missiles;
        
        internal MissilesMoveController(MissilesContainer missilesContainer)
        {
            _missiles = missilesContainer.Missiles;
        }
        public void FixedExecute(float time)
        {
            foreach (var missile in _missiles.ToList())
            {
                missile.Move(time);
            }
        }
    }
}