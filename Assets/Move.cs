using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpForce;
    private bool onGround = false;
    private float previousHeight;
    private bool active = false;
    private Vector3 startPosition;
    public bool complete;
    public bool waiting;
    private bool pushable;
    private bool completeable = true;
    public AudioSource jumpSound;
    public AudioSource lava;
    public Timer timer;
    public AudioSource fireworks;
    private void Start()
    {
        startPosition = transform.position;
        jumpSound.Stop();
        fireworks.Stop();
    }
    void Update()
    {
        if(!lava.isPlaying)
        {
            lava.volume = 500;
            lava.Play();
        }
        if(timer.timerStarted && !waiting)
        {
            active = true;
        }
        if(Input.anyKey)
        {
            if (pushable)
            {
                waiting = false;
                pushable = false;
                active = true;
            }
        } else
        {
            pushable = true;
        }
        if(transform.position.z>=70)
        {
            complete = true;
            rb.drag = 10000;
            if(completeable)
            {
                completeable = false;
                fireworks.Play();
            }
        }
        if (active && !complete)
        {
            if(timer.time<=0 || GetComponent<HealthManagement>().health <= 0)
            {
                GetComponent<HealthManagement>().health = 100;
                transform.position = startPosition;
                timer.StartTimer();
                transform.rotation = Quaternion.Euler(0, 0, 0);
                GetComponent<CameraRotation>().rotationX = 0;
                GetComponent<CameraRotation>().rotationY = 0;
                rb.drag = 1000000;
                waiting = true;
                active = false;
            } else
            {
                rb.drag = 1;
            }
            if (GetComponent<HealthManagement>().health <= 0)
            {
                active = false;
            }

            if (onGround)
            {
                if (Input.GetKey("a"))
                {
                    rb.AddRelativeForce(-speed * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey("d"))
                {
                    rb.AddRelativeForce(speed * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey("w"))
                {
                    rb.AddRelativeForce(0, 0, speed * Time.deltaTime);
                }
                if (Input.GetKey("s"))
                {
                    rb.AddRelativeForce(0, 0, -speed * Time.deltaTime);
                }
                if (Input.GetKey("space"))
                {
                    rb.AddForce(0, jumpForce * Time.deltaTime, 0);
                    onGround = false;
                    jumpSound.Play();
                }
                if (onGround)
                {
                    transform.position = new Vector3(transform.position.x, previousHeight + 0.5f, transform.position.z);
                    previousHeight = transform.position.y -0.5f;
                }
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Floor" && collision.collider.name != "Wall")
        {
            onGround = true;
        }
    }
}