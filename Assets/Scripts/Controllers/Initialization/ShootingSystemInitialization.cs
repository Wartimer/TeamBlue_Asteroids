using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class ShootingSystemInitialization
    {
        private readonly Data _data;
        private Transform _player;
        private Shooter _shooter;
        private MissilesContainer _missilesContainer;
        private MissileFactory _missileFactory;
        private RouteFactory _routeFactory;
        private SoundFactory _soundFactory;
        private RocketPool _rocketPool;
        private PlayerShootController _playerShootController;
        private MissilesMoveController _missilesMoveController;

        internal ShootingSystemInitialization(Data data, Transform player, SoundFactory soundFactory, Controllers controllers, IUserKeyInput keyInput)
        {
            _data = data;
            _player = player;
            _missilesContainer = new MissilesContainer();
            _missileFactory = new MissileFactory(data);
            _routeFactory = new RouteFactory(_player, data.RouteData);
            _soundFactory = soundFactory;
            _rocketPool = new RocketPool(_player, _missileFactory, _routeFactory, _soundFactory);
            _shooter = new Shooter(_player.GetComponent<PlayerView>(), _missilesContainer, _rocketPool, _soundFactory);
            _playerShootController = new PlayerShootController(_player.GetComponent<PlayerView>(), _shooter, keyInput);
            _missilesMoveController = new MissilesMoveController(_missilesContainer);
            
            controllers.Add(_playerShootController);
            controllers.Add(_missilesMoveController);
        }
    }
}