using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class Shooter
    {
        private float _firstShot = 0f;
        private float _repeatRate = 0.3f;

        private RocketPool _rocketPool;
        private MissilesContainer _movingMissiles;

        private PlayerView _player;
        private EnemyScanner _enemyScanner;
        private SoundFactory _soundFactory;

        internal Shooter(PlayerView player, MissilesContainer movingMissiles, EnemyScanner enemyScanner, RocketPool rocketPool)
        {
            _player = player;
            _movingMissiles = movingMissiles;
            _enemyScanner = enemyScanner;
            _rocketPool = rocketPool;
        }
        
        
        internal void Shoot(float time)
        {
            _firstShot += time;
            
            if (CanShoot())
            {
                var obj = _rocketPool.Pop();
                obj.GetComponent<MissileView>().Target = _enemyScanner.CurrentTarget;
                _movingMissiles.AddMissile(obj.GetComponent<MissileView>());
                obj.GetComponent<MissileView>().MissileDestroyed += Destroy;
                _firstShot = 0f;
                
            }   
            
        }
        
        private bool CanShoot()
        {
            return _enemyScanner.State == ScanState.STOP 
                    && (_firstShot > _repeatRate) 
                    && _enemyScanner.TargetSet;

        }

        internal void Destroy(MissileView missile)
        {
            missile.MissileDestroyed -= Destroy;
            missile.Target = null;
            _rocketPool.Push(missile);
            _movingMissiles.RemoveMissile(missile);
        }
    }
}