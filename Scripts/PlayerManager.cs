using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private int[] playerHealth;
    private int[] playerAttack;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        playerHealth = new int[] { 20, 20, 20, 20 };
        playerAttack = new int[] { 5, 5, 5, 15 };
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetPlayerHealth(int player)
    {
        return playerHealth[player];
    }

    public void SetPlayerHealth(int player, int newHealth)
    {
        playerHealth[player] = newHealth;
    }

    public int GetPlayerAttack(int player)
    {
        return playerAttack[player];
    }
}