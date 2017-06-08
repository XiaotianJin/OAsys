using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Attending;
using UnityEngine;
using UnityEngine.UI;

public class OnAttendingManager : MonoBehaviour {

    #region Public Pramas

    public Dropdown Selection;

    public Text ShowText;

    #endregion

    #region Btn ctrl

    public void OnSearchBtn()
    {
        Debug.Log(string.Format("{0} : {1}", Selection.value, Selection.captionText.text));

        ShowAttending(Selection.value);
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="level">0-</param>
    public void ShowAttending(int level)
    {
        List<AttendingInfo> res = AttendingInfo.GetAttendingInfo(GeneralSetting.UserName);
        Debug.Log("!!" + res.Count);

        ShowText.text = String.Empty;
        foreach (var single in res)
        {
            Debug.Log(single.toString());
            if (single.level == level || level == 0)
            {
                ShowText.text += single.toString() + "\n";
            }
        }
    }

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
