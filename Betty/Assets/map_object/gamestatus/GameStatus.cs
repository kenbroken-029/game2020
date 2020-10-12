using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private int Statusnum = 0;

    [SerializeField] Light[] Gameobject;

    // Start is called before the first frame update
    void Start()
    {
        switch (Statusnum)
        {
            case 0: //safe,非警戒状態

                break;
            case 1: //caution,警戒状態

                break;
            case 2: //warning,戦闘状態

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (Statusnum)
        {
            case 0: //safe,非警戒状態

                break;
            case 1: //caution,警戒状態

                break;
            case 2: //warning,戦闘状態
                foreach (Light light in Gameobject)
                {
                    light.color = new Color(1, 0, 0, 1);
                }
                //Gameobject.color = new Color(1, 0, 0, 1);
                break;
        }
        Debug.Log(Statusnum);
    }

    public int GetStatus()
    {
        return Statusnum;
    }

    public void SetStatus(int num)
    {
        Statusnum = num;
    }
}
