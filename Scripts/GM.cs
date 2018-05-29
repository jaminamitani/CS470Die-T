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
	// Use this for initialization
	void Start () {
        
        
        turn = 0;
        act = 0;
        MakeMap();
        SpawnCharacters();
		
	}

    //Populates Scene with tiles using a 2D array as a reference
    void MakeMap()
    {
        map = new string[5, 5];
        for (int i = 0; i < 5; i++)
        {
            map[0, i] = "X";
            map[i, 0] = "X";
            map[4, i] = "X";
            map[i, 4] = "X";
        }
        float x;
        float z;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                x = 10 * i;
                z = 10 * j;
                if (map[i, j] != null && map[i, j].Equals("X"))
                {
                    GameObject t = (GameObject)Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity);
                }


            }


        }
    }

    //Spawns characters into spaces on the map and places them in the array of current players
    void SpawnCharacters()
    {
        characterCount = 3;
        characterRoster = new GameObject[5];

        
            characterRoster[0] = (GameObject)Instantiate(character, new Vector3(0, 0.5f, 0), Quaternion.identity);
            characterRoster[1] = (GameObject)Instantiate(character, new Vector3(40, 0.5f, 0), Quaternion.identity);
            characterRoster[2] = (GameObject)Instantiate(character, new Vector3(0, 0.5f, 40), Quaternion.identity);
            characterRoster[3] = (GameObject)Instantiate(character, new Vector3(40, 0.5f, 40), Quaternion.identity);

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
            if(act == 4)
            {
                act = 0;
                for(int i = 0; i < 4; i++)
                {
                    ch = characterRoster[i].GetComponent<Character>();
                    ch.ResetMoves();
                }
            }
        }
	}
}
