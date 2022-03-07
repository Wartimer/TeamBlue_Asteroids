namespace TeamBlue_Asteroids
{
    internal class EnemyStats : UnitStats
    {
        public EnemyStats(UnitConfig config) : base(config) { }

        internal override void TakeDamage(int damage)
        {
            if (_health > 0)
                _health -= damage;
            if (_health <= 0)
                _health = 0;
        }
    }
}