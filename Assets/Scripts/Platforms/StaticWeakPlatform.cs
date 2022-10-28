using UnityEngine;

public class StaticWeakPlatform : StaticPlatform
{
    [SerializeField]
    private Bonus[] _bonuses; 

    protected override void Start()
    {
        int rand = Random.Range(0,100);
        if (rand < 25)
        {
            Bonus b = _bonuses[Random.Range(0, _bonuses.Length)];
            Instantiate(b, transform);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb!= null)
        {
            if (Vector2.Dot(rb.velocity, Vector2.up) <= 0)
            {
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
