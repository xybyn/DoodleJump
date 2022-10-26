using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DynamicPlatform : Platform
{
    [SerializeField]
    private GameBorders _gameBorders = null;
    private Rigidbody2D _rb = null;
    protected override void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(1, 0);
    }

    protected override void Update()
    {
        if (_gameBorders.IntersectsLeftBorder(_rb.transform))
        {
            _rb.velocity = new Vector2(1, 0);
        }
        else if (_gameBorders.IntersectsRightBorder(_rb.transform))
        {
            _rb.velocity = new Vector2(-1, 0);
        }
    }
}
