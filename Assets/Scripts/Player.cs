using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite right, left, forward, back;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        right = Resources.Load<Sprite>("Player_Right");
        left = Resources.Load<Sprite>("Player_Left");
        forward = Resources.Load<Sprite>("Player_Forward");
        back = Resources.Load<Sprite>("Player_Back");
    }

    
    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();

        if(Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            if (direction.x > 0)
            {
                rend.sprite = right;
            }
            else if (direction.y > 0)
            {
                rend.sprite = forward;
            }
            else if(direction.y < 0)
            {
                rend.sprite = back;
            }
            else
            {
                rend.sprite = left;
            }

            //checks if there is a stickybox adjacent to the player
            // if there is then that box moves in the same direction as the player if it is able to
            GameObject[] sticks = GameObject.FindGameObjectsWithTag("Stick");
            foreach (var stick in sticks)
            {
                if (stick.transform.position.x == transform.position.x + 1 && stick.transform.position.y == transform.position.y ||
                    stick.transform.position.x == transform.position.x - 1 && stick.transform.position.y == transform.position.y ||
                    stick.transform.position.x == transform.position.x && stick.transform.position.y == transform.position.y + 1 ||
                    stick.transform.position.x == transform.position.x && stick.transform.position.y == transform.position.y - 1)
                {
                    StickyBox bx = stick.GetComponent<StickyBox>();
                    bx.Move(direction);

                }
            }
            transform.Translate(direction / 4);
            return true;
        }
    }

    public bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPosition = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPosition.x && wall.transform.position.y == newPosition.y)
            {
                return true;
            }
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPosition.x && box.transform.position.y == newPosition.y)
            { 
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        GameObject[] slides = GameObject.FindGameObjectsWithTag("Slide");
        foreach (var slide in slides)
        {
            if (slide.transform.position.x == newPosition.x && slide.transform.position.y == newPosition.y)
            {
                SlideBox sd = slide.GetComponent<SlideBox>();
                if (sd && sd.Move(direction))
                {
                    sd.moving = true;
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        GameObject[] sticks = GameObject.FindGameObjectsWithTag("Stick");
        foreach (var stick in sticks)
        {
            if (stick.transform.position.x == newPosition.x && stick.transform.position.y == newPosition.y)
            {
                StickyBox bx = stick.GetComponent<StickyBox>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
           
        }
    
        GameObject[] holes = GameObject.FindGameObjectsWithTag("Hole");
        foreach (var hole in holes)
        {
            if (hole.transform.position.x == newPosition.x && hole.transform.position.y == newPosition.y)
            {
                return true;
            }
        }

        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (var door in doors)
        {
            if (door.transform.position.x == newPosition.x && door.transform.position.y == newPosition.y)
            {
                Door dr = door.GetComponent<Door>();
                if (!(dr.IsOpen()))
                    return true;
            }
        }

        return false;
    }

}
