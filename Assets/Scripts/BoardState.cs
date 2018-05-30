using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoardState
{
    private static GameObject[,] tileMap;
    private static GameObject[] characterRoster;

    public static GameObject[,] TileMap
    {
        get
        {
            return tileMap;
        }
        set
        {
            tileMap = value;
        }
    }

    public static GameObject[] CharacterRoster
    {
        get
        {
            return characterRoster;
        }
        set
        {
            characterRoster = value;
        }
    }
}
