using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;

    public GameObject[] prefabSections;
    public float gameIndex;
    public float safePlace = 12.0f;

    public Text scoreText;

    public bool alive;

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
}
