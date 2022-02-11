using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject itemGosth;
    public GameObject player;

    public float axisX;
    public float axisY;
    public float timeForGosth = 2.5f;

    public void OnEnable()
    {
        GameEvents.gc += GenerateGosth;
        GameEvents.geneItems += Generate;
    }
    public void OnDisable()
    {
        GameEvents.gc -= GenerateGosth;
        GameEvents.geneItems -= Generate;
    }

    public void FixedUpdate()
    {
        axisX = player.transform.position.x + 15;
    }

    public void Generate()
    {
        StartCoroutine("GenerateItems");
    }
    IEnumerator GenerateItems()
    {
        Debug.Log("Creating collectable Items.");
        yield return new WaitForSeconds(timeForGosth);
        GenerateGosth();
    }
    public void GenerateGosth()
    {
        axisY = Random.Range(-0.5f, 3.79f);
        Instantiate(itemGosth, new Vector3(axisX, axisY, 1), Quaternion.identity);
        Debug.Log("Gosth created.");
    }
}
