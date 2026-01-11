using System;
using System.Collections;
using System.Xml.Linq;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int healAmount = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.PlayerHeal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
