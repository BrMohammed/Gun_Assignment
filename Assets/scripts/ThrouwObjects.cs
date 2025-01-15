using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private GameplayController gameplayController;
    public float throwForce = 10f;
    public GameObject[] objects; 
    public float minSpawnInterval = 0.5f; 
    public float maxSpawnInterval = 2f; 

    private float currentSpawnInterval;
    public float Destroytime = 1f;
    public float destenceoflooping = 4;

    private void Start()
    {
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();

        UpdateSpawnInterval();
        InvokeRepeating("ThrowRandomObject",2, currentSpawnInterval);
        LeanTween.moveLocalX(gameObject,transform.localPosition.x - destenceoflooping, 2).setLoopPingPong();
    }

    void UpdateSpawnInterval()
    {
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void ThrowRandomObject()
    {
        if (gameplayController.gamebegin)
        {
            if (objects.Length == 0) return;
            int randomIndex = Random.Range(0, objects.Length);
            GameObject randomObject = objects[randomIndex];
            GameObject spawnedObject = Instantiate(randomObject, this.transform.position, randomObject.transform.rotation);
            StartCoroutine(_Destroy(spawnedObject));
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * throwForce, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("Spawned object does not have a Rigidbody!");
            }
            UpdateSpawnInterval();
        }
    }
    IEnumerator _Destroy(GameObject obj)
    {
        yield return new WaitForSeconds(Destroytime);
        Destroy(obj); 
    }
}
