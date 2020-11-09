using UnityEngine;

public class Move_drone : MonoBehaviour
{
    private float time;
    public float Move_time;
    private bool flg;
    private Vector3 DronePos;
    public GameObject rand_DronePos;


    // Start is called before the first frame update
    void Start()
    {
        DronePos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (Move_time < time)
        {
            Debug.Log("adsdfgasd");
            time = 0;
            flg = true;
        }
        if (flg)
        {

            transform.position = Vector3.Lerp(DronePos, rand_DronePos.transform.position, time);
            if (time > 1)
            {
                DronePos = transform.position;
                flg = false;
                time = 0;
            }
        }
    }
}
