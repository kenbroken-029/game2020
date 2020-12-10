using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_StealthDrone : MonoBehaviour
{
    private float time;
    public float Move_time;
    private bool flg;
    private Vector3 StealthDronePos;
    public GameObject StealthDronePos_;

    private Animator animator;
    private bool flg_;

    public Material StealthDroneMat;
    public Material StealthDroneEyeMat;
    public Material StealthDronelazerMat;
    private float Materialtime = 1;
    // Start is called before the first frame update
    void Start()
    {
        StealthDronePos = GetComponent<Transform>().position;
        StealthDroneMat.color = new Color(1, 1, 1, 1);
        StealthDroneEyeMat.color = new Color(1, 0, 0, 1);
        StealthDronelazerMat.color = new Color(1, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(Move_time < time)
        {
            time = 0;
            flg = true;
        }
        if (flg && !flg_)
        {
            transform.position = Vector3.Lerp(StealthDronePos, StealthDronePos_.transform.position, time);
            //Materialtime -= Time.deltaTime;
            StealthDroneMat.color = StealthDroneMat.color - new Color(0, 0, 0, Time.deltaTime);
            StealthDroneEyeMat.color = StealthDroneEyeMat.color - new Color(0, 0, 0, Time.deltaTime);
            StealthDronelazerMat.color = StealthDronelazerMat.color - new Color(0, 0, 0, Time.deltaTime);
            if (time > 1)
            {
                flg = false;
                flg_ = true;
                time = 0;
            }
        }
        if(flg && flg_)
        {
            transform.position = Vector3.Lerp(StealthDronePos_.transform.position, StealthDronePos, time);
            StealthDroneMat.color = StealthDroneMat.color + new Color(0, 0, 0, Time.deltaTime);
            StealthDroneEyeMat.color = StealthDroneEyeMat.color + new Color(0, 0, 0, Time.deltaTime);
            StealthDronelazerMat.color = StealthDronelazerMat.color + new Color(0, 0, 0, Time.deltaTime);
            if (time > 1)
            {
                flg = false;
                flg_ = false;
                time = 0;
            }
        }
    }
}
