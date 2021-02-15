using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, -1f)).normalized;
    }

    //private Vector3 GetRoamingPosition()
    //{
        //return startingPosition + GetRandomDir * UnityEngine.Random.range(10f, 70f);
    //}
}


