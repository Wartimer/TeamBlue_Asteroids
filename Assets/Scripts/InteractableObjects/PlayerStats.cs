using System.Threading.Tasks;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerStats : UnitStats
    {
        
        public PlayerStats(UnitConfig config) : base(config) { }
        internal override async void TakeDamage(int damage)
        {
            var result = await Task.Run(() =>
            {
                if (_armour > 0)
                {
                    if(_armour - damage >= 0)
                        _armour -= damage;
                }
                else if (_armour - damage < 0)
                {
                    var negativeDiff = -(_armour - damage);
                    _armour = 0;
                    _health -= negativeDiff;
                }
                else if (_armour == 0)
                {
                    if (_health > 0)
                        _health -= damage;
                    if (_health < 0)
                    {
                        _health = 0;
                    }
                }
                return _health;
            });
        }

    }
}