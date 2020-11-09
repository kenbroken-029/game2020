using UnityEngine;

public class walkrobotcontroll : MonoBehaviour
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
    public GameObject CameraScan;
    private Animator Walk_Robot;

    void Start()
    {
        //Rigidbodyを取得し，回転しないように固定
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Playerstatus = GetComponent<PlayerStatus>();
        GetComponent<Move_walkrobot>().enabled = false;
        CameraScan.SetActive(false);
        Walk_Robot = GetComponent<Animator>();
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
        if (h > 0.01f)
        {
            Walk_Robot.SetBool("walkflg", false);
            Walk_Robot.SetBool("walkflg_", true);
        }
        else if (h < -0.01f)
        {
            Walk_Robot.SetBool("walkflg_", false);
            Walk_Robot.SetBool("walkflg", true);
        }
        else
        {
            Walk_Robot.SetBool("walkflg", false);
            Walk_Robot.SetBool("walkflg_", false);
        }

        //足元から下へ向けてRayを発射し，着地判定をする
        isGrounded = Physics.Raycast(gameObject.transform.position + 0.1f * gameObject.transform.up, -gameObject.transform.up, 0.2f);
        //デバッグ用にシーンにRayを表示する
        Debug.DrawRay(gameObject.transform.position + 0.1f * gameObject.transform.up, -0.15f * gameObject.transform.up, Color.blue, 100f);
    }

    void FixedUpdate()
    {
        if (isGrounded || Mathf.Abs(rb.velocity.y) < 0.01f)
        {

            //if (h != 0 || v != 0)
            //{
            moveDirection = speed * new Vector3(v, 0, -h);   //奥に行ける
            moveDirection = transform.TransformDirection(moveDirection);
            rb.velocity = moveDirection;
            isMoving = true;
            //}
            if (h == 0 || v == 0)
            {
                isMoving = false;
            }
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

        if (!isGrounded)
        {
            //if (h != 0 || v != 0)
            //{
            //rb.velocity = Vector3.zero;
            moveDirection = speed * new Vector3(v, 0, -h);   //奥に行ける
            moveDirection = transform.TransformDirection(moveDirection);
            //rb.velocity = moveDirection;
            //rb.AddForce(moveDirection);
            isMoving = true;
            if (rb.velocity.magnitude < 3.5f)
            {
                rb.AddForce(moveDirection);
            }
            //}
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("j"))
            {
                Playerstatus.JumppartsOn();
                Destroy(gameObject);
                col.tag = "Player";
                col.GetComponent<walkrobotcontroll>().enabled = true;
            }
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
