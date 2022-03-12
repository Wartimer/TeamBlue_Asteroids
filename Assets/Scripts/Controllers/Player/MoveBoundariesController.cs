using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class MoveBoundariesController: IExecute
    {
        private Transform _player;
        private Camera _mainCamera;

        internal MoveBoundariesController(Transform player, Camera mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
        } 
        
        private void CheckBoundaries()
        {
            // var newPlayerPos = _mainCamera.WorldToViewportPoint(_player.position);
            // newPlayerPos.x = Mathf.Clamp(newPlayerPos.x, .02f, .99f);
            // newPlayerPos.y = Mathf.Clamp(newPlayerPos.y, .02f, .95f);
            // _player.position = _mainCamera.ViewportToWorldPoint(newPlayerPos);
            // Debug.Log($"New Player Position: {newPlayerPos}");
        }
        
        public void Execute(float deltaTime)
        {
            CheckBoundaries();
        }
    }
}