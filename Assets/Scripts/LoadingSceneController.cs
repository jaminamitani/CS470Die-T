using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneController : MonoBehaviour {
    public GameObject loadingScreen;
    public Slider slider;
    public Text percent;
    public Image lolipop;
    public GameObject startPos, endPos;

    public void loadLevel(int sceneIndex){
        StartCoroutine(loadAsynchronously(sceneIndex));

    }
   
    IEnumerator loadAsynchronously (int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true); 
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            percent.text = progress * 100f + "%";
            lolipop.transform.position = Vector3.Lerp(startPos.transform.position, endPos.transform.position, operation.progress);
            yield return null;
        }  
    }
}
