
namespace TeamBlue_Asteroids
{
    internal sealed class EnemySpawnSystem : IInitialization
    {
        private readonly Data _data;
        private EnemyFactory _enemyFactory;
        private InteractiveObjectsController _intObjController;
        private Controllers _controllers;
        private SpawnController _spawnController;
        
        internal EnemySpawnSystem(Data data, InteractiveObjectsController interObjController,  Controllers controllers)
        {
            _data = data;
            _intObjController = interObjController;
            _controllers = controllers;
            _enemyFactory = new EnemyFactory(_data.EnemyData);
            _spawnController = new SpawnController(_enemyFactory, _intObjController);
            _controllers.Add(_spawnController);
            _controllers.Add(_intObjController);
        }

        public void Initialization()
        {
        }
    }
}