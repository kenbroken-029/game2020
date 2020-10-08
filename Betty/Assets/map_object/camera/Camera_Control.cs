using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [SerializeField] private GameObject Status;
    private RaycastHit Hit_player;  //RaycastHit判定

    [SerializeField] private GameObject gameobject; //Rayポジション
    [SerializeField] private Material SafeColor;    //非警戒状態マテリアル
    [SerializeField] private Material WarningColor; //警戒状態マテリアル
    [SerializeField] private Material CautionColor; //戦闘状態マテリアル
    private Material MaterialColor;

    [SerializeField] GameObject bullet; //弾インスタンス

    // Start is called before the first frame update
    void Start()
    {
        MaterialColor = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider col)    //当たり判定
    {
        if (col.CompareTag("Player"))   //プレイヤー判定
        {
            Debug.Log(col.tag);

            //Rayを飛ばす
            if (Physics.Raycast(gameobject.transform.position, (col.transform.position - gameobject.transform.position).normalized, out Hit_player))
            {
                //デバッグ用Ray可視化
                Debug.DrawRay(gameobject.transform.position, (col.transform.position - gameobject.transform.position).normalized, Color.red, Mathf.Infinity);
                if (Hit_player.collider.tag == "Player")//ヒットしたタグがプレイヤーか
                {
                    CreateBullet();
                    Status.GetComponent<GameStatus>().SetStatus(2);
                    MaterialColor.color = WarningColor.color;
                    Debug.Log("Ray_Hit");
                    //SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }

    void CreateBullet()
    {
        Instantiate(bullet, gameobject.transform.position, Quaternion.identity);
    }

}
