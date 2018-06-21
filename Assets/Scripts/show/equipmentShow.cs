using UnityEngine;
using FairyGUI;

public class equipmentShow : MonoBehaviour
{
    GComponent panel1;
    //private PlayerControl PlayerControl.instance;
    //private EnemyControl EnemyControl.instance;
    //private HeroStatus hero;
    //private TurnControl TurnControl.instance;
    //private EnemyStatus enemy;

    //private void Awake()
    //{
    //    hero = GameObject.Find("hero").GetComponent<HeroStatus>();
    //    enemy = GameObject.Find("enemy").GetComponent<EnemyStatus>();

	//} 
	public Sprite a = new Sprite();
   
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
        
        
		GButton head = panel1.GetChild("headShow").asButton;
		GButton chest = panel1.GetChild("chest").asButton;
		GButton leg = panel1.GetChild("leg").asButton;
		GButton weapon = panel1.GetChild("weapon").asButton;
		GButton ring1 = panel1.GetChild("ring1").asButton;
		GButton ring2 = panel1.GetChild("ring2").asButton;

        
		head.icon = "head";
		chest.icon = "chest";
		leg.icon = "leg";
		weapon.icon = "weapon";
		ring1.icon = "ring";
		ring2.icon = "ring";

		//head.icon = "w" + "1";//n11   物品图标
		//head.icon = "31001" ;
        //GProgressBar pb2 = panel1.GetChild("enemy_headbar").asProgress;
   
        //pb2.max = EnemyStatus.instance.SumStatus.HP;
        //pb2.value = EnemyStatus.instance.CurStatus.CurHP;



	}


    void Update(){



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