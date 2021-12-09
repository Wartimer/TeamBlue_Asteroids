using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface IEffectFactory
    {
        GameObject CreateEffect(EffectType type);
    }
}