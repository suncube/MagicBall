using UnityEngine;
using System.Collections;

public class UiThemesController : MonoBehaviour {

    public GameObject[] SelectThemes;
	// Use this for initialization
	void Start ()
	{
	    SetSelectedThemeId(PlayerPrefs.GetInt("ThemeID"));
	}

    public void SetSelectedThemeId(int id)
    {
        for (int index = 0; index < SelectThemes.Length; index++)
            SelectThemes[index].SetActive(false);

        SelectThemes[id].SetActive(true);
    }

    // Update is called once per frame
	void Update () {
	
	}
}
