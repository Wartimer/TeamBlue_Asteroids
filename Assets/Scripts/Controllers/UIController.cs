
using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    public sealed class UIController : IDisposable
    {
        private readonly Data _data;
        private readonly UIFactory _uiFactory;
        private MainMenuView _mainMenu;
        private SettingsMenuView _settingsMenu;
        private PauseMenuView _pauseMenu;
        private GameOverMenu _gameOverMenu;
        private GameInterfaceView _gameInterface;
        private DisplayWonGameView _displayWonGame;


        private UIButton _startGameButton;
        private UIButton _settingsButton;
        private UIButton _settingsBackButton;
        private UIButton _continueButton;
        private UIButton _restartButton;
        private UIButton _restartGameButton;
        private ScoreText _scoreText;
        

        //public delegate void DisplayWonGame();
        //public static DisplayWonGame displayWonGame;


    
        internal PauseMenuView PauseMenu => _pauseMenu;
        internal UIButton StartGameButton => _startGameButton;
        internal UIButton RestartButton => _restartButton;

        internal GameInterfaceView GameInterfaceView => _gameInterface;

        
        internal UIController(Data data)
        {
            _data = data;
            _uiFactory = new UIFactory(_data);
            _mainMenu = new MainMenuView(_uiFactory.CreateUiElement(UiType.MainMenu));
            _settingsMenu = new SettingsMenuView(_uiFactory.CreateUiElement(UiType.SettingsMenu));
            _pauseMenu = new PauseMenuView(_uiFactory.CreateUiElement(UiType.PauseMenu));
            _gameOverMenu = new GameOverMenu(_uiFactory.CreateUiElement(UiType.GameOverDisplay));
            _gameInterface = new GameInterfaceView(_uiFactory.CreateUiElement(UiType.GameInterface));
            _displayWonGame = new DisplayWonGameView(_uiFactory.CreateUiElement(UiType.DisplayWonGame));
            
            _restartGameButton = _displayWonGame.RestarGameButton;
            _startGameButton = _mainMenu.StartGameButton;
            _settingsButton = _mainMenu.SettingsButton;
            _settingsBackButton = _settingsMenu.SettingsBackButton;
            _continueButton = _pauseMenu.ContinueButton;
            _restartButton = _gameOverMenu.RestartButton;
            
            
            _settingsButton.UIButtonClick += ShowSettings;
            _settingsBackButton.UIButtonClick += HideSettings;
            _continueButton.UIButtonClick += HidePauseMenu;
            _gameInterface.ScoreText.DisplayWonGame += ShowDisplayWonGame;
        }

        internal void ShowMainMenu()
        {
            _mainMenu.Show();
        }

        internal void HideMainMenu()
        {
            _mainMenu.Hide();
        }

        internal void ShowSettings()
        {
            _settingsMenu.Show();
        }

        internal void HideSettings()
        {
            _settingsMenu.Hide();
        }

        internal void ShowPauseMenu()
        {
            _pauseMenu.Show();
        }

        internal void HidePauseMenu()
        {
            _pauseMenu.Hide();
        }

        internal void ShowGameOver()
        {
            _gameOverMenu.Show();
        }

        internal void HideGameOver()
        {
            _gameOverMenu.Hide();
        }
        internal void ShowGameInterface()
        {
            _gameInterface.Show();

        }

        internal void HideGameInterface()
        {
            _gameInterface.Hide();
        }

        internal void ShowDisplayWonGame()
        {           
            _displayWonGame.Show();
        }
        internal void HideDisplayWonGane()
        {
            _displayWonGame.Hide();
        }

        public void Dispose()
        {
            _settingsButton.UIButtonClick -= ShowSettings;
            _settingsBackButton.UIButtonClick -= HideSettings;
            _continueButton.UIButtonClick -= HidePauseMenu;
            _gameInterface.ScoreText.DisplayWonGame -= ShowDisplayWonGame;
        }

        internal void HideAllMenus()
        {
            HideMainMenu();
            HideSettings();
            HidePauseMenu();
            HideGameOver();
            HideGameInterface();
            HideDisplayWonGane();
        }
    }
}