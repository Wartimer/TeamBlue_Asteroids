using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TeamBlue_Asteroids
{
    public class Demo : MonoBehaviour
    {

        public ProgressBar _healthBar;
        public ProgressBar _armorBar;
        

        private void Start()
        {
            _healthBar.BarValue = 100;
            _armorBar.BarValue = 100;
            
        }

        void FixedUpdate()
        {

            if (Input.GetKey(KeyCode.G))
            {
                _healthBar.BarValue += 1;
                _armorBar.BarValue += 1;
                
            }

            if (Input.GetKey(KeyCode.H))
            {
                _healthBar.BarValue -= 1;
                _armorBar.BarValue -= 1;
                
            }
        }
    }
}
