using System.IO;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data Paths", order = 51)]
    public class Data : ScriptableObject
    {
        private const string _dataPath = "Data";
        
        [Header("Data paths")]
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _routeDataPath;

        [Space][Header("Player Config path")]
        [SerializeField] private string _playerConfigPath;
        
        [Space] [Header("Sounds Paths")]
        [SerializeField] private string _soundsPath;

        [Space] [Header("UI path")] 
        [SerializeField] private string _uiPath;

        [Space] [Header("Stage Objects Paths")]
        [SerializeField] private string _bgDataPath;
        [SerializeField] private string _stage01Path;
        [SerializeField] private string _stars01;

        [Space] [Header("Buffs Data path")]
        [SerializeField] private string _buffDataPath;
        
        [Space][Header("Bullets Data path")]
        [SerializeField] private string _rocket01;

        [Space] [Header("Particles Data Paths")] 
        [SerializeField] private string _explosionPath;

        [Space] [Header("Move Clamp Configs Data path")] [SerializeField]
        private string _moveClampData;
        
        [Space] [Header("GameLoop Path")] 
        [SerializeField] private string _gameLoopPath;

        private Canvas _canvas;
        internal Transform Canvas
        {
            get
            {
                var canvas = FindObjectOfType<Canvas>();
                return canvas.transform;
            }
        }
        
        
        internal GameObject GameLoop
        {
            get
            {
                var gameLoop = Resources.Load<GameObject>(Path.Combine(_dataPath,_gameLoopPath));
                Instantiate(gameLoop);
                return gameLoop;
            }
        }
        
        internal GameObject Stage01
        {
            get
            {
                var stage = Resources.Load<GameObject>(Path.Combine(_dataPath, _stage01Path));
                Instantiate(stage);
                return stage;
            }
        }

        internal GameObject Stars01
        {
            get
            {
                var stars = Resources.Load<GameObject>(Path.Combine(_dataPath,_stars01));
                Instantiate(stars);
                return stars;
            }
        }

        internal MissileView Rocket
        {
            get
            {
                var rocket = Resources.Load<MissileView>(Path.Combine(_dataPath, _rocket01));
                return rocket;
            }
        }

        internal GameObject Explosion
        {
            get
            {
                var explosion = Resources.Load<GameObject>(Path.Combine(_dataPath,_explosionPath));
                return explosion;
            }
        }

        //Data
        
        internal EnemyData EnemyData => Resources.Load<EnemyData>(Path.Combine(_dataPath,_enemyDataPath));

        internal PlayerData PlayerData => Resources.Load<PlayerData>(Path.Combine(_dataPath,_playerDataPath));
        
        internal SoundsData SoundsData => Resources.Load<SoundsData>(Path.Combine(_dataPath,_soundsPath));

        internal UIData UIData => Resources.Load<UIData>(Path.Combine(_dataPath,_uiPath));
        
        internal BackgroundData BgData => Resources.Load<BackgroundData>(Path.Combine(_dataPath,_bgDataPath));
        
        internal RouteData RouteData => Resources.Load<RouteData>(Path.Combine(_dataPath, _routeDataPath));

        
        //Configurations
        internal UnitConfig UnitTitaniumFighter => Resources.Load<UnitConfig>(Path.Combine(_dataPath, _playerConfigPath));

        internal BuffData BuffData => Resources.Load<BuffData>(Path.Combine(_dataPath, _buffDataPath));

        internal MoveClampConfigsData MoveClampConfigs =>
            Resources.Load<MoveClampConfigsData>(Path.Combine(_dataPath, _moveClampData));
    }
}