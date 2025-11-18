using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
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
    public GameObject bullet;
    public GameObject beam;
    float BulletCooldown = 1;
    bool BulletReady = true;
    int bullets;
    float speed = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void SummonBeam()
    {
        bullets = 0;
        GameObject SpawnedBeam = Instantiate(beam);
        SpawnedBeam.transform.position = transform.position + new Vector3(0, 5.25f, 0);
        StartCoroutine(deleteBeam(1.2f, SpawnedBeam));
    }

    IEnumerator deleteBeam(float time, GameObject currentBeam)
    {
        yield return new WaitForSeconds(time);
        Destroy(currentBeam);
    }
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
                GameObject newBullet = Instantiate(bullet); //Skapa bullet och sätt position till playern
                newBullet.tag = "Bullet";
                newBullet.transform.position = transform.position;
                if (bullets == 3) //Efter 3 bullets skapa en beam som tar 2 health
                {
                    SummonBeam();
                    return;
                }
                bullets = bullets + 1;
            }
        }

        if (!BulletReady) //Cooldown för bullet spawning
        {
            BulletCooldown -= 2 * Time.deltaTime;
            if (BulletCooldown <= 0)
            {
                BulletReady = true;
                BulletCooldown = 1;
            }
        }
    }
}
