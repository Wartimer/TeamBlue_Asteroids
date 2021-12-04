namespace TeamBlue_Asteroids
{
    public class BackGroundInitialization : IInitialization
    {
        private readonly BackgroundFactory _backgroundFactory;
        private StageBackgroundView _background;

        internal BackGroundInitialization(BackgroundFactory backgroundFactory)
        {
            _backgroundFactory = backgroundFactory;
            _background = backgroundFactory.CreateBackground();
        }
        
        public void Initialization()
        {
            
        }

        internal StageBackgroundView GetBackground()
        {
            return _background;
        }
    }
}