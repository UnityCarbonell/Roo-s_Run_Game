using UnityEngine;

public class GosthScript : CollectableScript
{
    protected override void Collected()
    {
        ge.GCollected();
        Destroy(this.gameObject);
    }
}
