using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Platform Movement Type: show the platform is going ti move 
public enum MovementType {
    line,
    circle ,
    zigzag
};

// Movment orientation (if is applicable)
public enum MovementOrientation {
    horizontal,
    vertical
}

public class MovingPlatform : MonoBehaviour
{

    // General vars
    [SerializeField]
    MovementType movementType;
    [SerializeField]
    MovementOrientation movementOrientation;
    public float speed = 5f;

    // Line movement vars
    public float lineMovementDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
