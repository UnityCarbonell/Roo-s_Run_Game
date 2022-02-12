using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject itemGosth;
    public GameObject player;

    public float axisX;
    public float axisY;
    public float timeForGosth = 2.5f;

    public bool working;
    public void OnEnable()
    {
        GameEvents.gc += GenerateGosth;
        GameEvents.geneItems += Generate;
        GameEvents.Died += NotWork;
    }
    public void OnDisable()
    {
        GameEvents.gc -= GenerateGosth;
        GameEvents.geneItems -= Generate;
        GameEvents.Died -= NotWork;
    }
    private void Start()
    {
        working = true;
    }
    public void FixedUpdate()
    {
        axisX = player.transform.position.x + 15;
    }

    public void Generate()
    {
        if (working == true)
        {
            StartCoroutine("GenerateItems");
        }
    }
    IEnumerator GenerateItems()
    {
        yield return new WaitForSeconds(timeForGosth);
        GenerateGosth();
    }
    public void GenerateGosth()
    {
        if (working == true)
        {
            axisY = Random.Range(-0.5f, 3.79f);
            Instantiate(itemGosth, new Vector3(axisX, axisY, 1), Quaternion.identity);
        }
    }
    public void NotWork()
    {
        working = false;
    }
}
