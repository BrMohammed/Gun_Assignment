using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimation : MonoBehaviour
{

    [SerializeField]
    GameObject startobj, paramobj, sharobj, likeobj, betwin;

    public static UiAnimation ui;

    void Start()
    {
        ui = this;
        LeanTween.scale(startobj, new Vector3(1.767763f, 9.080779f, 1.874742f), 1f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(sharobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(paramobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(likeobj, new Vector3(0.8221743f, 4.358987f, 0.8221743f), 1f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic);
    }

    public void close()
    {
        LeanTween.scale(startobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(sharobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(paramobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(likeobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic);
    }

    static public void PausePaneleEAffects(GameObject resumeicoobj, GameObject homeicoobj, GameObject returnicoob)
    {
        resumeicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        homeicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        returnicoob.transform.localScale = new Vector3(0f, 0f, 0f);

        LeanTween.scale(resumeicoobj, new Vector3(0.5349266f, 0.5349266f, 0.5349266f), 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(homeicoobj, new Vector3(0.6832607f, 3.211845f, 0.6832607f), 1f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(returnicoob, new Vector3(0.557861f, 2.957656f, 0.557861f), 1f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
    }

    static public void closePausePaneleEAffects(GameObject resumeicoobj, GameObject homeicoobj, GameObject returnicoob)
    {
        LeanTween.scale(resumeicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(homeicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
        LeanTween.scale(returnicoob, new Vector3(0, 0, 0), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
    }

    static public void butten_haver(GameObject buttenobj)
    {
        LeanTween.scale(buttenobj, new Vector3(buttenobj.transform.localScale.x / 1.5f, buttenobj.transform.localScale.y / 1.5f, buttenobj.transform.localScale.z / 1.5f), 0.05f).setIgnoreTimeScale(true);
        LeanTween.scale(buttenobj, new Vector3((buttenobj.transform.localScale.x / 1.5f) * 1.5f, (buttenobj.transform.localScale.y / 1.5f) * 1.5f, (buttenobj.transform.localScale.z / 1.5f) * 1.5f), 0.05f).setDelay(0.05f).setIgnoreTimeScale(true);
    }
    static public void ADwatchEffect(GameObject adwatch)
    {
        adwatch.transform.localScale = new Vector3(0.8f, 0.8f, 0f);
        LeanTween.scale(adwatch, new Vector3(1.1f, 1.1f, 0), 0.8f)
            .setEaseLinear()
            .setLoopPingPong()
            .setDelay(0.2f);
    }
    static public void gameovereffect(GameObject Gogameovericoobj, GameObject Gohighscoreicoobj, GameObject Goscoreicoobj, GameObject Gohomeicoobj, GameObject Goretrygameicoobj)
    {
        Gogameovericoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        Gohighscoreicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        Goscoreicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        Gohomeicoobj.transform.localScale = new Vector3(0f, 0f, 0f);
        Goretrygameicoobj.transform.localScale = new Vector3(0f, 0f, 0f);

        LeanTween.scale(Gogameovericoobj, new Vector3(1.4579f, 1.4579f, 1.4579f), 1f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Gohighscoreicoobj, new Vector3(0.99371476f, 0.9371476f, 0.9371476f), 1f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Goscoreicoobj, new Vector3(0.9371476f, 0.9371476f, 0.9371476f), 1f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Gohomeicoobj, new Vector3(0.7405146f, 3.586867f, 0.7405146f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Goretrygameicoobj, new Vector3(0.702653f, 3.725312f, 0.702653f), 1f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
    }

    static public void close_gameovereffect(GameObject Gogameovericoobj, GameObject Gohighscoreicoobj, GameObject Goscoreicoobj, GameObject Gohomeicoobj, GameObject Goretrygameicoobj)
    {
        LeanTween.scale(Gogameovericoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Gohighscoreicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Goscoreicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Gohomeicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Goretrygameicoobj, new Vector3(0, 0, 0), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
    }

    public void betwen_scines()
    {
        Image r = betwin.GetComponent<Image>();
        LeanTween.value(betwin, 0, 1, 0.2f).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        }).setEase(LeanTweenType.easeInCirc);
    }

    static public void tutor(GameObject up, GameObject down , GameObject hande)
    {
        LeanTween.moveLocal(up,new Vector2 (0,40),0.3f)
            .setEaseLinear()
            .setLoopPingPong()
            .setDelay(0.2f);
        LeanTween.moveLocal(down, new Vector2(0, -500), 0.3f)
            .setEaseLinear()
            .setLoopPingPong()
            .setDelay(0.2f);
        LeanTween.moveLocal(hande, new Vector2(0, -180), 0.5f)
            .setEaseLinear()
            .setLoopPingPong()
            .setDelay(0.1f);
    }
}
