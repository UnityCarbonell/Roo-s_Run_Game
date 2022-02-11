[System.Serializable]
public class PlayerData
{
    public int highScore;
    public int recordGosths;

    public PlayerData(GameManager gm)
    {
        highScore = gm.highScore;
        recordGosths = gm.recordGosths;
    }
}
