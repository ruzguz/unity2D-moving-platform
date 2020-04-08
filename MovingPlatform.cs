using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Platform Movement Type: show the platform is going ti move 
public enum MovementType {
    line,
    circular,
    zigzag
};

// Movment orientation (if is applicable)
public enum LineMovementOrientation {
    horizontal,
    vertical
}

public enum CircularMovementOrientation {
    clockwise,
    counterclockwise
}

public class MovingPlatform : MonoBehaviour
{

    // General vars
    [SerializeField]
    MovementType movementType;

    public float speed = 2f;
    Vector3 startPosition;
    public Color gizmoColor = Color.yellow;

    // Line movement vars
    public LineMovementOrientation lineMovementOrientation; 
    public float lineDistance = 5f; 

    // Circle movement vars
    public CircularMovementOrientation circularMovementOrientation;
    public float circleRadius = 5f;

    // Zigzag movement vars

    // Start is called before the first frame update
    void Start()
    {
        // Set start position
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Manage how the platform have to move 
        switch (movementType) {
            case MovementType.line:
                moveInAStraightLine();
            break;
            case MovementType.circular:
                MoveInCircles();
            break;
        }
    }


    // Move the platform in a straight line in movementOrientation
    public void moveInAStraightLine() 
    {
        // Get current coordenates 
        float x = startPosition.x;
        float y = startPosition.y;
        float z = startPosition.z;

        // Calculating next position according to the orientation selected
        switch (lineMovementOrientation) {
            case LineMovementOrientation.horizontal:
                x = startPosition.x + Mathf.Sin(Time.time * speed) * lineDistance;
            break;
            case LineMovementOrientation.vertical:
                y = startPosition.y + Mathf.Sin(Time.time * speed) * lineDistance;
            break;
        }

        // Moving platform
        this.transform.position = new Vector3(x,y,z);
    }

    public void MoveInCircles() 
    {
        // Calculating direction (CW or CCW)
        int direction = (circularMovementOrientation == CircularMovementOrientation.counterclockwise)?1:-1;

        // Calculating coordenates 
        float x = startPosition.x + Mathf.Cos(Time.time * speed * direction) * circleRadius;
        x -= circleRadius;
        float y = startPosition.y + Mathf.Sin(Time.time * speed * direction) * circleRadius;
        float z = transform.position.z;

        // Moving Platform
        this.transform.position = new Vector3(x,y,z);

    }

    // Funtion to see the platform path (only for debugging)
    private void OnDrawGizmosSelected() {
        Gizmos.color = gizmoColor;
        Vector3 src = Vector3.zero;

        switch (movementType) {
            case MovementType.line:
                src = new Vector3 (startPosition.x - lineDistance, startPosition.y);
                Vector3 dest = new Vector3 (startPosition.x + lineDistance, startPosition.y); 
                Gizmos.DrawLine(src, dest);
                src = new Vector3 (startPosition.x, startPosition.y - lineDistance);
                dest = new Vector3 (startPosition.x, startPosition.y + lineDistance); 
                Gizmos.DrawLine(src, dest);
            break;
            case MovementType.circular:
                // Cicular movement 
                src = new Vector3(startPosition.x - circleRadius, startPosition.y);
                Gizmos.DrawWireSphere(src, circleRadius);
            break;
            case MovementType.zigzag:
            break;
        }
    }

}