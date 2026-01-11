using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int damage;

    private Enemy enemyInTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerKillEnemy();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInTrigger = other.GetComponent<Enemy>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInTrigger = null;
        }
    }

    public void PlayerKillEnemy()
    {
        if (enemyInTrigger != null && Input.GetKeyDown(KeyCode.Q))
        {
            enemyInTrigger.TakeDamage(damage);
            Player playerScore = GetComponent<Player>();
        }
    }
}
