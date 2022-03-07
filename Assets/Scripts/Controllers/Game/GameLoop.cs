using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameLoop : MonoBehaviour, IDisposable
    {
        private Controllers _controllers;

        private Data _data;
        private GameStarter _gameStarter;
        private UIController _uiController;
        private Reference _reference;

        private IUserKeyInput _keyInput;

        private bool _gamePaused;
        
        private void Awake()
        {
            _gamePaused = false;
            _gameStarter = FindObjectOfType<GameStarter>();
            _data = _gameStarter.Data;
            _controllers = _gameStarter.Controllers;
            _uiController = _gameStarter.UIController;
            _reference = _gameStarter.Reference;
            _keyInput = _reference.PCKeyIput;
        }

        private void Start()
        {
            _uiController.PauseMenu.ContinueButton.UIButtonClick += OnContinueButtonClick;
            _keyInput.KeyPressed += OnKeyPressed;
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
            if (_gamePaused) return;
            var deltaTime = Time.deltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        private void OnKeyPressed(string key)
        {
            switch (key)
            {
                case "PAUSE":
                    _uiController.PauseMenu.Show();
                    _gamePaused = true;
                    break;
            }
        }
        
        private void OnContinueButtonClick()
        {
            _uiController.PauseMenu.Hide();
            _gamePaused = false;
        }

        public void Dispose()
        {
            _uiController.PauseMenu.ContinueButton.UIButtonClick += OnContinueButtonClick;
        }
    }
}