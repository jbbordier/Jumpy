using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameState state;
    internal bool isHammerFire;

    public bool IsHammerReady { get;  set; }

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Menu;
        IsHammerReady = true;
    }


    private void Update()
    {
        
    }

}

public enum GameState
{
    Menu,
    Building,
    Playing,
    Pause
}
