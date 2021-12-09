
using UnityEngine.Audio;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface ISoundFactory
    {
      AudioClip GetAudioClip(SoundsType type);
        
    }
}
   

