namespace TeamBlue_Asteroids
{
    internal interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}