using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ViewYouWin : MonoBehaviour {
    public Text timerLabel;
	public Text fastestLabel;

    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            //timerLabel.text = ("Your Score:"+GameManager.instance.minutes) + ":" + (GameManager.instance.seconds);
            timerLabel.text = ("Your Time:" + GameManager.instance.seconds);

            if (SceneManager.GetActiveScene().name == "scene1")
            {
                fastestLabel.text = ("Fastest Time:" + PlayerPrefs.GetFloat("time1").ToString("0000"));
            }
            else if (SceneManager.GetActiveScene().name == "scene2")
            {
                fastestLabel.text = ("Fastest Time:" + PlayerPrefs.GetFloat("time2").ToString("0000"));
            }
            else fastestLabel.text = ("Fastest Time:" + PlayerPrefs.GetFloat("time3").ToString("0000"));

        }
    }
}
