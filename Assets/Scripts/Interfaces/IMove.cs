namespace TeamBlue_Asteroids
{
    public interface IMove
    {
        float Speed { get;}
        void Move(float time);
    }
}