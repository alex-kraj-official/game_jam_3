using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyMsg : MonoBehaviour
{
    [SerializeField] private GameObject dailyMesg_Panel;
    [SerializeField] private GameObject payWPplBtn;
    [SerializeField] private GameObject payWResBtn;
    [SerializeField] private GameObject FightBtn;


    // Start is called before the first frame update
    void Start()
    {
        dailyMesg_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PayWPpl()
    {
        dailyMesg_Panel.SetActive(false);
    }
    public void payWRes()
    {
        dailyMesg_Panel.SetActive(false);
    }
    public void Fight()
    {
        //FIGHT
        dailyMesg_Panel.SetActive(false);

    }
}
