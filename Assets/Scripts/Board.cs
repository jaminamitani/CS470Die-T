using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject tile;

    private GameObject[,] board;

    // Use this for initialization
    void Start()
    {
        board = new GameObject[11, 11];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            board[i, 0] = Instantiate(tile, new Vector3(i * 10, 0, 0), Quaternion.identity);
            board[i, 10] = Instantiate(tile, new Vector3(i * 10, 0, 100), Quaternion.identity);
        }

        for (int i = 1; i < board.GetLength(0) - 1; i++)
        {
            board[1, i] = Instantiate(tile, new Vector3(0, 0, i * 10), Quaternion.identity);
            board[9, i] = Instantiate(tile, new Vector3(100, 0, i * 10), Quaternion.identity);
        }

        for (int i = 1; i < board.GetLength(0) - 1; i++)
        {
            board[board.GetLength(0) / 2, i] = Instantiate(tile, new Vector3((board.GetLength(0) / 2) * 10, 0, i * 10), Quaternion.identity);
        }

        for (int i = 1; i < board.GetLength(0) - 1; i++)
        {
            if (i != board.GetLength(0) / 2)
            {
                board[i, board.GetLength(0) / 2] = Instantiate(tile, new Vector3(i * 10, 0, (board.GetLength(0) / 2) * 10), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
