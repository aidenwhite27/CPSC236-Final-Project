using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallGenerator : MonoBehaviour
{
    public ObjectPooler ballPool;


    public void SpawnBalls(Vector3 startPosition)
    {
        GameObject ball = ballPool.GetPooledObject();
        ball.transform.position = startPosition;
        ball.SetActive(true);
    }
}
