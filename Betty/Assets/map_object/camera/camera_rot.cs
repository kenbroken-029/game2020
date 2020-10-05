using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rot : MonoBehaviour
{
    private Vector3 Rot;
    public float RotationSpeed = 0;
    [SerializeField] private int Rot_Dir;   //１＝ｘ、２＝ｙ、３＝ｚ
    void Start()
    {
        Rot = new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);
        //switch (Rot_Dir)
        //{
        //    case 1:
        //        transform.localEulerAngles = new Vector3(Rot.x + sin, Rot.y, Rot.z);
        //        break;

        //    case 2:
        //        transform.localEulerAngles = new Vector3(Rot.x, Rot.y + sin, Rot.z);
        //        break;

        //    case 3:
        //        transform.localEulerAngles = new Vector3(Rot.x, Rot.y, Rot.z + sin);
        //        break;
        //}
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
    }
}
