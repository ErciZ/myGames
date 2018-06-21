using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using System.Threading;
using UnityEngine.UI;
using FairyGUI;
  



public enum ClassType{None,Swordman,Archer,Mage}//职业


[RequireComponent (typeof (HeroStatus))]
[RequireComponent (typeof (PlayerSkill))]
public class PlayerControl : MonoBehaviour
{


    public static PlayerControl instance;

    public Texture2D heroImage;
    public enum DamageType { Normal, Magic, True };//伤害类型
    public ClassType classType; //Class hero
    public GameObject target;     //Target enemy
    //public GameObject targetMoveTo; //Target move to (ex. npc , item)


    public bool autoAttack; 

    //Get component other script
    //private HeroStatus hero;  
    private PlayerSkill playerSkill;
    //private TurnControl turnScript; 
    //private EnemyControl enemyScript;
    //private EnemyStatus enemy;

    private GComponent _mainView;
    private GList _list;



    private float delayAttack = 100;  //Delay Attack speed
    private float delayTimeTag;

    private bool checkCritical; //检查是否暴击


    private bool onceAttack;    //Check Attack if disable AutoAttack
   
    private bool getSkillTarget;  //Check Get Skill Target
    private bool alreadyLockSkill;  //Check lock freeskill

    //public bool useSkill;                    //Check use skill
    private int turnNumber;
    public bool useFreeSkill;                    //Check use Free Target skill


	public activeskill normalAtk = new activeskill();
   


    [HideInInspector]
    public int castid;      //Cast skill id
    [HideInInspector]
    public int typeAttack;                      //Type Attack
    [HideInInspector]
    public int typeTakeAttack;          //Type TakeAttack

	//private bool oneShotOpenDeadWindow;
	//public List<CountDownTimer> cdTimers = new List<CountDownTimer>();
	public Dictionary<int, CountDownTimer> cdTimers = new Dictionary<int, CountDownTimer>();
    //public int layerActiveGround = 11;
    //public int layerActiveItem = 10;
    //public int layerActiveEnemy = 9;
    //public int layerActiveNpc = 13;

    //Editor Variable
    [HideInInspector]
    public int sizeMesh;


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
		//layerActiveGround = 11;
		//layerActiveItem = 10;
		//layerActiveEnemy = 9;

		//hero = GameObject.Find("hero").GetComponent<HeroStatus>();
		//enemy = GameObject.Find("enemy(Clone)").GetComponent<EnemyStatus>();


		playerSkill = this.GetComponent<PlayerSkill>();
		//turnScript = GameObject.Find("TurnSystem").GetComponent<TurnControl>();
		//enemyScript = GameObject.Find("TurnSystem").GetComponent<EnemyControl>();

		Application.targetFrameRate = 60;
		_mainView = GameObject.Find("UIPanel").GetComponent<UIPanel>().ui;

		_list = _mainView.GetChild("mailList").asList;

