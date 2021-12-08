namespace TeamBlue_Asteroids
{
    internal class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyData _enemyData;

        public EnemyFactory(EnemyData data)
        {
            _enemyData = data;
        }
        
        public EnemyView CreateEnemy(EnemyType type)
        {
            return _enemyData.GetEnemy(type);
        }
    }
}