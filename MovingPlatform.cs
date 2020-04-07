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

    public float speed = 5f;
    Vector3 startPosition;

    // Line movement vars
    public MovementOrientation lineMovementOrientation;
    public float lineDistance = 5f;
    bool lineMovingPositive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set start position
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Manage how the platfomr have to move 
        switch (movementType) {
            case MovementType.line:
                moveInAStraightLine();
            break;
        }
    }


    // Move the platform in a straight line in movementOrientation
    public void moveInAStraightLine() 
    {
        // Calculating final position depending of the orientation
        float finalPosition = lineDistance + ((this.lineMovementOrientation == MovementOrientation.vertical)?startPosition.y:startPosition.x);
        

        // Moving the platform according to the orientation
        switch (lineMovementOrientation) {
            case MovementOrientation.horizontal:
                // Calculating path
                LMCalculateMovingPositive(this.transform.position.x, startPosition.x, finalPosition);
                // Moving to the right 
                if (lineMovingPositive) {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
                } else {
                // Moving to the left
                   transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y); 
                } 
            break;
            case MovementOrientation.vertical:
                // Calculating path
                LMCalculateMovingPositive(this.transform.position.y, startPosition.y, finalPosition);
                if (lineMovingPositive) {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
                } else {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
                }
            break;
        }
    }

    // Change LMMovvingPositive according to the limits
    void LMCalculateMovingPositive(float currentPosition, float min, float max) {
        if (currentPosition >= max) {
            lineMovingPositive = false;
        } else if (currentPosition <= min) {
            lineMovingPositive = true;
        }
    }

}
