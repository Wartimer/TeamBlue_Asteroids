using UnityEngine;

namespace TeamBlue_Asteroids
{
    public class GameOverMenu : UIView
    {
        private UIButton _restartGameButton;

        internal UIButton RestartGameButton => _restartGameButton;
        internal GameOverMenu(GameObject element) : base(element)
        {
            _restartGameButton = element.GetComponentInChildren<RestartGameButton>();
        }
    }
}