using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUnlock : MonoBehaviour
{
    [SerializeField]
    private Toggle[] persons;
    [SerializeField]
    private GameObject[] frames;
    [SerializeField]
    private Image[] currency;
    [SerializeField]
    private Sprite[] currency_sprite;

    private string[] skins =
    {
        "Farmer", "Afra", "Chinese", "Shepherd", "Hunter", "Sheikh", "Fisher", "Beekeeper", "Fin", "Jake", "BMO", "Bubblegum"
    };

    private void Start()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i] == PlayerPrefs.GetString("choose"))
            {
                persons[i].isOn = true;
                frames[i].SetActive(true);
            }
            if (PlayerPrefs.HasKey(skins[i]))
            {
                Destroy(persons[i].transform.parent.GetChild(1).gameObject);
            }
        }
        isActivate();
    }

    public void isActivate()
    {
        for (int i = 0; i < persons.Length; i++)
        {
            if (persons[i].isOn)
            {
                frames[i].SetActive(true);
                PlayerPrefs.SetString("choose", skins[i]);
                foreach (var item in currency)
                {
                    try
                    {
                        item.sprite = currency_sprite[i];
                    }
                    catch (System.Exception)
                    {

                    }
                    
                }
            }
            else
            {
                frames[i].SetActive(false);
            }
        }
    }
}
