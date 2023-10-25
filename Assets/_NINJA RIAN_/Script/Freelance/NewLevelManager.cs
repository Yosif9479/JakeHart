using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class NewLevelManager : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NewLevelManager")
        {
            GlobalValue.lastOrNewLevel = 1;
            GameObject.Find("ScreenFade").GetComponent<ScreenFader>().yes = true;
            GameObject.Find("ScreenFade").GetComponent<ScreenFader>().StartCoroutine("Start");
            /*if (GameObject.Find("ScreenFade").GetComponent<ScreenFader>().fuck == true)
            {
                GlobalValue.checkpointNumber = 0;
                GlobalValue.lastOrNewLevel = 1;
                GameManager.Instance.GameFinish();
                if (GetComponent<Animator>() != null)
                    GetComponent<Animator>().SetBool("finish", true);
                MenuManager.Instance.NextLevel();
                //SoundManager.PlaySfx(sound, 0.5f);
            }*/
        }
    }
    public void gabe()
    {
        //if (GameObject.Find("ScreenFade").GetComponent<ScreenFader>().fuck == true)
     //   {
            GlobalValue.checkpointNumber = 0;
            GlobalValue.lastOrNewLevel = 1;
            GameManager.Instance.GameFinish();
            if (GetComponent<Animator>() != null)
                GetComponent<Animator>().SetBool("finish", true);
            MenuManager.Instance.NextLevel();
            //SoundManager.PlaySfx(sound, 0.5f);
            //GameObject.Find("ScreenFade").GetComponent<ScreenFader>().fuck = false;
       // }
    }
}
