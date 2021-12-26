using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class PauseMenuView : UIView
    {
        private UIButton _continueButton;
        internal UIButton ContinueButton => _continueButton;

        internal PauseMenuView(GameObject element) : base(element)
        {
            _continueButton = element.GetComponentInChildren<ContinueButton>();
        }
    }
}