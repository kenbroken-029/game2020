using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    public int width;
    private Vector3 targetPos;
    //[SerializeField] GameObject Gamestatus;
    public GameStatus Gamestatus_script;
    //private GameStatus
    // Start is called before the first frame update
    void Start()
    {
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
                Gamestatus_script.Statusnum = GameStatus.Gamestatus.warning;
                //gameObject.GetComponent<GameStatus>().Statusnum = GameStatus.Gamestatus.warning;
                //base.Statusnum = GameStatus.Gamestatus.warning;
            }
        }
    }
}
