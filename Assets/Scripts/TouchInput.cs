using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour, IInput
{
    private float _rawValue = 0.0f;
    private float _value = 0.0f;
    public float GetHorizontal()
    {
        return _value;
    }

    public float GetHorizontalRaw()
    {
        return _rawValue;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount  == 1)
        {
            Touch touch = Input.GetTouch(0);
            float normalized = touch.rawPosition.x/Screen.width-0.5f;
            if (normalized > 0)
            {
                _rawValue =  1.0f;
            }
            else if(normalized < 0)
            {
                _rawValue =  -1.0f;
            }
        }
        else
        {
            _rawValue =  0.0f;
        }
        //if(Input.GetKey(KeyCode.A))
        //{
        //    _rawValue = -1.0f;
        //    t = 0.0f;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    _rawValue =  1.0f;
        //    t = 0.0f;
        //}
        //else
        //{
        //    _rawValue = 0.0f;
        //}
        //t+=Time.deltaTime * Mathf.Abs(_rawValue);
        //_value = Mathf.Lerp(_value, _rawValue, t * 10.0f);
    }
}
