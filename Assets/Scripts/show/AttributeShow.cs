using UnityEngine;
using FairyGUI;

public class AttributeShow : MonoBehaviour
{
    GComponent panel1;
    //private PlayerControl PlayerControl.instance;
    //private EnemyControl EnemyControl.instance;
    //private HeroStatus hero;
    //private TurnControl TurnControl.instance;
    //private EnemyStatus enemy;
	public GTextField attributeShow1;
	public GTextField attributeShow2;
	public GTextField heroname;
	public GTextField money;
    public GTextField diamond;


   
    void Start()
	{
        //hero = GameObject.Find("hero").GetComponent<HeroStatus>();
        //enemy = GameObject.Find("enemy(Clone)").GetComponent<EnemyStatus>();
        //PlayerControl.instance = GameObject.FindGameObjectWithTag("HeroUnit").GetComponent<PlayerControl>();
        //EnemyControl.instance = GameObject.FindGameObjectWithTag("EnemyUnit").GetComponent<EnemyControl>();
		Application.targetFrameRate = 60;

       
        GRoot.inst.SetContentScaleFactor(720, 1280);

        panel1 = this.GetComponent<UIPanel>().ui;
        
		attributeShow1 = panel1.GetChild("attributeShow1").asTextField;
		attributeShow2 = panel1.GetChild("attributeShow2").asTextField;
		heroname = panel1.GetChild("heroname").asTextField;
		money = panel1.GetChild("gold_text").asTextField;
		diamond = panel1.GetChild("diamond_text").asTextField;


	}


    void Update(){

		attributeShow1.text = string.Format("英雄ID：{0}\n力量：{1}\n体质：{2}\n耐力：{3}\n敏捷：{4}\n智力：{5}\n" +
                                            "物理攻击：{6}\n物理防御：{7}\n法术攻击：{8}\n法术防御：{9}\n",
                                           HeroStatus.instance.BaseStatus.HeroID,
                                           HeroStatus.instance.SumStatus.S,
                                           HeroStatus.instance.SumStatus.P,
                                           HeroStatus.instance.SumStatus.D,
                                           HeroStatus.instance.SumStatus.A,
                                           HeroStatus.instance.SumStatus.I,
                                           HeroStatus.instance.SumStatus.AtkValue,
                                           HeroStatus.instance.SumStatus.DefValue,
                                           HeroStatus.instance.SumStatus.MagicAtk,
                                           HeroStatus.instance.SumStatus.MagicDef   
                                          );      
        attributeShow2.text = string.Format("速度值：{0}\n灵性：{1}\n运气：{2}\n攻速：{3}\n暴击率：{4}\n" +
                                            "暴击伤害：{5}\n命中率：{6}\n闪避率：{7}\n血量回复：{8}\n魔力回复：{9}\n",
       
                                            HeroStatus.instance.SumStatus.AValue,
                                            HeroStatus.instance.BaseStatus.Comprehension,
                                            HeroStatus.instance.BaseStatus.luck,
                                           HeroStatus.instance.SumStatus.AttackSpeed,
                                           HeroStatus.instance.SumStatus.Crit,
                                           HeroStatus.instance.SumStatus.CritDamage,
                                           HeroStatus.instance.SumStatus.Hit,
                                           HeroStatus.instance.SumStatus.Agl,
                                           HeroStatus.instance.SumStatus.HPRecoverPerSecond,
                                           HeroStatus.instance.SumStatus.MPRecoverPerSecond
                                          );
		heroname.text = HeroStatus.instance.BaseStatus.HeroName;
		money.text = "0";
		diamond.text = "0";

    }



	//void OnKeyDown(EventContext context)
	//{
	//	if (context.inputEvent.keyCode == KeyCode.Escape)
	//	{
	//		Application.Quit();
	//	}
	//}
}