using System.Collections.Generic;

namespace TeamBlue_Asteroids
{
    internal class MissilesMoveController : IExecute
    {
        private List<MissileView> _missiles;
        
        internal MissilesMoveController(MissilesContainer missilesContainer)
        {
            _missiles = missilesContainer.Missiles;
        }
        public void Execute(float time)
        {
            foreach(var missile in _missiles)
                missile.Move(time);
        }
    }
}