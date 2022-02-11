using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void RooIsDead();
    public static event RooIsDead Died;

    public delegate void ItemCollected();
    public static event ItemCollected ic;

    public delegate void GosthCollected();
    public static event GosthCollected gc;

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
}
