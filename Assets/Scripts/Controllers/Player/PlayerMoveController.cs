
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerMoveController : IFixedExecute, ICleanup, IRemoveFromControllers
    {
        public event Action<IController> PlayerRemoved;
        
        
        private readonly float _speed;
        private float _horizontal;
        private float _vertical;
        private readonly PlayerView _player;
        private IUserInputProxy _horizontalInput;
        private IUserInputProxy _verticalInput;
        private Rigidbody _playerRigidbody;
        private Vector3 _acceleration;
        private Vector2 _screenBounds;
        private bool _canMove = true;
        private Camera _mainCamera;
        private float _clampX;
        private float _clampY;
        public PlayerMoveController(PlayerView player, IUserInputProxy horizontalInput, IUserInputProxy verticalInput,
            Camera mainCamera, MoveClampConfig moveClampConfig)
        {
            _player = player;
            _horizontalInput = horizontalInput;
            _verticalInput = verticalInput;
            _speed = _player.PlayerStats.Speed;
            _playerRigidbody = _player.gameObject.GetComponent<Rigidbody>();
            _mainCamera = mainCamera;
            _clampX = moveClampConfig.X;
            _clampY = moveClampConfig.Y;
            _horizontalInput.AxisChange += OnHorizontalAxisChange;
            _verticalInput.AxisChange += OnVerticalAxisChange;
            _player.PlayerDestroyed += Cleanup;
        }

        private void OnVerticalAxisChange(float value)
        {
            _vertical = value;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value;
        }

        public void FixedExecute(float deltaTime)
        {
            CheckingBoundaries();
            
            var speed = deltaTime * _speed;
            _acceleration.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _playerRigidbody.AddForce(_acceleration, ForceMode.Impulse);
            
            if (_player.PlayerStats.Health <= 0)
            {
                _player.Dispose();
            }
        }
        
        private void CheckingBoundaries()
        {
            var playerPos = _player.transform.position;
            playerPos = new Vector3(Mathf.Clamp(playerPos.x, -_clampX, _clampX),
                Mathf.Clamp(playerPos.y, -_clampY, _clampY), playerPos.z);
            _player.transform.position = playerPos;
        }
        
        public void Cleanup()
        {
            _player.PlayerDestroyed -= Cleanup;
            _horizontalInput.AxisChange -= OnHorizontalAxisChange;
            _verticalInput.AxisChange -= OnVerticalAxisChange;
            PlayerRemoved?.Invoke(this);
        }

    }
}

