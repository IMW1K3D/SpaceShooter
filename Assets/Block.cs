using UnityEngine;

public class Block : MonoBehaviour
{
    SpriteRenderer block;
    public int health = 3;
    void Start()
    {
        block = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (health == 3)
        {
            block.color = Color.green;
        }
        else if (health == 2)
        {
            block.color = Color.yellow;
        }
        else if (health == 1) 
        { 
            block.color = Color.red;
        }
    }
}
