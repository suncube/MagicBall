using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using EventTrigger = UnityEngine.EventSystems.EventTrigger;


// game logic
public class GameController : MonoBehaviour
{
    public ShakingController ShakingController;
    //public TouchController TouchController;
    public Animator BallAnimator;
    public AnswerShowController AnswerShowController;
    private float ShowTime = 7f;

    private AnswerController AnswerController;

	// Use this for initialization
	void Start ()
	{
        AnswerController = new AnswerController(AnswerGroupHelper.instance.AnswerGroups[0]);

        ShakingController.OnShaked += () =>
        {
            if (isLockShowActive) return;
              GetAnswer();
        };
	}

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (!BallAnimator.GetBool("ShowAnswer"))
        {
            Reset();
            return;
        }

        if (isLockShowActive) return;

        LockShowActive();
        GetAnswer();
    }

    private bool isLockShowActive = false;

    public void UnlockShowActive()
    {
        isLockShowActive = false;
    }

    public void LockShowActive()
    {
        isLockShowActive = true;
    }

    public void GetAnswer()
    {
        LockShowActive();

        var answer = AnswerController.GetAnswer();
        AnswerShowController.ShowAnswer(answer);

        BallAnimator.SetBool("ShowAnswer", false);
        BallAnimator.Play("ShowAnswer");

        Invoke("AnswerShowed",ShowTime);

    }
    
    public void Reset()
    {
        UnlockShowActive();
        BallAnimator.Play("HideAnswer");
        BallAnimator.SetBool("ShowAnswer", true);
        CancelInvoke();
    }

    private void AnswerShowed()
    {
        Reset();
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
