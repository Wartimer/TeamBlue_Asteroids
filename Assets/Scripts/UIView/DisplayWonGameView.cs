
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class DisplayWonGameView : UIView
    {
        private UIButton _restarGameButton;

        internal UIButton RestarGameButton => _restarGameButton;

        internal DisplayWonGameView(GameObject element) : base(element)
        {
            _restarGameButton = element.GetComponentInChildren<RestartGameButton>();
        }

    }
}
