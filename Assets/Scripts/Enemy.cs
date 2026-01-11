using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int life;
    
    private Transform player;
    private Vector3 playerPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        playerPos = player.position;
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }
    
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Player.playerScore += 100;
        Debug.Log(Player.playerScore);
    }
}