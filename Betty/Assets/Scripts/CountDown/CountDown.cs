using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] private float CountInit;    //設定したカウントダウン秒数
    private float Count; //設定したカウントダウン秒数格納
    [SerializeField] private TextMeshProUGUI CountDownText; //カウントダウンテキスト
    private bool CountFlg = false;  //カウントダウン開始Flg

    //[SerializeField] GameObject gamestatus;

    // Start is called before the first frame update
    void Start()
    {
       //初期値設定-------------------------
        CountDownText.text = Count.ToString();  //設定したカウントダウン秒数をテキストに代入
        Count = CountInit;  //設定したカウントダウン秒数を保存
        //初期値設定-------------------------
    }

    // Update is called once per frame
    void Update()
    {
        //カウントダウンFlgがtrue(敵に見つかったら)になったら
        if (CountFlg == true)
        {
            Count -= Time.deltaTime;
            CountDownText.text = string.Format("{0:f2}", Count);
        }
        else
        {
            Count = CountInit;
        }

        //カウントが０になったら
        if(Count < 0)
        {
            CountFlgFalse();
        }
    }

    
    public void CountFlgTrue()  //カウントダウンFlgをTrue
    {
        CountFlg = true;
    }

    public void CountFlgFalse() //カウントダウンFlgをfalse
    {
        CountFlg = false;
    }
}
