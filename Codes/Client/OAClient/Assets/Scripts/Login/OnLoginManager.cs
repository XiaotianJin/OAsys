using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class userinfo
{
    public string username;
    public string password;

    public userinfo()
    {

    }

    public userinfo(string username, string password)
    {
        this.password = password;
        this.username = username;
    }
}

public class OnLoginManager : MonoBehaviour {

    public static List<userinfo> users = new List<userinfo>()
    {
        new userinfo("test", "test")
    };

    public InputField user;
    public InputField pwd;

    public void OnLoginBtn()
    {
        string userstr = user.text;
        string pwdstr = pwd.text;


        bool isFine = false;
        foreach (var u in users)
        {
            if (u.password == pwdstr && u.username == userstr)
            {
                isFine = true;
                break;
            }
        }

        if (isFine)
        {
            Debug.Log("登陆成功！");
            GeneralSetting.UserName = user.text;
            LoadMainScene();
        }
        else
        {
            Debug.Log("登陆失败！");
        }
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("Cuixiaoliang");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
