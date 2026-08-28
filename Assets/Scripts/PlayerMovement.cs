using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Player Input
    private PlayerInput playerInput;
    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
    #endregion

    private Rigidbody2D rb;
    private Animator ac;

    private Vector2 movement;
    private bool isMoving;
    public Vector3 lastMove;

    public float speed = 1;
    public GameObject projectile;


    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ac = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed);

        if (movement.x != 0 || movement.y != 0)
        {
            isMoving = true;
            lastMove = movement;
        }
        else
            isMoving = false;

    }

    private void Update()
    {
        movement = playerInput.Player.Move.ReadValue<Vector2>();
        if (playerInput.Player.Fire.triggered)
        {
            Vector2 direction = (transform.position + lastMove) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x);
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
            Instantiate(projectile, transform.position + lastMove, rotation);
        }

        AnimUpdate();
    }

    void AnimUpdate()
    {
        ac.SetFloat("moveX", lastMove.x);
        ac.SetFloat("moveY", lastMove.y);
        ac.SetBool("isMoving", isMoving);
    }
}
