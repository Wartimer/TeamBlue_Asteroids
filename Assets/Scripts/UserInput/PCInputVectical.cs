using System;
using TeamBlue_Asteroids;
using UnityEngine;

namespace UserInput
{
    public class PCInputVectical : IUserInputProxy
    {
        public event Action<float> AxisChange;
        
        public void GetAxis()
        {
            AxisChange?.Invoke(Input.GetAxis(AxisManager.VERTICAL));
        }
    }
}