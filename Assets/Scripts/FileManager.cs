using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManager : MonoBehaviour {

	public void SaveGame()
    {
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");

        int score = GetComponent<GameController>().GetScore();
        int highScore = GetComponent<GameController>().GetHighScore();
        Vector3 playerPos = GameObject.Find("Player").transform.position;

        GameInfo info = new GameInfo(highScore, score, playerPos);
        binFormatter.Serialize(file, info);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
            GameInfo info = (GameInfo)binFormatter.Deserialize(file);
            file.Close();

            GetComponent<GameController>().SetInfo(info);
        }
    }
}
