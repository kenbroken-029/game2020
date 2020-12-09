﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public bool jumpflg = false;

    public float speed = 3f;
    public float jumpSpeed = 5f;

    private Rigidbody rb;
    private float h, v;
    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded = false;
    private bool isMoving = false;

    private PlayerStatus Playerstatus;

    public Image Gauge_image;


    private Vector3 latestPos;

    float h2;
    float v2;
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
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            if (Input.GetButtonDown("Jump")) jumpflg = true;
        }

        //足元から下へ向けてRayを発射し，着地判定をする
        isGrounded = Physics.Raycast(gameObject.transform.position + 0.1f * gameObject.transform.up, -gameObject.transform.up, Mathf.Infinity);
        //デバッグ用にシーンにRayを表示する
        Debug.DrawRay(gameObject.transform.position + 0.1f * gameObject.transform.up, -0.15f * gameObject.transform.up, Color.blue, 100f);

        if (isGrounded || Mathf.Abs(rb.velocity.y) < 0.01f)
        {

            if (h != 0 || v != 0)
            {
                //moveDirection = speed * new Vector3(h, 0, v);   //奥に行ける
                //moveDirection = transform.TransformDirection(moveDirection);
                //rb.velocity = moveDirection;
                transform.Translate(Vector3.right * Time.deltaTime * speed * 1);
                isMoving = true;
                transform.rotation = Quaternion.LookRotation(transform.position +
                    (Vector3.forward * h) +
                    (Vector3.left * v)
                        - transform.position);
            }
            if (h == 0 || v == 0)
            {
                isMoving = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (isGrounded || Mathf.Abs(rb.velocity.y) < 0.01f)
        {

            //if (h != 0 || v != 0)
            //{
            //    //moveDirection = speed * new Vector3(h, 0, v);   //奥に行ける
            //    //moveDirection = transform.TransformDirection(moveDirection);
            //    //rb.velocity = moveDirection;
            //    transform.Translate(Vector3.right * Time.deltaTime * speed * 1);
            //    isMoving = true;
            //    transform.rotation = Quaternion.LookRotation(transform.position +
            //        (Vector3.forward * Input.GetAxis("L_S_Horizontal")) +
            //        (Vector3.left * Input.GetAxis("L_S_Vertical"))
            //            - transform.position);
            //}
            //if (h == 0 || v == 0)
            //{
            //    isMoving = false;
            //}
            if (jumpflg)
            {
                //rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
                rb.AddForce(transform.up * jumpSpeed);
                //rb.velocity = new Vector3(h, jumpSpeed, v);
                isMoving = true;
                jumpflg = false;
                Debug.Log("jump");
            }
        }

        //if (!isGrounded)
        //{
        //    //if (h != 0 || v != 0)
        //    //{
        //    //rb.velocity = Vector3.zero;
        //    moveDirection = speed * new Vector3(h, 0, v);   //奥に行ける
        //    moveDirection = transform.TransformDirection(moveDirection);
        //    //rb.velocity = moveDirection;
        //    //rb.AddForce(moveDirection);
        //    isMoving = true;
        //    if (rb.velocity.magnitude < 3.5f)
        //    {
        //        rb.AddForce(moveDirection);
        //    }
        //    //}
        //}
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("DroneRobot"))
        {
            if (Input.GetKey("joystick button 1") || Input.GetKeyDown("j"))
            {
                if (Gauge_image.fillAmount > 0.99f)
                {
                    //Playerstatus.JumppartsOn();
                    Destroy(gameObject);
                    col.tag = "Player";
                    col.GetComponent<DroneControl>().enabled = true;
                }
                Gauge_image.fillAmount += Time.deltaTime;
            }
            if (Input.GetKeyUp("joystick button 1"))
            {
                Gauge_image.fillAmount = 0;
            }
        }

        if (col.CompareTag("WalkRobot"))
        {
            if (Input.GetKey("joystick button 1") || Input.GetKeyDown("j"))
            {
                if (Gauge_image.fillAmount > 0.99f)
                {
                    //Playerstatus.JumppartsOn();
                    Destroy(gameObject);
                    col.tag = "Player";
                    col.GetComponent<walkrobotcontroll>().enabled = true;
                    Gauge_image.fillAmount = 0;
                }
                Gauge_image.fillAmount += Time.deltaTime;
            }
            if (Input.GetKeyUp("joystick button 1"))
            {
                Gauge_image.fillAmount = 0;
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("WalkRobot"))
        {
            Gauge_image.fillAmount = 0;
        }
        if (col.CompareTag("DroneRobot"))
        {
            Gauge_image.fillAmount = 0;
        }
    }

    public void SetJumpSpeed(float jumpPower)
    {
        jumpSpeed = jumpPower;
    }

    public bool GetisMoving()
    {
        return isMoving;
    }
}
