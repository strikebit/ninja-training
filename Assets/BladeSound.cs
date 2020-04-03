using UnityEngine;
public class BladeSound : MonoBehaviour
{
    public AudioSource sound;
    public Transform target;
    public float range;
    private float x;
    private float z;
    private bool playable;
    void Update()
    {
        x = Mathf.Abs(transform.position.x-target.position.x);
        z = Mathf.Abs(transform.position.z-target.position.z);
        if(Mathf.Sqrt(x*x+z*z)<=range)
        {
            if (playable)
            {
                sound.Play();
                playable = false;
            }
        } else
        {
            playable = true;
        }
    }
}
