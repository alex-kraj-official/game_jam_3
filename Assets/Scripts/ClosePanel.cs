using System;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject panelToClose;

    public void Close()
    {
        Console.Write("qq");
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
        }
    }
}