using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformHeight;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler theObjectPool;

    public float levelWidth = 4f;
    public float widthDistance;

    private BoneGenerator theBoneGenerator;
    public float randomBoneThreshold;

    private TennisBallGenerator theBallGenerator;
    public float randomBallThreshold;

    // Start is called before the first frame update
    void Start()
    {
        theBoneGenerator = FindObjectOfType<BoneGenerator>();
        theBallGenerator = FindObjectOfType<TennisBallGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < generationPoint.position.y)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            widthDistance = Random.Range(-levelWidth, levelWidth);
            transform.position = new Vector3(widthDistance, transform.position.y + distanceBetween, transform.position.z);
            //Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomBoneThreshold)
            {
                theBoneGenerator.SpawnBones(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomBallThreshold)
            {
                theBallGenerator.SpawnBalls(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
        }
    }
}
