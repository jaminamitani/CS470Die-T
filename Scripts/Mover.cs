using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    GameObject character;
    GameObject space;
    RaycastHit hit;
    GameObject activePlayer;
    GameObject activeSpace;
    Character c;
    Tile t;
    float s = 50;
    bool select;
    float x1;
    float x2;
    float z1;
    float z2;
    float offset;
    Vector3 dest;

    
     /*
      * Select is true when a piece is currently in motion and false otherwise
      * Use of Mover's functions is unavailable while Select is true to avoid interrupting movement
      */
    void Start()
    {
        select = false;

    }


    /*
     * Sets the player selected to be moved
     */
    public void SetActivePlayer(GameObject g)
    {

        if (!select)
        {
           
            activePlayer = g;
            c = activePlayer.GetComponent<Character>();
            
            
        }
    }

    /*
     * Sets the space for the selected player to move to
     * Player must be selected first for this to be filled
     */
    public void SetActiveSpace(GameObject g)
    {
        if (!select)
        {
            if (activePlayer != null)
            {
                activeSpace = g;
              
                select = true;
                Character ch = activePlayer.GetComponent<Character>();
                ch.decMoves();

            }
            else
            {
                Debug.Log("No Player Selected");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {




        //actual movement process
        if (activePlayer != null && activeSpace != null)
        {
            Character ch = activePlayer.GetComponent<Character>();
            x1 = activePlayer.transform.position.x;
            x2 = activeSpace.transform.position.x;
            z1 = activePlayer.transform.position.z;
            z2 = activeSpace.transform.position.z;
            //Checks to ensure that character being moved can only move to adjacent spaces (No diagonals)
            if (Mathf.Abs(x1 - x2) + Mathf.Abs(z1 - z2) <= 10)
            {
                //while Select is true, player will move toward destination (center of activeSpace tile)
                if (select)
                {
                    dest = new Vector3(activeSpace.transform.position.x, activePlayer.transform.position.y, activeSpace.transform.position.z);
                    activePlayer.transform.position = Vector3.MoveTowards(activePlayer.transform.position, dest, s * Time.deltaTime);
                }
                //Once the player has reached the destination, Mover functions become cleared and ready for use again
                if (activePlayer.transform.position == dest)
                {
                    select = false;
                    
                    activeSpace = null;
                    //if this action was the character's last move, the active player will be cleared to avoid further movement
                    if(ch.getMoves() <= 0)
                    {
                        activePlayer = null;
                    }

                }
            }
            else
            {
                select = false;
            }

        }
    }
}
