using UnityEngine;
using System.Collections;

public class UISettingController : MonoBehaviour {

    public GameObject[] SelectLocalize;
	// Use this for initialization
	void Start ()
	{
	    SetSelectLocalizeId(PlayerPrefs.GetInt("localize"));
	}

    public void SetSelectLocalizeId(int id)
    {
        for (int index = 0; index < SelectLocalize.Length; index++)
            SelectLocalize[index].SetActive(false);

        SelectLocalize[id].SetActive(true);
    }

    // Update is called once per frame
	void Update () {
	
	}

}
