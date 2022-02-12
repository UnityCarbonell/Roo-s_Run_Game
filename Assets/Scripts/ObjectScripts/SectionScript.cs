using System.Collections;
using UnityEngine;

public class SectionScript : MonoBehaviour
{
    public int sectionSize;
    public bool working;
    public void OnEnable()
    {
        GameEvents.Died += NotWork;
    }
    public void OnDisable()
    {
        GameEvents.Died -= NotWork;
    }
    public void Awake()
    {
        working = true;
        StartCoroutine("Destroy");
    }
    public IEnumerator Destroy()
    {
        if (working==true)
        {
            yield return new WaitForSeconds(15f);
            Destroy(gameObject);
        }
    }
    public void NotWork()
    {
        working = false;
    }
}
