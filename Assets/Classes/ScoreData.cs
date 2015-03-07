using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public sealed class ScoreData {
	public int HighScoreSeconds;
	public int HighScoreMinutes;

    public static string GetBasePath()
    {
        return Application.persistentDataPath;
    }

    public static string GetFilePath(string FileNameAndExtension)
    {
        return Application.persistentDataPath + @"\" + FileNameAndExtension;
    }

	/// <summary>
	/// Detects if the score is higher than the highscore
	/// </summary>
	/// <returns><c>true</c> If Score is larger than HighScore, <c>false</c> otherwise.</returns>
	/// <param name="Score">Score</param>
	/// <param name="HighScore">Current HighScore</param>
	public static bool HighScoreBeat(MinuteTimer Score,MinuteTimer HighScore){
		return Score.LargerThan(HighScore);
	}
	
	public ScoreData(MinuteTimer HighScoreTimer) {
		this.HighScoreSeconds = HighScoreTimer.getSeconds();
		this.HighScoreMinutes = HighScoreTimer.getMinutes();
	}
	
	/// <summary>
	/// Save the specified data to a file using a binary formatter
	/// </summary>
	/// <param name="path">Path and Name of this file you want (saved in the game's files)</param>
	/// <param name="extension">The extension used for the file</param>
	/// <param name="data">The data to save</param>
	public static void Save(string path, string extension, ScoreData data) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream fs = File.Create(Application.persistentDataPath + "\\" + path + extension);
		bf.Serialize(fs,data);
		fs.Close();
		Debug.Log("Save File saved at " + Application.persistentDataPath + "\\" + path + extension);
	}
	
	/// <summary>
	/// Save this object to a file data using a binary formatter
	/// </summary>
	/// <param name="path">Path and Name of this file you want (saved in the game's files)</param>
	/// <param name="extension">The extension used for the file</param>
	public void SaveThis(string path, string extension) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream fs = File.Create(Application.persistentDataPath + @"\" + path + extension);
		bf.Serialize(fs,this);
		fs.Close();
		Debug.Log("Save File saved at " + Application.persistentDataPath + @"\" + path + extension);
	}
	
	/// <summary>
	/// Open and deserialise a file, then store it in a ScoreData object
	/// </summary>
	/// <param name="path">Path and Name of the file you want (opened from the game's files)</param>
	/// <param name="extension">The extension used for the file</param>
	public static void OpenFile(out ScoreData ScoreDataStorage, string path, string extension) {
		BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = null;

        try
        {
            fs = File.Open(Application.persistentDataPath + "\\" + path + extension, FileMode.Open);
            ScoreData sd = (ScoreData)bf.Deserialize(fs);
            ScoreDataStorage = sd;
        }
        catch (FileNotFoundException ex)
        {
            Debug.LogWarning(string.Format("Error, File not found: {0}", ex.Message));
            ScoreDataStorage = null;
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
	}

	/// <summary>
	/// Sets this objects data to be that of a save file
	/// </summary>
	/// <param name="path">Path and Name of the file you want (opened from the game's files)</param>
	/// <param name="extension">The extension used for the file</param>
	public void SetThisFromFile(string path, string extension) {
		BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = null;

        try
        {
            fs = File.Open(Application.persistentDataPath + "\\" + path + extension, FileMode.Open);
            ScoreData sd = (ScoreData)bf.Deserialize(fs);
            this.HighScoreMinutes = sd.HighScoreMinutes;
            this.HighScoreSeconds = sd.HighScoreSeconds;
        }
        catch (FileNotFoundException ex)
        {
            Debug.LogWarning(string.Format("Error, File not found: {0}", ex.Message));
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
	}
}
