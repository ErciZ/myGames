using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//public class HeroStatus : MonoBehaviour
public class HeroStatus : MonoBehaviour
{




    public static HeroStatus instance;



    //Hero name
    /// <summary>
    /// 最高等级
    /// </summary>
    public int MaxLV;
    /// <summary>
    /// 当前等级所需要的经验总量
    /// </summary>
    public float NeedExpPerLV;
    //当前等级到下一个等级还需要的经验量
    public float EXP2NextLV;
    //到当前为止所获得的所有经验量
    public float MaxExp;
    //各类的实例对象：
    public BaseAttribute BaseStatus;
    public AdditionAttribute AddStatus;
    public CurAttribute CurStatus;
    public SumAttribute SumStatus;

    public AttributeGrowth attributeGrowth, growthPoint;
    //定义各种速度：

    public float hpRegenTime; //hp regen per second
    public float mpRegenTime; //mp regen per second

    public bool GetLvUp = false;
    public bool GrowthisAdd = true;
    //private bool checkStatus;

    //private PlayerSkill playerSkill;
    public List<PlayerSkill.PassiveSkill> have_passiveSkill = new List<PlayerSkill.PassiveSkill>();  //Passive skill
    public List<PlayerSkill.ActiveSkillAttack> have_activeSkillAttack = new List<PlayerSkill.ActiveSkillAttack>(); //Active Attack Skill
    public List<PlayerSkill.ActiveSkillBuff> have_activeSkillBuff = new List<PlayerSkill.ActiveSkillBuff>(); //Buff Skill

    //拥有技能的id和等级
	public int[] use_activeSkillAttack = new int[7] { 20006, 20002, 20004, 20000, 20001, 20000, 20000 };
	public List<activeskill> used_activeskill = new List<activeskill>();

	//玩家装备物品 武器  头 胸甲 腿 戒指
	public int[] equiped_armor = new int[5] { 31001, 40001, 40002, 40003, 40004 };
    public List<equipments> equip_on = new List<equipments>();
	public equipments noEquip = new equipments();

	public string haveActiveskill;
	public string haveArmor;




    [System.Serializable]
    public class BaseAttribute
    {
		public string HeroName, HeroID;
		//等级
		public int LV;
        /// <summary>
        ///血量，魔量 ,精力
        /// </summary>
        public float HP, MP,EP;
        /// <summary>
        ///体力/体质，力量/外功，防御/根骨，速度/身法，魔法/内功
        /// </summary>
        public float S,P,D, A,  I;

        /// <summary>
        ///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御,悟性，福缘
        /// </summary>
        public float AtkValue,DefValue,AValue,IValue,MagicAtk,MagicDef,Comprehension,luck;
        /// <summary>
        /// 攻击速度，经验值，暴击概率,暴击伤害百分比，命中，闪避，反击，连击；
        /// </summary>
        public float AttackSpeed,Exp, Crit, CritDamage,Hit,Agl,Counter,Double;
        /// <summary>
        /// 每秒血量回复，每秒魔量回复
        /// </summary>
        public float HPRecoverPerSecond, MPRecoverPerSecond;



    }

    [System.Serializable]
    public class AdditionAttribute
    {
        /// <summary>
        ///血量，魔量 ,精力
        /// </summary>
        public float HP, MP, EP;
        /// <summary>
        ///体力/体质，力量/外功，防御/根骨，速度/身法，魔法/内功
        /// </summary>
        public float S, P, D, A, I;
        /// <summary>
        ///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御
        /// </summary>
        public float AtkValue, DefValue, AValue, IValue, MagicAtk, MagicDef;
        /// <summary>
        /// 攻击速度，经验值，暴击概率,暴击伤害百分比，命中，闪避，反击，连击；
        /// </summary>
        public float AttackSpeed, Exp, Crit, CritDamage, Hit, Agl, Counter, Double;
        /// <summary>
        /// 每秒血量回复，每秒魔量回复
        /// </summary>
        public float HPRecoverPerSecond, MPRecoverPerSecond;
    }

