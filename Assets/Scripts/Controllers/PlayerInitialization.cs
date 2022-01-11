using UnityEngine;
using UnityTemplateProjects.UserInput;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private readonly Data _data;
        private readonly PlayerFactory _playerFactory;
        private PlayerView _player;
        private PlayerType _playerType;
        private IUserInputProxy _inputHorizontal;
        private Camera _mainCamera;
        
        private PlayerMoveController _playerMoveController;
        private PlayerAnimationController _playerAnimationController;
        

        internal PlayerMoveController PlayerMoveController => _playerMoveController;
        internal PlayerAnimationController PlayerAnimationController => _playerAnimationController;

        internal PlayerInitialization(Data data, PlayerType type, IUserInputProxy input, Camera mainCamera)
        {
            _data = data;
            _playerType = type;
            _inputHorizontal = input;
            _mainCamera = mainCamera;
            _playerFactory = new PlayerFactory(_data.PlayerData);
            _player = _playerFactory.CreatePlayer(_playerType).GetComponent<PlayerView>();
            _playerMoveController = new PlayerMoveController(_inputHorizontal, _player, _data.PlayerTitaniumFighter, _mainCamera);
            _playerAnimationController = new PlayerAnimationController(_inputHorizontal, _player);
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