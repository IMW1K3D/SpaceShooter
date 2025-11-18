using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float speed = 8;
    Stats stats;
    
    void Start()
    {

        stats = GameObject.Find("Shooter").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Bullet"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed); //Om bullet existerar åker den up med speed och deltaTime
            if (transform.position.y >= 6)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Block blockHealth = other.GetComponent<Block>(); //Hitta block scriptet för att kunna ändra health
        if (gameObject.tag == "Beam")
        {
            blockHealth.health = blockHealth.health - 2;
        }
        else if (gameObject.tag == "Bullet")
        {
            blockHealth.health -= 1;
        }

        if (blockHealth.health <= 0) //När blockhealth är 0 eller mindre ger det points och tar sönder block
        {
            stats.points = stats.points + 100;
            Destroy(other.gameObject);
        }
        if (gameObject.tag == "Beam")
        {
            return;
        }
        Destroy(gameObject);
    }
}
