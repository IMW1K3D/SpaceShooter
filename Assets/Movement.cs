using System.Threading.Tasks;
using UnityEditor.SceneManagement;
using UnityEditor.Timeline;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode shoot = KeyCode.Space;
    [SerializeField] GameObject bullet;
    float speed = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(right))
        {
            print("Right");
            transform.position = transform.position + new Vector3(1,0,0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(left))
        {
            print("Left");
            transform.position = transform.position - new Vector3(1,0,0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(shoot))
        {
            print("Shoot");
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.localPosition;
            if (newBullet.transform.position.y < 10)
            {
                newBullet.transform.position = newBullet.transform.position + new Vector3(0, 1, 0) * 4 * Time.deltaTime;
                print("Moving bullet");
            }
        }
    }
}
