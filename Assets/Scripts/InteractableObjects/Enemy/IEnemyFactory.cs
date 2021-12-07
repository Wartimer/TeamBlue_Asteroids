namespace TeamBlue_Asteroids
{
    internal interface IEnemyFactory
    {
        EnemyView CreateEnemy(EnemyType type);
    }
}