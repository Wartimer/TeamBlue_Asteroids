using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data, Reference reference, UIController uIController)
        {
            Camera camera = Camera.main;
            var interObjController = new InteractiveObjectsController();

            var inputInitialization = new InputInitialization(controllers);
            var playerInitialization = new PlayerInitialization(data, PlayerType.TitaniumFighter, inputInitialization.PCInputHorizontal, inputInitialization.PCInputVertical, camera);
            var stageInitialization = new StageInitialization(data);
            var enemySpawnSystem = new EnemySpawnSystem(data, interObjController, controllers);
            var explosionSpawnController = new ExplosionSpawnController(data, interObjController);
            var shootingSystem = new ShootingSystemInitialization(data, playerInitialization.GetPlayer().transform, new SoundFactory(data.SoundsData), controllers, inputInitialization.GetKeyInput());

            controllers.Add(stageInitialization.BackgroundController);
            controllers.Add(playerInitialization.PlayerMoveController);
            controllers.Add(playerInitialization.PlayerAnimationController);
            
            reference.SetPlayer(playerInitialization.GetPlayer().GetComponent<PlayerView>());
            reference.SetKeyInput(inputInitialization.GetKeyInput());
            uIController.ShowGameInterface();
            
        }
    }
}