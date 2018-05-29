using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	MeshRenderer m;
    Color selected;
    Color old;
    Mover master;
    float playerCount;
    float offset;
    public GameObject control;
    void Start()
    {
        m = GetComponent<MeshRenderer>();
        selected = Color.red;
        old = m.material.color;
        offset = 0;
        playerCount = 0;
        master = Camera.main.GetComponent<Mover>();
    }

    public void SetMover()
    {

    }
    //Highlights tile on mouseover
    void OnMouseOver()
    {
        m.material.color = selected;

        //Sends tile as active tile to be moved to in Mover script when clicked
        if (Input.GetMouseButtonDown(0))
        {
            master.SetActiveSpace(gameObject);
        }

    }

    public void addPlayer()
    {
        playerCount++;
        if(playerCount > 0)
        {
            offset = 3;
        }
    }

    public float getOffset()
    {
        return offset;
    }

    //returns tile to normal color when mouse is not on it
    void OnMouseExit()
    {

        m.material.color = old;
    }
}
