
using System;
using UnityEditor;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerView : InteractiveObject, IDisposable
    {
        internal event Action PlayerDestroyed;
        
        [SerializeField] private UnitConfig _playerConfig;
        private UnitStats _stats;
        private AudioSource _audioSource;
        private AudioClip _shootSound;
        
        
        internal AudioClip Sound
        {
            set => _shootSound = value;
        }
        internal UnitStats PlayerStats =>_stats;

        private void OnEnable()
        {
            PlayerInit();
        }
     
        private void PlayerInit()
        {
            _audioSource = GetComponent<AudioSource>();
            _stats = new PlayerStats(_playerConfig, this);
        }
        
        
        protected override void Interaction(){}
        protected override void OnTriggerEnter(Collider other){}

        internal void PlaySound()
        {
            _audioSource.PlayOneShot(_shootSound);
        }
        
        public override void Dispose()
        {
            PlayerDestroyed?.Invoke();

        }
    }
}
