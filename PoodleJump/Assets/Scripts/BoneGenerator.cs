using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneGenerator : MonoBehaviour
{
    public ObjectPooler bonePool;


    public void SpawnBones(Vector3 startPosition)
    {
        GameObject bone = bonePool.GetPooledObject();
        bone.transform.position = startPosition;
        bone.SetActive(true);
    }

   
}
