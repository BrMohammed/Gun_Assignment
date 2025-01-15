using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    public GameObject hitEffect;
    private GameplayController gameplayController;
    private timer _timer;
    public GameObject Smook;
    private void Start()
    {
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
        if (GameObject.FindGameObjectWithTag("timer").GetComponent<timer>())
                    _timer = GameObject.FindGameObjectWithTag("timer").GetComponent<timer>();
        Invoke("_Destroy", 0.7f);
    }

    private void _Destroy()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log(collision.collider.name);
            ContactPoint contact = collision.contacts[0];
            gameplayController.setscore();
            GameObject fire = Instantiate(hitEffect, contact.point, Quaternion.identity);
            StartCoroutine(Delay(collision.transform.gameObject));
            _timer.timelift += 1;
            FindObjectOfType<AudioManager>().PlaySound("puff");
            gameplayController.Addcoin();
            StartCoroutine(_destroyFire(fire));
        }
    }

    IEnumerator _destroyFire(GameObject fire)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(fire);
    }
    IEnumerator Delay(GameObject smook)
    {
        yield return new WaitForSeconds(0.05f);
        GameObject _smook = Instantiate(Smook, smook.transform.position, Quaternion.identity);

        Destroy(smook);
        StartCoroutine(_destroyFire(_smook));
        Destroy(gameObject);
    }


}
