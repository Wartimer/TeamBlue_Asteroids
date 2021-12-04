namespace TeamBlue_Asteroids
{
    internal class BackgroundFactory : IBackGroundFactory
    {
        private readonly Data _data;

        internal BackgroundFactory(Data data)
        {
            _data = data;
        }
        
        public StageBackgroundView CreateBackground()
        {
            return _data.BackGround01.AddComponent<StageBackgroundView>();
        }
    }
}