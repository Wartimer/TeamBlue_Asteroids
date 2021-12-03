using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            // Инициализация фабрики уровней и инициализация уровня

            var stageFactory = new StageFactory(data);
            var stageInitialization = new StageInitialization(stageFactory);
            var enemyFactory = new EnemyFactory(data.EnemyData);
            var interactiveObjectsController = new InteractiveObjectsController();
            var spawnController = new SpawnController(enemyFactory, interactiveObjectsController);
            
            //Добавление в Инициализирующие контроллеры
            controllers.Add(stageInitialization);
            
            //Добавление в Исполняющие контроллеры
            controllers.Add(spawnController);
            controllers.Add(interactiveObjectsController);

        }
    }
}