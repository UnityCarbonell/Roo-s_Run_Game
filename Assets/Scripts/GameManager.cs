using System;
using System.Collections;
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

    public bool alive;

    public int score;
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

    public void FinalScore()
    {
        //CameraScript.Instance.ShakeCam(0, 0.1f, 2);
        finalScoreText.text = "YOUR SCORE IS: " + scoreText.text;
    }
}
