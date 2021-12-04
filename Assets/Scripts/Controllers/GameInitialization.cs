using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            // Инициализация фабрики уровней и инициализация уровня

            var backgroundFactory = new BackgroundFactory(data);
            var backGroundInitialization = new BackGroundInitialization(backgroundFactory);
            var starsFactory = new StarsFactory(data);
            var starsInitialization = new StarsInitialization(starsFactory);
            var stageFactory = new StageFactory(data);
            var stageInitialization = new StageInitialization(stageFactory);
            var enemyFactory = new EnemyFactory(data.EnemyData);
            var interactiveObjectsController = new InteractiveObjectsController();
            var spawnController = new SpawnController(enemyFactory, interactiveObjectsController);
            
            var backgroundController = new BackgroundController();
            var starsController = new StarsController(starsInitialization.GetStars());
            
            //Добавление в Инициализирующие контроллеры
            // controllers.Add(backGroundInitialization);
            // controllers.Add(starsInitialization);
            // controllers.Add(stageInitialization);
            
            //Добавление в Исполняющие контроллеры
            controllers.Add(backgroundController);
            controllers.Add(starsController);
            controllers.Add(spawnController);
            controllers.Add(interactiveObjectsController);

        }
    }
}