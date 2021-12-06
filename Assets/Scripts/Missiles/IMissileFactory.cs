using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface IMissileFactory
    {
        MissileView CreateMissile(Vector3 position, Vector3 lookDirection);
    }
}