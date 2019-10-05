/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element
{
    public string m_Character;
    public GameObject m_Prefab;

}
public class Undo : MonoBehaviour
{
    public Button m_Undo;
    public GameObject[] prefabPlayer;
    public GameObject[] prefabBox;
    public GameObject[] prefabSliding;
    public GameObject[] prefabSticky;
    public GameObject[] prefabHole;

    private void Start()
    {
    }


    public void Update()
    {
       if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("U pressed");
            TaskOnClick();
        }
    }
   
public static void TaskOnClick()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] slidings = GameObject.FindGameObjectsWithTag("Stick");
        GameObject[] stickies = GameObject.FindGameObjectsWithTag("Slide");
        GameObject[] holes = GameObject.FindGameObjectsWithTag("Holes");

        foreach (var box in boxes)
        {
            Destroy(box);
        }
        foreach (var player in players)
        {
            Destroy(player);
        }
        foreach (var sliding in slidings)
        {
            Destroy(sliding);
        }
        foreach (var sticky in stickies)
        {
            Destroy(sticky);
        }
        foreach (var hole in holes)
        {
            Destroy(hole);
        }
                    
        string[] boxLines = System.IO.File.ReadAllLines(@"C:\Users\Christian\Desktop\Box Pusher\Assets\Resources\Box_Position.txt");
		string[] playerLines = System.IO.File.ReadAllLines(@"C:\Users\Christian\Desktop\Box Pusher\Assets\Resources\Player_Position.txt");
		string[] slidingLines = System.IO.File.ReadAllLines(@"C:\Users\Christian\Desktop\Box Pusher\Assets\Resources\Sliding_Position.txt");
		string[] stickyLines = System.IO.File.ReadAllLines(@"C:\Users\Christian\Desktop\Box Pusher\Assets\Resources\Sticky_Position.txt");
		string[] holeLines = System.IO.File.ReadAllLines(@"C:\Users\Christian\Desktop\Box Pusher\Assets\Resources\Hole_Position.txt");
		
		foreach (string boxLine in boxLines)
        {

            int indexX = boxLine.IndexOf("x");
            int indexComma = boxLine.IndexOf(",");
            indexX += 3;

            string xString = boxLine.Substring(indexX, indexComma);
            
            int indexY = boxLine.IndexOf("y");
            indexY += 3;
            string yString = boxLine.Substring(indexY);
            int x = int.Parse(xString);
            int y = int.Parse(yString);
            Instantiate(prefabBox, new Vector3(x, y, 0), Quaternion.identity).GetComponent<Box>();
        }
		
		foreach (string playerLine in playerLines)
        {
            int indexX = playerLine.IndexOf("x");
            int indexComma = playerLine.IndexOf(",");
            indexX += 3;

            string xString = playerLine.Substring(indexX, indexComma);

            int indexY = playerLine.IndexOf("y");
            indexY += 3;
            string yString = playerLine.Substring(indexY);
            int x = int.Parse(xString);
            int y = int.Parse(yString);
            Instantiate(prefabPlayer, new Vector2(x, y), Quaternion.identity).GetComponent<Player>(); ;
        }
		
		foreach (string slidingLine in slidingLines)
        {
            int indexX = slidingLine.IndexOf("x");
            int indexComma = slidingLine.IndexOf(",");
            indexX += 3;

            string xString = slidingLine.Substring(indexX, indexComma);

            int indexY = slidingLine.IndexOf("y");
            indexY += 3;
            string yString = slidingLine.Substring(indexY);
            int x = int.Parse(xString);
            int y = int.Parse(yString);
            Instantiate(prefabSliding, new Vector2(x, y), Quaternion.identity).GetComponent<SlideBox>(); ;
        }
		
		foreach (string stickyLine in stickyLines)
        {
            int indexX = stickyLine.IndexOf("x");
            int indexComma = stickyLine.IndexOf(",");
            indexX += 3;

            string xString = stickyLine.Substring(indexX, indexComma);

            int indexY = stickyLine.IndexOf("y");
            indexY += 3;
            string yString = stickyLine.Substring(indexY);
            int x = int.Parse(xString);
            int y = int.Parse(yString);
            Instantiate(prefabSticky, new Vector2(x, y), Quaternion.identity).GetComponent<StickyBox>(); ;
        }
		
		foreach (string holeLine in holeLines)
        {
            int indexX = holeLine.IndexOf("x");
            int indexComma = holeLine.IndexOf(",");
            indexX += 3;

            string xString = holeLine.Substring(indexX, indexComma);

            int indexY = holeLine.IndexOf("y");
            indexY += 3;
            string yString = holeLine.Substring(indexY);
            int x = int.Parse(xString);
            int y = int.Parse(yString);
            Instantiate(prefabHole, new Vector2(x, y), Quaternion.identity).GetComponent<Hole>(); ;
        }
		
    }
}
*/