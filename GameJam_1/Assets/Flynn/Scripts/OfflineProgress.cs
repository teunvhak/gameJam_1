using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class OfflineProgress : MonoBehaviour
{
    public GameObject OfflineScreen;
    public TMP_Text TimeText;
    public int Progress = 0;
    private double seconds;
    private void Start()
    {
        if(PlayerPrefs.HasKey("exitTime"))
        {
            OfflineScreen.SetActive(true);
            DateTime LastTime = DateTime.Parse(PlayerPrefs.GetString("exitTime"));
            DateTime CurrentTime = DateTime.UtcNow;

            TimeSpan TimeAway = CurrentTime - LastTime;
            //TimeText.text = string.Format("{0} Days {1} Hours {2} Mins {3} Secs", TimeAway.Days, TimeAway.Hours, TimeAway.Minutes, TimeAway.Seconds);
            seconds = TimeAway.TotalSeconds;
            TimeText.text = Progress.ToString();
            Progress = ((int)seconds);
        }
        else
        {
            OfflineScreen.SetActive(false);
        }
        SaveManager.instance.Data.Offline.OfflineInt += Progress;
        SaveManager.instance.Save(SaveManager.instance.Data);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("exitTime", DateTime.UtcNow.ToString());
    }
}
