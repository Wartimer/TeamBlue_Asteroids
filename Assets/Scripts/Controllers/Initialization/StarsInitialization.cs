namespace TeamBlue_Asteroids
{
    public class StarsInitialization : IInitialization
    {
        private readonly StarsFactory _starsFactory;
        private StarsView _stars;

        internal StarsInitialization(StarsFactory starsFactory)
        {
            _starsFactory = starsFactory;
            _stars = starsFactory.CreateStars();
        }
        
        public void Initialization()
        {
            
        }

        internal StarsView GetStars()
        {
            return _stars;
        }
    }
}