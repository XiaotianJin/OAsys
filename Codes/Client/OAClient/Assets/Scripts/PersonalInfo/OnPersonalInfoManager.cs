using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.PersonalInfo;
using UnityEngine;
using UnityEngine.UI;

public class OnPersonalInfoManager : MonoBehaviour {

    #region Public Pramas

    public Text ShowText;

    #endregion

    // Use this for initialization
    void Start ()
    {
        ShowText.text = PersonInfo.GetPersonalInfo("菜鸡").toString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
