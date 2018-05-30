using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    MeshRenderer m;
    Color selected;
    Color old;
    Mover master;
    int moves;
    private int playerNum;
    public GameObject control;
    public GameObject rule;
    bool active;
    int health;
    int attack;
    int def;

    Vector3 previousPosition;

    void Start()
    {
        moves = 2;
        m = GetComponent<MeshRenderer>();
        m.material.color = Color.black;
        selected = Color.blue;
        old = m.material.color;
        active = false;
        master = Camera.main.GetComponent<Mover>();

    }

    //Number of possible actions for this character
    public void ResetMoves()
    {
        moves = 2;
    }

    //Mouseover options
    void OnMouseOver()
    {
        //Highlights character when moves moves over it
        m.material.color = selected;

        //When character is selected
        if (Input.GetMouseButtonDown(0))
        {
            //If it's not this player's turn, character will not be active
            if (!GetActive())
            {
                Debug.Log("Player is not active");
            }
            else
            {
                //Sets this character to be moved using the mover script
                previousPosition.Set(transform.position.x, transform.position.y, transform.position.z);
                master.SetActivePlayer(gameObject);
            }
        }

    }

    //True when it is this character's turn to act, false otherwise
    public void ActiveStatus(bool a)
    {
        active = a;
    }

    //Return active
    public bool GetActive()
    {
        return active;
    }

    //Returns to previous color when not under mouse cursor
    void OnMouseExit()
    {

        m.material.color = old;
    }

    private void Update()
    {

    }

    
    //get remaining number of actions this character has
    public int getMoves()
    {
        return moves;
    }

    //Use to decrease remaining moves after each action
    public void decMoves()
    {
        moves--;
    }

    public int getAttack()
    {
        return attack;
    }
    public int getHealth()
    {
        return health;
    }
    public int getDefense()
    {
        return def;
    }

    public void setAttack(int n)
    {
        attack = n;
    }
    public void setHealth(int n)
    {
        health = n;
    }
    public void setDefense(int n)
    {
        def = n;
    }

    public void setPreviousPosition(Vector3 previousPosition_)
    {
        previousPosition = previousPosition_;
    }

    public void setPlayerNum(int playerNum_)
    {
        playerNum = playerNum_;
    }

    public int getPlayerNum()
    {
        return playerNum;
    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player Collision");
            transform.position = previousPosition;

            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("battleScene");
        }
    }
}
