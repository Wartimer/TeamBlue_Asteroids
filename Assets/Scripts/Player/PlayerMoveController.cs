
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerMoveController : IExecute, ICleanup
    {
        private readonly float _speed;
        private float _horizontal;
        private readonly PlayerView _player;
        private readonly PlayerModel _playerModel; 
        private IUserInputProxy _horizontalInputProxy;
        private Vector3 _move;
        private Camera _mainCamera;

        public PlayerMoveController(IUserInputProxy horizontalInputProxy, PlayerView player, PlayerModel playerModel,
            Camera mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _playerModel = playerModel;
            _speed = _playerModel.Speed;
            _horizontalInputProxy = horizontalInputProxy;
            _horizontalInputProxy.AxisChange += OnHorizontalAxisChange;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltatime)
        {
            var speed = deltatime * _speed;
            _move.Set(_horizontal * speed, 0.0f, 0.0f);
            _player.transform.position += _move;
        }

        public void FixedExecute(float deltaTime)
        {
            
        }

        // private void PlayerMovementRestriction()
        // {
        //     if (_player.transform.position.x < _mainCamera.rect.xMin)
        //     {
        //         transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        //     }
        //     if (transform.position.x > xRange)
        //     {
        //         transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        //     }
        // }
        
        public void Cleanup()
        {
            _horizontalInputProxy.AxisChange -= OnHorizontalAxisChange;
        }
    }
}

