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
    private GameObject score_text, timer, timer_img;

    float time = 60;
    public static int score = 0;
    public static bool obj_destroy = false;
    void Start()
    {
        time = 60;
        score = 0;
        create_objects();
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        timer.GetComponent<Text>().text = ((int)time).ToString();
        timer_img.GetComponent<Image>().fillAmount = time / 60;
        if (obj_destroy)
        {
            score_text.GetComponent<Text>().text = score.ToString();
            create_objects();
            obj_destroy = false;
        }
    }

    private void create_objects()
    {
        Instantiate(objects[Array.IndexOf(persons, PlayerPrefs.GetString("choose"))], new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 1, UnityEngine.Random.Range(-10.0f, 10.0f)), objects[Array.IndexOf(persons, PlayerPrefs.GetString("choose"))].transform.rotation);
    }
}
