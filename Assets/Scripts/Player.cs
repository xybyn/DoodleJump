using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] private IInput _input = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
