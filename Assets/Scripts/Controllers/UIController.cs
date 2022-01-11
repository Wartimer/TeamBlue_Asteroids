
using System;

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

        private UIButton _startGameButton;
        private UIButton _settingsButton;
        private UIButton _settingsBackButton;
        private UIButton _continueButton;
        private UIButton _restartButton;

        internal PauseMenuView PauseMenu => _pauseMenu;
        internal UIButton StartGameButton => _startGameButton;
        internal UIButton RestartButton => _restartButton;
        
        internal UIController(Data data)
        {
            _data = data;
            _uiFactory = new UIFactory(_data);
            _mainMenu = new MainMenuView(_uiFactory.CreateUiElement(UiType.MainMenu));
            _settingsMenu = new SettingsMenuView(_uiFactory.CreateUiElement(UiType.SettingsMenu));
            _pauseMenu = new PauseMenuView(_uiFactory.CreateUiElement(UiType.PauseMenu));
            _gameOverMenu = new GameOverMenu(_uiFactory.CreateUiElement(UiType.GameOverDisplay));
            _startGameButton = _mainMenu.StartGameButton;
            _settingsButton = _mainMenu.SettingsButton;
            _settingsBackButton = _settingsMenu.SettingsBackButton;
            _continueButton = _pauseMenu.ContinueButton;
            _restartButton = _gameOverMenu.RestartButton;
            
            _settingsButton.UIButtonClick += ShowSettings;
            _settingsBackButton.UIButtonClick += HideSettings;
            _continueButton.UIButtonClick += HidePauseMenu;
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

        public void Dispose()
        {
            _settingsButton.UIButtonClick -= ShowSettings;
            _settingsBackButton.UIButtonClick -= HideSettings;
            _continueButton.UIButtonClick -= HidePauseMenu;
        }

        internal void HideAllMenus()
        {
            HideMainMenu();
            HideSettings();
            HidePauseMenu();
            HideGameOver();
        }
    }
}