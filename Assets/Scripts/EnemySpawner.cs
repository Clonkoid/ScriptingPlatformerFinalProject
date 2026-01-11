using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyBat;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-34, 34), Random.Range(-3, 10));
            Instantiate(enemyBat, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
        
    }
}
