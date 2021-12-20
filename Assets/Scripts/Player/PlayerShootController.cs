using System;

namespace TeamBlue_Asteroids
{
  
    internal class PlayerShootController : IExecute, ICleanup, IRemoveFromControllers
    {
        public event Action<IController> PlayerRemoved;
        
        private Shooter _shooter;
        private EnemyScanner _enemyScanner;
        private PlayerView _player;
        
        internal PlayerShootController(PlayerView player, Shooter shooter, EnemyScanner enemyScanner)
        {
            _shooter = shooter;
            _enemyScanner = enemyScanner;
            _player = player;
            _player.PlayerDestroyed += Cleanup;
        }
        
        public void Execute(float time)
        {
            _shooter.Shoot(time);           
            _enemyScanner.ScanTargets(time);
        }

        public void Cleanup()
        {
            _player.PlayerDestroyed -= Cleanup;
            PlayerRemoved?.Invoke(this);
        }
    }
}
