using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MovementType {
    line,
    circle ,
    zigzag
};

public class MovingPlatform : MonoBehaviour
{

    // General vars
    [SerializeField]
    MovementType movementType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
