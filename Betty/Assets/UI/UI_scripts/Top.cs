using UnityEngine;
using UnityEngine.UI;

public class Top : MonoBehaviour
{
    public Button StageSelectButton;

    private void OnEnable()
    {
        Debug.Log("onenable");
        StageSelectButton.Select();
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    Debug.Log("Start");
    //    // 最初に選択状態にしたいボタンの設定
    //    StageSelectButton.Select();
    //}

    private void Update()
    {
        //if (Input.GetButtonDown("Cancel"))
        //{
        //    MenuController.SetActive(true);
        //    gameObject.SetActive(false);
        //    Debug.Log("a;oidfgh");
        //}
    }
}
