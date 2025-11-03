using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Bullet"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if (transform.position.y >= 6)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