    [System.Serializable]
    public class CurAttribute
    {
        /// <summary>
        ///血量，魔量  ,精力
        /// </summary>
        public float CurHP, CurMP,CurEP;
        /// <summary>
        ///体力/体质，力量/外功，防御/根骨，速度/身法，魔法/内功
        /// </summary>
        public float CurS, CurP, CurD, CurA, CurI;
        /// <summary>
        ///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御
        /// </summary>
        public float CurAtkValue, CurDefValue, CurAValue, CurIValue, CurMagicAtk, CurMagicDef;
        /// <summary>
        /// 攻击速度，经验值，暴击概率,暴击伤害百分比，命中，闪避，反击，连击；
        /// </summary>
        public float CurAttackSpeed, CurExp, CurCrit, CurCritDamage, CurHit, CurAgl, CurCounter, CurDouble;

        /// <summary>
        /// 每秒血量回复，每秒魔量回复
        /// </summary>
        public float CurHPRecoverPerSecond, CurMPRecoverPerSecond;
    }

    [System.Serializable]
    public class SumAttribute
    {
        /// <summary>
        ///血量，魔量 ,精力
        /// </summary>
        public float HP, MP, EP;
        /// <summary>
        ///力量/外功,体力/体质，防御/根骨，速度/身法，魔法/内功
        /// </summary>
        public float S, P, D, A, I;
        /// <summary>
        ///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御
        /// </summary>
        public float AtkValue, DefValue, AValue, IValue, MagicAtk, MagicDef;
        /// <summary>
        /// 攻击速度，经验值，暴击概率,暴击伤害百分比，命中，闪避，反击，连击；
        /// </summary>
        public float AttackSpeed, Exp, Crit, CritDamage, Hit, Agl, Counter, Double;
        /// <summary>
        /// 每秒血量回复，每秒魔量回复
        /// </summary>
        public float HPRecoverPerSecond, MPRecoverPerSecond;
    }

    [System.Serializable]
    public class AttributeGrowth
    {
        /// <summary>
        ///血量，魔量 ,精力
        /// </summary>
        public float HP, MP, EP;
        /// <summary>
        ///体力/体质，力量/外功，防御/根骨，速度/身法，魔法/内功
        /// </summary>
        public float S, P, D, A, I;
    }
    private void Awake()
    {
        instance = this;
        UpdateAttribute(); 
    }
    void Start()
    {
        //Invoke("SettingStatus", 0.1f);
        GetLvUp = false;
        GrowthisAdd = true;

    }

    // Update is called once per frame
    void Update()
    {

        UpdateExp();


         CheckHPMP();
        if (CurStatus.CurHP <= 0)
        {
            //CancelInvoke("RegenerationHP");
            //CancelInvoke("RegenerationMP");
        }





    }
    void CalculateExp()
    {
        //更新到当前等级为止的所有经验，包括本级到下一级
        MaxExp = 40.0f * BaseStatus.LV * BaseStatus.LV + 60.0f * BaseStatus.LV;
        //更新本级到下一级所需要的经验值；
        NeedExpPerLV = MaxExp - (40.0f * (BaseStatus.LV - 1) * (BaseStatus.LV - 1) + 60.0f * (BaseStatus.LV - 1));
    }




    public void UpdateExp()//更新经验值
    {
        if (BaseStatus.LV >= MaxLV)
        {
            BaseStatus.Exp = NeedExpPerLV;
            BaseStatus.LV = MaxLV;
        }
        else
        {
            if (BaseStatus.Exp >= NeedExpPerLV)
            {
                GetLvUp = true;
                //更新当前在本级拥有经验
                BaseStatus.Exp = BaseStatus.Exp - NeedExpPerLV;
                //更新等级
                BaseStatus.LV += 1;

                CalculateExp();
                GrowthisAdd = false;

                //更新属性
                UpdateAttribute();

                CurStatus.CurHP = SumStatus.HP;
                CurStatus.CurMP = SumStatus.MP;
            }
        }

    }

    public void StartRegen()
    {
        //InvokeRepeating("RegenerationHP", hpRegenTime, hpRegenTime);
        //InvokeRepeating("RegenerationMP", mpRegenTime, mpRegenTime);
    }


