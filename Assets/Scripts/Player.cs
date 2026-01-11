using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private float hInput;
    private float vInput;

    [SerializeField] public int life;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float movementVelocity;
    
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI healthText;
    
    public static int playerScore = 0;
    
    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        Movement();
        if (hInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        
        else if (hInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        scoreText.text = "Score: " + playerScore;
        healthText.text = "Health: " + life;
        
        WinCondition();
    }
    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));

    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void PlayerHeal(int healAmount)
    {
        life += healAmount;
    }
    
    public void WinCondition()
    {
        if (Player.playerScore >= 1500)
        {
            SceneManager.LoadScene("Win");
            playerScore = 0;
        }
    }

    private void Movement()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        
        Vector2 movement = new Vector2(hInput, 0f).normalized;
        
        transform.Translate(movement * movementVelocity * Time.deltaTime, Space.World);
        
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }

        if (hInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else 
        {
            animator.SetBool("isRunning", false);
        }
    }
}
