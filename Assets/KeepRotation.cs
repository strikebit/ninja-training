using UnityEngine;
public class KeepRotation : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
