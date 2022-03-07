using UnityEngine;
using UnityTemplateProjects.UserInput;
using UserInput;

namespace TeamBlue_Asteroids
{
    internal sealed class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserKeyInput _pcKeyInput;

        internal IUserInputProxy PCInputHorizontal => _pcInputHorizontal;
        internal IUserInputProxy PCInputVertical => _pcInputVertical;
        internal IUserKeyInput PCKeyInput => _pcKeyInput;
        
        internal InputController InputController { get; private set; }

        internal InputInitialization(Controllers controllers)
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVectical();
            _pcKeyInput = new PCKeyInput();
            InputController = new InputController(_pcInputHorizontal, _pcInputVertical);
            controllers.Add(InputController);
        }
        public void Initialization()
        {
            
        }
        
        public IUserKeyInput GetKeyInput()
        {
            return _pcKeyInput;
        }
    }
}