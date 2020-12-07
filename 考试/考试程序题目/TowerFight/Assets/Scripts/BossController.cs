using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target
{
    RedSolider,
    BlueSolider
}
public class BossController : MonoBehaviour
{
    public Target target;
    public Health hp;
    private string targetTag;

    private GameManager gameManager;

    private void Awake()
    {
        switch (target)
        {
            case Target.RedSolider:
                targetTag = "RedSolider";
                break;
            case Target.BlueSolider:
                targetTag = "BlueSolider";
                break;
            default:
                targetTag = "";
                break;
        }
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            Debug.LogWarning("基地血量减一");
            Destroy(other.gameObject);

            hp.OnAttack(1);

        }
    }
}
