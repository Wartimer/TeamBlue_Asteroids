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
        [SerializeField] private string _background01;
        [SerializeField] private string _stars01;


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

        internal StarsView Stars01
        {
            get
            {
                var stars = Resources.Load<StarsView>("Data/" + _stars01);
                Instantiate(stars);
                return stars;
            }
        }

        internal EnemyData EnemyData => Resources.Load<EnemyData>("Data/" + _enemyDataPath);
    }
}