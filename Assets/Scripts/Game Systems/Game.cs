using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Game : MonoBehaviour
{
    private static Game instance;
    public static Game Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Game>();
            return instance;
        }
    }

    public GameObject Castle;
}
