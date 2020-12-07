using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _Enemy;
    public float timer = 5.0f;
    float UpTime = 1f;
    public GameObject Target;
    Color upchangecolor;
    public Renderer m;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player_Base");
        StartCoroutine(Birth());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            UpTime++;
            timer = 10f;

        }
    }

    IEnumerator Birth() 
    {
        while (true)
        {
            var waite=  new WaitForSeconds(5f);
            for (int i = 3; i < 6; i++)
            {
                GameObject Enemy = GameObject.Instantiate(_Enemy);
                Enemy.transform.parent = this.transform;
                Enemy.transform.position = transform.position;
                Enemy.transform.rotation = transform.rotation;
                Enemy.AddComponent<NavMeshAgent>();
                NavMeshAgent agent = Enemy.GetComponent<NavMeshAgent>();
                agent.SetDestination(Target.transform.position);
                int walkable = 1 << 0;
                int canwalk = 1 << i;
                agent.areaMask = walkable | canwalk;
                EnemyAgent_HP enemy=Enemy.GetComponent<EnemyAgent_HP> ();
                enemy.Enemy_Healthy += UpTime;
                enemy.Enemy_Maxhealthy += UpTime;
                if (UpTime%3==0)
                {
                    m = Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();  // 得到子物体的拥有材质球的那个组件，然后进行颜色随机赋予
                    upchangecolor = Random.ColorHSV();
                    m.material.color = upchangecolor;
                    enemy.Speed++;
                    enemy.Enemy_deth_money += 3;
                }
            }
            yield return  waite;
        }
    
    }
}
