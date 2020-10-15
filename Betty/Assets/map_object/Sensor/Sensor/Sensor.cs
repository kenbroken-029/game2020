using UnityEngine;

public class Sensor : MonoBehaviour
{
    //[SerializeField] GameObject Gamestatus;
    [SerializeField] private GameStatus Gamestatus_script;
    // Start is called before the first frame update
    void Start()
    {
        //Gamestatus_script = GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Gamestatus_script.Statusnum = GameStatus.Gamestatus.warning;
        }
    }
}
