using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml; //引用命名空间
using System.IO;
using System.Xml.Serialization;



[SerializeField]
public class EnemyBaseAttribute : DataType
{
	//等级
	public int EnemyId { get; set; }
	public string EnemyName { get; set; } //Hero name
	public float expGive { get; set; }
	public int LV { get; set; }
	public float HP { get; set; }
	public float MP { get; set; }
	/// <summary>
	///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御,悟性，福缘
	public float S { get; set; }
	public float P { get; set; }
	public float D { get; set; }
	public float A { get; set; }
	public float I { get; set; }
	/// </summary>
	public float AtkValue { get; set; }
	public float DefValue { get; set; }
	public float AValue { get; set; }

	public float MagicAtk { get; set; }
	public float MagicDef { get; set; }
	/// <summary>
	/// 攻击速度，经验值，暴击概率,暴击伤害百分比，命中，闪避，反击，连击；
	/// </summary>
	public float AttackSpeed { get; set; }
	public float Exp { get; set; }
	public float Crit { get; set; }
	public float CritDamage { get; set; }
	public float Hit { get; set; }
	public float Agl { get; set; }
	public string  use_activeSkillAttack { get; set; }

	public float HPRecoverPerSecond { get; set; }
	public float MPRecoverPerSecond { get; set; }

	public EnemyBaseAttribute(
		 //int _id,

		 //string myName, 
		 int _EnemyId,
		string _EnemyName, //Hero name
		float _expGive,
		int _LV,
		float _HP,
		float _MP,
		 /// <summary>
		 ///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御,悟性，福缘
		float _S,
		float _P,
		float _D,
		float _A,
		float _I,
		 /// </summary>
		float _AtkValue,
		float _DefValue,
		float _AValue,

		float _MagicAtk,
		float _MagicDef,
		 /// <summary>
		 /// 攻击速度，经验值，暴击概率,暴击伤害百分比，命中，闪避，反击，连击；
		 /// </summary>
		float _AttackSpeed,
		float _Exp,
		float _Crit,
		float _CritDamage,
		float _Hit,
		float _Agl,


		float _HPRecoverPerSecond,
		float _MPRecoverPerSecond,
		string _use_activeSkillAttack
	)
	{
		EnemyId = _EnemyId;

		EnemyName= _EnemyName;//Hero name

		expGive= _expGive;

		LV= _LV;

		HP= _HP;

		MP= _MP;
         /// <summary>
         ///攻击力， 防御力，敏捷，精神，魔法攻击，魔法防御,悟性，福缘
		S= _S;

		P= _P;

		D= _D;

		A= _A;

		I= _I;
         /// </summary>
		AtkValue= _AtkValue;

		DefValue= _DefValue;

		AValue= _AValue;


		MagicAtk= _MagicAtk;

		MagicDef= _MagicDef;
         /// <summary>
         /// 攻击速度，经验值，暴击概率,暴击伤害百分比，命中，闪避，反击，连击；
         /// </summary>
		AttackSpeed= _AttackSpeed;

		Exp= _Exp;

		Crit= _Crit;

		CritDamage= _CritDamage;

		Hit= _Hit;

		Agl= _Agl;

		use_activeSkillAttack = _use_activeSkillAttack;

		HPRecoverPerSecond= _HPRecoverPerSecond;

		MPRecoverPerSecond= _MPRecoverPerSecond;
		setId(EnemyId);

	}

	public EnemyBaseAttribute()
    {
		setId(EnemyId);
    }
    public void Output()
    {
        //Debug.Log(id);
        //Debug.Log(myName);
        //Debug.Log(skillID);
        //Debug.Log(skillName);
        //Debug.LogError(skillID);
        //Debug.LogError(skillName);
        //Debug.LogError(id);
        //Debug.LogError(myName);
    }


}





