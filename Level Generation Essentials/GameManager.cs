using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    Transform StageHolder;
    public Transform[] levels;
    public string HolderName = "GenerateLevels";
    Transform level;

    UIManager uIManager;
    int counter = 0;

    public bool isTap = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        uIManager = UIManager.instance;
        StartGame();
    }

    void Update()
    {
        
    }

    public void GenerateLevel()
    {
        //if (PlayerPrefs.GetInt("Level") == 63)
        //{
        //    PlayerPrefs.SetInt("Level", 30);
        //}
        if (GameObject.Find(HolderName))
        {
            DestroyImmediate(GameObject.Find(HolderName));
        }
        StageHolder = new GameObject(HolderName).transform;
        StageHolder.parent = this.transform;
        level = Instantiate(levels[counter]) as Transform;
        uIManager.levelText.text = "LEVEL " + (counter + 1) + "";

        //level = Instantiate(Resources.Load<Transform>("Levels/Level")) as Transform;
        //uIManager.levelText.text = "LEVEL " + (PlayerPrefs.GetInt("Stage") + 1) + "";

        level.transform.parent = StageHolder;

        isTap = false;
    }

    public void StartGame() 
    {
        uIManager.ShowStartScreenPanel();
        GenerateLevel();
    }
    public void NextLevel()
    {
        if ((counter + 1) < levels.Length)
        {
            counter++;

        }
        else
        {
            counter = 0;

        }

        GenerateLevel();
        uIManager.ShowStartScreenPanel();
    }

    public void RestartGameAfterWin()
    {
        SubtractPlayerPrefValue();
        GenerateLevel();
        uIManager.ShowStartScreenPanel();
    }
    public void RestartGameAfterLose()
    {
        GenerateLevel();
        uIManager.ShowStartScreenPanel();
    }

    public void SkipLevel()
    {
        if ((counter + 1) < levels.Length)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        //AddPlayerPrefValue();
        GenerateLevel();
        uIManager.ShowStartScreenPanel();
    }

    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void TapToPlay()
    {
        if (!isTap)
        {
            isTap = true;
            uIManager.ShowInGameScreen();
        }
    }

    public void AddPlayerPrefValue()
    {
        PlayerPrefs.SetInt("Level", (PlayerPrefs.GetInt("Level") + 1));
        PlayerPrefs.SetInt("Stage", (PlayerPrefs.GetInt("Stage") + 1));
    }
    public void SubtractPlayerPrefValue()
    {
        PlayerPrefs.SetInt("Level", (PlayerPrefs.GetInt("Level") - 1));
        PlayerPrefs.SetInt("Stage", (PlayerPrefs.GetInt("Stage") - 1));
    }
}