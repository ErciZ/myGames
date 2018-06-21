/// <summary>
/// Player skill.
/// This script use for create a hero skill
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class PlayerSkill : MonoBehaviour
{
    //public static PlayerSkill instance;

    public enum AddAttribute { HP, MP, EP, S, P, D, A, I, AtkValue, DefValue, AValue, IValue, MagicAtk, MagicDef, Comprehension, luck,
        AttackSpeed, Exp, Crit, CritDamage, Hit, Agl, Counter, Double, HPRecoverPerSecond, MPRecoverPerSecond, }
    
    public enum SkillType { LockTarget, FreeTarget, Instance };

    public enum TargetSkill { SingleTarget, MultipleTarget };

    //public enum DamageType { Normal, Magic , True};//伤害类型


    // 定义一个类，包含Class1和Class2实例引用
     public int skillID { get; set; }
     public ActiveSkillAttack C1 { get; set; }
     public ActiveSkillBuff C2 { get; set; }    

    [System.Serializable]
    public class PassiveSkill
    {
        public string skillName = "Passive Skill";
        public int skillID { get; set; }
        public int skillLv;
        public float skillLvGrowth;
        //public int unlockLevel = 1;
        public string skillIcon;
        public string addAttribute;
        public float addValue;
        [Multiline]
        public string description = "This is passive skill.";
        public string typeSkill = "Passive";

        [HideInInspector]
        public bool isAdd;
    }

    [System.Serializable]
    public class ActiveSkillAttack
    {
        public int isRecover;
        public string skillName = "Skill Attack";
        public int skillID { get; set; }
        public int skillLv;
        public float skillLvGrowth;
        public int unlockLevel = 1;
        public string skillIcon;
        public int MPUse;
        public float baseDam;
        public string addAttribute;//附加属性
        public float addValue;//附加值
        //public TargetSkill targetSkill = PlayerSkill.TargetSkill.SingleTarget;
        //public float skillArea;
        //public SkillType skillType = PlayerSkill.SkillType.LockTarget;
        //public float castTime = 0;//施法速度
        //public float attackTimer = 0.5f;
        public float multipleDamage = 1;//多重伤害，剑刃风暴类
        //public float flichValue = 0;
        //public int skillAccurate;//命中率
        [Multiline]
        public string description = "This is active skill.";
        public string typeSkill = "Active";
        public string damageType = "Normal";
        //public bool speedTuning;
        public float skillPower;//技能威力系数，如果是真实伤害，就是伤害数值
        public float cd;
        public float cd_check;



        [HideInInspector]
        public bool isAdd;
        //[HideInInspector]
        //public float castTimer;
    }

    [System.Serializable]
    public class ActiveSkillBuff
    {
        public string skillName = "Skill Buff";
        public int skillID{ get; set; }
        public int skillLv;
        public float skillLvGrowth;
        public int unlockLevel = 1;
        public string skillIcon;
        public int MPUse;
        //public AnimationClip animationBuff;
        //public float speedAnimation = 1;
        //public float castTime = 0;//技能吟唱
        //public float activeTimer = 0.5f;
        public float duration;
        public string addAttribute;
        public float addValue;
        [Multiline]
        public string description = "This is Buff skill.";
        public string typeSkill = "Buff";
        public float cd;
        public float cd_check;


        [HideInInspector]
        public bool isAdd;
        //[HideInInspector]
        //public float castTimer;

    }

    [System.Serializable]
    public class DurationBuff
    {
        public string buffName;
        public int skillIndex;
        public string skillIcon;
        public float duration;
        public bool isCount;
        public float durationTimer;

    }

    public List<PassiveSkill> passiveSkill = new List<PassiveSkill>();  //Passive skill
    public List<ActiveSkillAttack> activeSkillAttack = new List<ActiveSkillAttack>(); //Active Attack Skill
    public List<ActiveSkillBuff> activeSkillBuff = new List<ActiveSkillBuff>(); //Buff Skill

    [HideInInspector]
    public DurationBuff[] durationBuff = new DurationBuff[20];


    //Private Variable
    //private TurnControl TurnControl.instance;
    //private PlayerControl PlayerControl.instance;
    //private HeroStatus hero;

    public bool canCast;
    //private bool setupSkillTimer;
    [HideInInspector]
    public bool oneShotResetTarget;


    //[HideInInspector]
   

   // private GameObject magicCircle;//施法条 到时候用施法条展现
    private string typeofSkill;
    private string typeofdamage;
    private string nameofskill;
    private int currentUseSkill;
   


    //Editor Variable
    [HideInInspector]
    public int sizePassiveSkill = 0;
    [HideInInspector]
    public int sizeActiveAttack = 0;
    [HideInInspector]
    public int sizeActiveBuff = 0;
    [HideInInspector]
    public List<bool> showPassiveSize = new List<bool>();
    [HideInInspector]
    public List<bool> showActiveAttackSize = new List<bool>();
    [HideInInspector]
    public List<bool> showActiveBuffSize = new List<bool>();

    //private void Awake()
    //{
    //    instance = this;
    //}
    // Use this for initialization
    void Start()
    {


        //TurnControl.instance = GameObject.Find("TurnSystem").GetComponent<TurnControl>();
        //HeroStatus.instance = GameObject.Find("hero").GetComponent<HeroStatus>();


        UpdatePassiveStatus();

    }

    // Update is called once per frame
    void Update()
    {

        CountDurationBuff();

    }

    //Update passive status method
    void UpdatePassiveStatus()
    {
        for (int i = 0; i < passiveSkill.Count; i++)
        {
            if ( !passiveSkill[i].isAdd)
            {
                CheckAddAttributePassive(i);
                passiveSkill[i].isAdd = true;
            }

            i++;

        }
    }

  
    void CheckAddAttributePassive(int indexSkill)
    {
        
    
        if (passiveSkill[indexSkill].addAttribute == "HP")
        {
            HeroStatus.instance.AddStatus.HP += Mathf.FloorToInt(passiveSkill[indexSkill].addValue);
        }


        if (passiveSkill[indexSkill].addAttribute == "MP")
        {
            HeroStatus.instance.AddStatus.MP += Mathf.FloorToInt(passiveSkill[indexSkill].addValue);
        }


        if (passiveSkill[indexSkill].addAttribute == "S")
        {
            HeroStatus.instance.AddStatus.S += Mathf.FloorToInt(passiveSkill[indexSkill].addValue);
        }


        if (passiveSkill[indexSkill].addAttribute == "P")
        {
            HeroStatus.instance.AddStatus.P += Mathf.FloorToInt(passiveSkill[indexSkill].addValue);
        }


        if (passiveSkill[indexSkill].addAttribute == "D")
        {
            HeroStatus.instance.AddStatus.D += Mathf.FloorToInt(passiveSkill[indexSkill].addValue);
        }


        if (passiveSkill[indexSkill].addAttribute == "A")
        {
            HeroStatus.instance.AddStatus.A += Mathf.FloorToInt(passiveSkill[indexSkill].addValue);
        }


        if (passiveSkill[indexSkill].addAttribute == "I")
        {
            HeroStatus.instance.AddStatus.I += passiveSkill[indexSkill].addValue;
        }

        if (passiveSkill[indexSkill].addAttribute == "AtkValue")
        {
            HeroStatus.instance.AddStatus.AtkValue += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "DefValue")
        {
            HeroStatus.instance.AddStatus.DefValue += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "AValue")
        {
            HeroStatus.instance.AddStatus.AValue += passiveSkill[indexSkill].addValue;
        }
        //if (passiveSkill[indexSkill].addAttribute == "IValue")
        //{
        //    HeroStatus.instance.AddStatus.IValue += passiveSkill[indexSkill].addValue;
        //}


        if (passiveSkill[indexSkill].addAttribute == "MagicAtk")
        {
            HeroStatus.instance.AddStatus.MagicAtk += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "MagicDef")
        {
            HeroStatus.instance.AddStatus.MagicDef += passiveSkill[indexSkill].addValue;
        }

        if (passiveSkill[indexSkill].addAttribute == "AttackSpeed")
        {
            HeroStatus.instance.AddStatus.AttackSpeed += passiveSkill[indexSkill].addValue;
        }

        if (passiveSkill[indexSkill].addAttribute == "Crit")
        {
            HeroStatus.instance.AddStatus.Crit += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "CritDamage")
        {
            HeroStatus.instance.AddStatus.CritDamage += passiveSkill[indexSkill].addValue;
        }

        if (passiveSkill[indexSkill].addAttribute == "Hit")
        {
            HeroStatus.instance.AddStatus.Hit += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "Agl")
        {
            HeroStatus.instance.AddStatus.Agl += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "Counter")
        {
            HeroStatus.instance.AddStatus.Counter += passiveSkill[indexSkill].addValue;
        }

        if (passiveSkill[indexSkill].addAttribute == "Double")
        {
            HeroStatus.instance.AddStatus.Double += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "HPRecoverPerSecond")
        {
            HeroStatus.instance.AddStatus.HPRecoverPerSecond += passiveSkill[indexSkill].addValue;
        }


        if (passiveSkill[indexSkill].addAttribute == "MPRecoverPerSecond")
        {
            HeroStatus.instance.AddStatus.MPRecoverPerSecond += passiveSkill[indexSkill].addValue;
        }


    }
   

    void CheckAddAttributeBuff(int indexSkill, string command)
    {
        
        if (activeSkillBuff[indexSkill].addAttribute == "HP")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.HP += Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.HP -= Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
        }


 

        if (activeSkillBuff[indexSkill].addAttribute == "MP")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.MP += Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.MP -= Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
        }


        if (activeSkillBuff[indexSkill].addAttribute == "S")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.S += Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.S -= Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
        }


        if (activeSkillBuff[indexSkill].addAttribute == "P")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.P += Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.P -= Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
        }


        if (activeSkillBuff[indexSkill].addAttribute == "D")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.D += Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.D -= Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
        }


        if (activeSkillBuff[indexSkill].addAttribute == "A")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.A += Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.A -= Mathf.FloorToInt(activeSkillBuff[indexSkill].addValue);
        }


        if (activeSkillBuff[indexSkill].addAttribute == "I")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.I += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.I -= activeSkillBuff[indexSkill].addValue;
        }

       
        if (activeSkillBuff[indexSkill].addAttribute == "AtkValue")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.AtkValue += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.AtkValue -= activeSkillBuff[indexSkill].addValue;
        }


        if (activeSkillBuff[indexSkill].addAttribute == "DefValue")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.DefValue += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.DefValue -= activeSkillBuff[indexSkill].addValue;
        }


        if (activeSkillBuff[indexSkill].addAttribute == "AValue")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.AValue += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.AValue -= activeSkillBuff[indexSkill].addValue;
        }
        if (activeSkillBuff[indexSkill].addAttribute == "IValue")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.IValue += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.IValue -= activeSkillBuff[indexSkill].addValue;
        }

      
        if (activeSkillBuff[indexSkill].addAttribute == "MagicAtk")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.MagicAtk += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.MagicAtk -= activeSkillBuff[indexSkill].addValue;
        }

      
        if (activeSkillBuff[indexSkill].addAttribute == "MagicDef")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.MagicDef += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.MagicDef -= activeSkillBuff[indexSkill].addValue;
        }

        if (activeSkillBuff[indexSkill].addAttribute == "AttackSpeed")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.AttackSpeed += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.AttackSpeed -= activeSkillBuff[indexSkill].addValue;
        }


        if (activeSkillBuff[indexSkill].addAttribute == "Crit")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.Crit += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.Crit -= activeSkillBuff[indexSkill].addValue;
        }


        if (activeSkillBuff[indexSkill].addAttribute == "CritDamage")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.CritDamage += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.CritDamage -= activeSkillBuff[indexSkill].addValue;
        }
        if (activeSkillBuff[indexSkill].addAttribute == "Hit")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.Hit += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.Hit -= activeSkillBuff[indexSkill].addValue;
        }


        if (activeSkillBuff[indexSkill].addAttribute == "Agl")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.Agl += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.Agl -= activeSkillBuff[indexSkill].addValue;
        }


        if (activeSkillBuff[indexSkill].addAttribute == "Counter")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.Counter += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.Counter -= activeSkillBuff[indexSkill].addValue;
        }
        if (activeSkillBuff[indexSkill].addAttribute == "Double")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.Double += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.Double -= activeSkillBuff[indexSkill].addValue;
        }

    
        if (activeSkillBuff[indexSkill].addAttribute == "HPRecoverPerSecond")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.HPRecoverPerSecond += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.HPRecoverPerSecond -= activeSkillBuff[indexSkill].addValue;
        }

       
        if (activeSkillBuff[indexSkill].addAttribute == "MPRecoverPerSecond")
        {
            if (command == "Buff")
                HeroStatus.instance.AddStatus.MPRecoverPerSecond += activeSkillBuff[indexSkill].addValue;
            if (command == "Debuff")
                HeroStatus.instance.AddStatus.MPRecoverPerSecond -= activeSkillBuff[indexSkill].addValue;
        }


    }

    //Find skill type
    public string FindSkillType(int skillID)
    {
        for (int i = 0; i < passiveSkill.Count; i++)
        {
            if (skillID == passiveSkill[i].skillID)
            {
                typeofSkill = "Passive";
                return typeofSkill;
            }
        }

        //Find current use skill in buff type
        for (int i = 0; i < activeSkillBuff.Count; i++)
        {
            if (skillID == activeSkillBuff[i].skillID)
            {
                typeofSkill = "Buff";
                return typeofSkill;
            }

        }

        for (int i = 0; i < activeSkillAttack.Count; i++)
        {
            if (skillID == activeSkillAttack[i].skillID)
            {
                typeofSkill = "Attack";
                return typeofSkill;
            }
        }

        return "";
    }

    //Find skill ID
    public int FindSkillIndex(int skillID)
    {
        for (int i = 0; i < passiveSkill.Count; i++)
        {
            if (skillID == passiveSkill[i].skillID)
            {
                currentUseSkill = i;
                return currentUseSkill;
            }

        }

        //Find current use skill in buff type
        for (int i = 0; i < activeSkillBuff.Count; i++)
        {
            if (skillID == activeSkillBuff[i].skillID)
            {
                currentUseSkill = i;
                return currentUseSkill;
            }

        }

        for (int i = 0; i < activeSkillAttack.Count; i++)
        {
            if (skillID == activeSkillAttack[i].skillID)
            {
                currentUseSkill = i;
                return currentUseSkill;
            }

        }

        return 0;
    }
    public string FindSkillName(int skillID)
    {
        for (int i = 0; i < passiveSkill.Count; i++)
        {
            if (skillID == passiveSkill[i].skillID)
            {
                nameofskill = passiveSkill[i].skillName;
                return nameofskill;
            }
        }

        //Find current use skill in buff type
        for (int i = 0; i < activeSkillBuff.Count; i++)
        {
            if (skillID == activeSkillBuff[i].skillID)
            {
                nameofskill = activeSkillBuff[i].skillName;
                return nameofskill;
            }

        }

        for (int i = 0; i < activeSkillAttack.Count; i++)
        {
            if (skillID == activeSkillAttack[i].skillID)
            {
                nameofskill = activeSkillAttack[i].skillName;
                return nameofskill;
            }
        }

        return "";
    }
    public string FindDamageType(int skillID)
    {

        for (int i = 0; i < activeSkillAttack.Count; i++)
        {
            if (skillID == activeSkillAttack[i].skillID)
            {
                typeofdamage = activeSkillAttack[i].damageType;
                return typeofdamage;
            }
        }

        return "Normal";
    }

    ////Cast Break Method  吟唱被打断
    //public void CastBreak()
    //{
    //    //if (magicCircle != null)
    //        //Destroy(magicCircle);
    //    PlayerControl.instance.target = null;
    //    setupSkillTimer = false;
    //    canCast = false;
    //    //botBar.showCastBar = false;
    //}

    //Cast skill method
	public void CastActiveSkill(activeskill skill,int x)
    {
		//Debug.Log("时间到了吗" +PlayerControl.instance.cdTimers[skill.skillID].CurrentTime );
		if (HeroStatus.instance.CurStatus.CurMP < skill.mpUse)
                {
                        Debug.Log("No MP");
                    canCast = false;
                }
                else
                {
			//if (skill.cdCount.IsTimeUp==false)
			if (PlayerControl.instance.cdTimers[skill.skillID].CurrentTime>= 0)
                    {
                        Debug.Log("No cd");
                        canCast = false;
                    }
                    else
                    {
                         
                            PlayerControl.instance.ResetBeforeCast();
                            PlayerControl.instance.ResetOldCast();
                            //PlayerControl.instance.useSkill = true;
					PlayerControl.instance.castid = skill.skillID;
					HeroStatus.instance.CurStatus.CurMP -= skill.mpUse;
                            canCast = true;
                       
                    }
         
                }
		//Debug.Log(canCast);

    }
	public void CastSkill(string skillType, int indexSkill)
    {

        if (skillType == "Buff")
        {
            if (HeroStatus.instance.CurStatus.CurMP < activeSkillBuff[indexSkill].MPUse)
            {
                Debug.Log("No MP");
                canCast = false;
            }
            else
            {
                if (activeSkillBuff[indexSkill].cd_check > 0)
                {
                    Debug.Log("No cd");
                    canCast = false;
                }
                else
                {
                    HeroStatus.instance.CurStatus.CurMP -= activeSkillBuff[indexSkill].MPUse;
                    canCast = true;
                }
            }
        }
        //else

        //if (skillType == "Attack" && activeSkillAttack[indexSkill].skillType == SkillType.Instance)
        //{
        //if (HeroStatus.instance.CurStatus.CurMP < activeSkillAttack[indexSkill].MPUse)
        //    {
        //        Debug.Log("No MP");
        //        canCast = false;
        //    }
        //    else
        //    {
        //        if (activeSkillAttack[indexSkill].cd_check > 0)
        //        {
        //            Debug.Log("No cd");
        //            canCast = false;
        //        }
        //        else
        //        {
        //            PlayerControl.instance.ResetBeforeCast();
        //            PlayerControl.instance.ResetOldCast();
        //        HeroStatus.instance.CurStatus.CurMP -= activeSkillAttack[indexSkill].MPUse;
        //            canCast = true;
        //        }

        //    }
        //}


        if (skillType == "Attack")
        {
            if (HeroStatus.instance.CurStatus.CurMP < activeSkillAttack[indexSkill].MPUse)
            {
                Debug.Log("No MP");
                canCast = false;
            }
            else
            {
                if (activeSkillAttack[indexSkill].cd_check > 0)
                {
                    Debug.Log("No cd");
                    canCast = false;
                }
                else
                {
                    if (!oneShotResetTarget)
                    {
                        PlayerControl.instance.ResetBeforeCast();
                        PlayerControl.instance.ResetOldCast();
                        //PlayerControl.instance.useSkill = true;
                        PlayerControl.instance.castid = activeSkillAttack[indexSkill].skillID;
                        HeroStatus.instance.CurStatus.CurMP -= activeSkillAttack[indexSkill].MPUse;
                        oneShotResetTarget = true;
                        canCast = true;
                    }
                }


            }
        }

        //if (skillType == "Attack" && activeSkillAttack[indexSkill].skillType == SkillType.FreeTarget)
        //{
        //if (HeroStatus.instance.CurStatus.CurMP < activeSkillAttack[indexSkill].MPUse)
        //    {
        //        Debug.Log("No MP");

        //        canCast = false;
        //    }
        //    else
        //    {

        //        if (activeSkillAttack[indexSkill].cd_check > 0)
        //        {
        //            Debug.Log("No cd");
        //            canCast = false;
        //        }
        //        else
        //        {
        //            if (!oneShotResetTarget)
        //            {
        //                PlayerControl.instance.ResetBeforeCast();
        //                PlayerControl.instance.ResetOldCast();
        //                PlayerControl.instance.useSkill = true;
        //                PlayerControl.instance.useFreeSkill = true;
        //            HeroStatus.instance.CurStatus.CurMP -= activeSkillAttack[indexSkill].MPUse;
        //                PlayerControl.instance.castid = activeSkillAttack[indexSkill].skillID;
        //            canCast = true;
        //                oneShotResetTarget = true;
        //            }
        //        }


        //    }
        //}



    }

    //Active Skill method
	public void playActiveSkill(activeskill skill)
    {
  
                    
      
		if (skill != null)
		{
	         
			if (skill.isRecover == 0)
			{
				
				//if (PlayerControl.instance.target != null)
				//{
					
					//EnemyControl enemy;
					//enemy = PlayerControl.instance.target.GetComponent<EnemyControl>();
					//Debug.Log(PlayerControl.instance.gameObject);
					//enemy.EnemyLockTarget(PlayerControl.instance.gameObject);
					float damage;
					float addDam;
					addDam = CalAddDamage(skill);
					for (int a = 0; a < skill.multipleDamage; a = a + 1)
					{
						
						if (skill.damageType == "Normal")
						{
                        
							damage = PlayerControl.instance.SkillDamage(addDam, skill.baseDam, skill.skillPower, "Normal");
						//Debug.Log("释放了技能" + skill.skillName + "造成了伤害：结算前" + damage);
						EnemyControl.instance.ReceiveDamage((int)damage,skill);
								skill.cd_check = skill.cd - Time.deltaTime;
						//Debug.Log("重击的cd" + skill.cd_check);
						}
						else if (skill.damageType == "Magic")
						{
							damage = PlayerControl.instance.SkillDamage(addDam, skill.baseDam, skill.skillPower, "Magic");
						EnemyControl.instance.ReceiveDamage((int)damage, skill);

							skill.cd_check = skill.cd - Time.deltaTime;
						}
						else if (skill.damageType == "True")
						{
							damage = PlayerControl.instance.SkillDamage(addDam, skill.baseDam, skill.skillPower, "True");
						EnemyControl.instance.ReceiveDamage((int)damage, skill);

							skill.cd_check = skill.cd - Time.deltaTime;
						}
					}

					//伤害 =[基础伤害+ 技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 + 2]×各类修正
				//}


			}
			else
			{
				float recover;
				float addDam = CalAddDamage(skill);
				recover = PlayerControl.instance.SkillDamage(addDam, skill.baseDam, skill.skillPower, "True");
				//Debug.Log("回复值addDam：" + addDam);
				//Debug.Log("回复值：" + recover);
				HeroStatus.instance.CurStatus.CurHP += recover;
				PlayerControl.instance.ShowText((int)recover, skill.damageType, skill.skillName);

				skill.cd_check = skill.cd - Time.deltaTime;
				//Debug.Log("回复的cd"+skill.cd_check);
			}
		}


    }
    

 
	//public void ActiveSkill(string skillType, int indexSkill)
    //{


        //if (skillType == "Buff")
        //{

        //    if (!activeSkillBuff[indexSkill].isAdd)
        //    {
        //        CheckAddAttributeBuff(indexSkill, "Buff");
        //        activeSkillBuff[indexSkill].isAdd = true;
        //        activeSkillBuff[indexSkill].cd_check = activeSkillBuff[indexSkill].cd - Time.deltaTime;
        //    }
        //    SentBuffParameter(indexSkill);
        //    HeroStatus.instance.UpdateAttribute();


        //}
        //else if (skillType == "Attack")
        //{
        //    if (activeSkillAttack[indexSkill].isRecover == 0)
        //    {
        //        //if (activeSkillAttack[indexSkill].skillType == SkillType.Instance)
        //        //{
        //        //    if (activeSkillAttack[indexSkill].skillAccurate == 0)
        //        //        activeSkillAttack[indexSkill].skillAccurate = (int)HeroStatus.instance.CurStatus.CurHit;
        //        //    PlayerControl.instance.ResetState();
        //        //}
        //        //else if (activeSkillAttack[indexSkill].skillType == SkillType.LockTarget)
        //        //{

        //        //if (activeSkillAttack[indexSkill].skillAccurate == 0)
        //        //activeSkillAttack[indexSkill].skillAccurate = (int)HeroStatus.instance.CurStatus.CurHit;

        //        //if (activeSkillAttack[indexSkill].targetSkill == TargetSkill.MultipleTarget)
        //        //{
        //        //    PlayerControl.instance.ResetState();
        //        //}
        //        //else if (activeSkillAttack[indexSkill].targetSkill == TargetSkill.SingleTarget)
        //        //{
        //        if (PlayerControl.instance.target != null)
        //        {
        //            EnemyControl enemy;
        //            enemy = PlayerControl.instance.target.GetComponent<EnemyControl>();
        //            enemy.EnemyLockTarget(PlayerControl.instance.gameObject);
        //            float damage;
        //            float addDam;
        //            addDam = CalAddDamage(indexSkill);
        //            for (int a = 0; a < activeSkillAttack[indexSkill].multipleDamage; a = a + 1)
        //            {
        //                if (activeSkillAttack[indexSkill].damageType == "Normal")
        //                {

        //                    damage = PlayerControl.instance.SkillDamage(addDam, activeSkillAttack[indexSkill].baseDam, activeSkillAttack[indexSkill].skillPower, "Normal");
        //                    enemy.ReceiveDamage((int)damage, "Normal", activeSkillAttack[indexSkill].skillName);
        //                    activeSkillAttack[indexSkill].cd_check = activeSkillAttack[indexSkill].cd - Time.deltaTime;
        //                }
        //                else if (activeSkillAttack[indexSkill].damageType == "Magic")
        //                {
        //                    damage = PlayerControl.instance.SkillDamage(addDam, activeSkillAttack[indexSkill].baseDam, activeSkillAttack[indexSkill].skillPower, "Magic");
        //                    enemy.ReceiveDamage((int)damage, "Magic", activeSkillAttack[indexSkill].skillName);
        //                    activeSkillAttack[indexSkill].cd_check = activeSkillAttack[indexSkill].cd - Time.deltaTime;
        //                }
        //                else if (activeSkillAttack[indexSkill].damageType == "True")
        //                {
        //                    damage = PlayerControl.instance.SkillDamage(addDam, activeSkillAttack[indexSkill].baseDam, activeSkillAttack[indexSkill].skillPower, "True");
        //                    enemy.ReceiveDamage((int)damage, "True", activeSkillAttack[indexSkill].skillName);
        //                    activeSkillAttack[indexSkill].cd_check = activeSkillAttack[indexSkill].cd - Time.deltaTime;
        //                }
        //            }

        //            //伤害 =[基础伤害+ 技能威力 × 攻击方攻击力 ÷ 防御方防御力 ÷ 50 + 2]×各类修正
        //            //PlayerControl.instance.useSkill = false;

        //            //enemy.GetDamage((hero.CurStatus.atk) * activeSkillAttack[indexSkill].multipleDamage, activeSkillAttack[indexSkill].skillAccurate, activeSkillAttack[indexSkill].flichValue
        //            //, activeSkillAttack[indexSkill].skillFxTarget, activeSkillAttack[indexSkill].soundFxTarget);
        //        }

        //        //}
        //        //PlayerControl.instance.ResetState();


        //        //    }
        //        //    else if (activeSkillAttack[indexSkill].skillType == SkillType.FreeTarget)
        //        //    {


        //        //        if (activeSkillAttack[indexSkill].skillAccurate == 0)
        //        //            activeSkillAttack[indexSkill].skillAccurate = (int)HeroStatus.instance.CurStatus.CurHit;


        //        //        PlayerControl.instance.useSkill = false;
        //        //        PlayerControl.instance.useFreeSkill = false;
        //        //        PlayerControl.instance.ResetState();
        //        //    }

        //    }
        //    else
        //    {
        //        float recover;
        //        float addDam = CalAddDamage(indexSkill);
        //        recover = PlayerControl.instance.SkillDamage(addDam, activeSkillAttack[indexSkill].baseDam, activeSkillAttack[indexSkill].skillPower, "True");
        //        HeroStatus.instance.CurStatus.CurHP += recover;
        //        PlayerControl.instance.ShowText((int)recover, activeSkillAttack[indexSkill].damageType, activeSkillAttack[indexSkill].skillName);
        //        activeSkillAttack[indexSkill].cd_check = activeSkillAttack[indexSkill].cd - Time.deltaTime;
        //    }


        //}
    //}
    //Send buff parameter
    void SentBuffParameter(int indexSkill)
    {
        for (int i = 0; i < durationBuff.Length; i++)
        {
            if (durationBuff[i].buffName == "" || durationBuff[i].buffName == activeSkillBuff[indexSkill].skillName)
            {
                durationBuff[i].buffName = activeSkillBuff[indexSkill].skillName;
                durationBuff[i].skillIndex = indexSkill;
                durationBuff[i].skillIcon = activeSkillBuff[indexSkill].skillIcon;
                durationBuff[i].duration = activeSkillBuff[indexSkill].duration;
                durationBuff[i].isCount = true;
                break;
            }

        }
    }



	public  float CalAddDamage(activeskill skill)
    {

        float AddDamage=0f;

		if (skill.addAttribute == "None")
        {
            AddDamage = 0;
        }
		if (skill.addAttribute == "HP")
        {
            AddDamage = HeroStatus.instance.SumStatus.HP * (skill.addValue);
        }


        if (skill.addAttribute == "MP")
        {
            AddDamage = HeroStatus.instance.SumStatus.MP * (skill.addValue);
        }


        if (skill.addAttribute == "S")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurS * (skill.addValue);
        }


        if (skill.addAttribute == "P")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurP * (skill.addValue);
        }


        if (skill.addAttribute == "D")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurD * (skill.addValue);
        }


        if (skill.addAttribute == "A")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurA * (skill.addValue);
        }


        if (skill.addAttribute == "I")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurI * (skill.addValue);
        }

        if (skill.addAttribute == "AtkValue")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurAtkValue * (skill.addValue);
        }


        if (skill.addAttribute == "DefValue")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurDefValue * (skill.addValue);
        }


        if (skill.addAttribute == "AValue")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurAValue * (skill.addValue);
        }
        //if (skill.addAttribute == "IValue")
        //{
        //    HeroStatus.instance.AddStatus.IValue += skill.addValue;
        //}


        if (skill.addAttribute == "MagicAtk")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurMagicAtk * (skill.addValue);
        }


        if (skill.addAttribute == "MagicDef")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurMagicDef * (skill.addValue);
        }

        if (skill.addAttribute == "AttackSpeed")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurAttackSpeed * (skill.addValue);
        }

        if (skill.addAttribute == "Crit")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurCrit * (skill.addValue);
        }


        if (skill.addAttribute == "CritDamage")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurCritDamage * (skill.addValue);
        }

        if (skill.addAttribute == "Hit")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurHit * (skill.addValue);
        }


        if (skill.addAttribute == "Agl")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurAgl * (skill.addValue);
        }


        if (skill.addAttribute == "Counter")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurCounter * (skill.addValue);
        }

        if (skill.addAttribute == "Double")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurDouble * (skill.addValue);
        }


        if (skill.addAttribute == "HPRecoverPerSecond")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurHPRecoverPerSecond * (skill.addValue);
        }


        if (skill.addAttribute == "MPRecoverPerSecond")
        {
            AddDamage = HeroStatus.instance.CurStatus.CurMPRecoverPerSecond * (skill.addValue);
        }
        return AddDamage/100f;

    }
    //Count duration buff
    void CountDurationBuff()
    {
        for (int i = 0; i < durationBuff.Length; i++)
        {
            if (durationBuff[i].isCount)
            {
                if (durationBuff[i].duration > 0)
                {
                    durationBuff[i].duration -= Time.deltaTime;

                }
                else if (durationBuff[i].duration <= 0)
                {
                    activeSkillBuff[durationBuff[i].skillIndex].isAdd = false;
                    CheckAddAttributeBuff(durationBuff[i].skillIndex, "Debuff");
                    HeroStatus.instance.UpdateAttribute();
                    durationBuff[i].buffName = "";
                    durationBuff[i].skillIndex = 0;
                    durationBuff[i].duration = 0;
                    durationBuff[i].skillIcon = null;
                    durationBuff[i].isCount = false;
                }
            }
        }
    }




}
