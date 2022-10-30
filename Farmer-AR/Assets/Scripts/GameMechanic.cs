using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameMechanic : MonoBehaviour
{
    [SerializeField]
    private string[] persons;
    [SerializeField]
    private GameObject[] objects;

    [SerializeField]
    private GameObject score_text, timer, timer_img, game_over_panel, num0, num1, num2, num3, num4, num5, arrow, marker;

    float time = 60;
    public static int bag = 0;
    public static bool put_to_bag = false;
    public static int score = 0;
    public static bool obj_destroy = false;
    int money;
    bool game;
    void Start()
    {
        game_over_panel.SetActive(false);
        score_text.GetComponent<TextMesh>().text = "0";
        time = 60;
        score = 0;
        bag = 0;
        money = PlayerPrefs.GetInt("money");
        game = true;
        create_objects();
    }

    void Update()
    {
        if (game)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            timer.GetComponent<Text>().text = ((int)time).ToString();
            timer_img.GetComponent<Image>().fillAmount = time / 60;
            if (time <= 0)
            {
                money += bag;
                PlayerPrefs.SetInt("money", money);
                if (bag > PlayerPrefs.GetInt("record"))
                {
                    PlayerPrefs.SetInt("record", bag);
                    // record.GetComponent<Text>().text = bag.ToString();
                }
                // Time.timeScale = 0;
                game = false;
                game_over_panel.SetActive(true);
            }
            if (obj_destroy)
            {
                // score_text.GetComponent<Text>().text = score.ToString();
                create_objects();
                obj_destroy = false;
            }
            if (put_to_bag)
            {
                score_text.GetComponent<TextMesh>().text = bag.ToString();
                put_to_bag = false;
            }

            if (score == 0)
            {
                num5.SetActive(false);
                num0.SetActive(true);
                arrow.SetActive(false);
            }
            else if (score == 1)
            {
                num0.SetActive(false);
                num1.SetActive(true);
            }
            else if (score == 2)
            {
                num1.SetActive(false);
                num2.SetActive(true);
            }
            else if (score == 3)
            {
                num2.SetActive(false);
                num3.SetActive(true);
            }
            else if (score == 4)
            {
                num3.SetActive(false);
                num4.SetActive(true);
            }
            else if (score == 5)
            {
                num4.SetActive(false);
                num5.SetActive(true);
                arrow.SetActive(true);
            }
        }
    }

    private void create_objects()
    {
        var obj = Instantiate(objects[Array.IndexOf(persons, PlayerPrefs.GetString("choose"))], new Vector3(UnityEngine.Random.Range(GameObject.Find("box").transform.position.x - 0.5f, GameObject.Find("box").transform.position.x + 0.5f), GameObject.Find("box").transform.position.y, UnityEngine.Random.Range(GameObject.Find("box").transform.position.z - 0.5f, GameObject.Find("box").transform.position.z + 0.5f)), objects[Array.IndexOf(persons, PlayerPrefs.GetString("choose"))].transform.rotation);
        obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    public void reset()
    {
        game_over_panel.SetActive(false);
        score_text.GetComponent<TextMesh>().text = "0";
        time = 60;
        score = 0;
        bag = 0;
        game = true;
        obj_destroy = true;
        Destroy(GameObject.FindGameObjectWithTag("objects"));
        GameObject.Find("man").transform.position = marker.transform.position;
        GameObject.Find("man").transform.rotation = marker.transform.rotation;
    }
}
