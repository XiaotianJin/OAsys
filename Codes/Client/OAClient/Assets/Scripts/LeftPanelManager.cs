using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanelManager : MonoBehaviour
{
    private class Btn
    {
        public GameObject btn;
        public Vector3 btnOriginalLocalPosition;
        public bool isBtnOpened;
    }
    private GameObject _dyPart;
    private float _moveUnitDistance;
    private int _openedBtnIndex;
    private List<Btn> _btns;
    private GameObject _rightPanel;
    private GameObject _currentLocationText;
    // Use this for initialization
    void Start ()
    {
		Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    #region InternalFunc

    private void Initialize()
    {
        _dyPart = GameObject.Find("DyPart");
        _moveUnitDistance = _dyPart.GetComponent<GridLayoutGroup>().cellSize.y;
        _btns = new List<Btn>();
        foreach (Transform child in _dyPart.transform)
        {
            Btn temp = new Btn();
            temp.btn = child.gameObject;
            temp.isBtnOpened = false;
            temp.btnOriginalLocalPosition = child.transform.localPosition;
            _btns.Add(temp);
        }
        _openedBtnIndex = 0;
        _rightPanel = GameObject.Find("RightPanel");
        _currentLocationText = GameObject.Find("CurrentLocation");
    }

    private void MoveBtns(int startIndexOfBtn, int moveCount)
    {
        _dyPart.GetComponent<GridLayoutGroup>().enabled = false;
        for (int i = startIndexOfBtn; i < _btns.Count; i++)
        {
            Vector3 distinction =_btns[i].btnOriginalLocalPosition + new Vector3(0, -moveCount*_moveUnitDistance, 0);
            _btns[i].btn.transform.DOLocalMove(distinction, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                _btns[startIndexOfBtn - 1].isBtnOpened = true;
            });
        }
    }
    private void ResetBtns(int startIndexOfBtn)
    {
        _dyPart.GetComponent<GridLayoutGroup>().enabled = false;
        for (int i = startIndexOfBtn; i < _btns.Count; i++)
        {
            _btns[i].btn.transform.DOLocalMove(_btns[i].btnOriginalLocalPosition, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                _btns[startIndexOfBtn - 1].isBtnOpened = false;
            });
        }
    }
    #endregion

    #region BtnClickFunc

    public void OnClickSystemIndexBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("IndexPanel");
        _currentLocationText.GetComponent<Text>().text = "";
    }

    public void OnClickTeachingDepartmentBtn()
    {
        if (!_btns[0].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            _openedBtnIndex = 0;
            MoveBtns(1, 2);
            return;
        }
        if (_btns[0].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            return;
        }
    }

    public void OnClickTeachingQualityDepartmentBtn()
    {
        if (!_btns[1].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            _openedBtnIndex = 1;
            MoveBtns(2, 2);
            return;
        }
        if (_btns[1].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            return;
        }
    }
    public void OnClickFinanceDepartmentBtn()
    {
        if (!_btns[2].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            _openedBtnIndex = 2;
            MoveBtns(3, 2);
            return;
        }
        if (_btns[2].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            return;
        }
    }
    public void OnClickReportStatisticsBtn()
    {
        if (!_btns[3].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            _openedBtnIndex = 3;
            MoveBtns(4, 2);
            return;
        }
        if (_btns[3].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            return;
        }
    }
    public void OnClickPropagandaDepartmentBtn()
    {
        ResetBtns(_openedBtnIndex + 1);
        _openedBtnIndex = 4;
    }
    public void OnClickPersonnelDepartmentBtn()
    {
        if (!_btns[5].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            _openedBtnIndex = 5;
            MoveBtns(6, 2);
            return;
        }
        if (_btns[5].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            return;
        }
    }

    public void OnClickProfileBtn()
    {
        if (!_btns[6].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            _openedBtnIndex = 6;
            MoveBtns(7, 2);
            return;
        }
        if (_btns[6].isBtnOpened)
        {
            ResetBtns(_openedBtnIndex + 1);
            return;
        }
    }

    public void OnClickCorporationCultureBtn()
    {
        ResetBtns(_openedBtnIndex + 1);
        _openedBtnIndex = 7;
    }

    public void OnClickBackBtn()
    {
        Application.Quit();
    }

    public void OnClickTeachInfoBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("TeacherInfoPanel");
        _currentLocationText.GetComponent<Text>().text = "教师简介";
    }
    public void OnClickCheckSchduleBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("CheckSchdulePanel");
        _currentLocationText.GetComponent<Text>().text = "查看课表";
    }

    public void OnClickCourseArrangementBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("CourseArrangementPanel");
        _currentLocationText.GetComponent<Text>().text = "课程安排";
    }

    public void OnClickEnpenseInfoBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("ExpenseInquiryPanel");
        _currentLocationText.GetComponent<Text>().text = "报销单详情";
    }

    public void OnClickAttendanceBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("AttendingRightPanel");
        _currentLocationText.GetComponent<Text>().text = "个人考勤";
    }
    public void OnDWEBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("DetailsOfWorkExpensesStatisticsPanel");
        _currentLocationText.GetComponent<Text>().text = "报销单统计";
    }
    public void OnClickDCFBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("DepartmentalClassificationStatisticsPanel");
        _currentLocationText.GetComponent<Text>().text = "部门分类统计";
    }
    public void OnPersonInfoBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("PersonalInfoPanel");
        _currentLocationText.GetComponent<Text>().text = "个人信息";
    }

    public void OnClickReimbursementTypeBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("ReimbursementTypePanel");
        _currentLocationText.GetComponent<Text>().text = "报销类型";
    }

    public void OnClickEmployeeLeavePanel()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("EmployeeLeavePanel");
        _currentLocationText.GetComponent<Text>().text = "职工请假";

    }

    public void OnClickLeaveApprovalPanelBtn()
    {
        _rightPanel.GetComponent<RightPanelManager>().ActivePanel("LeaveApprovalPanel");
        _currentLocationText.GetComponent<Text>().text = "请假审批";
    }
    #endregion
}
