using UnityEngine;
public class HealthManagement : MonoBehaviour
{
    public float health = 100;
    private float waitTime = 10;
    private bool collideable = true;
    public AudioSource hurt;
    void Start()
    {
        hurt.Stop();
    }
    void Update()
    {
        if (!collideable)
        {
            if (waitTime > 0)
            {
                waitTime--;
            } else
            {
                waitTime = 10;
                collideable = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy" && collideable && !GetComponent<Move>().complete)
        {
            health -= collision.collider.GetComponent<EnemyDamage>().damage;
            collideable = false;
            hurt.Play();
        }
    }
}
