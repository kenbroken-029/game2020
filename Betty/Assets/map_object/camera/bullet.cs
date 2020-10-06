using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform Player;
    private Vector3 PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
        PlayerPos = Player.position;
        //transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * 1);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * 1);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, PlayerPos, Time.deltaTime);
    }
}
