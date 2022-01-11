using UnityTemplateProjects.UserInput;

namespace TeamBlue_Asteroids
{
    internal sealed class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserKeyInput _pcKeyInput;

        internal IUserInputProxy PCInputHorizontal => _pcInputHorizontal;
        internal InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcKeyInput = new PCKeyInput();
        }
        public void Initialization()
        {
        }

        public IUserInputProxy GetInput()
        {
            return _pcInputHorizontal;
        }

        public IUserKeyInput GetKeyInput()
        {
            return _pcKeyInput;
        }
    }
}