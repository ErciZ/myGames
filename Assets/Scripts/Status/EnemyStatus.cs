using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class EnemyStatus : MonoBehaviour
{


    public static EnemyStatus instance;

    //各类的实例对象：
    public BaseAttribute BaseStatus;
    public AdditionAttribute AddStatus;
    public CurAttribute CurStatus;
    public SumAttribute SumStatus;

    public AttributeGrowth attributeGrowth, growthPoint;

    public bool GrowthisAdd = true;
    //定义各种速度：

    //private bool checkStatus;

    //private EnemySkills playerSkill;
    public List<PlayerSkill.PassiveSkill> have_passiveSkill = new List<PlayerSkill.PassiveSkill>();  //Passive skill
    public List<PlayerSkill.ActiveSkillAttack> have_activeSkillAttack = new List<PlayerSkill.ActiveSkillAttack>(); //Active Attack Skill
    public List<PlayerSkill.ActiveSkillBuff> have_activeSkillBuff = new List<PlayerSkill.ActiveSkillBuff>(); //Buff Skill

    //拥有技能的id和等级



	public int[] use_activeSkillAttack = new int[7] { 20000, 20000, 20000, 20000, 20000, 20000, 20000 };
    public List<activeskill> used_activeskill = new List<activeskill>();








    [System.Serializable]
    public class BaseAttribute
    {
        //等级
        public int EnemyId;
        public string EnemyName; //Hero name
        public float expGive;
        public int LV;
        /// <summary>
        ///血量，魔量 
        /// </summary>
        public float HP, MP;
        /// <summary>
        ///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御,悟性，福缘
        public float S, P, D, A, I;
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
    public class AdditionAttribute
    {
        /// <summary>
        ///血量，魔量 ,精力
        /// </summary>
        public float HP, MP;
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
        public float CurHP, CurMP;
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
        public float HP, MP;
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
        public float HP, MP;
        public float S, P, D, A, I;
    }
    private void Awake()
    {
        instance = this;

        UpdateAttribute();
    }
    void Update()
    {
        CheckHPMP();
    }

    //检测HP、MP的当前值是否超出规定，每帧调用
    void CheckHPMP()
    {

        if (CurStatus.CurHP < 0)
        {
            CurStatus.CurHP = 0;
        }
        if (CurStatus.CurMP < 0)
        {
            CurStatus.CurMP = 0;
        }
        if (CurStatus.CurHP >= SumStatus.HP)
        {
            CurStatus.CurHP = SumStatus.HP;
        }
        if (CurStatus.CurMP >= SumStatus.MP)
        {
            CurStatus.CurMP = SumStatus.MP;
        }
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
    public void UpdateAttribute()
    {
        if (!GrowthisAdd)
        //S, P, D, A, I
        {
            CalculateAttributePointGrowth();
            BaseStatus.HP += attributeGrowth.HP;
            BaseStatus.MP += attributeGrowth.MP;

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
        SumStatus.D = BaseStatus.D + AddStatus.D;

        SumStatus.AtkValue = BaseStatus.AtkValue + AddStatus.AtkValue + Mathf.FloorToInt((SumStatus.S * 20f + SumStatus.P * 1f + SumStatus.D * 2f + SumStatus.A * 2f + SumStatus.I * 1f) / 10f);
        SumStatus.DefValue = BaseStatus.DefValue + AddStatus.DefValue + Mathf.FloorToInt((SumStatus.S * 2f + SumStatus.P * 1f + SumStatus.D * 20f + SumStatus.A * 2f + SumStatus.I * 1f) / 10f);
        SumStatus.AValue = BaseStatus.AValue + AddStatus.AValue + Mathf.FloorToInt((SumStatus.S * 2f + SumStatus.P * 1f + SumStatus.D * 2f + SumStatus.A * 20f + SumStatus.I * 1f) / 10f);
        SumStatus.IValue = BaseStatus.IValue + AddStatus.IValue + Mathf.FloorToInt((SumStatus.I * 8f - SumStatus.S * 1f + SumStatus.D * 2f - SumStatus.P * 3f - SumStatus.A * 1f) / 10f);
        SumStatus.MagicAtk = BaseStatus.MagicAtk + AddStatus.MagicAtk + Mathf.FloorToInt((SumStatus.S * 1f + SumStatus.P * 1f + SumStatus.D * 1f + SumStatus.A * 2f + SumStatus.I * 20f) / 10f);
        SumStatus.MagicDef = BaseStatus.MagicDef + AddStatus.MagicDef + Mathf.FloorToInt((SumStatus.S * 2f + SumStatus.P * 1f + SumStatus.D * 10f + SumStatus.A * 2f + SumStatus.I * 10f) / 10f);
        SumStatus.HPRecoverPerSecond = BaseStatus.HPRecoverPerSecond + AddStatus.HPRecoverPerSecond + Mathf.FloorToInt((SumStatus.P * 8f - SumStatus.S * 1f - SumStatus.D * 1f + SumStatus.A * 2f - SumStatus.I * 3f) / 10f);
        SumStatus.MPRecoverPerSecond = BaseStatus.MPRecoverPerSecond + AddStatus.MPRecoverPerSecond + Mathf.FloorToInt((SumStatus.P * 3f - SumStatus.S * 1f - SumStatus.D * 1f - SumStatus.A * 2f + SumStatus.I * 8f) / 10f);

        SumStatus.HP = BaseStatus.HP + AddStatus.HP + Mathf.FloorToInt(SumStatus.S * 2f + SumStatus.P * 8f + SumStatus.D * 3f + SumStatus.A * 3f + SumStatus.I * 1f);
        SumStatus.MP = BaseStatus.MP + AddStatus.MP + Mathf.FloorToInt(SumStatus.S * 1f + SumStatus.P * 2f + SumStatus.D * 2f + SumStatus.A * 2f + SumStatus.I * 10f);

        BaseStatus.AttackSpeed = BaseStatus.AValue / (BaseStatus.AValue + 1000);
        SumStatus.AttackSpeed = SumStatus.AValue / (SumStatus.AValue + 1000);
        CurStatus.CurAttackSpeed = CurStatus.CurAttackSpeed / (CurStatus.CurAttackSpeed + 1000);



        SumStatus.Crit = BaseStatus.Crit + AddStatus.Crit;
        SumStatus.CritDamage = BaseStatus.CritDamage + AddStatus.CritDamage;
        SumStatus.Hit = BaseStatus.Hit + AddStatus.Hit;
        SumStatus.Agl = BaseStatus.Agl + AddStatus.Agl;
        SumStatus.Counter = BaseStatus.Counter + AddStatus.Counter;
        SumStatus.Double = BaseStatus.Double + AddStatus.Double;

        CurStatus.CurHP = SumStatus.HP;
        CurStatus.CurMP = SumStatus.MP;
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


}
