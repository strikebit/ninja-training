using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public float speed;
    public float breakHeight;
    public float x;
    public float y;
    public float z;
    public int clones;
    public GameObject player;
    public GameObject red;
    public GameObject orange;
    public GameObject yellow;
    public GameObject green;
    public GameObject blue;
    public GameObject purple;
    void Start()
    {
        
    }
    void Update()
    {
        if (player.GetComponent<Move>().complete)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }else
        {
            transform.position = new Vector3(player.transform.position.x + x, player.transform.position.y + y - 4, player.transform.position.z + z);
        }
        if (transform.position.y<breakHeight+speed/2&&transform.position.y>breakHeight-speed/2)
        {
            Debug.Log("clone");
            for (var i = 0; i < clones; i++)
            {
                GameObject clone1 = Instantiate(red, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                GameObject clone2 = Instantiate(orange, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                GameObject clone3 = Instantiate(yellow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                GameObject clone4 = Instantiate(green, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                GameObject clone5 = Instantiate(blue, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                GameObject clone6 = Instantiate(purple, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                Debug.Log(clone1);
            }
        }
    }
}