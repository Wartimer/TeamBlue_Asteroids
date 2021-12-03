using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data Paths", order = 51)]
    public class Data : ScriptableObject
    {
        [Header("Model paths")]
        [SerializeField] private string _playerModelPath;
        [SerializeField] private string _enemyDataPath;

        
        [Space] [Header("Objects Paths")] 
        [SerializeField] private string _stage01Path;
        [SerializeField] private string _smallAsteroidPrefPath;
        [SerializeField] private string _mediunmAsteroidPrefPath;
        [SerializeField] private string _bigAsteroidPrefPath;
        [SerializeField] private string _rocketPrefPath;

        internal GameObject Stage01
        {
            get
            {
                var stage = Resources.Load<GameObject>("Data/" + _stage01Path);
                Instantiate(stage);
                return stage;
            }
        }

        internal EnemyData EnemyData => Resources.Load<EnemyData>("Data/" + _enemyDataPath);
    }
}