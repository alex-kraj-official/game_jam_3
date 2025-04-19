using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyMsg : MonoBehaviour
{
    [SerializeField] private GameObject dailyMsg_Panel;
    [SerializeField] private GameObject payWPplBtn;
    [SerializeField] private GameObject payWResBtn;
    [SerializeField] private GameObject FightBtn;

    public bool dailyMsg_PanelIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        dailyMsg_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PayWPpl()
    {
        dailyMsg_PanelIsActive = false;
        dailyMsg_Panel.SetActive(false);
    }
    public void payWRes()
    {
        dailyMsg_PanelIsActive = false;
        dailyMsg_Panel.SetActive(false);
    }
    public void Fight()
    {
        dailyMsg_PanelIsActive = false;
        dailyMsg_Panel.SetActive(false);
    }
}
