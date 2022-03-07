
using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerView : MonoBehaviour, IDisposable
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
            _stats = new PlayerStats(_playerConfig);
        }
        

        internal void PlaySound()
        {
            _audioSource.PlayOneShot(_shootSound);
        }
        
        public void Dispose()
        {
            PlayerDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
