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

    public GameObject TopLeft, TopRight, BottomLeft, BottomRight, Goal;
    public GameObject wallsGO;
    public GameObject pauseMenu;
    public GameObject MainMenu;
    public GameObject BuildingMenu;

    public GameObject posToCamForBuilding;
    internal bool isHammerFire;
    int previousGoalPos;

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

    public void MoveWall()
    {
        foreach (Transform item in wallsGO.transform)
        {
            float x = Random.Range(TopLeft.transform.position.x, TopRight.transform.position.x);
            float z = Random.Range(BottomLeft.transform.position.x, BottomRight.transform.position.x);
            Vector3 newPos = new Vector3(x, item.position.y, z);
            Debug.Log(item.name + item.position + newPos);
            StartCoroutine(MoveObject(item, newPos, 5f));
        }
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
                foreach (Transform item in wallsGO.transform)
                {
                    item.gameObject.SetActive(false);
                }
                StartCoroutine(MoveObject(Camera.main.transform, posToCamForBuilding.transform.position, 2f));
                BuildingMenu.SetActive(true);
                break;
            case GameState.Pause:
                pauseMenu.SetActive(true);
                break;
            case GameState.Playing:
                foreach (Transform item in wallsGO.transform)
                {
                    item.gameObject.SetActive(true);
                }
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

    [ContextMenu("Build")]
    public void Build()
    {
        State = GameState.Building;
    }

    public void MoveGoal()
    {
        int random = Random.Range(1, 5);
        while (random == previousGoalPos)
        {
            random = Random.Range(1, 5);
        }
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
        previousGoalPos = random;

    }



}

public enum GameState
{
    Menu,
    Building,
    Playing,
    Pause
}
