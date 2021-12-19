using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data Paths", order = 51)]
    public class Data : ScriptableObject
    {
        [Header("Data paths")]
        [SerializeField] private string _playerModelPath;
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _playerDataPath;

        [Space] [Header("Sounds Paths")]
        [SerializeField] private string _soundsPath;


        [Space] [Header("Stage Objects Paths")] 
        [SerializeField] private string _stage01Path;
        [SerializeField] private string _background01;
        [SerializeField] private string _background02;
        [SerializeField] private string _stars01;
        [SerializeField] private string _rocket01;


        [Space] [Header("Particles Paths")] 
        [SerializeField] private string _explosionPath;

        

        internal GameObject Stage01
        {
            get
            {
                var stage = Resources.Load<GameObject>("Data/" + _stage01Path);
                Instantiate(stage);
                return stage;
            }
        }
        
        internal GameObject BackGround01
        {
            get
            {
                var background = Resources.Load<GameObject>("Data/" + _background01);
                Instantiate(background);
                return background;
            }
        }
        
        internal GameObject BackGround02
        {
            get
            {
                var background = Resources.Load<GameObject>("Data/" + _background02);
                Instantiate(background);
                return background;
            }
        }
        
        internal GameObject Stars01
        {
            get
            {
                var stars = Resources.Load<GameObject>("Data/" + _stars01);
                Instantiate(stars);
                return stars;
            }
        }

        internal MissileView Rocket
        {
            get
            {
                var rocket = Resources.Load<MissileView>("Data/" + _rocket01);
                return rocket;
            }
        }

        internal GameObject Explosion
        {
            get
            {
                var explosion = Resources.Load<GameObject>("Data/" + _explosionPath);
                return explosion;
            }
        }

        internal EnemyData EnemyData => Resources.Load<EnemyData>("Data/" + _enemyDataPath);

        internal PlayerData PlayerData => Resources.Load<PlayerData>("Data/" + _playerDataPath);

        internal PlayerModel PlayerTitaniumFighter => Resources.Load<PlayerModel>("Data/" + _playerModelPath);

        internal SoundsData SoundsData => Resources.Load<SoundsData>("Data/" + _soundsPath);
    }
}