namespace TeamBlue_Asteroids
{
    internal class StarsFactory : IStarFactory
    {
        private readonly Data _data;

        internal StarsFactory(Data data)
        {
            _data = data;
        }
        
        public StarsView CreateStars()
        {
            var obj = _data.Stars01.AddComponent<StarsView>();
            return obj;
        }
    }
}