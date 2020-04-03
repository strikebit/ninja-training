using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotation = 0;
    public float x;
    public float y;
    void Update()
    {
        if(rotation<360)
        {
            rotation += 2;
        } else
        {
            rotation = 1;
        }
        transform.rotation = Quaternion.Euler(x, y, rotation);
    }
}
