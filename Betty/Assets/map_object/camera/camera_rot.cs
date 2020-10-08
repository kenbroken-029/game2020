using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rot : MonoBehaviour
{
    private Vector3 Rot;
    public float RotationSpeed = 0;
    [SerializeField] private int Rot_Dir;   //１＝ｘ、２＝ｙ、３＝ｚ


    [SerializeField] private GameObject newcamera;
    [SerializeField] private float camera_rot_time; //カメラの見る向きを変えるまでの時間
    [SerializeField] private float camera_dir;  //カメラの見る向き
    private float time;
    private float deltatime;
    private bool flg;
    void Start()
    {
        Rot = new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);




        switch (camera_dir)
        {
            case 1: //左向き
                //gameObject.transform.localEulerAngles = new Vector3(270, 0, 0);
                break;
            case 2: //右向き
                //gameObject.transform.localEulerAngles = new Vector3(90, 180, 0);
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

        float sin = Mathf.Sin(Time.time) * RotationSpeed;
        //transform.rotation = Quaternion.Euler(Rot.x, Rot.y, Rot.z);
        //transform.localEulerAngles = new Vector3(Rot.x, Rot.y, Rot.z + sin);
        switch (Rot_Dir)
        {
            case 1:
                transform.localEulerAngles = new Vector3(Rot.x + sin, Rot.y, Rot.z);
                break;

            case 2:
                transform.localEulerAngles = new Vector3(Rot.x, Rot.y + sin, Rot.z);
                break;

            case 3:
                transform.localEulerAngles = new Vector3(Rot.x, Rot.y, Rot.z + sin);
                break;
        }


        time += Time.deltaTime;

        if (time > camera_rot_time)
        {
            camera_dir = Random.Range(1, 4);
            Debug.Log("一周");
            time = 0;
        }

        switch (camera_dir)
        {
            case 1: //左向き

                newcamera.transform.rotation = Quaternion.RotateTowards(newcamera.transform.rotation, Quaternion.Euler(90, 270, 0), 1f);
                break;
            case 2: //右向き
                newcamera.transform.rotation = Quaternion.RotateTowards(newcamera.transform.rotation, Quaternion.Euler(0, 270, 0), 1f);
                //gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                break;
            case 3: //上向き
                newcamera.transform.rotation = Quaternion.RotateTowards(newcamera.transform.rotation, Quaternion.Euler(270, 270, 0), 1f);
                //gameObject.transform.localEulerAngles = new Vector3(180, 0, 0);
                break;
            case 4: //下向き

                break;
        }
    }
}
