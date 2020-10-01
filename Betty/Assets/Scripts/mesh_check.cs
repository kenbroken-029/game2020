using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh_check : MonoBehaviour
{
    [SerializeField] private GameObject Ray_post;
    private RaycastHit Hit_Ray;

    private List<Vector3> vertextList;
    private MeshFilter myMesh;
    private Vector3[] vertPos;
    // Start is called before the first frame update
    void Start()
    {
        vertextList = new List<Vector3>();

        myMesh = gameObject.GetComponent<MeshFilter>();

        vertPos = myMesh.mesh.vertices; 
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vertPos.Length; i++)
        {
            if (Physics.Raycast(gameObject.transform.position, new Vector3(0, Ray_post.transform.position.y - transform.position.y, Ray_post.transform.position.z - transform.position.z).normalized, out Hit_Ray))
            {
                Debug.DrawRay(gameObject.transform.position, (Ray_post.transform.position - gameObject.transform.position).normalized,Color.blue,Mathf.Infinity);
                vertextList.Add(vertPos[i]);
                vertextList[i] += new Vector3(Hit_Ray.point.x, Hit_Ray.point.y, Hit_Ray.point.z);
            }
        }
        Debug.Log(Hit_Ray.point);
        myMesh.mesh.SetVertices(vertextList);
    }
}
