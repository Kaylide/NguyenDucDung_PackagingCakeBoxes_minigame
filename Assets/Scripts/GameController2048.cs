using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2048 : MonoBehaviour
{
    public static GameController2048 instance;
    public static int ticker;

    [SerializeField] GameObject fillPrefab;
    [SerializeField] Cell2048[] allCells;

    public static Action<string> slide;
    public int myScore;
    [SerializeField] Text scoreDisplay;

    int isGameOver;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] int winningScore;
    [SerializeField] GameObject winningPanel;
    bool hasWon;

    public float timeRemaining;
    public Text timeText;

    private void OnEnable()
    {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 45;
        StartSpawnFill();
        StartSpawnFill();
    }
    // Update is called once per frame
    void Update()
    {
        timeText.text = timeRemaining.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFill();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ticker = 0;
            isGameOver = 0;
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ticker = 0;
            isGameOver = 0;
            slide("a");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ticker = 0;
            isGameOver = 0;
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ticker = 0;
            isGameOver = 0;
            slide("d");
        }
    }

    IEnumerator BeginGame() 
    {  
        while (true) {
            yield return new WaitForSeconds(1f);
            if (timeRemaining > 0)
            {
                timeRemaining--;
            }
            else break;
        }
    }

    public void SpawnFill()
    {
        bool isFull = true;
        for (int i = 0; i < allCells.Length; i++) 
        {
            if (allCells[i].fill == null)
            {
                isFull = false;
            }
        }

        if (isFull == true)
        {
            Debug.Log("Game Over");
            return;
        }

        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].transform.childCount != 0)
        {
            Debug.Log(allCells[whichSpawn].name + " is already filled");
            SpawnFill();
            return;
        }
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);
        if (chance < .2f)
        {
            return;
        }
        else if (chance < .8f)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
            Debug.Log(2);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
            Debug.Log(4);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(4);
        }
    }

    public void StartSpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].transform.childCount != 0)
        {
            Debug.Log(allCells[whichSpawn].name + " is already filled");
            SpawnFill();
            return;
        }
       
        GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
        Debug.Log(2);
        Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
        allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
        tempFillComp.FillValueUpdate(2);
       
    }

    public void ScoreUpdate(int scoreIn)
    {
        myScore += scoreIn;
        scoreDisplay.text = myScore.ToString();
    }

    public void GameOverCheck()
    {
        isGameOver++;
        if (isGameOver >= 9)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart() 
    {
        SceneManager.LoadScene(0);
    }

    public void WinCheck(int highestFill)
    {
        if (hasWon == true)
        {
            return;
        }
        if (highestFill == winningScore) 
        {
            winningPanel.SetActive(true);
            hasWon = true;
        }
    }

    public void KeepPlaying() 
    {
        winningPanel.SetActive(false);
    }

    public void ButtonHome() 
    {
        SceneManager.LoadScene(0);
    }

    void DisplayTime (float timeToDisplay) 
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
}