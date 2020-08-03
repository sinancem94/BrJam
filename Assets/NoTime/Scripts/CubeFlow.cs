using System;
using System.Collections;
using System.Collections.Generic;
using RewindEngine;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeFlow : Rewindable
{
    protected enum Direction
    {
        Right = 0,
        Left,
        Down,
        Up
    }

    [Range(0,10)]public float speed;
    
    private Direction currDirection;
    private List<Direction> unCollidedDirections;
    
    void Start()
    {
        currDirection = (Direction)Random.Range(0, 4);
        unCollidedDirections = new List<Direction>(4) {(Direction) 0, (Direction) 1, (Direction) 2, (Direction) 3};
        
        speed = speed / 100;
        Debug.Log(currDirection);

        //unCollidedDirections.AddRange(new List<Direction>() {(Direction)0,(Direction)1,(Direction)2,(Direction)3});
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
        if (rewindState == State.Normal || clock.localTimeScale > 0f)
        {
            switch (currDirection)
            {
                case Direction.Down:
                    transform.position += Vector3.back * speed;
                    break;
                case Direction.Up:
                    transform.position += Vector3.forward * speed;
                    break;
                case Direction.Left:
                    transform.position += Vector3.left * speed;
                    break;
                case Direction.Right:
                    transform.position += Vector3.right * speed;
                    break;
                default:
                    break;
                    
            }
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Direction collidedDirection = currDirection;
            
            if(unCollidedDirections.Exists(direction => direction == currDirection))
                unCollidedDirections.Remove((Direction)currDirection);
        
            //var random = new System.Random();
            //currDirection = (Direction)random.Next(unCollidedDirections.Count);

            currDirection = GetRandomDirectionWithout(currDirection);
         /*   if (collidedDirection == currDirection)
            {
                currDirection =
            }*/
            
            Debug.Log(currDirection);
        }
       

    }

    Direction GetRandomDirectionWithout(Direction unwanteDirection)
    {
        Direction dirr = (Direction)Random.Range(0, 4);
        if (dirr == unwanteDirection)
        {
            dirr = GetRandomDirectionWithout(unwanteDirection);
        }
        return dirr;

    }
}
