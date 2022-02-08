using System.Collections;
using System.Collections.Generic;
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
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
