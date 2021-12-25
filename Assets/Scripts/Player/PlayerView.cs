
using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerView : MonoBehaviour, IDisposable, IDamagable
    {
        [SerializeField] private PlayerModel _playerModel;
        internal event Action PlayerDestroyed;
        private UnitStats _stats = new UnitStats();
        
        private AudioSource _audioSource;
        private AudioClip _shootSound;
        
        internal AudioClip Sound
        {
            set => _shootSound = value;
        }

        private void OnEnable()
        {
            PlayerInit();
        }
     

        private void PlayerInit()
        {
            _audioSource = GetComponent<AudioSource>();
            _stats.Health = _playerModel.HitPoints;
            _stats.Armour = _playerModel.Armour;
        }
        
        public void TakeDamage(int damage)
        {
            if (_stats.Health > 0)
                _stats.Health -= damage;
            if (_stats.Health <= 0)
                Dispose();
        }
        
        public void Dispose()
        {
            PlayerDestroyed?.Invoke();
            Destroy(gameObject);
        }

        internal void PlaySound()
        {
            _audioSource.PlayOneShot(_shootSound);
        }
    }
}
