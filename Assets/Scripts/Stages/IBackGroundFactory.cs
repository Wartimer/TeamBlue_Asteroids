using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface IBackGroundFactory
    {
        BackgroundView CreateBackground(BgType type);
    }
}