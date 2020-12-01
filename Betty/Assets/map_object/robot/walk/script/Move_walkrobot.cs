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
            if (animator.GetBool("walkflg2") == true)
            {
                animator.SetTrigger("walktrigger2");
            }
            else
            {
                animator.SetBool("walkflg1", false);
                animator.SetBool("walkflg2", true);
            }
            transform.position = Vector3.Lerp(DronePos, DronePos_.transform.position, time);
            if (time > 1)
            {
                animator.SetBool("walkflg2", false);
                //DronePos = transform.position;
                flg = false;
                flg_ = true;
                time = 0;
            }
        }
        if (flg && flg_)
        {
            if (animator.GetBool("walkflg1") == true)
            {
                animator.SetTrigger("walktrigger1");
            }
            else
            {
                animator.SetBool("walkflg2", false);
                animator.SetBool("walkflg1", true);
            }
            transform.position = Vector3.Lerp(DronePos_.transform.position, DronePos, time);
            if (time > 1)
            {
                animator.SetBool("walkflg1", false);
                //DronePos = transform.position;
                flg = false;
                flg_ = false;
                time = 0;
            }
        }
    }


}