		delayAttack = 100; //Declare delay 100 sec
		calAttackSpeed();
		for (int i = 0; i < 7; i++){
			
			CountDownTimer cdTimer = new CountDownTimer(HeroStatus.instance.used_activeskill[i].cd);

			if(cdTimers.ContainsKey(HeroStatus.instance.used_activeskill[i].skillID))  {  }  
			else{
				cdTimers.Add(key: HeroStatus.instance.used_activeskill[i].skillID, value: cdTimer);
                HeroStatus.instance.used_activeskill[i].cdCount = cdTimer;
			}


		}

      
    }



    void Update()
    {
        if (TurnControl.instance.currentState == TurnControl.GameState.Game)
        {
            
                TargetLock();

                WaitAttack();
          
        }
		//Debug.Log("0---"+cdTimers[HeroStatus.instance.used_activeskill[0].skillID]);
		//Debug.Log("1---" + cdTimers[1].CurrentTime);
		//Debug.Log("2---" + cdTimers[2].CurrentTime);
		//Debug.Log("3---" + cdTimers[3].CurrentTime);
		//Debug.Log("4---" + cdTimers[4].CurrentTime);
		//Debug.Log("5---" + cdTimers[5].CurrentTime);
		//Debug.Log("6---" + cdTimers[6].CurrentTime);
		//Debug.Log(cdTimers[0].IsTimeUp);
      
           

                ////Debug.Log("主角使用了普通攻击");
                ////播放攻击动画  
                ////enemyAnimator.SetTrigger("attack");
                //int damage = Damage();
                ////text.text = text.text + "你使用了普通攻击，对怪物造成了" + damage + "点伤害\n";
                ////延迟1s出现玩家操作UI  
                //enemyScript.ReceiveDamage(damage, "Normal", "普通攻击");
                ////延迟1s出现玩家操作UI  
                //StartCoroutine("EnemyWait");
                //turnScript.isHeroAction = false;
                //turnScript.isEnemyAction = true;


      



        ////游戏状态是Game才会进行  
        //if (turnScript.currentState == TurnControl.GameState.Game)
        //{
        //    if (turnScript.isHeroAction)
        //    {
        //        //Debug.Log("主角使用了普通攻击");
        //        //播放攻击动画  
        //        //enemyAnimator.SetTrigger("attack");
        //        int damage = Damage();
        //        //text.text = text.text + "你使用了普通攻击，对怪物造成了" + damage + "点伤害\n";
        //        //延迟1s出现玩家操作UI  
        //        enemyScript.ReceiveDamage(damage, "Normal", "普通攻击");
        //        //延迟1s出现玩家操作UI  
        //        StartCoroutine("EnemyWait");
        //        turnScript.isHeroAction = false;
        //        turnScript.isEnemyAction = true;


        //    }
        //}
    }


    public int Damage(){


        //伤害 =[（攻击方等级 × 2 ÷ 5 + 2） × 技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 + 2]×各类修正
        int damage=0;
        damage = (int)(( 1f * HeroStatus.instance.CurStatus.CurAtkValue) * (10f)*(1f) * Random.Range(85, 101f) / 100f);
        //int damage = Mathf.Max(0, attack - enemyScript.(int)hero.CurStatus.CurDefValue);
        //Debug.Log(damage);
        //判断命中
        if (IsHit(HeroStatus.instance.CurStatus.CurHit,EnemyStatus.instance.CurStatus.CurAgl)){
            //判断暴击
            if (CriticalCal(HeroStatus.instance.CurStatus.CurCrit))
            {
                damage = ((int)(damage * (1f + HeroStatus.instance.CurStatus.CurCritDamage)));
                return damage;
            }
            else
            {
                
                return damage;
            }
        }
        else{
            return -1;
        }


    }

    public int SkillDamage(float addDam,float baseDam,float skillPower,string damageType)
    {


		//伤害 =（附加属性X附加比例+基本伤害+ 技能威力 * 人物攻击力/100）X(85--100伤害浮动)
        int damage = 0;
        if (damageType=="Normal"){
			damage = (int)(((addDam+baseDam+ skillPower * HeroStatus.instance.CurStatus.CurAtkValue/100f)* (10f)* (1f) * Random.Range(85, 101f) / 100f));
            //int damage = Mathf.Max(0, attack - enemyScript.(int)hero.CurStatus.CurDefValue);
        }
        else if (damageType == "Magic"){
			damage = (int)(((addDam +baseDam+ skillPower * HeroStatus.instance.CurStatus.CurMagicAtk/100f)* (10f) * (1f) * Random.Range(85, 101f) / 100f));

        }
        else if (damageType == "True"){
            damage = (int)(addDam +baseDam+skillPower);

        }

		return damage;

        ////判断命中
        //if (IsHit(HeroStatus.instance.CurStatus.CurHit, EnemyStatus.instance.CurStatus.CurAgl))
        //{
        //    //判断暴击
        //    if (CriticalCal(HeroStatus.instance.CurStatus.CurCrit))
        //    {
        //        damage = ((int)(damage * (1f + HeroStatus.instance.CurStatus.CurCritDamage)));
        //        return damage;
        //    }
        //    else
        //    {
        //        return damage;
        //    }
        //}
        //else
        //{
        //    return -1;
        //}


    }


    //判断命中
    bool IsHit(float hit,float agl){
        //        命中结果 =（命中能力 + a）/（闪避能力 + a）*基本命中率
        //a：一般为100，避免0除，以及避免数值过小差异结果过大。
        //基本命中率：0.7左右。
        //命中下限：0.2 - 0.3
        float baseRate = 0.7f;
        float result = (hit + 100f) / (agl + 100f) * baseRate*100f-Random.Range(0, 101f);
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


    //承受伤害    
	public void ReceiveDamage(int damage, activeskill skill)
    {
        //伤害 =[（攻击方等级 × 2 ÷ 5 + 2） × 技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 ]×各类修正
        float trueDamage;
        if (damage == -1)
        {
			ShowText(damage, skill.damageType, skill.skillName);
            //Debug.Log("MISS!");
        }
        else
        {
			if (skill.damageType == "Normal")
            {


                trueDamage = damage / (HeroStatus.instance.CurStatus.CurDefValue) / 1f;
                HeroStatus.instance.CurStatus.CurHP = HeroStatus.instance.CurStatus.CurHP - trueDamage;
				ShowText((int)trueDamage, "物理伤害", skill.skillName);
				//Debug.Log("敌人使用"+skill.skillName +",对你造成了" + trueDamage + "点物理伤害");
               

            }
			else if (skill.damageType == "Magic")
            {
                trueDamage = damage / (HeroStatus.instance.CurStatus.CurMagicDef) / 1f;
                HeroStatus.instance.CurStatus.CurHP = HeroStatus.instance.CurStatus.CurHP - trueDamage;
				ShowText((int)trueDamage, "魔法伤害", skill.skillName);
                //Debug.Log("敌人使用"+skillName +",对你造成了" + trueDamage + "点魔法伤害");
               

            }
			else if (skill.damageType == "True")
            {
                trueDamage = damage;
                HeroStatus.instance.CurStatus.CurHP = HeroStatus.instance.CurStatus.CurHP - trueDamage;
				ShowText((int)trueDamage, "真实伤害", skill.skillName);
                //Debug.Log("敌人使用"+skillName +",对你造成了" + trueDamage + "点真实伤害");
               
            }

        }
        if (HeroStatus.instance.CurStatus.CurHP  <= 0)
        {
            //Debug.Log("战斗失败");
			ShowText(-2, skill.damageType, skill.skillName);
            HeroStatus.instance.CurStatus.CurHP = 0;
           
           
            //Reborn();
        }

    }

    public void ShowText(int damage, string damageType, string skillName)
    {

        int index = _list.ItemIndexToChildIndex(TurnControl.instance._index);
		GObject obj = _list.GetChildAt((index + 11)%50);
        if (damageType != "True1")
        {
            
            if (damage == -1)
            {
                string str = EnemyStatus.instance.BaseStatus.EnemyName + "使用了" + skillName + ",但是被你闪避了！";
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
            else if (damage == -2)
            {
                string str = EnemyStatus.instance.BaseStatus.EnemyName + "把你打败了";
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
            else if (damage == -3)
            {
                string str = "休息并寻找下一个敌人中。。。";
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
            else if (damage == -4)
            {
                string str = "发现" + EnemyStatus.instance.BaseStatus.EnemyName;
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
            else
            {
                string str = EnemyStatus.instance.BaseStatus.EnemyName + "使用了" + skillName + ",对你造成了" + damage + "点" + damageType + "伤害";
                _list.AddSelection(TurnControl.instance._index, true);
                MailItem item = (MailItem)obj;
                item.setText(str);
            }
        }
                    else{
                        string str = HeroStatus.instance.BaseStatus.HeroName + "使用了" + skillName + ",回复了" + damage + "点生命";
            _list.AddSelection(TurnControl.instance._index, true);
            MailItem item = (MailItem)obj;
            item.setText(str);
                    }
		TurnControl.instance._index =(TurnControl.instance._index + 1)%50;




    }

    void doTrun(int a)
    {
        int x = a % 7;


        // //开始计时  
        //timer.startTiming (1, OnComplete, OnProcess);  
                    
		if (HeroStatus.instance.used_activeskill[x].skillID == 20000)
        {
            int thisDamage = Damage();
			EnemyControl.instance.ReceiveDamage(thisDamage, normalAtk);
        }
        else
        {
			//Debug.Log(x + "检查技能cd" + cdTimers[HeroStatus.instance.used_activeskill[x].skillID].CurrentTime);
			playerSkill.CastActiveSkill(HeroStatus.instance.used_activeskill[x],x);
			//Debug.Log("aaaaaaaaa"+playerSkill.canCast);
            if (playerSkill.canCast)
            {
				//HeroStatus.instance.used_activeskill[x].cdCount.Start();
				//Debug.Log("开始放技能" + HeroStatus.instance.used_activeskill[x].cdCount.IsTimeUp);
				//Debug.Log("释放技能：" + HeroStatus.instance.used_activeskill[x].skillName);
				playerSkill.playActiveSkill(HeroStatus.instance.used_activeskill[x]);
				//Debug.Log(x+"释放技能是的cd时间"+cdTimers[HeroStatus.instance.used_activeskill[x].skillID].CurrentTime);
				cdTimers[HeroStatus.instance.used_activeskill[x].skillID].Start();
				//cdTimers[x].Start();
				//Debug.Log(x);
				//Debug.Log(x+"开始转cd"+"-----"+HeroStatus.instance.used_activeskill[x].skillName);
				//HeroStatus.instance.used_activeskill[x].cdCount=cdCount;            
				//HeroStatus.instance.used_activeskill[x].cdCount.Start();
				//Debug.Log("刚放完技能"+HeroStatus.instance.used_activeskill[x].cdCount.IsTimeUp);
				//CountDownTimer cdTimer = new CountDownTimer(HeroStatus.instance.used_activeskill[x].cd);
            }
            else
            {
                int thisDamage = Damage();
				EnemyControl.instance.ReceiveDamage(thisDamage, normalAtk);
            }
        }


        turnNumber = turnNumber + 1;

    }

    void calAttackSpeed()
    {
        float speedAttack = 1f - HeroStatus.instance.CurStatus.CurAttackSpeed;
        delayAttack = 1f + 1f * speedAttack;
        delayTimeTag=1f + 1f * speedAttack;
        //Debug.Log(delayTimeTag);
    }

    void WaitAttack()
    {

        if (EnemyStatus.instance.CurStatus.CurHP <= 0)
        {
            ResetState();
           
        }


        if (delayAttack > 0)
        {

            delayAttack -= Time.deltaTime;
        }
        else if (delayAttack <= 0)
        {
            doTrun(turnNumber);
            delayAttack = delayTimeTag;

        }
    }



    //在切换到敌人操作前添加延迟  
    IEnumerator EnemyWait()
    {
        yield return new WaitForSeconds(1);
        TurnControl.instance.isEnemyAction = true;
    }





    void TargetLock()
    {


        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("EnemyUnit");

        }
        //Disable Auto Attack Command


    }
    public void ResetAttack()
    {
        target = null;
    }

    public void ResetState()
    {
       
        target = null;
        //ctrlAnimState = ControlAnimationState.Idle;
        alreadyLockSkill = false;

    }
    public void ResetBeforeCast()
    {
        
        target = null;
        alreadyLockSkill = false;
    }
    public void ResetOldCast()
    {
        //useSkill = false;
        useFreeSkill = false;
        //GameSetting.Instance.SetMouseCursor(0);
    }









    public void GetCastID(int caseID)
    {
            castid = caseID;

    }

    public void Reborn()
    {
        
        HeroStatus.instance.CurStatus.CurHP = HeroStatus.instance.SumStatus.HP;
        HeroStatus.instance.CurStatus.CurMP = HeroStatus.instance.SumStatus.MP ;

        HeroStatus.instance.CurStatus.CurExp -= (HeroStatus.instance.CurStatus.CurExp / 10f);//死亡惩罚
        if (HeroStatus.instance.CurStatus.CurExp < 0)
        {
            HeroStatus.instance.CurStatus.CurExp = 0;
        }

        HeroStatus.instance.StartRegen();

        target = null;
        alreadyLockSkill = false;
     
    

    }
}  

