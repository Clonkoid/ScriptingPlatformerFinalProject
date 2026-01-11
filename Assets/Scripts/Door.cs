using UnityEngine;

public class Door : MonoBehaviour
{
    PlayerCollision key;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hasKey()
    {
        PlayerCollision Key =  GetComponentInChildren<PlayerCollision>();
        if (Key != null)
        {
            Destroy(gameObject);
        }
    }
}
