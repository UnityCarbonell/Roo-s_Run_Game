using UnityEngine;

public class GosthScript : CollectableScript
{
    public GameObject gosthAudio;
    protected override void Collected()
    {
        ge.GCollected();
        Destroy(
            Instantiate(gosthAudio, this.gameObject.transform.position, Quaternion.identity), 
            1f);
        Destroy(this.gameObject);
    }
}
