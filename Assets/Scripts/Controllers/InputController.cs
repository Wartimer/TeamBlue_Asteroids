using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;

        internal InputController(IUserInputProxy input)
        {
            _horizontal = input;
        }

        public void Execute(float time)
        {
            _horizontal.GetAxis();
        }
    }
}