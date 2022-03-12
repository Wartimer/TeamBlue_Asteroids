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
        private IUserInputProxy _inputVertical;
        private Camera _mainCamera;
        
        private PlayerMoveController _playerMoveController;
        private PlayerAnimationController _playerAnimationController;

        private ResolutionChecker _resolutionChecker;
        

        internal PlayerMoveController PlayerMoveController => _playerMoveController;
        internal PlayerAnimationController PlayerAnimationController => _playerAnimationController;

        internal PlayerInitialization(Data data,
                                      PlayerType type, 
                                      IUserInputProxy inputHorizontal, 
                                      IUserInputProxy inputVertical, 
                                      Camera mainCamera)
        {
            _data = data;
            _playerType = type;
            _inputHorizontal = inputHorizontal;
            _inputVertical = inputVertical;
            _mainCamera = mainCamera;
            _resolutionChecker = new ResolutionChecker();
            _playerFactory = new PlayerFactory(_data.PlayerData);
            _player = _playerFactory.CreatePlayer(_playerType).GetComponent<PlayerView>();
            _playerMoveController = new PlayerMoveController(_player, _inputHorizontal, _inputVertical, _mainCamera, GetMoveClampConfig());
            _playerAnimationController = new PlayerAnimationController(_inputHorizontal, _player);
        }
        
        public void Initialization()
        {
        }

        internal PlayerView GetPlayer()
        {
            return _player;
        }

        private MoveClampConfig GetMoveClampConfig()
        {
            var config = ScriptableObject.CreateInstance<MoveClampConfig>();
            
            switch (_resolutionChecker.GetCurrentResolution())
            {
                case (3840,2160):
                    config = _data.MoveClampConfigs.GetMoveClampConfig(ResolutionType.Res3840X2160);
                    break;
                case(1280,1024):
                    config = _data.MoveClampConfigs.GetMoveClampConfig(ResolutionType.Res1280X1024);
                    break;
            }

            return config;
        }
    }
}