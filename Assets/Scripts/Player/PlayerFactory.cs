namespace TeamBlue_Asteroids
{
    internal class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _data;

        internal PlayerFactory(PlayerData data)
        {
            _data = data;
        }
        
        public PlayerView CreatePlayer(PlayerType type)
        {
            return _data.GetPlayer(type).AddComponent<PlayerView>();
        }
    }
}