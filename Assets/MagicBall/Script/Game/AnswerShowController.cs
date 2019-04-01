using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// for visualize
public class AnswerShowController : MonoBehaviour
{
    public Text AnswerText2;// for test 
    public Text AnswerText;
    public UILocalization Localization;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowAnswer(Answer answer)
    {
      //  AnswerText2.text = AnswerText.text = answer.TextKey;
        Localization.Key = answer.TextKey;
    //    UnityAnalyticsHelper.UnityAnalyticsLog("Show Answer", new Dictionary<string, object> { { answer.TextKey, string.Empty } });
     //   UnityAnalyticsHelper.FlurryAnalyticsLog("Show Answer", new Dictionary<string, string> { { answer.TextKey, string.Empty } });
    }
}