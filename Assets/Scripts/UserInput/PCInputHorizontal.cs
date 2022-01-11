using System;
using TeamBlue_Asteroids;
using UnityEngine;

namespace UnityTemplateProjects.UserInput
{
    internal sealed class PCInputHorizontal : IUserInputProxy, IExecute
    {
        public event Action<float> AxisChange;
        
        public void GetAxis()
        {
            Debug.Log("InGetAxis Method");
            AxisChange?.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }

        public void Execute(float time)
        {
            GetAxis();
        }
    }
}