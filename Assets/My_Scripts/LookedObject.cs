
using UnityEngine;
using UnityEngine.UI;
using Tobii.G2OM;
using PixelCrushers.DialogueSystem;

public class LookedObject : MonoBehaviour, IGazeFocusable
{
    public DialogueSystemTrigger DS_trigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void GazeFocusChanged(bool hasFocus)
    {
        //If this object received focus, fade the object's color to highlight color
        if (hasFocus && DS_trigger.isActiveAndEnabled)
        {
            DS_trigger.OnUse();
            DS_trigger.enabled = false;
            // QuestLog.SetQuestState("開始玩", QuestState.Active);
        }
    }
}
