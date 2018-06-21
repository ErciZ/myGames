using UnityEngine;
using FairyGUI;

public class HeadBarMain : MonoBehaviour
{
    GComponent panel1;
    //private PlayerControl PlayerControl.instance;
    //private EnemyControl EnemyControl.instance;
    //private HeroStatus hero;
    private PlayerSkill playerSkill;
    //private TurnControl TurnControl.instance;
    //private EnemyStatus enemy;

    //private void Awake()
    //{
    //    hero = GameObject.Find("hero").GetComponent<HeroStatus>();
    //    enemy = GameObject.Find("enemy").GetComponent<EnemyStatus>();

    //}

    void Start()
	{
        //hero = GameObject.Find("hero").GetComponent<HeroStatus>();
        //enemy = GameObject.Find("enemy(Clone)").GetComponent<EnemyStatus>();
        //PlayerControl.instance = GameObject.FindGameObjectWithTag("HeroUnit").GetComponent<PlayerControl>();
        //EnemyControl.instance = GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<EnemyControl>();
		Application.targetFrameRate = 60;

		//Stage.inst.onKeyDown.Add(OnKeyDown);
        //Transform npc1 = GameObject.Find("hero").transform;
        //Transform npc2 = GameObject.Find("enemy(Clone)").transform;



        panel1 = this.GetComponent<UIPanel>().ui;
        GProgressBar pb1 = panel1.GetChild("hero_headbar").asProgress;
        GProgressBar pb2 = panel1.GetChild("enemy_headbar").asProgress;
		//Debug.Log(pb1);
   
        pb1.max = HeroStatus.instance.SumStatus.HP;
        pb1.value = HeroStatus.instance.CurStatus.CurHP;
        pb2.max = EnemyStatus.instance.SumStatus.HP;
        pb2.value = EnemyStatus.instance.CurStatus.CurHP;



	}


    void Update(){
        GProgressBar pb1 = panel1.GetChild("hero_headbar").asProgress;
        GProgressBar pb2 = panel1.GetChild("enemy_headbar").asProgress;
        pb1.max = HeroStatus.instance.SumStatus.HP;
        pb1.value = HeroStatus.instance.CurStatus.CurHP;
        pb2.max = EnemyStatus.instance.SumStatus.HP;
        pb2.value = EnemyStatus.instance.CurStatus.CurHP;


        //panel1.GetChild("blood").asProgress.value = (float)PlayerControl.instance.hp/PlayerControl.instance.hp_Max*100 ;
        //panel1.ui.GetChild("value").text = PlayerControl.instance.hp + "/" + PlayerControl.instance.hp_Max;
        //panel2.ui.GetChild("blood").asProgress.value = (float)EnemyControl.instance.hp/EnemyControl.instance.hp_Max* 100 ; 
        //panel2.ui.GetChild("value").text = EnemyControl.instance.hp + "/" + EnemyControl.instance.hp_Max;
    }



	//void OnKeyDown(EventContext context)
	//{
	//	if (context.inputEvent.keyCode == KeyCode.Escape)
	//	{
	//		Application.Quit();
	//	}
	//}
}