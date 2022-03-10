using System.Threading;
using System.Threading.Tasks;

namespace TeamBlue_Asteroids
{
    public abstract class UnitStats
    {
        protected readonly float _speed;
        protected int _health;
        protected int _armour;
        protected int _collisionDamage;

        internal float Speed => _speed;
        internal int Health => _health;
        internal int Armour => _armour;
        internal int CollisionDamage => _collisionDamage;
        
        
        internal UnitStats(UnitConfig config)
        {
            _speed = config.Speed;
            _health = config.HitPoints;
            _armour = config.Armour;
            _collisionDamage = config.CollisionDamage;
        }

        internal abstract void TakeDamage(int damage);
    }
}