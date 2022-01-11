using UnityEngine;

namespace TeamBlue_Asteroids
{
    public class GameOverMenu : UIView
    {
        private UIButton _restartButton;

        internal UIButton RestartButton => _restartButton;
        internal GameOverMenu(GameObject element) : base(element)
        {
            _restartButton = element.GetComponentInChildren<RestartGameButton>();
        }
    }
}