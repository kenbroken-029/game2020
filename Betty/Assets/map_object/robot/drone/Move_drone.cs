using UnityEngine;

public class Move_drone : MonoBehaviour
{
    private float time;
    public float Move_time;
    private bool flg;
    private Transform DronePos;
    public GameObject rand_DronePos;

    public Transform[] randpos;
    private int posnum = 0;

    // Start is called before the first frame update
    void Start()
    {
        DronePos = GetComponent<Transform>();
        //randpos[0] = DronePos;
        //Debug.Log(randpos[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!flg)
        {
            time += Time.deltaTime;
        }

        if (Move_time < time && !flg)
        {
            Debug.Log("adsdfgasd");
            time = 0;
            flg = true;
            if (posnum > 0 && posnum < randpos.Length - 1)
            {
                posnum += Random.Range(-1, 2);
            }
            else if (posnum == 0)
            {
                posnum += Random.Range(0, 2);
            }
            else
            {
                posnum += Random.Range(-1, 1);
            }
            Debug.Log(posnum);
        }

        if (flg)
        {
            transform.position = Vector3.Lerp(DronePos.position, randpos[posnum].position, time);

            time += Time.deltaTime / 10;
            if (time > 1 || DronePos.position == randpos[posnum].position)
            {
                DronePos = gameObject.transform;
                flg = false;
                time = 0;
            }
        }
    }
}
