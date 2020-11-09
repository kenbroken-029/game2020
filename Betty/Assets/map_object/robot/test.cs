using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    //パーティクルを指定
    private ParticleSystem particle;


    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Simulate(5.0f, true, true);
        particle.Play();
    }
    //void Awake()
    //{
    //    StartCoroutine(testLoop(5f, () => {
    //        particle.Simulate(2.0f, true, true);
    //        particle.Play();
    //    }));
    //}

    ////FOR TEST
    //IEnumerator testLoop(float waitTme, UnityAction action)
    //{
    //    var waitTime = new WaitForSeconds(waitTme);
    //    while (true)
    //    {
    //        yield return waitTime;
    //        action();
    //    }
    //}
}
