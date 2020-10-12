using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] GameObject Gamestatus;
    private GameStatus Gamestatus_script;
    // Start is called before the first frame update
    void Start()
    {
        Gamestatus_script = GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Gamestatus.GetComponent<GameStatus>().SetStatus(2);
        }
    }
}
