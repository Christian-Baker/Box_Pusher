using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Switch class only checks whether there is a Box or a Player ontop of a switch. 
 */
public class Switch : MonoBehaviour
{
    /** Checks for Boxes */
    public bool BoxOnSwitch()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (transform.position.x == box.transform.position.x && transform.position.y == box.transform.position.y)
            {
                return true;
            }
        }
        return false;
    }
    /** Checks for Players */
    public bool PlayerOnSwitch()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (transform.position.x == player.transform.position.x && transform.position.y == player.transform.position.y)
            return true;
        return false;
    }
}
