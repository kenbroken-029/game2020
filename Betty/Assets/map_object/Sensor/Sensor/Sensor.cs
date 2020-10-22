using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] GameObject Gamestatus;
    private GameStatus Gamestatus_script;
    private CountDown Countdown_script;

    // Start is called before the first frame update
    void Start()
    {
        Gamestatus_script = Gamestatus.GetComponent<GameStatus>();
        Countdown_script = Gamestatus.GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
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
