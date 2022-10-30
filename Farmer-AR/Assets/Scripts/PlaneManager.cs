using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaneManager : SwitchCanvas
{
    [SerializeField] 
    private GameObject plane_marker_person, score, nums, arrow;
    [SerializeField]
    private GameObject[] persons, storage;

    private ARRaycastManager ARRaycastManagerScript;
    private Vector2 TouchPosition;
    
    bool flag = true;
    bool create = true;
    bool start = false;

    private Dictionary<string, GameObject> spawner_persons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> spawner_storage = new Dictionary<string, GameObject>();


    void Start()
    {
        for (int i = 0; i < persons.Length; i++)
        {
            spawner_persons.Add(persons[i].name.ToString(), persons[i]);
            spawner_storage.Add(persons[i].name.ToString(), storage[i]);

            Debug.Log(spawner_persons[persons[i].name.ToString()]);
        }

        Debug.Log(PlayerPrefs.GetString("currency"));

        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        // plane_marker_person.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ShowMarker();
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0 && flag)
        {
            plane_marker_person.transform.position = hits[0].pose.position;
            plane_marker_person.SetActive(true);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && flag)
        {
            var man = Instantiate(spawner_persons[PlayerPrefs.GetString("choose")], plane_marker_person.transform.Find("default").transform.position, plane_marker_person.transform.Find("default").transform.rotation);
            var box = Instantiate(spawner_storage[PlayerPrefs.GetString("choose")], plane_marker_person.transform.Find("corob_marker").transform.position, plane_marker_person.transform.Find("corob_marker").transform.rotation);

            man.transform.localScale = plane_marker_person.transform.localScale;
            box.transform.localScale = plane_marker_person.transform.localScale;

            man.name = "man";
            box.name = "box";

            // nums.transform.parent = GameObject.Find("man").transform;
            // arrow.transform.parent = GameObject.Find("box").transform;
            // score.transform.parent = GameObject.Find("box").transform;

            flag = false;
            // GetComponent<ARPointCloudManager>().enabled = false;
            // Destroy(GameObject.Find("AR Default Point Cloud"));

            // man.transform.SetParent(nums.transform);
            

            main();

            plane_marker_person.SetActive(false);
            start = true;

            /*for (int i = 1; i < 5; i++)
            {
                TakeProduct.polky.Add(shelf.transform.Find("Polka" + i.ToString()).gameObject);
            }

            Debug.Log(TakeProduct.polky);*/
        }
    }

    public void Test()
    {
        var man = Instantiate(spawner_persons[PlayerPrefs.GetString("choose")], plane_marker_person.transform.Find("default").transform.position, plane_marker_person.transform.Find("default").transform.rotation);
        var box = Instantiate(spawner_storage[PlayerPrefs.GetString("choose")], plane_marker_person.transform.Find("corob_marker").transform.position, plane_marker_person.transform.Find("corob_marker").transform.rotation);

        man.transform.localScale = plane_marker_person.transform.localScale;
        box.transform.localScale = plane_marker_person.transform.localScale;

        man.name = "man";
        box.name = "box";

        // nums.transform.SetParent(GameObject.Find("man").transform);
        // arrow.transform.SetParent(GameObject.Find("box").transform);
        // score.transform.SetParent(GameObject.Find("box").transform);

        plane_marker_person.SetActive(false);

        main();

        start = true;
    }

    public void change_pers()
    {
        if (start)
        {
            if (create)
            {
                nums.transform.SetParent(null);
                arrow.transform.SetParent(null);
                score.transform.SetParent(null);

                Destroy(GameObject.Find("man"));
                Destroy(GameObject.Find("box"));

                var man = Instantiate(spawner_persons[PlayerPrefs.GetString("choose")], plane_marker_person.transform.Find("default").transform.position, plane_marker_person.transform.Find("default").transform.rotation);
                var box = Instantiate(spawner_storage[PlayerPrefs.GetString("choose")], plane_marker_person.transform.Find("corob_marker").transform.position, spawner_storage[PlayerPrefs.GetString("choose")].transform.rotation);

                man.transform.localScale = plane_marker_person.transform.localScale;
                box.transform.localScale = plane_marker_person.transform.localScale;

                man.name = "man";
                box.name = "box";

                //nums.transform.parent = GameObject.Find("man").transform;
                //arrow.transform.parent = GameObject.Find("box").transform;
                //score.transform.parent = GameObject.Find("box").transform;
                create = false;
            }
            else
            {
                create = true;
            }
        }
    }
}
