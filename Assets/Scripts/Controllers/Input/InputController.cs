using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        
        internal InputController(IUserInputProxy horizontal, IUserInputProxy vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }

        public void Execute(float time)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}