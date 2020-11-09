using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject[] Jumpparts;
    private bool JumpFlg;

    private float time;
    public int cansel;

    private PlayerControl Playercontrol;
    private float HiJumppower = 350;
    private float Jumppower;

    // Start is called before the first frame update
    void Start()
    {
        Playercontrol = GetComponent<PlayerControl>();
        Jumppower = Playercontrol.jumpSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (JumpFlg == true)
        {
            time += Time.deltaTime;
            foreach (var i in Jumpparts)
            {
                i.SetActive(true);
            }
            Playercontrol.SetJumpSpeed(HiJumppower);
            if (time > cansel)
            {
                foreach (var i in Jumpparts)
                {
                    i.SetActive(false);
                }
                Playercontrol.SetJumpSpeed(Jumppower);
                time = 0;
                JumpFlg = false;
            }
        }
    }

    public void JumppartsOn()
    {
        JumpFlg = true;
    }
}
