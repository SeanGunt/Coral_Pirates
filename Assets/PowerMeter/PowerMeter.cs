using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeter : MonoBehaviour
{
    public float increaseSpeed = 20f;
    public float decreaseSpeed = 20f;  
    private bool isDecreasing = false;
    
    public float lastValue;

    private bool stopSlider = false;

    public Slider mainSlider;

    void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });

    }

    
    void Update()
    {
        Debug.Log(stopSlider);

        StopMeter();
        
        if (stopSlider == false)
        {
            if (!isDecreasing)
            {
                MeterMoveRight();

                if (mainSlider.value >= 100)
                {
                    //mainSlider.value = 100;
                    isDecreasing = true;
                }
            }
            else
            {
                MeterMoveLeft();
                
                if (mainSlider.value <= 0)
                {
                    //mainSlider.value = 0;
                    isDecreasing = false;
                }
            }
        }

        

    }

    public void StopMeter()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            lastValue = mainSlider.value;
            stopSlider = !stopSlider;
        }
    }
    public void StopBUTTONTEST()
    {
        
        lastValue = mainSlider.value;
        stopSlider = !stopSlider;
    }

    public void ValueChangeCheck()
    {
        //Debug.Log(mainSlider.value);
    }

    void MeterMoveRight()
    {
        increaseSpeed = 20 * Time.deltaTime;
        mainSlider.value += increaseSpeed;
        
    }

    void MeterMoveLeft()
    {
        decreaseSpeed = 20 * Time.deltaTime;
        mainSlider.value -= decreaseSpeed;
    }
}
