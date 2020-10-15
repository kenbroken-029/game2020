using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public enum Gamestatus
    {
        safe = 0,
        caution = 1,
        warning = 2
    }

    public Gamestatus Statusnum;

    // Start is called before the first frame update
    void Start()
    {
        switch (Statusnum)
        {
            case Gamestatus.safe: //safe,非警戒状態

                break;
            case Gamestatus.caution: //caution,警戒状態

                break;
            case Gamestatus.warning: //warning,戦闘状態

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (Statusnum)
        {
            case Gamestatus.safe: //safe,非警戒状態

                break;
            case Gamestatus.caution: //caution,警戒状態

                break;
            case Gamestatus.warning: //warning,戦闘状態

                break;
        }
        Debug.Log(Statusnum);
    }

    public Gamestatus GetStatus()
    {
        return Statusnum;
    }

    public void SetStatus(Gamestatus num)
    {
        Statusnum = num;
    }
}
