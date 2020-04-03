using UnityEngine;

public class CollidingSaws : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name != "Body")
        {
            GetComponentInParent<TurretBehaviour>().framesCompleted = GetComponentInParent<TurretBehaviour>().framesPerShot;
        }
    }
}
