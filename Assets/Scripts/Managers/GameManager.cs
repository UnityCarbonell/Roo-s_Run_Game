using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Camera
    public Camera mainCamera;

    //GameObject
    public GameObject player;
    public GameObject audioManager;
    public GameObject[] prefabSections;

    //AudioSorce
    public AudioSource gamplayMusic;

    //Texts
    public Text scoreText;
    public Text hsText;
    public Text finalScoreText;
    public Text recordsText;

    //Floats
    public float gameIndex;
    public float safePlace = 12.0f;
    
    //Bools
    public bool alive;

    //Ints
    public int position;
    public int score;
    public int highScore;
    public int collectedGosths;
    public int gosthPoints;
    public int recordGosths;

    void OnEnable()
    {
        GameEvents.Died += FinalScore;
        GameEvents.gc += GosthAdded;
        GameEvents.getRec += GetRecords;
    }
    void OnDisable()
    {
        GameEvents.Died -= FinalScore;
        GameEvents.gc -= GosthAdded;
        GameEvents.getRec -= GetRecords;
    }
    void Start()
    {
        gameIndex = -7.0f;
        alive = true;
        collectedGosths = 0;
        LoadDataToGM();

        gamplayMusic = audioManager.GetComponent<AudioSource>();
    }
    void Update()
    {
        gosthPoints = 50 * collectedGosths;
        position = Mathf.FloorToInt(player.transform.position.x + gosthPoints);
        if (player != null)
        {
           
           mainCamera.transform.position = new Vector3(player.transform.position.x,
           mainCamera.transform.position.y,
           mainCamera.transform.position.z);

            if (position > score)
            {
                score = position;
                scoreText.text = score.ToString();
            }
        }

        while (player != null && gameIndex < player.transform.position.x + safePlace)
        {
            int sectionIndex = Random.Range(1, prefabSections.Length);

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
    public void StopMusic()
    {
        if (gamplayMusic.enabled == true)
        {
            gamplayMusic.enabled = false;
        }
        else
        {
            gamplayMusic.enabled = true;
        }
        
    }
    private void LoadDataToGM()
    {
        PlayerData playerData = SaveManager.LoadData();
        highScore = playerData.highScore;
        recordGosths = playerData.recordGosths;
        Debug.Log("Data loaded.");
        hsText.text = "Highest Score: " + highScore.ToString();
    }
    private void SaveDataFromGM()
    {
        highScore = score;
        recordGosths = collectedGosths;
        SaveManager.SavePlayerData(this);
        Debug.Log("Data Saved.");
    }
    public void FinalScore()
    {
        gamplayMusic.enabled = false;

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
    private void GosthAdded()
    {
        collectedGosths++;

        if (collectedGosths > recordGosths)
        {
            SaveDataFromGM();
        }
    }
    public void GetRecords()
    {
        recordsText.text = "Highest Score: " + highScore.ToString()
            + "\nBest Gosths collected: " + recordGosths.ToString();
    }

    //Only for testing purposes
    /*
    public void EraseRecords()
    {
        highScore = 0;
        recordGosths = 0;
        SaveManager.SavePlayerData(this);
        Debug.Log("Data erased.");
    }
    */
}
