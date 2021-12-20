namespace TeamBlue_Asteroids
{
    internal class UnitStats
    {
        private int _health;
        private int _armour;

        internal int Health
        {
            get => _health;
            set => _health = value;
        }

        internal int Armour
        {
            get => _armour;
            set => _armour = value;
        }
    }
}