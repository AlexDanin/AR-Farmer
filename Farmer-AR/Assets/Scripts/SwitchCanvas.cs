using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject shop, game, home, place, record, money1, money2, nums, arrow, score;
    void Start()
    {
        place.SetActive(true);
        home.SetActive(false);
        shop.SetActive(false);
        game.SetActive(false);

        if (!PlayerPrefs.HasKey("record"))
            PlayerPrefs.SetInt("record", 0);

        record.GetComponent<Text>().text = "best " + PlayerPrefs.GetInt("record").ToString();
    }

    public void shopping()
    {
        home.SetActive(false);
        shop.SetActive(true);
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
        nums.transform.SetParent(GameObject.Find("man").transform);
        arrow.transform.SetParent(GameObject.Find("box").transform);
        score.transform.SetParent(GameObject.Find("box").transform);
    }

    public void main()
    {
        record.GetComponent<Text>().text = "best " + PlayerPrefs.GetInt("record").ToString();
        money1.GetComponent<Text>().text = PlayerPrefs.GetInt("money").ToString();
        money2.GetComponent<Text>().text = PlayerPrefs.GetInt("money").ToString();
        home.SetActive(true);
        place.SetActive(false);
        game.SetActive(false);
    }
}
