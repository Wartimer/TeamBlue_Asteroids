using UnityEngine.Audio;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface ISoundFactory
    {
        AudioClip GetSound(SoundsType type);

    }
}
