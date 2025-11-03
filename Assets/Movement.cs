using System.Threading.Tasks;
using UnityEditor.SceneManagement;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode shoot = KeyCode.Space;
    [SerializeField] GameObject bullet;
    float BulletCooldown = 2;
    bool BulletReady = true;
    float speed = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(right))
        {
            if (transform.position.x <= 4)
            {
                print("Right");
                transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(left))
        {
            if (transform.position.x >= -4) 
            {
                print("Left");
                transform.position = transform.position - new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(shoot))
        {
            if (BulletReady)
            {
                print("Shoot");
                BulletReady = false;
                GameObject newBullet = Instantiate(bullet);
                newBullet.tag = "Bullet";
                newBullet.transform.position = transform.position;
            }
        }

        if (!BulletReady) 
        {
            BulletCooldown -= 1 * Time.deltaTime;
            if (BulletCooldown <= 0)
            {
                BulletReady = true;
                BulletCooldown = 2;
            }
        }
    }
}
