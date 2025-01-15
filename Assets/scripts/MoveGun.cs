using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGun : MonoBehaviour
{
    public float distence;
    public  Camera cam;
    public float speed = 1f;

    public LayerMask layerMask;
    private Vector3 tempMousePos;
    private bool isDragging = false;

    public GameObject placeOfbullet;
    public GameObject bullet;
    public float bulletSpeed = 20f;

    public GameObject Fireplace;
    public GameObject Fireparticle;
    private GameplayController gameplayController;



    void Start()
    {
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float screenHeight = Screen.height;
        float upperLimit = screenHeight;
        float lowerLimit = screenHeight / 3;
        mousePos.y = Mathf.Clamp(mousePos.y, lowerLimit, upperLimit);
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distence));
        Vector3 direction = mouseWorldPos - this.transform.position;
        bool isMouse0Down = Input.GetKey(KeyCode.Mouse0);
        bool isMouse0Up = Input.GetMouseButtonUp(0);
        Ray ray = cam.ScreenPointToRay(mousePos);
        if (direction != Vector3.zero)
        {

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Slerp(
                this.transform.rotation,
                targetRotation,
                speed * Time.deltaTime
            );
        }
        if (gameplayController.gamebegin)
        {

            if (isMouse0Up)
            {
                isDragging = true;

            }

            if (isDragging && isMouse0Up)
            {
                isDragging = false;
                FireBullet(mouseWorldPos);

            }
        }
        

    }


    void FireBullet(Vector3 targetPosition)
    {
        FindObjectOfType<AudioManager>().PlaySound("fire");
        GameObject spawnedBullet = Instantiate(bullet, placeOfbullet.transform.position, Quaternion.identity);
        GameObject fire = Instantiate(Fireparticle, Fireplace.transform.position, Quaternion.identity);
        StartCoroutine(_destroyFire(fire));
        StartCoroutine(MoveBullet(spawnedBullet, targetPosition, fire));
    }

    IEnumerator MoveBullet(GameObject spawnedBullet, Vector3 targetPosition,GameObject fire)
    {
        Vector3 direction = (targetPosition - spawnedBullet.transform.position).normalized;

        while (spawnedBullet != null && Vector3.Distance(spawnedBullet.transform.position, targetPosition) > 0.1f)
        {
            spawnedBullet.transform.position += direction * bulletSpeed * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator _destroyFire( GameObject fire)
    {
        yield return new WaitForSeconds(1);
        Destroy(fire);
    }


}
