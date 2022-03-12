using System;

namespace TeamBlue_Asteroids
{
    internal class EnemyStats : UnitStats
    {
        public EnemyStats(UnitConfig config, InteractiveObject gameObject) : base(config, gameObject) { }

        internal override void TakeDamage(int damage)
        {
            if (_health > 0)
                _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                GlobalEventManager.SendEnemyKilled();
               _gameObject.Dispose();
            }
        }
    }
}