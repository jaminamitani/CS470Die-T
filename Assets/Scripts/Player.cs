using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    MeshRenderer m;
    private GameObject[] characterRoster = new GameObject[3];
    private int playerNumber;


   

    public void Activate()
    {
        for(int i = 0; i < characterRoster.Length; i++)
        {
            Character ch = characterRoster[i].GetComponent<Character>();
            ch.ActiveStatus(false);
            Debug.Log(ch.GetActive());
            ch.ResetMoves();
            Debug.Log(ch.getMoves());
        }
    }

    public void DeActivate()
    {
        for (int i = 0; i < characterRoster.Length; i++)
        {
            Character ch = characterRoster[i].GetComponent<Character>();
            ch.ActiveStatus(false);
        }
    }
	// Use this for initialization
	void Start () {

    
        
    }

    public void setCharacter(GameObject c, int index)
    {
        characterRoster[index] = c;
    }

    public GameObject[] getCharacter()
    {
        return characterRoster;
    }

    public void setNum(int n)
    {
        playerNumber = n;
    }

    public int getNum()
    {
        return playerNumber;
    }

    public bool TurnDone()
    {
        for(int i = 0; i < characterRoster.Length; i++)
        {
            Character ch = characterRoster[i].GetComponent<Character>();
            if(ch.GetActive())
            {
                return false;
            }
        }

        return true;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
