using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject shop, game, home, place;
    void Start()
    {
        place.SetActive(true);
    }

    public void shopping()
    {
        home.SetActive(false);
        shop.SetActive(true);
        UI.check_choose_skin();
    }

    public void close()
    {
        home.SetActive(true);
        shop.SetActive(false);
    }

    public void settings()
    {
        
    }

    public void play()
    {
        home.SetActive(false);
        game.SetActive(true);
    }

    public void main()
    {
        home.SetActive(true);
        place.SetActive(false);
    }
}
