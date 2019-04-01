using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;

public class UIController : MonoBehaviour
{
    public GameObject[] LocalizeSelect;
    public CanvasGroup MenuGroup;
    private bool isMenuShow;
    public void ShowMenu()
    {
        isMenuShow = !isMenuShow;
        StartCoroutine(ShowMenuAlpha(isMenuShow));
    }

    private void SetLocalizeSelect()
    {
        switch (LocalizationHelper.instance.Localization)
        {
            case LocalizationHelper.LocalizationType.English:
                LocalizeSelect[0].SetActive(false);
                LocalizeSelect[1].SetActive(false);
                LocalizeSelect[2].SetActive(true);
                break;
            case LocalizationHelper.LocalizationType.Russian:
                LocalizeSelect[0].SetActive(false);
                LocalizeSelect[1].SetActive(true);
                LocalizeSelect[2].SetActive(false);
                break;
            case LocalizationHelper.LocalizationType.Belarussian:
                LocalizeSelect[0].SetActive(true);
                LocalizeSelect[1].SetActive(false);
                LocalizeSelect[2].SetActive(false);
                break;
        }
    }

    IEnumerator ShowMenuAlpha(bool isShow)
    {
        var from = 0f;
        var to = 1f;
        var step = 1f;
        if (!isShow)
        {
            from = 1f;to = 0f;step = -1f;
        }
        while (true)
        {
            MenuGroup.alpha = from;
            from += step * Time.deltaTime;
            if (isShow && from >= to)
            {
                MenuGroup.alpha = to;
                break;
            }else
            if (!isShow && from <= to)
            {
                MenuGroup.alpha = to;
                break;
            }

            yield return null;
        }
    }

    public void SetEnglish()
    {
        LocalizationHelper.instance.Localization = LocalizationHelper.LocalizationType.English;
        SetLocalizeSelect();
    }

    public void SetRussian()
    {
        LocalizationHelper.instance.Localization = LocalizationHelper.LocalizationType.Russian;
        SetLocalizeSelect();
    }

    public void SetBelarussian()
    {
        LocalizationHelper.instance.Localization = LocalizationHelper.LocalizationType.Belarussian;
        SetLocalizeSelect();
    }

    // Use this for initialization
    private void Start()
    {
        MenuGroup.alpha = 0;
        SetLocalizeSelect();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

#endif
    }
  
    /* 
    public TouchController TouchController;
    public UiThemesController UiThemesController;
    public UISettingController UISettingController;
    public GameController GameController;
    public GameObject MenuButton;
    public MenuGroup[] MenuGroups;
    public Animator MenuAnimator;
    private int GroupId;
    private bool isCanTouch;

	// Use this for initialization
	void Start () {
        TouchController.TouchDownClicked += TouchBeganHandler;
	    MenuActivate();

        for (int index = 0; index < MenuGroups.Length; index++)
            MenuGroups[index].Activate(false);

        MenuGroups[GroupId].Activate(true);
	}
    private void TouchBeganHandler(TouchInfo obj)
    {
        if (obj==null || obj.HitObject == null) return;
        Debug.Log("Touch " + obj.HitObject.name);
     

        
        switch (obj.HitObject.name)
        {
            case "GameButton":
                MenuAnimator.SetBool("isHide",true);
                MenuAnimator.SetBool("isNext", false);
                GroupId = 0;
                isCanTouch = false;
                ButtonActivate(obj.HitObject);
                break;
            case "SettingsButton":
                MenuAnimator.SetBool("isHide",true);
                MenuAnimator.SetBool("isNext", true);
                GroupId = 1;
                isCanTouch = false;
                ButtonActivate(obj.HitObject);
                break;
            case "ThemesButton":
                MenuAnimator.SetBool("isHide",true);
                MenuAnimator.SetBool("isNext", true);
                GroupId = 2;
                isCanTouch = false;
                ButtonActivate(obj.HitObject);
                break;

            case "English":
                SetEnglish();
                UISettingController.SetSelectLocalizeId(0);
                ButtonActivate(obj.HitObject);
                break;

            case "Belarussian":
                SetBelarussian();
                UISettingController.SetSelectLocalizeId(1);
                ButtonActivate(obj.HitObject);
                break;

            case "Russian":
                SetRussian();
                UISettingController.SetSelectLocalizeId(2);
                ButtonActivate(obj.HitObject);
                break;

            case "Themes0":
                 GameController.SetThemes(0);
                UiThemesController.SetSelectedThemeId(0);
                ButtonActivate(obj.HitObject);
                break;
            case "Themes1":
                GameController.SetThemes(1);
                UiThemesController.SetSelectedThemeId(1);
                ButtonActivate(obj.HitObject);
                break;
            case "Themes2":
                GameController.SetThemes(2);
                UiThemesController.SetSelectedThemeId(2);
                ButtonActivate(obj.HitObject);
                break;

            case "Back":
                MenuAnimator.SetBool("isHide", true);
                MenuAnimator.SetBool("isNext", true);
                if (GroupId == 2)
                {
                    ShowAds();
                    Debug.Log("SHOW ADS!!!");
                }
                GroupId = 0;
                isCanTouch = false;
                ButtonActivate(obj.HitObject);
                break;
        }
    }

    private void ButtonActivate(Transform button)
    {
        var component = button.GetComponent<Animator>();
        if (component != null)
        {
            component.Play("Click");
        }
    }

    public void SetEnableTouch()
    {
        isCanTouch = true;
    }

    public void MenuActivate(bool activate)
    {
        GameController.IsLock = activate;
        gameObject.SetActive(activate);
        MenuButton.SetActive(!activate);
        if (activate)
        {
            MenuAnimator.Play("Start");
            MenuAnimator.SetBool("isHide", false);
            MenuAnimator.SetBool("isNext", false);
            GroupId = 0;
        }

    }

    public void ShowAds()
    {
        if (!UnityAdsHelper.IsReady()) return;
        UnityAdsHelper.ShowAd();
        UnityAnalyticsHelper.UnityAnalyticsLog("Show Unity Ads", null);
        UnityAnalyticsHelper.FlurryAnalyticsLog("Show Unity Ads", null);
    }

    public void MenuActivate()
    {
        MenuActivate(true);
        GameController.Reset();
    }

    public void HideMenuEvent()
    {
        if (MenuAnimator.GetBool("isHide") && !MenuAnimator.GetBool("isNext")) 
        {
            MenuActivate(false);
            return;
        }
        MenuAnimator.SetBool("isHide", false);
        MenuAnimator.SetBool("isNext", false);

        for (int index = 0; index < MenuGroups.Length; index++)
             MenuGroups[index].Activate(false);

        MenuGroups[GroupId].Activate(true);
     
    }

    public void SetEnglish()
    {
        LocalizationHelper.instance.Localization = LocalizationHelper.LocalizationType.English;
    }

    public void SetRussian()
    {
        LocalizationHelper.instance.Localization = LocalizationHelper.LocalizationType.Russian;
    }

    public void SetBelarussian()
    {
        LocalizationHelper.instance.Localization = LocalizationHelper.LocalizationType.Belarussian;
    }
    // Update is called once per frame
	void Update () 
    {
        #if UNITY_ANDROID

            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit(); 

        #endif
	}*/
}


/*[System.Serializable]
public class MenuGroup
{
    public GameObject[] Objects;

    public void Activate(bool activate)
    {
        for (int index = 0; index < Objects.Length; index++) 
            Objects[index].SetActive(activate);
    }
}*/