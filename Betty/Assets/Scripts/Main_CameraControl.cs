using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_CameraControl : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 Camera_Pos;

    public float speed = 3f;
    private float h, v;
    private Vector3 moveCamera = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Camera_Pos = transform.position -= Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("R_S_Horizontal");
        v = Input.GetAxis("R_S_Vertical");

        Debug.Log(h);
        Debug.Log(v);
        if (h != 0 || v != 0)
        //if(h != 0)
        {
            moveCamera = speed * new Vector3(h, -v, 0);   //奥に行ける
            //moveDirection = speed * new Vector3(h, 0, 0);   //奥に行けない
            moveCamera = transform.TransformDirection(moveCamera);
        }
        transform.position = new Vector3(Player.transform.position.x + Camera_Pos.x + moveCamera.x, 
                                        Player.transform.position.y + Camera_Pos.y + moveCamera.y,
                                        Player.transform.position.z + Camera_Pos.z);
    }
}
