using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class MainMenuView : UIView
    {
        private UIButton _startGameButton;
        private UIButton _quitGameButton;
        private UIButton _settingButton;

        internal UIButton StartGameButton => _startGameButton;
        internal UIButton QuitGameButton => _quitGameButton;

        internal UIButton SettingsButton => _settingButton;

        
        internal MainMenuView(GameObject element) : base(element)
        {
            _startGameButton = element.GetComponentInChildren<StartGameButton>();
            _quitGameButton = element.GetComponentInChildren<QuitGameButton>();
            _settingButton = element.GetComponentInChildren<SettingsButton>();
        }
    }
}