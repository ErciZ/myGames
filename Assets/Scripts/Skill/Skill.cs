/// <summary>
/// Player skill.
/// This script use for create a hero skill
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill : DataType
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
    public class PassiveSkill: DataType
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
    public class ActiveSkillAttack: DataType
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
    public class ActiveSkillBuff: DataType
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





}
