using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeanCloud.Core;
using LeanCloud.Storage;
using LeanCloud.Utilities;
using Unity.Tasks;
using LeanCloud.Realtime;
using LeanCloud;
using System.Threading.Tasks;

public class TurnControl : MonoBehaviour
{

    public static TurnControl instance;

    //控制玩家操作及操作窗口是否出现  
    public bool isWaitForPlayer = true;
    //控制怪物操作  
    public bool isEnemyAction = false;

    public bool isHeroAction = true;

    public int _index = 0;
    //private CloudManager cloud;
    //获取玩家及敌人脚本的引用   
    //private PlayerControl PlayerControl.instance;
    //private EnemyControl EnemyControl.instance;
    //private HeroStatus hero;
    //private PlayerSkill playerSkill;
    //private TurnControl turnScript;
    //private EnemyStatus enemy;


    //定义游戏状态枚举    
    public enum GameState
    {
        Menu,//游戏开始菜单    
        Game,//游戏中   
        Over//游戏结束  
    }
    //游戏初始状态  
    public GameState currentState = GameState.Menu;

    //private void Awake()
    //{
    //    hero = GameObject.Find("hero").GetComponent<HeroStatus>();
    //    enemy = GameObject.Find("enemy").GetComponent<EnemyStatus>();

    //}
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        //AVObject football = new AVObject("Sport");
        //football["totalTime"] = 90;
        //football["name"] = "Football";
        //Task saveTask = football.SaveAsync();
        //await saveTask;

        //获取玩家及敌人脚本引用  
        //hero = GameObject.Find("hero").GetComponent<HeroStatus>();
        //enemy = GameObject.Find("enemy(Clone)").GetComponent<EnemyStatus>();
        //PlayerControl.instance = GameObject.FindGameObjectWithTag("HeroUnit").GetComponent<PlayerControl>();
        //EnemyControl.instance = GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<EnemyControl>();
        currentState = GameState.Game;
        //StartCoroutine(ShowReborn());    
    }



    //static async void MyMethod()
    //{
    //    AVObject football = new AVObject("Sport");
    //    football["totalTime"] = 90;
    //    football["name"] = "Football";
    //    Task saveTask = football.SaveAsync();
    //    //await saveTask;
    //}







    //void OnGUI()
    //{
    //    if (currentState == GameState.Menu)
    //    {
    //        GUI.Window(0, new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 60), GameStartConfirm, "战斗开始确认");
    //    }
    //    else if (currentState == GameState.Over)
    //    {
    //        GUI.Window(2, new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 60), GameRestartConfirm, "战斗结束");
    //    }

    //}



    //void GameStartConfirm(int ID)
    //{
    //    if (GUI.Button(new Rect(50, 30, 100, 20), "开始战斗"))
    //    {
    //        currentState = GameState.Game;
    //        isHeroAction = true;
    //    }
    //}

    //void GameRestartConfirm(int ID)
    //{
    //    if (GUI.Button(new Rect(50, 30, 100, 20), "重新开始"))
    //    {
    //        hero.CurStatus.CurHP = hero.SumStatus.HP;
    //        enemy.CurStatus.CurHP = enemy.SumStatus.HP;
    //        isWaitForPlayer = true;
    //        isEnemyAction = false;
    //        isHeroAction = true;
    //        currentState = GameState.Game;
    //    }
    //}

    float m_timer = 2;

    void Update()
    {
        if (currentState == GameState.Game)
        {
            //如果任意一方生命值为0，则游戏结束    
            if (HeroStatus.instance.CurStatus.CurHP <= 0)
            {
                //Debug.Log("战斗失败1111");
                PlayerControl.instance.ShowText(-3, "", "");
                currentState = GameState.Over;

            }
            if (EnemyStatus.instance.CurStatus.CurHP <= 0)
            {
                //Debug.Log("战斗胜利1111");
                PlayerControl.instance.ShowText(-3, "", "");
                currentState = GameState.Over;

            }


        }
        else{
            m_timer -= Time.deltaTime;
            //Debug.Log(m_timer);
            if (m_timer <= 0)
            {
                ShowB();
                m_timer = 2;
            }
        }

    }

    public int randomEnemy()
    {
        int x = Random.Range(1, 7);
        return x;
    }
    private void ShowB()
    {
        
        PlayerControl.instance.ShowText(-4, "", "");

            PlayerControl.instance.Reborn();
            //EnemyControl.instance.Reborn();
        //int a = randomEnemy();
        //cloud.getEnemyStatus(a);
        EnemyStatus.instance.UpdateAttribute();
        EnemyStatus.instance.CurStatus.CurHP = EnemyStatus.instance.SumStatus.HP;
        EnemyStatus.instance.CurStatus.CurMP = EnemyStatus.instance.SumStatus.MP;

            currentState = GameState.Game;
        //Debug.Log(_index);



    }

}