   public  void UpdateAttribute()
    {
        if (!GrowthisAdd)
            //S, P, D, A, I
        {
            CalculateAttributePointGrowth();
            BaseStatus.HP += attributeGrowth.HP;
            BaseStatus.MP += attributeGrowth.MP;
            BaseStatus.EP += attributeGrowth.EP;
            BaseStatus.D += attributeGrowth.D;
            BaseStatus.S += attributeGrowth.S;
            BaseStatus.I += attributeGrowth.I;
            BaseStatus.A += attributeGrowth.A;
            BaseStatus.P += attributeGrowth.P;
            GrowthisAdd = true;
        }
        SumStatus.S = BaseStatus.S + AddStatus.S;
        SumStatus.I = BaseStatus.I + AddStatus.I;
        SumStatus.A = BaseStatus.A + AddStatus.A;
        SumStatus.P = BaseStatus.P + AddStatus.P;
        SumStatus.D = BaseStatus.D+ AddStatus.D;

        SumStatus.AtkValue = BaseStatus.AtkValue + AddStatus.AtkValue + Mathf.FloorToInt((SumStatus.S * 20f+SumStatus.P * 1f+ SumStatus.D * 2f+ SumStatus.A * 2f+ SumStatus.I * 1f)/10f);
        SumStatus.DefValue = BaseStatus.DefValue + AddStatus.DefValue+ Mathf.FloorToInt((SumStatus.S * 2f + SumStatus.P * 1f + SumStatus.D * 20f + SumStatus.A * 2f + SumStatus.I * 1f)/10f);
        SumStatus.AValue = BaseStatus.AValue + AddStatus.AValue + Mathf.FloorToInt((SumStatus.S * 2f + SumStatus.P * 1f + SumStatus.D * 2f + SumStatus.A * 20f + SumStatus.I * 1f)/10f);
        //SumStatus.IValue = BaseStatus.IValue + AddStatus.IValue + Mathf.FloorToInt((SumStatus.I * 8f-SumStatus.S * 1f + SumStatus.D * 2f - SumStatus.P * 3f - SumStatus.A * 1f )/10f);
        SumStatus.MagicAtk = BaseStatus.MagicAtk + AddStatus.MagicAtk + Mathf.FloorToInt((SumStatus.S * 1f + SumStatus.P * 1f + SumStatus.D * 1f + SumStatus.A * 2f + SumStatus.I * 20f)/10f);
        SumStatus.MagicDef = BaseStatus.MagicDef + AddStatus.MagicDef + Mathf.FloorToInt((SumStatus.S * 2f + SumStatus.P * 1f + SumStatus.D * 10f + SumStatus.A * 2f + SumStatus.I * 10f)/10f);
        SumStatus.HPRecoverPerSecond = BaseStatus.HPRecoverPerSecond + AddStatus.HPRecoverPerSecond + Mathf.FloorToInt((SumStatus.P * 8f-SumStatus.S * 1f  - SumStatus.D * 1f + SumStatus.A * 2f - SumStatus.I * 3f)/10f);
        SumStatus.MPRecoverPerSecond = BaseStatus.MPRecoverPerSecond + AddStatus.MPRecoverPerSecond + Mathf.FloorToInt((SumStatus.P * 3f - SumStatus.S * 1f - SumStatus.D * 1f - SumStatus.A * 2f + SumStatus.I * 8f)/10f);

        SumStatus.HP = BaseStatus.HP + AddStatus.HP + Mathf.FloorToInt(SumStatus.S * 2f + SumStatus.P * 8f + SumStatus.D * 3f + SumStatus.A * 3f + SumStatus.I * 1f);
        SumStatus.MP = BaseStatus.MP + AddStatus.MP + Mathf.FloorToInt(SumStatus.S * 1f + SumStatus.P * 2f + SumStatus.D * 2f + SumStatus.A * 2f + SumStatus.I * 10f);

        BaseStatus.AttackSpeed = BaseStatus.AValue / (BaseStatus.AValue + 1000);
        SumStatus.AttackSpeed = SumStatus.AValue/(SumStatus.AValue+1000);
        CurStatus.CurAttackSpeed = CurStatus.CurAttackSpeed / (CurStatus.CurAttackSpeed + 1000);



        SumStatus.Crit = BaseStatus.Crit + AddStatus.Crit;
        SumStatus.CritDamage = BaseStatus.CritDamage + AddStatus.CritDamage;
        SumStatus.Hit = BaseStatus.Hit + AddStatus.Hit;
        SumStatus.Agl = BaseStatus.Agl + AddStatus.Agl;
        SumStatus.Counter = BaseStatus.Counter + AddStatus.Counter;
        SumStatus.Double = BaseStatus.Double + AddStatus.Double;

        CurStatus.CurHP = SumStatus.HP;
        CurStatus.CurMP = SumStatus.MP;
        CurStatus.CurEP = SumStatus.EP;
        CurStatus.CurD = SumStatus.D;
        CurStatus.CurS = SumStatus.S;
        CurStatus.CurI = SumStatus.I;
        CurStatus.CurA = SumStatus.A;
        CurStatus.CurP = SumStatus.P;

        CurStatus.CurHit = SumStatus.Hit;
        CurStatus.CurCritDamage = SumStatus.CritDamage;
        CurStatus.CurCrit = SumStatus.Crit;
        CurStatus.CurAgl = SumStatus.Agl;
        CurStatus.CurCounter = SumStatus.Counter;
        CurStatus.CurDouble = SumStatus.Double;

        CurStatus.CurAtkValue = SumStatus.AtkValue;
        CurStatus.CurDefValue = SumStatus.DefValue;
        CurStatus.CurAValue = SumStatus.AValue;
        CurStatus.CurIValue = SumStatus.IValue;
        CurStatus.CurMagicAtk = SumStatus.MagicAtk;
        CurStatus.CurMagicDef = SumStatus.MagicDef;
        CurStatus.CurHPRecoverPerSecond = SumStatus.HPRecoverPerSecond;
        CurStatus.CurMPRecoverPerSecond = SumStatus.MPRecoverPerSecond;
    }

