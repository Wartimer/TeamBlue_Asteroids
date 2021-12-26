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
        [SerializeField] private RouteData _routeData;
        private Controllers _controllers;
        private GameObject _mainMenu;
        private MainMenuView _mainMenuView;

        internal Controllers Controllers => _controllers;
        internal Data Data => _data;
        
        private void Start()
        {
            GameInitialized += StartGameLoop;
            _controllers = new Controllers();
            _mainMenu = Instantiate(_data.UIData.CreateUiElement(UiType.MainMenu), _data.Canvas);
            _mainMenuView = new MainMenuView(_mainMenu);
            _mainMenuView.StartGameButton.UIButtonClick += StartGame;
        }

        private void StartGame()
        {
            _mainMenuView.StartGameButton.UIButtonClick -= StartGame;
            new GameInitialization(_controllers, _data, _routeData);
            _controllers.Initialization();
            GameInitialized?.Invoke();
        }

        private void StartGameLoop()
        {
            GameInitialized -= StartGameLoop;
            _mainMenuView.Dispose();
            var gameLoop = _data.GameLoop;
        }
    }
}