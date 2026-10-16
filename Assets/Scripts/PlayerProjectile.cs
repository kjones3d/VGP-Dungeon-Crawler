using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    //TODO - Collision detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage();
            Destroy(gameObject);
        }
    }
    
}
