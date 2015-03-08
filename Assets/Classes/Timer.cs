using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class MinuteTimer {
	public static readonly int minuteInSeconds = 60;

	private int seconds = 0;
	private int minutes = 0;
	private int totalSeconds = 0;
    private Timer timer = new Timer(1000);

    public MinuteTimer()
    {
        this.seconds = 0;
        this.minutes = 0;
        timer.Elapsed += AddToTimer;
    }

    public MinuteTimer (ScoreData sd)
    {
        this.seconds = sd.HighScoreSeconds;
        this.minutes = sd.HighScoreMinutes;
        timer.Elapsed += AddToTimer;
    }

	public int getSeconds() {
		return this.seconds;
	}

	public int getMinutes() {
		return this.minutes;
	}

	public int getTotalSeconds() {
		return totalSeconds;
	}

	public string getTimeString() {
		string retStr = String.Format("{0}:{1}",minutes,seconds);
		return retStr;
	} 

	public void start () {
        timer.Enabled = true;
	}

	public void pause () {
        timer.Enabled = false;
	}

	/// <summary>
	/// Returns true if Instance is larger than the Timer passed in 
	/// </summary>
	public bool LargerThan(MinuteTimer otherTimer) {
		if (this.minutes > otherTimer.minutes) {
			return true;
		}
		else if (this.minutes == otherTimer.minutes) {
			if (this.seconds > otherTimer.seconds) {
				return true;
			}
			else if (this.seconds == otherTimer.seconds){
				return false;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}

    private void AddToTimer(System.Object source, ElapsedEventArgs e)
    {
		totalSeconds++;

		if (seconds == (minuteInSeconds - 1)){
			seconds = 0;
			minutes++;
		}
		else {
			seconds++;
		}
	}

	public override string ToString ()
	{
		return getTimeString();
	}

	public override bool Equals (object o)
	{
		try {
			MinuteTimer Compare = (MinuteTimer)o;
			return (Compare.seconds == this.seconds && this.minutes == Compare.minutes);
		} 
		catch (Exception ex) {
			Debug.LogError(String.Format("Caught error: '{0}', during Timer.Equals()",ex));
			return false;
		}
	}
}