using System;
using TeamBlue_Asteroids;
using UnityEngine;

namespace UnityTemplateProjects.UserInput
{
    internal sealed class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisChange;
        
        public void GetAxis()
        {
            Debug.Log("InGetAxis Method");
            AxisChange?.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }
    }
}