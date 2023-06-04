using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }
    public inputController InputController { get; private set; }
    private void Awake()
    {
        Instance = this;
        InputController = GetComponentInChildren<inputController>();
    }

}
