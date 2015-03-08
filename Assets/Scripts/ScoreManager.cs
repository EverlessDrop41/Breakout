using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour {

    public Text CurrentScoreDisplay;
    public Text HighScoreDisplay;
    
    public string FileNameAndPath;
	public string FileExtension = ".dat";

    private MinuteTimer Score;
    private MinuteTimer HighScore;

	private int NumberOfBlocks;
	private int NumberOfBlocksLeft;
	private MinuteTimer CurrentScoreTimer = new MinuteTimer();

    private bool HasSaveFile = false;

	void Start () 
    {
		CurrentScoreTimer.start();
		NumberOfBlocks = GameObject.FindGameObjectsWithTag("Block").Length;
		NumberOfBlocksLeft = NumberOfBlocks;
        if (File.Exists(ScoreData.GetFilePath(FileNameAndPath + FileExtension)))
        {
            ScoreData HighScoreData;
            ScoreData.OpenFile(out HighScoreData, FileNameAndPath, FileExtension);
            HighScore = new MinuteTimer(HighScoreData);

            HasSaveFile = true;

            HighScoreDisplay.text = string.Format("Best Time: {0}", HighScore.getTimeString());
        }
        else
        {
            HighScoreDisplay.text = "Best Time: Unavailable";
            HighScore = new MinuteTimer();
        }
	}

	void Update () 
    {
        Score = CurrentScoreTimer;
        CurrentScoreDisplay.text = String.Format("Time Taken: {0}", CurrentScoreTimer);
	}

	void BlockDestroyed () 
    {
        NumberOfBlocksLeft--;
        if (NumberOfBlocksLeft <= 0)
        {
            if (ScoreData.HighScoreBeat(Score, HighScore) || !HasSaveFile)
            {
                //Larger also means slower in this context
                ScoreData.Save(FileNameAndPath, FileExtension, new ScoreData(Score));
            }
            
            Application.LoadLevel(0);
        }
	}
}
