using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject panelToClose;

    public void Close()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);
        }
    }
}