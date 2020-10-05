using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rnd : MonoBehaviour
{
    [SerializeField] private float camera_rot_time; //カメラの見る向きを変えるまでの時間
    [SerializeField] private float camera_dir;  //カメラの見る向き
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        switch (camera_dir)
        {
            case 1: //左向き
                gameObject.transform.localEulerAngles = new Vector3(-90, 0, 0);
                break;
            case 2: //右向き
                gameObject.transform.localEulerAngles = new Vector3(-90, 180, 0);
                break;
            case 3: //上向き

                break;
            case 4: //下向き

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > camera_rot_time)
        {
            camera_dir = Random.Range(1, 4);
            Debug.Log("一周");
            time = 0;
        }

        switch (camera_dir)
        {
            case 1: //左向き
                gameObject.transform.localEulerAngles = new Vector3(270, 0, 0);
                break;
            case 2: //右向き
                gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                break;
            case 3: //上向き
                gameObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                break;
            case 4: //下向き

                break;
        }
    }
}
