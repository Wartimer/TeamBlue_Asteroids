using UnityTemplateProjects.UserInput;

namespace TeamBlue_Asteroids
{
    internal sealed class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;

        internal InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
        }
        public void Initialization()
        {
            
        }

        public IUserInputProxy GetInput()
        {
            return _pcInputHorizontal;
        }
    }
}