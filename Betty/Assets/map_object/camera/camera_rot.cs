using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rot : MonoBehaviour
{
    private Vector3 Rot;
    public float RotationSpeed = 0;
    void Start()
    {
        Rot = new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);
    }
    // Update is called once per frame
    void Update()
    {
        float sin = Mathf.Sin(Time.time) * RotationSpeed;
        //transform.rotation = Quaternion.Euler(Rot.x, Rot.y, Rot.z);
        transform.localEulerAngles = new Vector3(Rot.x, Rot.y, Rot.z + sin);
    }
}
