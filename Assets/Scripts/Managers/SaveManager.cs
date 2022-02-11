using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void SavePlayerData(GameManager gm)
    {
        PlayerData pd = new PlayerData(gm);
        string dataPath = Application.persistentDataPath + "/data.save";
        FileStream fs = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, pd);
        fs.Close();
    }
    public static PlayerData LoadData()
    {
        string dataPath = Application.persistentDataPath + "/data.save";
        if (File.Exists(dataPath))
        {
            FileStream fs = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            PlayerData pd = (PlayerData) bf.Deserialize(fs);
            fs.Close();
            return pd;
        }
        else
        {
            Debug.LogError("None save file has been found.");
            return null;
        }
    }
}
