using UnityEngine;
public class LavaBehaviour : MonoBehaviour
{
    private float startingY;
    private float z;
    public int duplications;
    public GameObject lava;
    private bool up;
    void Start()
    {
        startingY = lava.transform.position.y;
        z = lava.transform.position.z;
        for(var i = 0; i < duplications; i++)
        {
            //startingY += lava.transform.localScale.z / 2;
            if(up)
            {
                if(startingY < lava.GetComponent<LavaMovement>().maxHeight)
                {
                    startingY += lava.transform.localScale.z / 2;
                } else
                {
                    up = false;
                    startingY -= lava.transform.localScale.z / 2;
                }
            } else
            {
                if (startingY > lava.GetComponent<LavaMovement>().minHeight)
                {
                    startingY -= lava.transform.localScale.z / 2;
                }
                else
                {
                    up = true;
                    startingY += lava.transform.localScale.z / 2;
                }
            }
            z += lava.transform.localScale.z;
            GameObject clone = Instantiate(lava, new Vector3(lava.transform.position.x, startingY, z), Quaternion.Euler(0, 0, 0));
        }
    }
    void Update()
    {
        
    }
}