    void CalculateAttributePointGrowth()
    {
        if (growthPoint.HP > 0)
        {
            attributeGrowth.HP += 2 * growthPoint.HP;

        }
        if (growthPoint.MP > 0)
        {
            attributeGrowth.MP += 2 * growthPoint.MP;
        }
        if (growthPoint.D > 0)
        {
            attributeGrowth.D += 2 * growthPoint.D;

        }
        if (growthPoint.S > 0)
        {
            attributeGrowth.S += 2 * growthPoint.S;

        }
        if (growthPoint.I > 0)
        {
            attributeGrowth.I += 2 * growthPoint.I;
        }
        if (growthPoint.A > 0)
        {
            attributeGrowth.A += 2 * growthPoint.A;

        }
        if (growthPoint.P > 0)
        {
            attributeGrowth.P += 2 * growthPoint.P;
        }
    }

    //检测HP、MP的当前值是否超出规定，每帧调用
    void CheckHPMP()
    {
        if (CurStatus.CurHP >= SumStatus.HP)
        {
            CurStatus.CurHP = SumStatus.HP;
        }
        if (CurStatus.CurMP >= SumStatus.MP)
        {
            CurStatus.CurMP = SumStatus.MP;
        }

        if (CurStatus.CurHP < 0)
        {
            CurStatus.CurHP = 0;
        }
        if (CurStatus.CurMP < 0)
        {
            CurStatus.CurMP = 0;
        }

    }





    //}
    //Save Method
    public void Save()
    {
        PlayerPrefs.SetString("pName", BaseStatus.HeroName);
        PlayerPrefs.SetInt("pLv", BaseStatus.LV);
        PlayerPrefs.SetFloat("pHP", BaseStatus.HP);
        PlayerPrefs.SetFloat("pMP", BaseStatus.MP);
        PlayerPrefs.SetFloat("pEP", BaseStatus.EP);
        PlayerPrefs.SetFloat("pS", BaseStatus.S);
        PlayerPrefs.SetFloat("pP", BaseStatus.P);
        PlayerPrefs.SetFloat("pD", BaseStatus.D);
        PlayerPrefs.SetFloat("pA", BaseStatus.A);
        PlayerPrefs.SetFloat("pI", BaseStatus.I);
        PlayerPrefs.SetFloat("pAtkValue", BaseStatus.AtkValue);
        PlayerPrefs.SetFloat("pDefValue", BaseStatus.DefValue);
        PlayerPrefs.SetFloat("pAValue", BaseStatus.AValue);
        PlayerPrefs.SetFloat("pIValue", BaseStatus.IValue);
        PlayerPrefs.SetFloat("pMagicAtk", BaseStatus.MagicAtk);
        PlayerPrefs.SetFloat("pMagicDef", BaseStatus.MagicDef);
        PlayerPrefs.SetFloat("pComprehension", BaseStatus.Comprehension);
        PlayerPrefs.SetFloat("pluck", BaseStatus.luck);
        PlayerPrefs.SetFloat("pAttackSpeed", BaseStatus.AttackSpeed);
        PlayerPrefs.SetFloat("pExp", BaseStatus.Exp);
        PlayerPrefs.SetFloat("pCrit", BaseStatus.Crit);
        PlayerPrefs.SetFloat("pCritDamage", BaseStatus.CritDamage);
        PlayerPrefs.SetFloat("pHit", BaseStatus.Hit);
        PlayerPrefs.SetFloat("pAgl", BaseStatus.Agl);
        PlayerPrefs.SetFloat("pCounter", BaseStatus.Counter);
        PlayerPrefs.SetFloat("pDouble", BaseStatus.Double);
     
        PlayerPrefs.SetInt("GrowthisAdd", GrowthisAdd ? 1 : 0);

    }

