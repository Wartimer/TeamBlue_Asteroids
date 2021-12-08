using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal enum ScanState
    {
        SCAN = 0,
        STOP = 1,
    }
    
    internal sealed class EnemyScanner
    {
        private float _firstScan = 0f;
        private float _scanRepeatRate = 0.1f;
        private bool _targetSet = false;
        private Vector3 _forward;
        internal ScanState _state = ScanState.STOP;
        

        private Transform _player;
        private Transform _currentTarget;
        
        internal Transform CurrentTarget => _currentTarget;
        internal ScanState State => _state;
        internal bool TargetSet => _targetSet;
        
        
        internal EnemyScanner(Transform player)
        {
            _player = player;
        }
        
        internal void ScanTargets(float time)
        {
            _firstScan += time;
            if (_firstScan > _scanRepeatRate)
            {
                _state = ScanState.SCAN;
                var playerTransform = _player.transform;
                _forward = playerTransform.TransformDirection(Vector3.forward);
                var hit = new RaycastHit();
                
                DrawRay(playerTransform.position, _forward);
                
                if (!Physics.Raycast(playerTransform.position, _forward, out hit, 11)) return;

                if (!hit.collider.gameObject.CompareTag("Enemy")) return;
                
                SetTarget(hit.collider.transform);
                Debug.Log(hit);
            }
        }
        
        private void SetTarget(Transform newTarget)
        {
            _state = ScanState.STOP;
            _currentTarget = newTarget;
            _targetSet = true;
        }

        private void DrawRay(Vector3 position, Vector3 dir)
        {
            Debug.DrawRay(position, dir * 11, Color.red);
        }
    }
}