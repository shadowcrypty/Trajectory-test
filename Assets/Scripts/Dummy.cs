using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public bool bounceAble;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Ball")
        {
            if (ProjectileReflectionEmitterUnityNative.instance.finishs[BallMovment._index+1]!=null)
            {
                BallMovment._index++;
            }
            Debug.Log("hit");

        }
        
    }
    
}
