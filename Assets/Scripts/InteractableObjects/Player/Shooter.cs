
namespace TeamBlue_Asteroids
{
    internal sealed class Shooter
    {
        private float _firstShot = 0f;
        private float _repeatRate = 0.3f;

        private RocketPool _rocketPool;
        private MissilesContainer _movingMissiles;

        private PlayerView _player;
        private SoundFactory _soundFactory;

        internal Shooter(PlayerView player, MissilesContainer movingMissiles, RocketPool rocketPool, SoundFactory soundFactory)
        {
            _player = player;
            _movingMissiles = movingMissiles;
            _rocketPool = rocketPool;
            _soundFactory = soundFactory;
        }
        
        internal void Shoot(float time)
        {
            _firstShot += time;
            
            if (CanShoot())
            {
                _player.Sound = _soundFactory.GetSound(SoundsType.PlayerShotSound);
                _player.PlaySound();
                var obj = _rocketPool.Pop();
                obj.GetComponent<MissileView>().GetPoints();
                _movingMissiles.AddMissile(obj.GetComponent<MissileView>());
                obj.GetComponent<MissileView>().MissileDestroyed += Destroy;
                _firstShot = 0f;
            }
        }
        
        private bool CanShoot()
        {
            return
                (_firstShot > _repeatRate);

        }

        private void Destroy(MissileView missile)
        {
            missile.MissileDestroyed -= Destroy;
            _movingMissiles.RemoveMissile(missile);
            _rocketPool.Push(missile);
        }
    }
}