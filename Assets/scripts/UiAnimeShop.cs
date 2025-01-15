using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimeShop : MonoBehaviour
{
    [SerializeField] GameObject Soundobj, betwin;
    public static UiAnimeShop ui;
    private int Double = 1;
    private int begin = 0;
    void Start()
    {
        ui = this;
    }

    public void motion()
    {
        if(Double == 1)
        {
            LeanTween.moveLocalX(Soundobj, -375.57f, 0.2f);
            LeanTween.scaleX(Soundobj, 2.93f, 0.2f);
            if(begin == 0)
                LeanTween.moveLocalY(Soundobj, Soundobj.transform.localPosition.y - 10f, 1.5f).setEaseInOutSine().setLoopPingPong();
            Double = 0;
            begin = 1;
        }
        else
        {
            LeanTween.moveLocalX(Soundobj, -100, 0.2f);
            LeanTween.scaleX(Soundobj, 0f, 0.2f);
            Double = 1;
        }
    }
    static public void butten_haver(GameObject buttenobj)
    {
        LeanTween.scale(buttenobj, new Vector3(buttenobj.transform.localScale.x / 1.5f, buttenobj.transform.localScale.y / 1.5f, buttenobj.transform.localScale.z / 1.5f),0.05f);
        LeanTween.scale(buttenobj, new Vector3((buttenobj.transform.localScale.x / 1.5f) * 1.5f, (buttenobj.transform.localScale.y / 1.5f) * 1.5f, (buttenobj.transform.localScale.z / 1.5f) * 1.5f), 0.05f).setDelay(0.05f);
    }

    public void betwen_scines()
    {
        Image r = betwin.GetComponent<Image>();
        LeanTween.value(betwin, 1, 0, 0.2f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setEase(LeanTweenType.easeInCirc);
    }

}
