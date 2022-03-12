using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerStats : UnitStats
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        public event Action PlayerDead;
        public PlayerStats(UnitConfig config, InteractiveObject gameObject) : base(config, gameObject) { }
        internal override async void TakeDamage(int damage)
        {
            var result = await Task.Run(() =>
            {
                var currentHealth = _health;
                var currentArmour = _armour;

                if (currentArmour - damage > 0)
                {
                    currentArmour -= damage;
                }
                if (currentArmour - damage < 0)
                {
                    var negativeDiff = -(_armour - damage);
                    currentArmour = 0;
                    currentHealth -= negativeDiff;
                }
                if (currentArmour == 0 && currentHealth > 0)
                {
                    currentHealth -= damage;
                }
                if (currentArmour == 0 && currentHealth <= 0)
                {
                    currentHealth = 0;
                }
                
                Debug.Log($"Armour: {currentArmour}, Health{currentHealth}");
                return (currentHealth, currentArmour);
            });

            _health = result.currentHealth;
            _armour = result.currentArmour;
        }
    }
}