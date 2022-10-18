using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pages, cost_text;
    [SerializeField]
    private GameObject buy_panel, insufficient_funds;
    [SerializeField]
    private Text how_mach;
    private int page = 0;
    private int money = 0;

    GameObject obj;
    int cost_num = 100;

    void Start()
    {
        if (PlayerPrefs.GetString("choose") == "")
            PlayerPrefs.SetString("choose", "Farmer");

        if (!PlayerPrefs.HasKey("money"))
            PlayerPrefs.SetInt("money", 0);
        money = PlayerPrefs.GetInt("money");

        update_money();
    }

    public void next_page()
    {
        page += 1;
        turn_page();
    }

    public void previous_page()
    {
        page -= 1;
        turn_page();
    }

    private void turn_page()
    {
        foreach (GameObject item in pages)
        {
            item.transform.localPosition = new Vector3(2000, item.transform.localPosition.y, 0);
        }
        pages[page].transform.localPosition = new Vector3(0, pages[page].transform.localPosition.y, 0);
    }

    private void update_money()
    {
        foreach (var item in cost_text)
        {
            item.GetComponent<Text>().text = " " + money.ToString();
        }
    }

    public void buy(GameObject game)
    {
        if (money >= cost_num)
        {
            buy_panel.SetActive(true);
            obj = game;
        }
        else
        {
            insufficient_funds.SetActive(true);
            how_mach.text = money.ToString() + "/" + cost_num.ToString();
        }
    }

    public void yes()
    {
        buy_panel.SetActive(false);
        PlayerPrefs.SetInt(obj.transform.parent.gameObject.name, 1);

        money -= cost_num;
        PlayerPrefs.SetInt("money", money);
        update_money();
        Destroy(obj);
    }

    public void no()
    {
        buy_panel.SetActive(false);
    }
    /*public void yes()
    {
        if (page == 0)
            making_a_purchase(people[index_person]);
        else if (page == 1)
            making_a_purchase(advanture_time[index_person]);

        buy_panel.SetActive(false);

        // Debug.Log(GameObject.Find("Shop").GetComponent<ToggleGroup>().GetFirstActiveToggle().name);
        change_currency();
    }

    private void making_a_purchase(GameObject gameObject)
    {
        money -= int.Parse(gameObject.transform.Find("cost").GetComponent<Text>().text);

        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt(gameObject.name, 1);

        gameObject.transform.Find("lock").gameObject.SetActive(false);
        gameObject.transform.Find("cost").gameObject.SetActive(false);
        gameObject.transform.Find("currency").gameObject.SetActive(false);
        gameObject.transform.Find("frame").gameObject.SetActive(true);
        gameObject.GetComponent<EventTrigger>().enabled = false;
        gameObject.GetComponent<Toggle>().enabled = true;
        update_cost();
        gameObject.GetComponent<Toggle>().isOn = true;
    }

    public void no()
    {
        buy_panel.SetActive(false);
    }

    public void ok()
    {
        not_enough_panel.SetActive(false);
    }

    public void change_currency()
    {
        try
        {
            PlayerPrefs.SetString("choose", shop.GetComponent<ToggleGroup>().GetFirstActiveToggle().name);
        }
        catch (Exception)
        {
            Debug.Log("404");
        } 
        foreach (var item in currency)
        {
            item.GetComponent<Image>().sprite = objects[Array.IndexOf(persons, PlayerPrefs.GetString("choose"))];
            // GameObject.Find("Shop").GetComponent<ToggleGroup>().GetFirstActiveToggle().name
        }
        Debug.Log(objects[Array.IndexOf(persons, PlayerPrefs.GetString("choose"))]);
    }

    private void add_skins_pp(GameObject[] skins)
    {
        if (PlayerPrefs.GetInt(skins[0].name.ToString()) == 0)
        {
            foreach (var img in skins)
            {
                if (img.name == "Farmer")
                {
                    PlayerPrefs.SetInt("Farmer", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name, 0);
                }
            }
        }
    }

    private void check_skins(GameObject[] skins)
    {
        foreach (var img in skins)
        {
            if (PlayerPrefs.GetInt(img.name) == 1)
            {
                img.transform.Find("lock").gameObject.SetActive(false);
                img.transform.Find("cost").gameObject.SetActive(false);
                img.transform.Find("currency").gameObject.SetActive(false);
                img.transform.Find("frame").gameObject.SetActive(true);
                img.GetComponent<EventTrigger>().enabled = false;
                img.GetComponent<Toggle>().enabled = true;
            }
        }
    }


    public static void check_choose_skin()
    {
        Debug.Log(GameObject.Find(PlayerPrefs.GetString("choose")));
        GameObject.Find(PlayerPrefs.GetString("choose")).GetComponent<Toggle>().enabled = true;
        GameObject.Find(PlayerPrefs.GetString("choose")).GetComponent<Toggle>().isOn = true;
        // change_currency();
    }*/
}
