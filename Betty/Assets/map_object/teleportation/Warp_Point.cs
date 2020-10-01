using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp_Point : MonoBehaviour
{
    [SerializeField] GameObject Warp_Point_Pos;
    private bool WarpFlg = false;

    private Warp_Point Warp_script;

    // Start is called before the first frame update
    void Start()
    {
        Warp_script = Warp_Point_Pos.GetComponent<Warp_Point>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (!WarpFlg)
            {
                WarpFlg = true;
                col.transform.position = Warp_Point_Pos.transform.position;
                Warp_script.set_WarpFlg(true);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        WarpFlg = false;
    }

    public void set_WarpFlg(bool Flg)
    {
        WarpFlg = Flg;
    }

    public bool get_Warp_Point()
    {
        return WarpFlg;
    }
}
