using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRunner : MonoBehaviour {

    public GameObject tile;
    public GameObject character;
    public GameObject player;
    GameObject[] playerRoster;
    GameObject[] characters = new GameObject[3];
    private int playerCount;
    GameObject c;
    int current;
    bool gameDone;
    int Rounds;
    // Use this for initialization
    void Start()
    {
        Rounds = 1;
        current = 0;
        gameDone = false;
        playerCount = 2;

        playerRoster = new GameObject[playerCount];
        float x;
        float z;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                x = 10 * i;
                z = 10 * j;
                GameObject t = (GameObject)Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity);


            }


        }

        for (int j = 0; j < playerRoster.Length; j++)
        {
            playerRoster[j] = (GameObject)Instantiate(player, new Vector3(0, 0.5f, 0), Quaternion.identity);
            Player pl = playerRoster[j].GetComponent<Player>();
            for (int i = 0; i < characters.Length; i++)
            {
                 pl.setCharacter((GameObject)Instantiate(character, new Vector3(20 * j, 0.5f, 10 * i), Quaternion.identity) , i);
            }
            
        }
        
    }
    private void Update()
    {

        if (!gameDone)
        {
            Debug.Log("Round: " + Rounds);
            Player pl = playerRoster[current].GetComponent<Player>();
            Debug.Log("Player " + (current + 1) + " Turn");


            for (int i = 0; i < characters.Length; i++)
            {
                Character ch = pl.getCharacter()[i].GetComponent<Character>();
                if (ch.getMoves() == 0)
                {
                    ch.ActiveStatus(false);
                    Debug.Log("Out of Moves");
                }
                else
                {
                    ch.ActiveStatus(true);
                }
            }

            if (pl.TurnDone())
            {
                current++;
                if (current == 2)
                {
                    Rounds++;
                    pl = playerRoster[1].GetComponent<Player>();
                    pl.Activate();
                    current = 0;
                    pl = playerRoster[current].GetComponent<Player>();
                    pl.Activate();
                }
            }

            if (Rounds > 5)
            {
                gameDone = true;
            }
        }
        else
        {
            Debug.Log("Game Done");
        }

    }
}
