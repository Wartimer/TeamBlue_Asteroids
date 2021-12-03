namespace TeamBlue_Asteroids
{
    public interface IDamagable
    {
        int HitPoints { get;}
        void TakeDamage(int damage);
    }
}