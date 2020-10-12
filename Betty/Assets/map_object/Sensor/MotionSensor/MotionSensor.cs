using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    public int width;
    private Vector3 targetPos;
    [SerializeField] GameObject Gamestatus;
    private GameStatus Gamestatus_script;

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
                Gamestatus.GetComponent<GameStatus>().SetStatus(2);
            }
        }
    }
}
