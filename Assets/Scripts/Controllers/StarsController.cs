using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class StarsController : IExecute
    {
        private StarsView _stars;

        internal StarsController(StarsView stars)
        {
            _stars = stars;
        }
        public void Execute(float deltaTime)
        {
            _stars.Execute(deltaTime);
        }
    }
}