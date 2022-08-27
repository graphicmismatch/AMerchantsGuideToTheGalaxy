using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string sceneToLoad = "Menu";
    public bool async = false;
    public bool onstart = false;
    public static bool hasStated;
    public float waitfor;
    public Image loader;

    private bool iswaiting = false;
    private float timer= 0;
    private void Start()
    {
        if (onstart)
        {    
                LoadScene();
        }
    }

    public void LoadScene()
    {
        bool canLoad = true;

        if (canLoad) {
            if (async)
            {
                StartCoroutine(LoadSceneAsync());
            }
            else
            {
                iswaiting = true;
                timer = waitfor;
            }
        }
        else
        {
            LoadScene();
        }

    }

    private void Update()
    {
        if (iswaiting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            { 
                iswaiting = false;
                timer = 0;
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
                
            }
        }
    }
    public IEnumerator LoadSceneNoAsync()
    {
        yield return new WaitForSeconds(waitfor);
        SceneManager.LoadScene(sceneToLoad);
    }
    public IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(waitfor);
        AsyncOperation gameScene = SceneManager.LoadSceneAsync(sceneToLoad);
        gameScene.allowSceneActivation = false;
        Scene curScene = SceneManager.GetActiveScene();
        while (gameScene.progress < 0.9f)
        { 
           loader.fillAmount = gameScene.progress +0.1f;
            yield return new WaitForEndOfFrame();
        }
        loader.fillAmount = gameScene.progress + 0.1f;
        yield return new WaitForSeconds(waitfor);
        gameScene.allowSceneActivation=true;
        SceneManager.UnloadSceneAsync(curScene);
    }

}
