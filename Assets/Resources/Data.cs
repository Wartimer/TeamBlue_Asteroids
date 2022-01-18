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

        [Space][Header("Models paths")]
        [SerializeField] private string _playerModelPath;
        
        [Space] [Header("Sounds Paths")]
        [SerializeField] private string _soundsPath;

        [Space] [Header("UI path")] 
        [SerializeField] private string _uiPath;

        [Space]
        [Header("Buff path")]
        [SerializeField] private string _buffpath;


        [Space] [Header("Stage Objects Paths")] 
        [SerializeField] private string _stage01Path;
        [SerializeField] private string _background01;
        [SerializeField] private string _background02;
        [SerializeField] private string _stars01;
        [SerializeField] private string _rocket01;


        [Space] [Header("Particles Paths")] 
        [SerializeField] private string _explosionPath;

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
        
        internal GameObject BackGround01
        {
            get
            {
                var background = Resources.Load<GameObject>(Path.Combine(_dataPath, _background01));
                Instantiate(background);
                return background;
            }
        }
        
        internal GameObject BackGround02
        {
            get
            {
                var background = Resources.Load<GameObject>(Path.Combine(_dataPath, _background02));
                Instantiate(background);
                return background;
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

        internal EnemyData EnemyData => Resources.Load<EnemyData>(Path.Combine(_dataPath,_enemyDataPath));

        internal PlayerData PlayerData => Resources.Load<PlayerData>(Path.Combine(_dataPath,_playerDataPath));

        internal PlayerModel PlayerTitaniumFighter => Resources.Load<PlayerModel>(Path.Combine(_dataPath, _playerModelPath));

        internal SoundsData SoundsData => Resources.Load<SoundsData>(Path.Combine(_dataPath,_soundsPath));

        internal UIData UIData => Resources.Load<UIData>(Path.Combine(_dataPath,_uiPath));
        
        internal RouteData RouteData => Resources.Load<RouteData>(Path.Combine(_dataPath, _routeDataPath));

        internal BuffData BuffData => Resources.Load<BuffData>(Path.Combine(_dataPath, _buffpath));
    }
}