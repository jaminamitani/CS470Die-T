using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

    PlayerManager playerManager;
    GameObject[] fightingPlayers;

	// Use this for initialization
	void Start () {
        fightingPlayers = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Attack(fightingPlayers[0].GetComponent<Character>().getPlayerNum(), fightingPlayers[1].GetComponent<Character>().getPlayerNum());
        Attack(fightingPlayers[1].GetComponent<Character>().getPlayerNum(), fightingPlayers[0].GetComponent<Character>().getPlayerNum());

        SceneManager.LoadScene("boardScene");
    }

    public void Attack(int currentPlayer, int otherPlayer)
    {
        playerManager.SetPlayerHealth(otherPlayer, playerManager.GetPlayerHealth(otherPlayer) - playerManager.GetPlayerAttack(currentPlayer));
    }
}
