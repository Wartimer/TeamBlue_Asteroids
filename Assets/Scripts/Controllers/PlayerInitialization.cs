using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class PlayerInitialization : IInitialization
    {
        private readonly PlayerFactory _playerFactory;
        private PlayerView _player;

        internal PlayerInitialization(PlayerFactory playerFactory, PlayerType type)
        {
            _playerFactory = playerFactory;
            _player = playerFactory.CreatePlayer(type).GetComponent<PlayerView>();
        }
        
        public void Initialization()
        {
            
        }

        internal PlayerView GetPlayer()
        {
            return _player;
        }
    }
}