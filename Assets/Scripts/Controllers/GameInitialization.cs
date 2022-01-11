using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data, Reference reference)
        {
            Camera camera = Camera.main;
            var interObjController = new InteractiveObjectsController();
            // Инициализация фабрики уровней и инициализация уровня
            var inputInitialization = new InputInitialization();
            var playerInitialization = new PlayerInitialization(data, PlayerType.TitaniumFighter, inputInitialization.GetInput(), camera);
            var stageInitialization = new StageInitialization(data);
            var enemySpawnSystem = new EnemySpawnSystem(data, interObjController, controllers);
            var explosionSpawnController = new ExplosionSpawnController(data, interObjController);
            var shootingSystem = new ShootingSystem(data, playerInitialization.GetPlayer().transform, new SoundFactory(data.SoundsData), controllers, inputInitialization.GetKeyInput());

            
            controllers.Add(inputInitialization.PCInputHorizontal as IExecute);
            controllers.Add(stageInitialization.BackgroundController);
            controllers.Add(playerInitialization.PlayerMoveController);
            controllers.Add(playerInitialization.PlayerAnimationController);
            
            reference.SetPlayer(playerInitialization.GetPlayer().GetComponent<PlayerView>());
            reference.SetKeyInput(inputInitialization.GetKeyInput());
        }
    }
}