using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface IMissileFactory
    {
        MissileView CreateMissile();
    }
}