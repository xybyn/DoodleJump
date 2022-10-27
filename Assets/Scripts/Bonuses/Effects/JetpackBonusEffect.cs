using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackBonusEffect : BonusEffect
{
    private float _jetpackForce = 10.0f;
    private Rigidbody2D _rb = null;
    protected override void EndEffect()
    {
    }

    protected override void StartEffect()
    {
        _duration = 5.0f;
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void UpdateEffect()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jetpackForce);
    }
}
