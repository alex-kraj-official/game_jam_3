using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        else
        {
            Debug.LogWarning("Nincs hang beállítva!");
        }
    }
}