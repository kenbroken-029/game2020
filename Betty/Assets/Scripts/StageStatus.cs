using UnityEngine;

public class StageStatus : MonoBehaviour
{
    private GameObject Player;  //プレイヤー取得
    private Transform Player_pos;   //プレイヤーの位置取得
    [SerializeField] private Material Wall_mat; //中央の壁取得
    private Color color;    //中央の壁の色格納
    private float Alphacolor;   //colorのα値最大
    private float ChangeAlphacolor; //colorのα値を薄くする
    private Vector3 Back_pos;   //奥に行ったかどうかの判定

    //[SerializeField] GameObject countdown;
    private GameStatus Gamestatus;
    [SerializeField] Light[] Gameobject;

    // Start is called before the first frame update
    void Start()
    {
        //初期値設定----------------------------------------
        color = Wall_mat.color; //Wall_matのcolorを格納
        Alphacolor = 1.0f;
        ChangeAlphacolor = 0.2f;
        Back_pos = new Vector3(0, 0, 0);
        Gamestatus = gameObject.GetComponent<GameStatus>();
        Player = GameObject.FindWithTag("Player");
        Player_pos = Player.transform;
        //初期値設定----------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        Player_pos = Player.transform;
        //常にstatusnumの値を取得する
        //statusnum = gameObject.GetComponent<GameStatus>().GetStatus();

        //プレイヤーが奥に移動したら
        if (Player_pos.position.z > Back_pos.z)
        {
            color.a = ChangeAlphacolor; //壁を透けさせる
            Wall_mat.color = color; //α値を代入
        }
        else
        {
            color.a = Alphacolor;   //壁が現れる
            Wall_mat.color = color; //α値を代入
        }

        //攻撃状態になったら
        if (Gamestatus.Statusnum == GameStatus.Gamestatus.warning)
        {
            //Lightを赤くする
            foreach (Light light in Gameobject)
            {
                light.color = new Color(1, 0, 0, 1);    //ライトを赤く
                gameObject.GetComponent<CountDown>().CountFlgTrue();    //カウントダウンを開始する
            }
        }

        //警戒状態になったら
        if (Gamestatus.Statusnum == GameStatus.Gamestatus.caution)
        {
            //Lightを黄色くする
            foreach (Light light in Gameobject)
            {
                light.color = new Color(1, 1, 0, 1);    //ライトを黄色
                gameObject.GetComponent<CountDown>().CountFlgTrue();    //カウントダウンを開始する
            }
        }

        //安全状態になったら
        if (Gamestatus.Statusnum == GameStatus.Gamestatus.safe)
        {
            //Lightを白くする
            foreach (Light light in Gameobject)
            {
                light.color = new Color(1, 1, 1, 1);    //ライトを白
                //gameObject.GetComponent<CountDown>().CountFlgTrue();    //カウントダウンを開始する
            }
        }
    }

    private void FixedUpdate()
    {
    }
}
