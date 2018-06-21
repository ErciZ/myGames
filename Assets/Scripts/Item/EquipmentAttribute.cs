using UnityEngine;
using System.Collections;

public class EquipmentAttribute : MonoBehaviour {


    //private static Equipment instance;
    //public static Equipment Instance
    //{
    //    get
    //    {
    //        if (null == instance)
    //            instance = new Equipment();
    //        return instance;
    //    }
    //    set { }
    //}
    public int ID ;
    public string Name ;
    public string Type ;
    public string Quality ;
    public string Description ;
    public int Capacity ;
    public int BuyPrice ;
    public int SellPrice ;
    public string Sprite ;
    public float requiredS;
    public float requiredP;
    public float requiredD ;
    public float requiredA ;
    public float requiredI ;
    public float HP ;
    public float MP ;
    public float S ;
    public float P ;
    public float D ;
    public float A ;
    public float I ;
    public float AtkValue ;
    public float DefValue ;
    public float AValue ;
    public float IValue ;
    public float MagicAtk ;
    public float MagicDef ;
    public float Comprehension ;
    public float Luck ;
    public float AttackSpeed ;
    public float Exp ;
    public float Crit ;
    public float CritDamage ;
    public float Hit ;
    public float Agl ;
    public float Counter ;
    public float Double ;
    public float HPRecoverPerSecond ;
    public float MPRecoverPerSecond ;
    public float stamina ;//耐久度
    public string EquipType ;

    //public Equipment(int id, string name, string type, string quality, string description, int capacity, int buyPrice, int sellPrice,string sprite,
    //                 float HP,float MP,float EP,float S,float P,float D,float A, float I, float AtkValue,float DefValue,float AValue,float IValue,float MagicAtk,float MagicDef,float Comprehension,float luck,
    //                 float  AttackSpeed,float Exp,float Crit,float CritDamage,float Hit,float Agl,float Counter,float Double,float HPRecoverPerSecond,float MPRecoverPerSecond,int stamina,string equipType,float requiredS,float requiredP,float requiredD,float requiredA,float requiredI)
    //    : base(id, name, type, quality, description, capacity, buyPrice, sellPrice,sprite)
    //{
    //    this.HP = HP;
    //    this.MP = MP;
    //    this.S = S;
    //    this.P = P;
    //    this.D = D;
    //    this.A = A;
    //    this.I = I;
    //    this.AtkValue = AtkValue;
    //    this.DefValue = DefValue;
    //    this.AValue = AValue;
    //    this.IValue = IValue;
    //    this.MagicAtk = MagicAtk;
    //    this.MagicDef = MagicDef;
    //    this.Comprehension = Comprehension;
    //    this.Luck = Luck;
    //    this.AttackSpeed = AttackSpeed;
    //    this.stamina = stamina;
    //    this.Crit = Crit;
    //    this.CritDamage = CritDamage;
    //    this.Hit = Hit;
    //    this.Agl = Agl;
    //    this.Counter = Counter;
    //    this.Double = Double;
    //    this.HPRecoverPerSecond = HPRecoverPerSecond;
    //    this.MPRecoverPerSecond = MPRecoverPerSecond;
    //    this.Exp = Exp;
    //    this.EquipType = equipType;
    //    this.requiredS = requiredS;
    //    this.requiredP = requiredP;
    //    this.requiredD = requiredD;
    //    this.requiredA = requiredA;
    //    this.requiredI = requiredI;
    //}

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
