using UnityEngine;

public class StageStatus : MonoBehaviour
{
    [SerializeField] private Transform Player_pos;
    [SerializeField] private Material Wall_mat;
    private Color color;
    private float Alphacolor = 1.0f;
    private float ChangeAlphacolor = 0.2f;
    private Vector3 Back_pos;

    [SerializeField] GameObject gamestatus;
    [SerializeField] Light[] Gameobject;

    // Start is called before the first frame update
    void Start()
    {
        color = Wall_mat.color;
        Back_pos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_pos.position.z > Back_pos.z)
        {
            color.a = ChangeAlphacolor;
            Wall_mat.color = color;
        }
        else
        {
            color.a = Alphacolor;
            Wall_mat.color = color;
        }

        foreach (Light light in Gameobject)
        {
            light.color = new Color(1, 0, 0, 1);
        }
    }
}
