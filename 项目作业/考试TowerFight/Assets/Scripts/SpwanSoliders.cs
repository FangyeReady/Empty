using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpwanSoliders : MonoBehaviour
{
    public GameObject prefab;
    public Transform target;
    public Transform soliderContainer;

    public int spwanCount = 3;
    bool canStartGame = false;
    float spwanInterval = 10f;
    float time = 10f;
    private void Start()
    {
       // InvokeRepeating("Spwan", 0f,10f);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (canStartGame && time > spwanInterval)
        {
            Spwan();
            time = 0f;
        }
    }

    public void SetGameStart()
    {
        canStartGame = true;
        time = 10f;
    }

    public void SetGamePause()
    {
        canStartGame = false;
    }

    public void ContinuePlay()
    {
        canStartGame = true;
    }


    void Spwan()
    {
        for (int i = 0; i < spwanCount; i++)
        {
            GameObject item = Instantiate(prefab, soliderContainer);
            item.transform.localRotation = Quaternion.identity;
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = new Vector3(0, 0, i);

            NavMeshAgent agent = item.GetComponent<NavMeshAgent>();
            agent.SetDestination(target.position);

            int mask = 1 << (i + 3) | 1;
            agent.areaMask = mask;
        }
    }

}
