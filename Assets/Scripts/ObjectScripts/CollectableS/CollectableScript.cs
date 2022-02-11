using System.Collections;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public GameEvents ge;
    public Transform it;

    public float delayTime = 0.5f;

    public void Awake()
    {
        ge = GameObject.Find("GameEvents").GetComponent<GameEvents>();
        it = this.gameObject.transform;
        StartCoroutine("Destroy");
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Collected();
        }
    }
    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
        ge.GI();
    }
    protected virtual void Collected()
    {
        ge.ItemCol();
        Destroy(this.gameObject);
    }
}
