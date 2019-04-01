using UnityEngine;
using System.Collections;

// answer stock
public class AnswerGroupHelper : MonoBehaviour 
{
    public AnswerGroup[] AnswerGroups;
    public static AnswerGroupHelper instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }
}
