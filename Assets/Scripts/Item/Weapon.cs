//using UnityEngine;
//using System.Collections;

///// <summary>
///// 武器
///// </summary>
//public class Weapon : Item {

//    public float HP { get; set; }
//    public float MP { get; set; }
//    public float S { get; set; }
//    public float P { get; set; }
//    public float D { get; set; }
//    public float A { get; set; }
//    public float I { get; set; }
//    public float AtkValue { get; set; }
//    public float DefValue { get; set; }
//    public float AValue { get; set; }
//    public float IValue { get; set; }
//    public float MagicAtk { get; set; }
//    public float MagicDef { get; set; }
//    public float Comprehension { get; set; }
//    public float Luck { get; set; }
//    public float AttackSpeed { get; set; }
//    public float Exp { get; set; }
//    public float Crit { get; set; }
//    public float CritDamage { get; set; }
//    public float Hit { get; set; }
//    public float Agl { get; set; }
//    public float Counter { get; set; }
//    public float Double { get; set; }
//    public float HPRecoverPerSecond { get; set; }
//    public float MPRecoverPerSecond { get; set; }
//    public float stamina { get; set; }//耐久度
//    public WeaponType WpType { get; set; }

//    public Weapon(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice, string sprite,
//                     float HP, float MP, float EP, float S, float P, float D, float A, float I, float AtkValue, float DefValue, float AValue, float IValue, float MagicAtk, float MagicDef, float Comprehension, float luck,
//                     float AttackSpeed, float Exp, float Crit, float CritDamage, float Hit, float Agl, float Counter, float Double, float HPRecoverPerSecond, float MPRecoverPerSecond, int stamina, WeaponType wpType)
//        : base(id, name, type, quality, des, capacity, buyPrice, sellPrice,sprite)
//    {
//        this.HP = HP;
//        this.MP = MP;
//        this.S = S;
//        this.P = P;
//        this.D = D;
//        this.A = A;
//        this.I = I;
//        this.AtkValue = AtkValue;
//        this.DefValue = DefValue;
//        this.AValue = AValue;
//        this.IValue = IValue;
//        this.MagicAtk = MagicAtk;
//        this.MagicDef = MagicDef;
//        this.Comprehension = Comprehension;
//        this.Luck = Luck;
//        this.AttackSpeed = AttackSpeed;
//        this.Exp = stamina;
//        this.Crit = Crit;
//        this.CritDamage = CritDamage;
//        this.Hit = Hit;
//        this.Agl = Agl;
//        this.Counter = Counter;
//        this.Double = Double;
//        this.HPRecoverPerSecond = HPRecoverPerSecond;
//        this.MPRecoverPerSecond = MPRecoverPerSecond;
//        this.stamina = stamina;
//        this.WpType = wpType;


//    }

//    public enum WeaponType
//    {
//        None,
//        OffHand,
//        MainHand
//    }

//    //重写GetToolTipText()

//    public override string GetToolTipText()
//    {
//        string text = base.GetToolTipText();

//        string wpTypeText = "";

//        switch (WpType)
//        {
//            case WeaponType.OffHand:
//                wpTypeText = "副手";
//                break;
//            case WeaponType.MainHand:
//                wpTypeText = "主手";
//                break;
//        }

//        string newText = Description;

//        return newText;
//    }


//        public Weapon(Item item,  WeaponType weaponType)
//        {
//            this.ID = item.ID;
//            this.Name = item.Name;
//            this.Type = item.Type;
//            this.Quality = item.Quality;
//            this.Description = item.Description;
//            this.Capacity = item.Capacity;
//            this.BuyPrice = item.BuyPrice;
//            this.SellPrice = item.SellPrice;
//            this.Sprite = item.Sprite;


//            this.WpType = weaponType;
//        }
//}
