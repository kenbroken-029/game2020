using UnityEngine;

public class Move_walkrobot : MonoBehaviour
{
    private float time;
    public float Move_time;
    private bool flg;
    private Vector3 DronePos;
    public GameObject DronePos_;

    private Animator animator;
    private bool flg_;
    // Start is called before the first frame update
    void Start()
    {
        DronePos = GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (Move_time < time)
        {
            time = 0;
            flg = true;
        }
        if (flg && !flg_)
        {
            animator.SetBool("walkflg", true);
            transform.position = Vector3.Lerp(DronePos, DronePos_.transform.position, time);
            if (time > 1)
            {
                animator.SetBool("walkflg", false);
                //DronePos = transform.position;
                flg = false;
                flg_ = true;
                time = 0;
            }
        }
        if (flg && flg_)
        {
            animator.SetBool("walkflg_", true);
            transform.position = Vector3.Lerp(DronePos_.transform.position, DronePos, time);
            if (time > 1)
            {
                animator.SetBool("walkflg_", false);
                //DronePos = transform.position;
                flg = false;
                flg_ = false;
                time = 0;
            }
        }
    }
}
