using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlatform : Platform
{
    [SerializeField]
    private GameBorders _gameBorders = null;
    private Vector3 _velocity = Vector3.right;
    protected override void Start()
    {

    }

    protected override void Update()
    {
        if (_gameBorders.IntersectsLeftBorder(transform))
        {
            _velocity = new Vector3(1, 0, 0);
        }
        else if (_gameBorders.IntersectsRightBorder(transform))
        {
            _velocity = new Vector3(-1, 0, 0);
        }
        transform.Translate(_velocity*Time.deltaTime);
    }
}
