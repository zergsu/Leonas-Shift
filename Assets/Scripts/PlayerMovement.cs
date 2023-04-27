using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject Shadow;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D Collider;

    [Header("Player Values")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 500f;

    float xAxisInput = 0;

    Vector2 spawn;

    private bool inDialog;
    
    void Start() {
        spawn = transform.position;
        GameEventsHandler.onDialog += DialogUpdate;
    }

    private void Update() {
        xAxisInput = Input.GetAxis("Horizontal");
        if (!inDialog) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (IsGrounded()) {
                    Shadow.SetActive(false);
                    animator.SetTrigger("Jump");
                    animator.SetBool("isJumping", true);
                    Jump();
                }
            }
            Rotate();
        }

        if (IsGrounded()) {
            Shadow.SetActive(true);
        } else if (IsGrounded() == false) {
            Shadow.SetActive(false);
        }

        animator.SetFloat("velocityY", rb.velocity.y);

        if (IsGrounded() && rb.velocity.y == 0) {
            animator.SetBool("isJumping", false);
        }
    }
    void FixedUpdate() {
        if (!inDialog) {
            if (xAxisInput == 0) {
                animator.SetBool("isRunning", false);
            } else {
                animator.SetBool("isRunning", true);
            }
            rb.velocity = new Vector2(movementSpeed * xAxisInput, rb.velocity.y);
        }

        if (inDialog) {
            rb.velocity -= rb.velocity;
            animator.SetBool("isRunning", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Spikes")) {
            Respawn();
        }
		if (other.gameObject.CompareTag("Exit")) {
		}
    }


    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size, 0f, Vector2.down, 0.05f, layer);
        return raycastHit2D.collider != null;
    }

    private void Jump() {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        SoundManager.instance.PlaySound("jump");
    }

    private void Rotate() {
        Vector3 CharacterScale = transform.localScale;
        if (xAxisInput > 0)
        {
            CharacterScale.x = 1f;
        }
        else if (xAxisInput < 0)
        {
            CharacterScale.x = -1f;
        }
        transform.localScale = CharacterScale;
    }

    public void Respawn() {
        GameEventsHandler.Respawn();
        transform.position = spawn;
        SoundManager.instance.PlaySound("damage");
    }

    private void DialogUpdate(bool dialog) {
        inDialog = dialog;
	}
}
