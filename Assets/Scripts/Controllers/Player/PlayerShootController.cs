using System;

namespace TeamBlue_Asteroids
{
  
    internal class PlayerShootController : IExecute, ICleanup, IRemoveFromControllers
    {
        public event Action<IController> PlayerRemoved;
        
        private Shooter _shooter;
        private PlayerView _player;
        private IUserKeyInput _keyInput;
        
        internal PlayerShootController(PlayerView player, Shooter shooter, IUserKeyInput keyInput)
        {
            _shooter = shooter;
            _player = player;
            _keyInput = keyInput;
            _player.PlayerDestroyed += Cleanup;
        }
        
        public void Execute(float deltaTime)
        {
            if(_keyInput.GetKey() == "FIRE")
                _shooter.Shoot(deltaTime);
        }

        public void Cleanup()
        {
            _player.PlayerDestroyed -= Cleanup;
            PlayerRemoved?.Invoke(this);
        }
    }
}
