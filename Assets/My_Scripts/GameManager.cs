using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log("menu button pressed"); // the menu button on the controller
        }
    }

    public void Exit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void FadeIn(float duration = 0.5f) //預設時間0.5秒
    { SteamVR_Fade.View(Color.black, duration); } //0.5秒內畫面變黑色

    public void FadeOut(float duration = 0.5f)
    { SteamVR_Fade.View(Color.clear, duration); }


    public void ChangeScene(string scenename)
    {
        SteamVR_LoadLevel.Begin(scenename);
        //StartCoroutine(LoadAsyncScene(scenename));
    }

    IEnumerator LoadAsyncScene(string scenename)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
