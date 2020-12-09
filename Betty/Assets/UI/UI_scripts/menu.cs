using UnityEngine;

using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public GameObject StageSelectCanvas;

    public GameObject TopCanvas;

    private void Start()
    {
        TopCanvas.SetActive(true);
    }

    public void Push_StageSelectButton()
    {
        StageSelectCanvas.SetActive(true);
        TopCanvas.SetActive(false);
    }

    public void Push_TutorialButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
