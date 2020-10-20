using System.Collections.Generic;
using UnityEngine;

public class BeltConveyor : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 Direction;
    [SerializeField] private float currentspeed { get { return _currentspeed; } }
    [SerializeField] private float forcepower;
    private float _currentspeed;
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [SerializeField] private bool moveflg;

    // Start is called before the first frame update
    void Start()
    {
        Direction = Direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        _currentspeed = moveflg ? Speed : 0;
    }
}
