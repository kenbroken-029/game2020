﻿using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 3f;
    public float jumpSpeed = 5f;

    private Rigidbody rb;
    private float h, v;
    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded = false;

    private PlayerStatus Playerstatus;
    void Start()
    {
        //Rigidbodyを取得し，回転しないように固定
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Playerstatus = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        //移動
        h = Input.GetAxis("L_S_Horizontal");
        v = Input.GetAxis("L_S_Vertical");
        if (Input.GetKey("a")) h = -1;
        if (Input.GetKey("d")) h = 1;
        if (Input.GetKey("w")) v = 1;
        if (Input.GetKey("s")) v = -1;
        //足元から下へ向けてRayを発射し，着地判定をする
        isGrounded = Physics.Raycast(gameObject.transform.position + 0.1f * gameObject.transform.up, -gameObject.transform.up, 0.15f);
        //デバッグ用にシーンにRayを表示する
        Debug.DrawRay(gameObject.transform.position + 0.1f * gameObject.transform.up, -0.15f * gameObject.transform.up, Color.blue, 100f);

        if (isGrounded || Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            if (h != 0 || v != 0)
            //if(h != 0)
            {
                moveDirection = speed * new Vector3(h, 0, v);   //奥に行ける
                //moveDirection = speed * new Vector3(h, 0, 0);   //奥に行けない
                moveDirection = transform.TransformDirection(moveDirection);
                rb.velocity = moveDirection;
            }
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Behind"))
        {
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("j"))
            {
                Playerstatus.JumppartsOn();
                Destroy(col.transform.root.gameObject);
            }
        }
    }

    public void SetJumpSpeed(int jumpPower)
    {
        jumpSpeed = jumpPower;
    }
}