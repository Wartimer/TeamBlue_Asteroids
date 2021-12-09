using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

namespace TeamBlue_Asteroids
{
    internal sealed class PlayerView : MonoBehaviour
    {
        private Vector3 fwd;
              
        internal bool EnemyInSight()
        {
            fwd = transform.TransformDirection(Vector3.forward);
            var hit = new RaycastHit();
            Debug.DrawRay(transform.position, fwd * 30, Color.red);

            if (Physics.Raycast(transform.position, fwd, out hit, 100))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log(hit);
                    return true;

                }
                
            }            
            return false;
        }

    }
}
