using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_Control : MonoBehaviour
{
    private RaycastHit Hit_player;

    [SerializeField] GameObject gameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log(col.tag);

            if (Physics.Raycast(gameobject.transform.position, (col.transform.position - gameobject.transform.position).normalized,out Hit_player))
            {
                Debug.DrawRay(gameobject.transform.position, (col.transform.position - gameobject.transform.position).normalized, Color.red, Mathf.Infinity);
                if(Hit_player.collider.tag == "Player")
                {
                    Debug.Log("Ray_Hit");
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }
}
