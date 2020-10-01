using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashbreak : MonoBehaviour
{
    [SerializeField]
    float breakValue = 0.1f;

    void Start()
    {
        List<Vector3> vertextList = new List<Vector3>();

        MeshFilter myMesh = this.gameObject.GetComponent<MeshFilter>();

        Vector3[] vertPos = myMesh.mesh.vertices;

        for (int i = 0; i < vertPos.Length; i++)
        {
            vertextList.Add(vertPos[i]);
            vertextList[i] += new Vector3(Random.Range(-breakValue, breakValue), Random.Range(-breakValue, breakValue), 0);
        }

        myMesh.mesh.SetVertices(vertextList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
