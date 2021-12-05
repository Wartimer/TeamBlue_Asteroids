namespace TeamBlue_Asteroids
{
    internal interface IPlayerFactory
    {
        PlayerView CreatePlayer(PlayerType type);
    }
}