using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ac;

    public float speed = 1.0f;
    public float followRange = 4f;
    public LayerMask playerLayer;
    private GameObject playerToChase;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ac = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        RaycastHit2D playerCheck = Physics2D.CircleCast(transform.position, followRange, Vector2.right, 0f, playerLayer);

        if (playerCheck.collider != null)
        {
            playerToChase = playerCheck.collider.gameObject;
        }
        else
            playerToChase = null;

        if (playerToChase == null)
            return;
        else
        {
            Vector3 moveDirection = playerToChase.transform.position - transform.position;
            if (Vector3.Distance(playerToChase.transform.position, transform.position) > 1.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerToChase.transform.position, speed * Time.deltaTime);
                ac.SetFloat("moveX", moveDirection.x);
                ac.SetFloat("moveY", moveDirection.y);
            }

        }
    }
}
