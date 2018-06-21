using UnityEngine;
using System.Collections;

public class equipments : DataType
{



	public int equipmentID { get; set; }
	public string Name { get; set; }
	public string Type { get; set; }
	public string Quality { get; set; }
	public string Description { get; set; }
	public int Capacity { get; set; }
	public int BuyPrice { get; set; }
	public int SellPrice { get; set; }
	public string icon { get; set; }
	public float requiredS { get; set; }
	public float requiredP { get; set; }
	public float requiredD { get; set; }
	public float requiredA { get; set; }
	public float requiredI { get; set; }
	public float HP { get; set; }
	public float MP { get; set; }
	public float S { get; set; }
	public float P { get; set; }
	public float D { get; set; }
	public float A { get; set; }
	public float I { get; set; }
	public float AtkValue { get; set; }
	public float DefValue { get; set; }
	public float AValue { get; set; }
	public float MagicAtk { get; set; }
	public float MagicDef { get; set; }
	public float Comprehension { get; set; }
	public float Luck { get; set; }
	public float AttackSpeed { get; set; }
	public float Crit { get; set; }
	public float CritDamage { get; set; }
	public float Hit { get; set; }
	public float Agl { get; set; }
	public float HPRecoverPerSecond { get; set; }
	public float MPRecoverPerSecond { get; set; }
	public float stamina { get; set; }//耐久度
	public string EquipType { get; set; }
	public string skill { get; set; }

	public equipments(int _equipmentID,
	                  string _Name,
	                  string _Type,
	                  string _Quality,
	                  string _Description,
	                  int _Capacity,
	                  int _BuyPrice,
	                  int _SellPrice,
	                  string _icon,
					  float _HP,
					  float _MP,
					  float _EP,
					  float _S,
					  float _P,
					  float _D,
					  float _A,
					  float _I,
					  float _AtkValue,
					  float _DefValue,
					  float _AValue,
					  float _MagicAtk,
					  float _MagicDef,
					  float _Comprehension,
	                  float _Luck,
					  float _AttackSpeed,
					  float _Crit,
					  float _CritDamage,
					  float _Hit,
					  float _Agl,
					  float _HPRecoverPerSecond,
					  float _MPRecoverPerSecond,
					  int _stamina,
	                  string _EquipType,
					  float _requiredS,
					  float _requiredP,
					  float _requiredD,
					  float _requiredA,
					  float _requiredI,
	                  string _skill)

	{
		equipmentID = _equipmentID;
		Name = _Name;
		Type = _Type;
		Quality = _Quality;
		Description = _Description;
		Capacity = _Capacity;
		BuyPrice = _BuyPrice;
		SellPrice = _SellPrice;
		icon = _icon;
		requiredS = _requiredS;
		requiredP = _requiredP;
		requiredD = _requiredD;
		requiredA = _requiredA;
		requiredI = _requiredI;
		HP = _HP;
		MP = _MP;
		S = _S;
		P = _P;
		D = _D;
		A = _A;
		I = _I;
		AtkValue = _AtkValue;
		DefValue = _DefValue;
		AValue = _AValue;
		MagicAtk = _MagicAtk;
		MagicDef = _MagicDef;
		Comprehension = _Comprehension;
		Luck = _Luck;
		AttackSpeed = _AttackSpeed;
		Crit = _Crit;
		CritDamage = _CritDamage;
		Hit = _Hit;
		Agl = _Agl;
		HPRecoverPerSecond = _HPRecoverPerSecond;
		MPRecoverPerSecond = _MPRecoverPerSecond;
		stamina = _stamina;//耐久度
		EquipType = _EquipType;
		skill=_skill;
	}
	public equipments()
    {
    }

    //public enum EquipmentType
    //{
    //    None,
    //    weapon,
    //    Head,//头部
    //    Neck,//脖子
    //    Chest,//胸部
    //    Ring,//戒指
    //    Leg,//腿部
    //    Bracer,//护腕
    //    Boots,//靴子
    //    Shoulder,//护肩
    //    Belt,//腰带
    //    OffHand//副手
    //}
    //重写父类的GetToolTipText
    //   public override string GetToolTipText()
    //   {
    //       string text = base.GetToolTipText();

    //       string equipTypeText = "";
    //       switch (EquipType)
    //{
    //  case EquipmentType.Head:
    //               equipTypeText="头部";
    //        break;
    //       case EquipmentType.Neck:
    //               equipTypeText="脖子";
    //        break;
    //       case EquipmentType.Chest:
    //               equipTypeText="胸部";
    //        break;
    //       case EquipmentType.Ring:
    //               equipTypeText="戒指";
    //        break;
    //       case EquipmentType.Leg:
    //               equipTypeText="腿部";
    //        break;
    //       case EquipmentType.Bracer:
    //               equipTypeText="护腕";
    //        break;
    //       case EquipmentType.Boots:
    //               equipTypeText="靴子";
    //        break;
    //       case EquipmentType.Shoulder:
    //               equipTypeText="护肩";
    //        break;
    //       case EquipmentType.Belt:
    //               equipTypeText = "腰带";
    //        break;
    //       case EquipmentType.OffHand:
    //               equipTypeText="副手";
    //        break;
    //}

    //    string newText = Description;

    //    return newText;
    //}
}
