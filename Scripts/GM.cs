using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    public GameObject tile;
    public GameObject character;
    GameObject[] characterRoster;
    int characterCount;
    int turn;
    int action;
    string[,] map;
	// Use this for initialization
	void Start () {
        
        
        turn = 0;
        MakeMap();
        SpawnCharacters();
		
	}

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

    void SpawnCharacters()
    {
        characterCount = 3;
        characterRoster = new GameObject[5];

        
            characterRoster[0] = (GameObject)Instantiate(character, new Vector3(0, 0.5f, 0), Quaternion.identity);
            characterRoster[0] = (GameObject)Instantiate(character, new Vector3(40, 0.5f, 0), Quaternion.identity);
            characterRoster[0] = (GameObject)Instantiate(character, new Vector3(0, 0.5f, 40), Quaternion.identity);
            characterRoster[0] = (GameObject)Instantiate(character, new Vector3(40, 0.5f, 40), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