    //Load Method
    public void Load()
    {
        BaseStatus.HeroName =PlayerPrefs.GetString("pName", BaseStatus.HeroName); 
        BaseStatus.LV =PlayerPrefs.GetInt("pLv", BaseStatus.LV);
        BaseStatus.HP =PlayerPrefs.GetFloat("pHP", BaseStatus.HP);
        BaseStatus.MP =PlayerPrefs.GetFloat("pMP", BaseStatus.MP);
        BaseStatus.EP =PlayerPrefs.GetFloat("pEP", BaseStatus.EP);
        BaseStatus.S =PlayerPrefs.GetFloat("pS", BaseStatus.S);
        BaseStatus.P =PlayerPrefs.GetFloat("pP", BaseStatus.P);
        BaseStatus.D =PlayerPrefs.GetFloat("pD", BaseStatus.D);
        BaseStatus.A =PlayerPrefs.GetFloat("pA", BaseStatus.A);
        BaseStatus.I =PlayerPrefs.GetFloat("pI", BaseStatus.I);
        BaseStatus.AtkValue =PlayerPrefs.GetFloat("pAtkValue", BaseStatus.AtkValue);
        BaseStatus.DefValue =PlayerPrefs.GetFloat("pDefValue", BaseStatus.DefValue);
        BaseStatus.AValue =PlayerPrefs.GetFloat("pAValue", BaseStatus.AValue);
        BaseStatus.IValue =PlayerPrefs.GetFloat("pIValue", BaseStatus.IValue);
        BaseStatus.MagicAtk =PlayerPrefs.GetFloat("pMagicAtk", BaseStatus.MagicAtk);
        BaseStatus.MagicDef =PlayerPrefs.GetFloat("pMagicDef", BaseStatus.MagicDef);
        BaseStatus.Comprehension =PlayerPrefs.GetFloat("pComprehension", BaseStatus.Comprehension);
        BaseStatus.luck =PlayerPrefs.GetFloat("pluck", BaseStatus.luck);
        BaseStatus.AttackSpeed =PlayerPrefs.GetFloat("pAttackSpeed", BaseStatus.AttackSpeed);
        BaseStatus.Exp =PlayerPrefs.GetFloat("pExp", BaseStatus.Exp);
        BaseStatus.Crit =PlayerPrefs.GetFloat("pCrit", BaseStatus.Crit);
        BaseStatus.CritDamage =PlayerPrefs.GetFloat("pCritDamage", BaseStatus.CritDamage);
        BaseStatus.Hit =PlayerPrefs.GetFloat("pHit", BaseStatus.Hit);
        BaseStatus.Agl =PlayerPrefs.GetFloat("pAgl", BaseStatus.Agl);
        BaseStatus.Counter =PlayerPrefs.GetFloat("pCounter", BaseStatus.Counter);
        BaseStatus.Double =PlayerPrefs.GetFloat("pDouble", BaseStatus.Double);


  
        GrowthisAdd = PlayerPrefs.GetInt("GrowthisAdd") == 1 ? true : false;

        SettingStatusLoad();

    }

    //Setting Status
    void SettingStatus()
    {
        GrowthisAdd = true;

        CalculateExp();
        CalculateAttributePointGrowth();
        UpdateAttribute();
    }

    //Setting status when load
    void SettingStatusLoad()
    {
       
        CalculateExp();
        CalculateAttributePointGrowth();
        UpdateAttribute();
    }





}

