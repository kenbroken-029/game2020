using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject[] Jumpparts;
    private bool JumpFlg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (JumpFlg == true)
        {
            foreach (var i in Jumpparts)
            {
                i.SetActive(true);
            }
        }
    }

    public void JumppartsOn()
    {
        JumpFlg = true;
    }
}
