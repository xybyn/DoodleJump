using UnityEngine;

public class SpringBonusEffect : BonusEffect
{
    private float _force = 1000.0f;
    private Rigidbody2D _rb = null;
    protected override void EndEffect()
    {
    }

    protected override void StartEffect()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.up * _force);
    }

    protected override void UpdateEffect()
    {
        
    }
}
