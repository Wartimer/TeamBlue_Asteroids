namespace TeamBlue_Asteroids
{
    public class Reference
    {
        private PlayerView _player;
        private IUserKeyInput _pcKeyInput;

        internal PlayerView PlayerView => _player;
        internal IUserKeyInput PCKeyIput => _pcKeyInput;

        internal void SetPlayer(PlayerView player)
        {
            _player = player;
        }

        internal void SetKeyInput(IUserKeyInput pcKeyInput)
        {
            _pcKeyInput = pcKeyInput;
        }
    }
}