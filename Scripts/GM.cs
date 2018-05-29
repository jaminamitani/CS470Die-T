using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    public GameObject tile;
    public GameObject character;
    GameObject[] characterRoster;
    int characterCount;
    int turn;
    int act;
    string[,] map;
    GameObject[,] tileMap;
    GameObject t;
    Mover s;
	// Use this for initialization
	void Start () {

        s = Camera.main.GetComponent<Mover>();
        turn = 0;
        act = 0;
        PlanMap();
        MakeMap();
        SpawnCharacters();
		
	}

    //This marks the string layout with X's that the MakeMap() function will use later to spawn the map into place
    void PlanMap()
    {
        map = new string[10, 12];
        for (int i = 0; i < 11; i++)
        {
            map[6, i] = "X";
        }
        for (int i = 1; i < 11; i++)
        {
            map[1, i] = "X";
        }
        map[0, 6] = "X";
        map[0, 10] = "X";
        map[2, 0] = "X";
        map[2, 1] = "X";
        map[2, 3] = "X";
        map[2, 6] = "X";
        map[2, 10] = "X";
        map[3, 0] = "X";
        map[3, 3] = "X";
        map[3, 4] = "X";
        map[3, 5] = "X";
        map[3, 6] = "X";
        map[3, 8] = "X";
        map[3, 10] = "X";
        map[3, 11] = "X";
        map[4, 0] = "X";
        map[4, 1] = "X";
        map[4, 2] = "X";
        map[4, 3] = "X";
        map[4, 6] = "X";
        map[4, 7] = "X";
        map[4, 8] = "X";
        map[4, 9] = "X";
        map[4, 10] = "X";
        map[5, 1] = "X";
        map[5, 3] = "X";
        map[5, 5] = "X";
        map[5, 7] = "X";
        map[5, 10] = "X";
        map[7, 2] = "X";
        map[7, 4] = "X";
        map[7, 7] = "X";
        map[8, 2] = "X";
        map[8, 3] = "X";
        map[8, 4] = "X";
        map[8, 5] = "X";
        map[8, 6] = "X";
        map[8, 7] = "X";
        map[9, 6] = "X";
    }

    /* Populates Scene with tiles using a 2D array as a reference
    * Map is the layout, tileMap is an array of the actual tiles for interaction purposes
    * Game should use tileMap to find out if the tile that the player is currently on has
    * special properties, and act accordingly
    */
    void MakeMap()
    {
        
        tileMap = new GameObject[10, 12];
        
        float x;
        float z;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                x = 10 * i;
                z = 10 * j;
                if (map[i, j] != null && map[i, j].Equals("X"))
                {
                    tileMap[i, j] = (GameObject)Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity);
                    
                }


            }


        }
    }

    //Spawns characters into spaces on the map and places them in the array of current players
    void SpawnCharacters()
    {
        characterCount = 3;
        characterRoster = new GameObject[5];

        
            characterRoster[0] = (GameObject)Instantiate(character, new Vector3(20, 0.5f, 10), Quaternion.identity);
            characterRoster[1] = (GameObject)Instantiate(character, new Vector3(60, 0.5f, 0), Quaternion.identity);
            characterRoster[2] = (GameObject)Instantiate(character, new Vector3(90, 0.5f, 60), Quaternion.identity);
            characterRoster[3] = (GameObject)Instantiate(character, new Vector3(30, 0.5f, 80), Quaternion.identity);

    }
	
	/*
     * This update function contains the turn system
     * 
     * At the start of each turn, the player at the current array position (designated using 'act' as the index) is activated
     * 
     * functions for actions in other scripts (like the Mover) decrease the character's move counter
     * 
     * when the move counter hits 0, 'act' is incremented to activate the next character, the
     * current character is deactivated, and the program signals that the current character's turn is done
     * 
     * if it's reached the end of the character roster (hard coded as being size 4 here because characterRoster.length was 
     * casuing problems), 'act' will be reset to 0 and all of the characters in the roster will have their available
     * moves restored
     */
	void Update () {
        Character ch = characterRoster[act].GetComponent<Character>();
        ch.ActiveStatus(true);

        if (ch.getMoves() <= 0)
        {
            Debug.Log("Player " + (act + 1) + " turn done");
            ch.ActiveStatus(false);
            act++;
            if (act < 4)
            {
                ch = characterRoster[act].GetComponent<Character>();
                ch.ResetMoves();
            }
        }

        if (act == 4)
        {
            act = 0;
            
                ch = characterRoster[0].GetComponent<Character>();
                ch.ResetMoves();
        }
    }
}
