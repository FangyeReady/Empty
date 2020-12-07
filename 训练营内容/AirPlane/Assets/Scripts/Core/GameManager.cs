using System.Collections.Generic;
using UnityEngine;
/*九城教育*/
public class GameManager : MonoBehaviour
{
    //声明了一个GameManager静态变量
    public static GameManager Instance;

    [SerializeField] Transform SpwanerContainer;

    GameObject playerPrefab;

    //用于控制游戏开始或结束
    private bool startGame = false;

    //撞击的固定伤害
    [SerializeField] int HitDamage = 1;

    //炸弹的上限
    [SerializeField] int maxBoom = 3;
    public int MaxBoom
    {
        set {
            maxBoom = value;
        }

        get {
            return maxBoom;
        }
    }

    //当前炸弹数量
    [SerializeField] int boomCount = 3;
    //炸弹数量的属性
    public int BoomCount
    {
        //设置值的时候调用
        set {
            boomCount = value;

            UIManager.Instance.UpdateBoomNum(boomCount);
        }

        //获得值的时候调用
        get { 
            return boomCount;
        }
    }


    //血量上限
    [SerializeField] int maxHealth = 10;


    private void Awake()
    {
        //让这个静态变量赋值为自己
        Instance = this;
    }

    private void Start()
    {
        playerPrefab = Resources.Load<GameObject>("Player");
    }

    //得到撞击的固定伤害
    public int GetHitDamage()
    {
        return HitDamage;
    }
    //得到炸弹数量
    public int GetBoomCount()
    {
        return boomCount;
    }

    //得到炸弹上线
    public int GetMaxBoomCount()
    {
        return maxBoom;
    }

    //得到血量上限
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    //开始游戏
    public void StartGame()
    {
        startGame = true;
        UIManager.Instance.GameStartEvent();
    }

    //判断是否开始游戏
    public bool IsStartGame()
    {
        return startGame;
    }

    public void SetGameEnd()
    {

        startGame = false;
        GameObject player = Instantiate(playerPrefab, new Vector3(0, 0, -30), Quaternion.identity);
        player.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        int childCount = SpwanerContainer.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(SpwanerContainer.GetChild(i).gameObject);
        }


        var foods = GameObject.FindObjectsOfType<Food>();
        for (int i = 0; i < foods.Length; i++)
        {
            Destroy(foods[i].gameObject);
        }

        UIManager.Instance.GameEndEvent();
    }
}
