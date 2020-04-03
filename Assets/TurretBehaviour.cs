using UnityEngine;
public class TurretBehaviour : MonoBehaviour
{
    public Transform saw;
    public Transform target;
    public string direction;
    public float speed;
    public int framesCompleted;
    public int framesPerShot;
    public AudioSource sound;
    public float range;
    private float x;
    private float z;
    void Update()
    {
        x = Mathf.Abs(transform.position.x - target.position.x);
        z = Mathf.Abs(transform.position.z - target.position.z);
        if (framesCompleted < framesPerShot)
        {
            ShootSaw();
        }
        else
        {
            saw.position = new Vector3(0, 1, 0) + transform.position;
            framesCompleted = 0;
            if (Mathf.Sqrt(z * z + x * x) <= range)
            {
                sound.Play();
            }
            GetComponent<RandomDirection>().Randomize();
        }
    }
    private void ShootSaw()
    {
        if (direction == "backwards")
        {
            saw.position = new Vector3(saw.position.x, saw.position.y, saw.position.z - speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (direction == "forwards")
        {
            saw.position = new Vector3(saw.position.x, saw.position.y, saw.position.z + speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (direction == "right")
        {
            saw.position = new Vector3(saw.position.x + speed, saw.position.y, saw.position.z);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (direction == "left")
        {
            saw.position = new Vector3(saw.position.x - speed, saw.position.y, saw.position.z);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        framesCompleted++;
    }
}