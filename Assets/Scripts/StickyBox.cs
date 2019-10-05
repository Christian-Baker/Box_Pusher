using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBox : MonoBehaviour
{
    public bool m_OnCircle;
    public bool m_OnHole = false;
    private SpriteRenderer rend;
    private Sprite Box_Hole;

    public void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Box_Hole = Resources.Load<Sprite>("Sticky_Box_in_Hole");
    }

    public bool Move(Vector2 direction)
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            //lastPosition.writeLastPosition();
            transform.Translate(direction / 4);
            TestForOnCircle();
            TestForOnHole();
            return true;
        }
    }

    bool BoxBlocked(Vector3 position, Vector2 direction)
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
                return true;
            }
        }

        GameObject[] slides = GameObject.FindGameObjectsWithTag("Slide");
        foreach (var slide in slides)
        {
            if (slide.transform.position.x == newPosition.x && slide.transform.position.y == newPosition.y)
            {
                return true;
            }
        }
        

        GameObject[] sticks = GameObject.FindGameObjectsWithTag("Stick");
        foreach (var stick in sticks)
        {
            if (stick.transform.position.x == newPosition.x && stick.transform.position.y == newPosition.y)
            {
                return true;
            }
        }
        return false;
    }

    void TestForOnCircle()
    {
        GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
        foreach (var circle in circles)
        {
            if (transform.position.x == circle.transform.position.x && transform.position.y == circle.transform.position.y)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
                m_OnCircle = true;
                return;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        m_OnCircle = false;
    }

    void TestForOnHole()
    {
        GameObject[] holes = GameObject.FindGameObjectsWithTag("Hole");
        GameObject[] sticks = GameObject.FindGameObjectsWithTag("Stick");

        foreach (var hole in holes)
        {
            if (transform.position.x == hole.transform.position.x && transform.position.y == hole.transform.position.y)
            {
                foreach (var stick in sticks)
                {
                    if (stick.transform.position.x == hole.transform.position.x && stick.transform.position.y == hole.transform.position.y)
                    {
                        stick.tag = "Untagged";
                        Object.Destroy(hole);
                        rend.sprite = Box_Hole;
                        m_OnHole = true;
                        rend.sortingOrder = -3;
                    }
                }
                return;
            }
        }
    }
}
