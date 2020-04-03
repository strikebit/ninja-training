using UnityEngine;

public class StarDuplication : MonoBehaviour
{
    public float range;
    public int duplications;
    public GameObject star;
    private float x;
    private float z;
    void Start()
    {
        for(var i = 0; i < duplications; i++)
        {
            x = Random.Range(star.transform.position.x-range/2,star.transform.position.x+range/2);
            z = Random.Range(star.transform.position.z-range/2,star.transform.position.z+range/2);
            GameObject clone = Instantiate(star, new Vector3(x, star.transform.position.y, z), Quaternion.Euler(0, 0, 0));
        }
    }
    void Update()
    {
        
    }
}
