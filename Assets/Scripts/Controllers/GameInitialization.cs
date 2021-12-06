using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            // Инициализация фабрики уровней и инициализация уровня
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.PlayerData);
            var playerInitialization = new PlayerInitialization(playerFactory, PlayerType.TitaniumFighter);
            
            
            var backgroundFactory = new BackgroundFactory(data);
            var backGroundInitialization = new BackGroundInitialization(backgroundFactory);
            var starsFactory = new StarsFactory(data);
            var starsInitialization = new StarsInitialization(starsFactory);
            var stageFactory = new StageFactory(data);
            var stageInitialization = new StageInitialization(stageFactory);
            var enemyFactory = new EnemyFactory(data.EnemyData);
            var missileFactory = new MissileFactory(data);
            var interactiveObjectsController = new InteractiveObjectsController();
            var spawnController = new SpawnController(enemyFactory, interactiveObjectsController);
            var missilesContainer = new MissilesContainer();
            //Добавление в Инициализирующие контроллеры
            // controllers.Add(backGroundInitialization);
            // controllers.Add(starsInitialization);
            // controllers.Add(stageInitialization);
            
            //Добавление в Исполняющие контроллеры
            controllers.Add(new BackgroundController());
            controllers.Add(spawnController);
            controllers.Add(interactiveObjectsController);
            
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new PlayerMoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(),
                data.PlayerTitaniumFighter, camera));
            controllers.Add(new MissilesMoveController(missilesContainer));
            controllers.Add(new PlayerShootController(playerInitialization.GetPlayer(), missileFactory, missilesContainer));
        }
    }
}