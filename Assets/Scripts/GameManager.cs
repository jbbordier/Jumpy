using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    private GameState state;
    public GameState State
    {
        get
        {
            return state;
        }
        set
        {
            UnabledScene(state, value);
            EnableScene(value);
        }
    }

    public GameObject TopLeft, TopRight, BottomLeft, BottomRight,Goal;

    public GameObject pauseMenu;
    public GameObject MainMenu;
    public GameObject PlayingSetup;
    public GameObject BuildingMenu;

    public GameObject posToCamForBuilding;
    internal bool isHammerFire;

    public bool IsHammerReady { get; set; }

    [SerializeField]
    private NavMeshSurface[] Surfaces;
    public Transform[] WallToMove;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Menu;
        IsHammerReady = true;
    }

    private void MoveWall()
    {
        for (int i = 0; i < Surfaces.Length; i++)
        {
            Surfaces[i].BuildNavMesh();
        }
    }
    public void UnabledScene(GameState stateToLeave, GameState stateToGo)
    {
        switch (stateToLeave)
        {
            case GameState.Menu:
                MainMenu.SetActive(false);
                break;
            case GameState.Building:
                BuildingMenu.SetActive(false);
                break;
            case GameState.Playing:
                PlayingSetup.SetActive(false);
                break;
            case GameState.Pause:
                pauseMenu.SetActive(false);
                break;
            default:
                break;
        }

        state = stateToGo;
    }

    public void EnableScene(GameState nextState)
    {
        switch (nextState)
        {
            case GameState.Menu:
                MainMenu.SetActive(true);
                break;
            case GameState.Building:
                StartCoroutine(MoveObject(Camera.main.transform, posToCamForBuilding.transform.position, 2f));
                BuildingMenu.SetActive(true);
                break;
            case GameState.Playing:
                PlayingSetup.SetActive(true);
                break;
            case GameState.Pause:
                pauseMenu.SetActive(true);
                break;
            default:
                break;
        }
    }

    IEnumerator MoveObject(Transform source, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            source.position = Vector3.Lerp(source.position, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        source.position = target;
    }

    [ContextMenu("Play")]
    public void Play()
    {
        State = GameState.Playing;
    }

    public void MoveGoal()
    {
        int random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                Goal.transform.position = TopLeft.transform.position;
                break;
            case 2:
                Goal.transform.position = TopRight.transform.position;
                break;
            case 3:
                Goal.transform.position = BottomLeft.transform.position;
                break;
            case 4:
                Goal.transform.position = BottomRight.transform.position;
                break;
            default:
                break;
        }

    }



}

public enum GameState
{
    Menu,
    Building,
    Playing,
    Pause
}
