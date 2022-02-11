using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public GameEvents ge;

    public void Awake()
    {
        ge = GameObject.Find("GameEvents").GetComponent<GameEvents>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Collected();
            
        }
        else if (collision.gameObject.tag == "Destructor")
        {
            Destroy(this.gameObject);
        }
    }
    
    protected virtual void Collected()
    {
        ge.ItemCol();
        Destroy(this.gameObject);
    }
}
