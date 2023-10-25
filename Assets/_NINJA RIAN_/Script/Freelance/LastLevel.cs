using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastLevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NewLevelManager")
        {
            GlobalValue.lastOrNewLevel = 0;
            GameObject.Find("ScreenFade").SetActive(true);
            GameObject.Find("ScreenFade").GetComponent<ScreenFader>().yes = true;
            GameObject.Find("ScreenFade").GetComponent<ScreenFader>().StartCoroutine("Start");
            /*if (GameObject.Find("ScreenFade").GetComponent<ScreenFader>().fuck == true)
            {
                GlobalValue.lastOrNewLevel = 0;
                GlobalValue.levelPlaying -= 2;
                GameManager.Instance.GameFinish();
                if (GetComponent<Animator>() != null)
                    GetComponent<Animator>().SetBool("finish", true);
                MenuManager.Instance.NextLevel();
            }*/
        }
    }
    public void gabe()
    {
        //if (GameObject.Find("ScreenFade").GetComponent<ScreenFader>().fuck == true)
        //{
            GlobalValue.lastOrNewLevel = 0;
            GlobalValue.levelPlaying -= 2;
            GameManager.Instance.GameFinish();
            if (GetComponent<Animator>() != null)
                GetComponent<Animator>().SetBool("finish", true);
            //GameObject.Find("ScreenFade").GetComponent<ScreenFader>().fuck = false;
            MenuManager.Instance.NextLevel();
      //  }
    }
}
