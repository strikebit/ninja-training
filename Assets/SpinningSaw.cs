using UnityEngine;

public class SpinningSaw : MonoBehaviour
{
    private float rotation;
    void Start()
    {
        rotation = transform.rotation.y;
    }
    void Update()
    {
        rotation += 5;
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponentInParent<TurretBehaviour>().framesCompleted = GetComponentInParent<TurretBehaviour>().framesPerShot;
    }
}
