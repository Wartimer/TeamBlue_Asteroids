using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface IUIFactory
    {
        GameObject CreateUiElement(UiType type);
    }
}
