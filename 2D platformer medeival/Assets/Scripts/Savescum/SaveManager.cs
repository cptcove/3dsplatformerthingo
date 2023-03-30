using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public byte[] leScore;
}

public class SaveManager : MonoBehaviour {
    private string saveFileName = "savednumbers.json";
    private byte[] key = new byte[] { 0x03, 0x05, 0x04, 0x01 }; 

    public void SaveGame(int score) {
        SaveData data = new SaveData();
        data.leScore = Encoding.UTF8.GetBytes(score.ToString());

        
        for (int i = 0; i < data.leScore.Length; i++) {
            data.leScore[i] = (byte)(data.leScore[i] ^ key[i % key.Length]);
        }

        string jsonData = JsonUtility.ToJson(data);
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        File.WriteAllText(filePath, jsonData);
    }

    public int LoadGame() {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(filePath)) {
            string jsonData = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            
            for (int i = 0; i < data.leScore.Length; i++) {
                data.leScore[i] = (byte)(data.leScore[i] ^ key[i % key.Length]);
            }

            string scoreString = Encoding.UTF8.GetString(data.leScore);
            int score = 0;
            int.TryParse(scoreString, out score);

            return score;
        } 
        else {
            return 0;
        }
    }
}