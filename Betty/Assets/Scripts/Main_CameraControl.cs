using UnityEngine;

public class Main_CameraControl : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 Camera_Pos;

    float Player_pos_y;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Camera_Pos = transform.position - Player.transform.position;
        Player_pos_y = Player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 2, transform.position.z);
    }
}
