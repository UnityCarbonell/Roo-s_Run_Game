using System.Collections;
using UnityEngine;

public class SectionScript : MonoBehaviour
{
    public int sectionSize;

    public void Awake()
    {
        StartCoroutine("Destroy");
    }
    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
