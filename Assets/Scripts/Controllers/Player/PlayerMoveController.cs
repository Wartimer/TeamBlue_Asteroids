
using System;
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
        private Camera _mainCamera;
        private Rigidbody _playerRigidbody;
        private Vector3 _acceleration;
        
        public PlayerMoveController(PlayerView player, IUserInputProxy horizontalInput, IUserInputProxy verticalInput,
            Camera mainCamera)
        {
            _player = player;
            _horizontalInput = horizontalInput;
            _verticalInput = verticalInput;
            _mainCamera = mainCamera;
            _speed = _player.PlayerStats.Speed;
            _playerRigidbody = _player.gameObject.GetComponent<Rigidbody>();
            
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
            var speed = deltaTime * _speed;
            _acceleration.Set(_horizontal * speed, _vertical * speed, 0.0f);
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
            _player.PlayerDestroyed -= Cleanup;
            _horizontalInput.AxisChange -= OnHorizontalAxisChange;
            _verticalInput.AxisChange -= OnVerticalAxisChange;
            PlayerRemoved?.Invoke(this);
        }

    }
}

