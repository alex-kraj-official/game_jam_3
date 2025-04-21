using UnityEngine;
using UnityEngine.EventSystems;

public class DifficultyHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private DifficultySelector difficultySelector;
    [SerializeField] private GameObject DifficultyDesc;
    [SerializeField] private string difficultyName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        DifficultyDesc.SetActive(true);
        difficultySelector.DifficultyDesc(difficultyName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DifficultyDesc.SetActive(false);
        difficultySelector.DifficultyDesc("");
    }
}