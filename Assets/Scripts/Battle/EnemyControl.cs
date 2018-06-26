using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using FairyGUI;


//[RequireComponent(typeof(EnemyStatus))]
//[RequireComponent(typeof(DropItem))]
public class EnemyControl : MonoBehaviour
{

    public static EnemyControl instance;

    public enum EnemyNature { Natural, Wild } //enemy nature
    public enum DamageType { Normal, Magic, True };//伤害类型

    public EnemyNature nature;   //enemy nature

    public GameObject target;     //Target enemy
    public float deadTimer; //destroy timer when enemy dead
    GameObject Enemy;

	public activeskill normalAtk = new activeskill();

	private EnemySkill playerSkill;

    private GComponent _mainView;
    private GList _list;
    //回合控制脚本  
    //private TurnControl TurnControl.instance;
    //获取玩家脚本的引用   
    //private PlayerControl PlayerControl.instance;
	public Dictionary<int, CountDownTimer> cdTimers_enemy = new Dictionary<int, CountDownTimer>();

    private CloudManager cloud;
    private int turnNumber;
    private float delayAttack = 100;        //Delay Attack speed
    private bool checkCritical;                 //Check Critical
    private float delayTimeTag;
   
    public bool useSkill;      


    [HideInInspector]
    public int typeAttack;                      //Type Attack
    [HideInInspector]
    public int typeTakeAttack;                  //Type TakeAttack

    [HideInInspector]
    public int castid;      //Cast skill id
    //Editor Variable
    [HideInInspector]
    public int sizeMesh;

    



