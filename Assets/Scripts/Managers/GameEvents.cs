using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void RooIsDead();
    public static event RooIsDead Died;

    public delegate void ItemCollected();
    public static event ItemCollected ic;

    public delegate void GosthCollected();
    public static event GosthCollected gc;

    public delegate void GenerateItems();
    public static event GenerateItems geneItems;

    public void Awake()
    {
        GI();
    }
    public void RooDying()
    {
        Died();
    }
    public void ItemCol()
    {
        ic();
    }
    public void GCollected()
    {
        gc();
    }
    public void GI()
    {
        geneItems();
    }
}