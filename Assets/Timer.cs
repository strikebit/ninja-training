using UnityEngine;

public class Timer : MonoBehaviour
{
    public float startTime;
    public float currentTime;
    public bool timerStarted;
    public int time = 1;
    public float wait;
    public float waitTime;
    public Move move;
    public void StartTimer()
    {
        currentTime = startTime;
    }
    void Start()
    {
        StartTimer();
        GetComponent<RectTransform>().position = new Vector3(360, 260, 0);
    }
    private void FixedUpdate()
    {
        if(wait<waitTime)
        {
            wait += 1 * Time.fixedDeltaTime;
        } else
        {
            timerStarted = true;
            if (!move.waiting)
            {
                GetComponent<RectTransform>().position = new Vector3(30, 40, 0);
            }
            GetComponent<UnityEngine.UI.Text>().fontSize = 30;
        }
        if (timerStarted)
        {
            if (!move.complete && !move.waiting)
            {
                currentTime -= 1 * Time.fixedDeltaTime;
            }
            time = Mathf.RoundToInt(currentTime);
            GetComponent<UnityEngine.UI.Text>().text = time.ToString();
            if (time==10||time==8||time==6||time<6)
            {
                GetComponent<UnityEngine.UI.Text>().color = Color.red;
            } else
            {
                GetComponent<UnityEngine.UI.Text>().color = Color.white;
            }
            if(move.waiting)
            {
                GetComponent<UnityEngine.UI.Text>().text = "Press any key to Play";
                GetComponent<RectTransform>().position = new Vector3(500, 280, 0);
            }
        }
        if(move.complete)
        {
            GetComponent<UnityEngine.UI.Text>().color = Color.green;
        }
    }
}