    private void Awake()
    {
        GameObject Enemy = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));  
        instance = this;

    }

    void Start()
    {

  
        _mainView = GameObject.Find("UIPanel").GetComponent<UIPanel>().ui;

        _list = _mainView.GetChild("mailList").asList;

		playerSkill = GameObject.Find("enemy(Clone)").GetComponent<EnemySkill>();
        //questData = GameObject.Find("QuestData").GetComponent<Quest_Data>();

        //攻击间隔 = 基础攻击间隔 + 最大攻击间隔 * （1 - (敏捷)/(敏捷+加成系数)）
        calAttackSpeed();//Declare delay 100 sec
		for (int i = 0; i < 7; i++)
        {

			CountDownTimer cdTimer_enemy = new CountDownTimer(EnemyStatus.instance.used_activeskill[i].cd);

			if (cdTimers_enemy.ContainsKey(EnemyStatus.instance.used_activeskill[i].skillID)) { }
            else
            {
				cdTimers_enemy.Add(key: EnemyStatus.instance.used_activeskill[i].skillID, value: cdTimer_enemy);
				EnemyStatus.instance.used_activeskill[i].cdCount = cdTimer_enemy;
            }


        }



    }

    void Update()
    {
        if (TurnControl.instance.currentState == TurnControl.GameState.Game){
           
           
                WaitAttack();

        }
    }



    void calAttackSpeed(){
        float speedAttack = 1f - EnemyStatus.instance.CurStatus.CurAttackSpeed;
        //float speedAttack = 1f - enemy.CurStatus.CurAttackSpeed;
        delayAttack = 1f + 1f * speedAttack;
        delayTimeTag = 1f + 1f * speedAttack;
        //Debug.Log(delayTimeTag);
    }

    //判断命中
    bool IsHit(float hit, float agl)
    {
        //命中结果 =（命中能力 + a）/（闪避能力 + a）*基本命中率
        //a：一般为100，避免0除，以及避免数值过小差异结果过大。
        //基本命中率：0.7左右。
        //命中下限：0.2 - 0.3
        float baseRate = 0.7f;
        float result = (hit + 100f) / (agl + 100f) * baseRate * 100f - Random.Range(0, 101f);
        if (result > 0)
        {
            return true; //Critical
        }
        else
        {
            return false; //Not Critical
        }
    }

    //Critical Calculate
    bool CriticalCal(float criticalStat)
    {
        float calCritical = criticalStat - Random.Range(0, 101f);


        if (calCritical > 0)
        {
            return true; //Critical
        }
        else
        {
            return false; //Not Critical
        }
    }

	void doTrun(int a)
	{
		int x = a % 7;

		if (EnemyStatus.instance.used_activeskill[x].skillID == 20000)
		{
			//if (enemy.use_activeSkillAttack[x] ==0){
			int thisDamage = Damage();
			PlayerControl.instance.ReceiveDamage(thisDamage, normalAtk);
		}
            
        else{
				playerSkill.CastActiveSkill(EnemyStatus.instance.used_activeskill[x]);
				if (playerSkill.canCast)
				{
				playerSkill.playActiveSkill(EnemyStatus.instance.used_activeskill[x]);
					//Debug.Log(x+"释放技能是的cd时间"+cdTimers[HeroStatus.instance.used_activeskill[x].skillID].CurrentTime);
					cdTimers_enemy[EnemyStatus.instance.used_activeskill[x].skillID].Start();
				}
				else
				{
					int thisDamage = Damage();
					PlayerControl.instance.ReceiveDamage(thisDamage, normalAtk);
				}
			}


			turnNumber = turnNumber + 1;

		}


    public int Damage()
    {


        //伤害 =[（攻击方等级 × 2 ÷ 5 + 2） × 技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 + 2]×各类修正
        int damage = 0;
        damage = (int)(( 1f * EnemyStatus.instance.CurStatus.CurAtkValue) *(10f)* (1f) * Random.Range(85, 101f) / 100f);

        if (IsHit(EnemyStatus.instance.CurStatus.CurHit, HeroStatus.instance.CurStatus.CurAgl))
        {
            //判断暴击
            if (CriticalCal(EnemyStatus.instance.CurStatus.CurCrit))
            {
                damage = ((int)(damage * (1f + EnemyStatus.instance.CurStatus.CurCritDamage)));
                return damage;
            }
            else
            {

                return damage;
            }
        }
        else
        {
            return -1;
        }


    }
    
    //承受伤害    
	public void ReceiveDamage(int damage,activeskill skill)
    {
		//Debug.Log("111+"+damage);
        //伤害 =[（攻击方等级 × 2 ÷ 5 + 2） × 技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 ]×各类修正
        float trueDamage ;
        if (damage == -1){
			ShowText(damage, skill.damageType, skill.skillName);
            //Debug.Log("MISS!");
        }
        else{
			if (skill.damageType == "Normal"){

                trueDamage = damage / (EnemyStatus.instance.CurStatus.CurDefValue) / 1f;
                EnemyStatus.instance.CurStatus.CurHP = EnemyStatus.instance.CurStatus.CurHP - trueDamage;
				//Debug.Log("释放了技能" + skill.skillName + "造成了伤害：结算后" + trueDamage);
				ShowText((int)trueDamage, "物理伤害", skill.skillName);
                //Debug.Log("你使用"+skillName +",对敌人造成了" + trueDamage + "点物理伤害");
               
            }
			else if (skill.damageType == "Magic"){
                trueDamage = damage / (EnemyStatus.instance.CurStatus.CurMagicDef) / 1f;
                EnemyStatus.instance.CurStatus.CurHP = EnemyStatus.instance.CurStatus.CurHP - trueDamage;
				ShowText((int)trueDamage, "魔法伤害", skill.skillName);
                //Debug.Log("你使用" + skillName + ",对敌人造成了" + trueDamage + "点魔法伤害");
            }
			else if (skill.damageType == "True"){
                trueDamage = damage  ;
                EnemyStatus.instance.CurStatus.CurHP = EnemyStatus.instance.CurStatus.CurHP - trueDamage;
				ShowText((int)trueDamage, "真实伤害", skill.skillName);
                //Debug.Log("你使用" + skillName + ",对敌人造成了" + trueDamage + "点真实伤害");
            }

        }

        if (EnemyStatus.instance.CurStatus.CurHP <= 0)
            {
            EnemyStatus.instance.CurStatus.CurHP = 0;
			ShowText(-2, skill.damageType, skill.skillName);


            }
          
    }

    public void Reborn()
    {
        EnemyStatus.instance.CurStatus.CurHP = EnemyStatus.instance.SumStatus.HP;
        EnemyStatus.instance.CurStatus.CurMP = EnemyStatus.instance.SumStatus.MP;

        target = null;



    }

    public int randomEnemy()
    {
        int x = Random.Range(1, 7);
        return x;
    }

       
    public void ShowText(int  damage, string damageType, string skillName)
    {

        int index = _list.ItemIndexToChildIndex(TurnControl.instance._index);
		GObject obj = _list.GetChildAt((index + 11)%50);
        //Debug.Log(index);
        if (damageType != "True1")
        {
            
            if (damage == -1)
            {
                string str = "你使用了" + skillName + ",但是被" + EnemyStatus.instance.BaseStatus.EnemyName + "闪避了！";
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
            else if (damage == -2)
            {
                string str = "你打败了" + EnemyStatus.instance.BaseStatus.EnemyName;
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
            else
            {
                string str = "你使用了" + skillName + ",对" + EnemyStatus.instance.BaseStatus.EnemyName + "造成了" + damage + "点" + damageType + "伤害";
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
        }
            else{
            string str = EnemyStatus.instance.BaseStatus.EnemyName + "使用了" + skillName + ",回复了" + damage + "点生命";
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
		TurnControl.instance._index = (TurnControl.instance._index + 1)%50;


    } 

    //reset all state of enemy
    public void ResetState()
    {
        target = null;

    }




    public void EnemyLockTarget(GameObject targetlock)
    {
        target = targetlock;
    }

    //Wait before attack
    void WaitAttack()
    {

        //if (hero.CurStatus.CurHP <= 0)
        if(HeroStatus.instance.CurStatus.CurHP<=0)
        {
            ResetState();
        }

        if (delayAttack > 0)
        {
            //Debug.Log(delayAttack);
            delayAttack -= Time.deltaTime ;
        }
        else if (delayAttack <= 0)
        {
            doTrun(turnNumber);
            delayAttack = delayTimeTag;
        }
    }


    public int SkillDamage(float addDam,float baseDam,float skillPower, string damageType)
    {


        //伤害 =[技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 + 2]×各类修正
        int damage = 0;
        if (damageType == "Normal")
        {
			damage = (int)(((addDam +baseDam + skillPower * EnemyStatus.instance.CurStatus.CurAtkValue/100f)* (10f)  * (1f) * Random.Range(85, 101f) / 100f));
            //int damage = Mathf.Max(0, attack - enemyScript.(int)hero.CurStatus.CurDefValue);
        }
        else if (damageType == "Magic")
        {
			damage = (int)(((addDam +baseDam+ skillPower * EnemyStatus.instance.CurStatus.CurMagicAtk/100f) * (10f)* (1f) * Random.Range(85, 101f) / 100f));

        }
                               else if (damageType == "True")
        {
            damage = (int)(addDam + baseDam + skillPower);
        }


        //判断命中
        if (IsHit(EnemyStatus.instance.CurStatus.CurHit, HeroStatus.instance.CurStatus.CurAgl))
        {
            //判断暴击
            if (CriticalCal(EnemyStatus.instance.CurStatus.CurCrit))
            {
                damage = ((int)(damage * (1f + EnemyStatus.instance.CurStatus.CurCritDamage)));
                return damage;
            }
            else
            {
                return damage;
            }
        }
        else
        {
            return -1;
        }


    }

    void TargetLock()
    {


        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("HeroUnit");

        }
        //Disable Auto Attack Command


    }


}
    

   



   
