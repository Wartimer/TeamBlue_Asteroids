using System;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TeamBlue_Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        public event Action GameInitialized;
        
        [SerializeField] private Data _data;
        private UIController _uiController;
        private Controllers _controllers;
        private Reference _reference;

        internal Data Data => _data;
        internal Controllers Controllers => _controllers;
        internal UIController UIController => _uiController;
        internal Reference Reference => _reference;
        
        private void Start()
        {
            GameInitialized += StartGameLoop;
            _controllers = new Controllers();
            _uiController = new UIController(_data);
            _uiController.StartGameButton.UIButtonClick += StartGame;
            _uiController.HideAllMenus();
            _uiController.ShowMainMenu();
        }

        private void StartGame()
        {
            _uiController.StartGameButton.UIButtonClick -= StartGame;
            _reference = new Reference();
            new GameInitialization(_controllers, _data, _reference);
            _controllers.Initialization();
            GameInitialized?.Invoke();
        }

        private void StartGameLoop()
        {
            GameInitialized -= StartGameLoop;
            _uiController.HideMainMenu();
            var gameLoop = _data.GameLoop;
        }
    }
}