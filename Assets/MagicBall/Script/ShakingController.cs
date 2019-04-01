using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShakingController : MonoBehaviour {

    public Action OnShaked; 
    float lowPassKernelWidthInSeconds  = 1.0f;
    float shakeDetectionThreshold = 2.0f;
 
    private float lowPassFilterFactor  = 1/60;
    private  Vector3 lowPassValue  = Vector3.zero;
    private Vector3 acceleration;
    private Vector3 deltaAcceleration ;
 
 
    void Start()
    {
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    public void Temp()
    {
        if (OnShaked != null)
            OnShaked();
    }

    void Update()
    {
        acceleration = Input.acceleration;
            lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
            deltaAcceleration = acceleration - lowPassValue;

        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            if (OnShaked != null)
                OnShaked();
        }
    }

}
