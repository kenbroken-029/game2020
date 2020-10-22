using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    [SerializeField] private GameObject Gamestatus;
    [SerializeField] private int width;
    private Vector3 targetPos;
    private GameStatus Gamestatus_script;
    private CountDown Countdown_script;

    // Start is called before the first frame update
    void Start()
    {
        Gamestatus_script = Gamestatus.GetComponent<GameStatus>();
        Countdown_script = Gamestatus.GetComponent<CountDown>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * width + targetPos.x, targetPos.y, targetPos.z);
    }

    
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.GetComponent<PlayerControl>().GetisMoving() == true)
            {
                if (Gamestatus_script.Statusnum == GameStatus.Gamestatus.warning)
                {
                    Countdown_script.Countinit();
                }
                else if (Gamestatus_script.Statusnum == GameStatus.Gamestatus.caution)
                {
                    Gamestatus_script.Statusnum = GameStatus.Gamestatus.warning;
                    Countdown_script.Countinit();
                }
                else
                {
                    Gamestatus_script.Statusnum = GameStatus.Gamestatus.warning;
                }
            }
        }
    }
}
