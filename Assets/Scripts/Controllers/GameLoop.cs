using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameLoop : MonoBehaviour, IDisposable
    {
        private Controllers _controllers;

        private Data _data;
        private GameStarter _gameStarter;
        private PauseMenuView _pauseMenu;
        private UIFactory _uiFactory;

        private bool _gamePaused;
        
        private void Awake()
        {
            _gamePaused = false;
            _gameStarter = FindObjectOfType<GameStarter>();
            _data = _gameStarter.Data;
            _controllers = _gameStarter.Controllers;
            _uiFactory = new UIFactory(_data.UIData, _data);
        }

        private void Start()
        {
            _pauseMenu = new PauseMenuView(_uiFactory.CreateUiElement(UiType.PauseMenu));
            _pauseMenu.ContinueButton.UIButtonClick += OnContinueButtonClick;
            _pauseMenu.Hide();
        }

        private void Update()
        {
            if (_gamePaused) return;
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            if (_gamePaused) return;
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void FixedUpdate()
        {
            
            var deltaTime = Time.deltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        // private void OnKeyPressed(KeyCode key)
        // {
        //     switch (key)
        //     {
        //         case KeyCode.P:
        //             ShowUiElement(_pauseMenu);
        //             _gamePaused = true;
        //             break;
        //     }
        // }
        //
        //
        // private void ShowUiElement(IUIView view)
        // {
        //     view.Show();
        // }
        //
        // private void HideUIElement(IUIView view)
        // {
        //     view.Hide();
        // }
        
        

        private void OnContinueButtonClick()
        {
            _gamePaused = false;
            _pauseMenu.Hide();
        }

        public void Dispose()
        {
            _pauseMenu.ContinueButton.UIButtonClick -= OnContinueButtonClick;
        }
    }
}