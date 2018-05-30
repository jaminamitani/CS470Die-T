using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

    GameObject playerManager;
    GameObject[] fightingPlayers;

	// Use this for initialization
	void Start () {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
        Debug.Log(playerManager.tag);
        fightingPlayers = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Attack(fightingPlayers[0].GetComponent<Character>().getPlayerNum(), fightingPlayers[1].GetComponent<Character>().getPlayerNum());
        Attack(fightingPlayers[1].GetComponent<Character>().getPlayerNum(), fightingPlayers[0].GetComponent<Character>().getPlayerNum());

        Destroy(fightingPlayers[0]);
        Destroy(fightingPlayers[1]);

        SceneManager.LoadScene("boardScene");
    }

    public void Attack(int currentPlayer, int otherPlayer)
    {
        playerManager.GetComponent<PlayerManager>().SetPlayerHealth(otherPlayer, playerManager.GetComponent<PlayerManager>().GetPlayerHealth(otherPlayer) - playerManager.GetComponent<PlayerManager>().GetPlayerAttack(currentPlayer));
    }
}
