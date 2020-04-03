using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float health = 100;
    void Update()
    {
        health = GetComponentInParent<HealthManagement>().health;
        if(health < 0)
        {
            health = 0;
        }
        transform.localScale = new Vector3(health * 0.0025f, transform.localScale.y, transform.localScale.z);
    }
}