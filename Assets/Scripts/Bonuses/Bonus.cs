using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Bonus : MonoBehaviour
{
    protected abstract void ApplyBonus(GameObject receiver);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BonusEffect>() == null)
        {
            ApplyBonus(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
