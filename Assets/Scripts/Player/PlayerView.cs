
using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerView : MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioClip _shootSound;

        internal AudioClip Sound
        {
            set => _shootSound = value;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }


        internal void PlaySound()
        {
            _audioSource.PlayOneShot(_shootSound);
        }
    }
}
