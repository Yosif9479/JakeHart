using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public float fade_speed = 0.5f;
    public bool yes;
    public bool fuck = false;

    IEnumerator Start()
    {
        fuck = false;
        Image fadeImage = GetComponent<Image>();
        Color color = fadeImage.color;

        if (yes == true)
        {
            color.a = 0;
            while (color.a < 1f)
            {
                color.a += fade_speed * Time.deltaTime;
                fadeImage.color = color;
                yield return null;
            }
            if (GlobalValue.lastOrNewLevel == 0)
            {
                GlobalValue.lastOrNewLevel = 0;
                GlobalValue.levelPlaying -= 2;
                GameManager.Instance.GameFinish();
                if (GetComponent<Animator>() != null)
                    GetComponent<Animator>().SetBool("finish", true);
                //GameObject.Find("ScreenFade").GetComponent<ScreenFader>().fuck = false;
                MenuManager.Instance.NextLevel();
            }
            else if (GlobalValue.lastOrNewLevel == 1)
            {
                GlobalValue.checkpointNumber = 0;
                GlobalValue.lastOrNewLevel = 1;
                GameManager.Instance.GameFinish();
                if (GetComponent<Animator>() != null)
                    GetComponent<Animator>().SetBool("finish", true);
                MenuManager.Instance.NextLevel();
            }
        }
        else
        {
            color.a = 1;
            while (color.a > 0f)
            {
                color.a -= fade_speed * Time.deltaTime;
                fadeImage.color = color;
                yield return null;
            }
        }
        fuck = true;
        //gameObject.SetActive(false);
    }
}