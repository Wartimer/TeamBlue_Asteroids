using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TeamBlue_Asteroids
{

    public class SetVolume : MonoBehaviour
    {
        public AudioMixer mixer;

        public void SetLevel(float slderValue)
        {
            mixer.SetFloat("MusicVol", Mathf.Log10(slderValue) * 20);
        }
    }
}
