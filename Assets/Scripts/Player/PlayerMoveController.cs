
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerMoveController : IFixedExecute, ICleanup
    {
        private readonly float _speed;
        private float _horizontal;
        private readonly PlayerView _player;
        private readonly PlayerModel _playerModel; 
        private IUserInputProxy _horizontalInputProxy;
        private Vector3 _move;
        private Camera _mainCamera;
        private Rigidbody _playerRigidbody;
        private Vector3 _acceleration;
        
        public PlayerMoveController(IUserInputProxy horizontalInputProxy, PlayerView player, PlayerModel playerModel,
            Camera mainCamera)
        {
            _player = player;
            _playerModel = playerModel;
            _mainCamera = mainCamera;
            
            _speed = _playerModel.Speed;
            _playerRigidbody = _player.gameObject.GetComponent<Rigidbody>();
            
            _horizontalInputProxy = horizontalInputProxy;
            _horizontalInputProxy.AxisChange += OnHorizontalAxisChange;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value;
        }

        public void FixedExecute(float deltatime)
        {
            var speed = deltatime * _speed;
            //Debug.Log($"Speed: {speed}, Horizontal: {_horizontal}");
            _acceleration.Set(_horizontal * speed, 0.0f, 0.0f);
            _playerRigidbody.AddForce(_acceleration, ForceMode.Impulse);
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

