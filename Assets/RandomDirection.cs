using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    public int possibilities;
    public string one;
    public string two;
    public string three;
    public string four;
    private int direction;
    private string choice;
    public void Randomize()
    {
        direction = Random.Range(1, possibilities + 1);
        if(direction == 1)
        {
            choice = one;
        }
        if(direction == 2)
        {
            choice = two;
        }
        if (direction == 3)
        {
            choice = three;
        }
        if (direction == 4)
        {
            choice = four;
        }
        GetComponent<TurretBehaviour>().direction = choice;
    }
}