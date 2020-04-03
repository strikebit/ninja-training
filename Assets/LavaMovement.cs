using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    public float speed;
    public float maxHeight;
    public float minHeight;
    public float variation;
    private float realMaxHeight;
    private float realMinHeight;
    private bool up;
    void Start()
    {
        realMinHeight = Random.Range(minHeight - variation, minHeight + variation);
        realMaxHeight = Random.Range(maxHeight - variation, maxHeight + variation);
    }
    void Update()
    {
        
        if(up)
        {
            if(transform.position.y < realMaxHeight)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            } else
            {
                up = false;
                realMinHeight = Random.Range(minHeight - variation, minHeight + variation);
            }
        } else
        {
            if (transform.position.y > realMinHeight)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
            }
            else
            {
                up = true;
                realMaxHeight = Random.Range(maxHeight - variation, maxHeight + variation);
            }
        }
    }
}
