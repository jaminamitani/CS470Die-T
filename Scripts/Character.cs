using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void ResetMoves()
    {
        moves = 2;
    }
    void OnMouseOver()
    {
        m.material.color = selected;

        if (Input.GetMouseButtonDown(0))
        {
            
                master.SetActivePlayer(gameObject);
            
        }

    }

    public void ActiveStatus(bool a)
    {
        active = a;
    }

    public bool GetActive()
    {
        return active;
    }
    void OnMouseExit()
    {

        m.material.color = old;
    }

    private void Update()
    {

    }

    public void SetNum(int n)
    {
        playerNum = n;
    }

    public int getMoves()
    {
        return moves;
    }

    public void decMoves()
    {
        moves--;
    }
}
