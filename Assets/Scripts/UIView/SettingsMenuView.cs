using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class SettingsMenuView : UIView
    {
        private UIButton _settingsBackButton;

        internal UIButton SettingsBackButton => _settingsBackButton;
        internal SettingsMenuView(GameObject element) : base(element)
        {
            _settingsBackButton = element.GetComponentInChildren<SettingsBackButton>(); 
        }
    }
}