using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public GameObject TopCanvas;
    public Button tutorial;

    private void OnEnable()
    {
        //StageSelectmenu.SetActive(true);
        tutorial.Select();
        Debug.Log("OnEnable_Exit");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TopCanvas.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("StageSelectCanvas---false---");
        }
    }
}
