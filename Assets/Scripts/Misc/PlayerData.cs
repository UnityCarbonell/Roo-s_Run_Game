[System.Serializable]
public class PlayerData
{
    public int highScore;

    public PlayerData(GameManager gm)
    {
        highScore = gm.highScore;
    }
}
