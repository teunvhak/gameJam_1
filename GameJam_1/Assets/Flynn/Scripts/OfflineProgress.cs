using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class OfflineProgress : MonoBehaviour
{
    public GameObject OfflineScreen;
    public TMP_Text TimeText;
    private void Start()
    {
        if(PlayerPrefs.HasKey("exitTime"))
        {
            OfflineScreen.SetActive(true);
            DateTime LastTime = DateTime.Parse(PlayerPrefs.GetString("exitTime"));
            DateTime CurrentTime = DateTime.Now;

            TimeSpan TimeAway = CurrentTime - LastTime;
            TimeText.text = string.Format("{0} Days {1} Hours {2} Mins {3} Secs", TimeAway.Days, TimeAway.Hours, TimeAway.Minutes, TimeAway.Seconds);

        }
        else
        {
            OfflineScreen.SetActive(false);

        }

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("exitTime", DateTime.Now.ToString());
    }
}
