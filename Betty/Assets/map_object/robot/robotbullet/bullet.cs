using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    //プレイヤーの位置に弾が飛ぶ
    private Transform Player;   //プレイヤー取得
    private Vector3 PlayerPos;  //プレイヤーの位置取得
    [SerializeField] private float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;   //プレイヤー取得
        PlayerPos = Player.position;    //プレイヤーの位置保存

    }

    // Update is called once per frame
    void Update()
    {
        //弾を初期位置から、プレイヤーの位置に飛ばす
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, PlayerPos, Time.deltaTime * BulletSpeed);
        if (gameObject.transform.position == PlayerPos)
        {
            Destroy(gameObject);
        }
        //GetComponent<Rigidbody>().AddForce(PlayerPos, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
