using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameStarted;
    public GameObject platformSpawnner;
    public GameObject highScoreImage;

    [Header("GameOver")]
    public GameObject gameOverPanel;

    [Header("Score")]
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    public TMP_Text diamondText;
    public TMP_Text starText;
    public TMP_Text lastScoreText;


    private int score = 0;
    private int bestScore, totalDiamond, totalStar;
    private bool countScore;
   
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //totalDiamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text = totalDiamond.ToString();
        //total star
        totalStar = PlayerPrefs.GetInt("totalStar");
        starText.text = totalStar.ToString();

        //bestScore
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestScoreText.text = bestScore.ToString();
       
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                
            }
        }
        
    }
    public void GameStart()
    {
        isGameStarted = true;
        countScore = true;
        platformSpawnner.SetActive(true);
        StartCoroutine(UpdateScore());
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        countScore = false;
        platformSpawnner.SetActive(false);
        lastScoreText.text = score.ToString();
        if (score > bestScore)
        {
            highScoreImage.SetActive(true);
            PlayerPrefs.SetInt("bestScore", score);
            
        }
    }

    IEnumerator UpdateScore()
    {
        while (countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if(score > bestScore)
            {
                
                scoreText.text = score.ToString();
                bestScoreText.text = score.ToString();

            }
                scoreText.text = score.ToString();
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void GetStar()
    {
        int newStar = totalStar++;
        PlayerPrefs.SetInt("totalStar", newStar);
        starText.text = totalStar.ToString();
    }
    public void GetDiamond()
    {
        int newDiamond = totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond", newDiamond);
        diamondText.text = totalDiamond.ToString();
    }
}
