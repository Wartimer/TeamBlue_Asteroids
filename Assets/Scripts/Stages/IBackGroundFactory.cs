using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface IBackGroundFactory
    {
        GameObject CreateBackground(BgType type);
    }
}