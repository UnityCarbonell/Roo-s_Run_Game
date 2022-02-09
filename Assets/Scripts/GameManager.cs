using System;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    public GameObject[] prefabSections;
    public float gameIndex;
    public float safePlace = 12.0f;

    public Text scoreText;
    public Text hsText;

    public bool alive;

    public int score;
    public int highScore;
    public Text finalScoreText;

    void OnEnable()
    {
        GameEvents.Died += FinalScore;
    }
    void OnDisable()
    {
        GameEvents.Died -= FinalScore;
    }
    void Start()
    {
        gameIndex = -7.0f;
        alive = true;
        LoadDataToGM();
    }

    void Update()
    {
        if (player != null)
        {
           
           mainCamera.transform.position = new Vector3(player.transform.position.x,
           mainCamera.transform.position.y,
           mainCamera.transform.position.z);

            scoreText.text = Mathf.Floor(player.transform.position.x).ToString();
            score = Int32.Parse(scoreText.text);
        }

        while (player != null && gameIndex < player.transform.position.x + safePlace)
        {
            int sectionIndex = UnityEngine.Random.Range(1, prefabSections.Length);

            if (gameIndex < 0)
            {
                sectionIndex = 0;
            }

            GameObject sectionObject = Instantiate(prefabSections[sectionIndex]);
            sectionObject.transform.SetParent(this.transform);
            SectionScript section = sectionObject.GetComponent<SectionScript>();
            sectionObject.transform.position = new Vector2(gameIndex + section.sectionSize / 2, -0.43f);
            gameIndex += section.sectionSize;
        }
    }

    private void LoadDataToGM()
    {
        PlayerData playerData = SaveManager.LoadData();
        highScore = playerData.highScore;
        Debug.Log("Data loaded.");
        hsText.text = "Highest Score: " + highScore.ToString();
    }

    private void SaveDataFromGM()
    {
        highScore = score;
        SaveManager.SavePlayerData(this);
        Debug.Log("Data Saved.");
    }
    public void FinalScore()
    {
        if (score > highScore)
        {
            SaveDataFromGM();
            finalScoreText.text = "YOUR SCORE IS: " + scoreText.text +
                "\nTHAT IS A NEW HIGHSCORE! CONGRATULATIONS!";
        }
        else
        {
            finalScoreText.text = "YOUR SCORE IS: " + scoreText.text + 
                "\nYOUR HIGHEST SCORE IS: " + highScore.ToString();
        }
    }
}
