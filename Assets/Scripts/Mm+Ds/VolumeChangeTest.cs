using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.Internal;
using UnityEngine.UI;
using System;

public class VolumeChangeTest : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) //Megnézzük, hogy nincs-e eltárolt musicVolume nevű érték
        {
            PlayerPrefs.SetFloat("musicVolume", 0.75f); //Ha nincsen eddig eltárolt érték, akkor beállítás 75%-ra
        }
        Load(); //Az újonnan beállított érték érvényesítése és mentése (Ha volt korábbi elmentett érték, akkor elég ez)
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save(); //Ha módosul a volumeSlider értéke, akkor az új érték elmentése
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); //A volumeSlider értékének beállítása a musicVolume key name-ben tárolt értékre
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value); //Eltárolja a volumeSlider értékét a musicVolume névben (key name)
    }
}