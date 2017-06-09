using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPanelManager : MonoBehaviour
{
    public GameObject IndexPanel;
    public GameObject CheckSchdulePanel;
    public GameObject CourseArrangementPanel;
    public GameObject ExpenseInquiryPanel;
    public GameObject InquiryInfoPanel;
    public GameObject TeacherInfoPanel;
    public GameObject AttendingRightPanel;
    public GameObject DepartmentalClassificationStatisticsPanel;
    public GameObject DetailsOfWorkExpensesStatisticsPanel;
    public GameObject PersonalInfoPanel;
    public GameObject ReimbursementTypePanel;
    public GameObject EmployeeLeavePanel;
    public GameObject LeaveApprovalPanel;


    private List<GameObject> _panels;
    // Use this for initialization
    void Start ()
    {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Initialize()
    {
        _panels = new List<GameObject>();
        _panels.Add(CheckSchdulePanel);
        _panels.Add(CourseArrangementPanel);
        _panels.Add(ExpenseInquiryPanel);
        _panels.Add(InquiryInfoPanel);
        _panels.Add(TeacherInfoPanel);
        _panels.Add(AttendingRightPanel);
        _panels.Add(DepartmentalClassificationStatisticsPanel);
        _panels.Add(DetailsOfWorkExpensesStatisticsPanel);
        _panels.Add(PersonalInfoPanel);
        _panels.Add(ReimbursementTypePanel);
        _panels.Add(EmployeeLeavePanel);
        _panels.Add(LeaveApprovalPanel);
        foreach (var panel in _panels)
        {
            panel.SetActive(false);
        }
        _panels.Add(IndexPanel);
    }

    public void ActivePanel(string panelName)
    {
        foreach (var panel in _panels)
        {
            panel.SetActive(false);
            if (panel.name.Equals(panelName))
            {
                panel.SetActive(true);
            }
        }
    }
}
