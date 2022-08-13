using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pages, people, advanture_time, cost;
    [SerializeField]
    private GameObject buy_panel, not_enough_panel, shop;
    [SerializeField]
    private Text how_much;
    private int page = 0;
    private int money = 0;
    private int index_person = 0;

    [SerializeField]
    private string[] persons;
    [SerializeField]
    private Sprite[] objects;

    void Start()
    {
        add_skins_pp(people);
        add_skins_pp(advanture_time);
        check_skins(people);
        check_skins(advanture_time);

        if (PlayerPrefs.GetString("choose") == "")
            PlayerPrefs.SetString("choose", "Farmer");

        money = PlayerPrefs.GetInt("money");
        turn_page();
        change_currency();
        update_cost();
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

    public void buy(int i)
    {
        if (page == 0) {
            if (money >= int.Parse(people[i].transform.Find("cost").GetComponent<Text>().text))
            {
                people[i].transform.Find("frame").gameObject.SetActive(true);
                people[i].transform.GetComponent<Toggle>().enabled = true;
                people[i].GetComponent<Toggle>().isOn = true;
                index_person = i;
                buy_panel.SetActive(true);
            }
            else
            {
                how_much.text = money.ToString() + "/" + int.Parse(people[i].transform.Find("cost").GetComponent<Text>().text).ToString();
                not_enough_panel.SetActive(true);
                people[i].GetComponent<Toggle>().isOn = false;
            }
        }
        else if (page == 1)
        {
            if (money >= int.Parse(advanture_time[i].transform.Find("cost").GetComponent<Text>().text))
            {
                advanture_time[i].transform.Find("frame").gameObject.SetActive(true);
                advanture_time[i].GetComponent<Toggle>().enabled = true;
                advanture_time[i].GetComponent<Toggle>().isOn = true;
                index_person = i;
                buy_panel.SetActive(true);
            }
            else
            {
                how_much.text = money.ToString() + "/" + int.Parse(advanture_time[i].transform.Find("cost").GetComponent<Text>().text).ToString();
                not_enough_panel.SetActive(true);
                advanture_time[i].GetComponent<Toggle>().isOn = false;
            }
        }
    }

    private void update_cost()
    {
        foreach (var item in cost)
        {
            item.GetComponent<Text>().text = " " + money.ToString();
        }
    }

    public void yes()
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
        gameObject.GetComponent<EventTrigger>().enabled = false;
        update_cost();
        // gameObject.GetComponent<Toggle>().isOn = true;
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
        GameObject[] cur = GameObject.FindGameObjectsWithTag("currency");
        foreach (var item in cur)
        {
            item.GetComponent<Image>().sprite = objects[Array.IndexOf(persons, PlayerPrefs.GetString("choose"))];
            // GameObject.Find("Shop").GetComponent<ToggleGroup>().GetFirstActiveToggle().name
        }
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
                img.GetComponent<EventTrigger>().enabled = false;
            }
        }
    }


    public static void check_choose_skin()
    {
        Debug.Log(GameObject.Find(PlayerPrefs.GetString("choose")));
        GameObject.Find(PlayerPrefs.GetString("choose")).GetComponent<Toggle>().isOn = true;
        // change_currency();
    }
}
