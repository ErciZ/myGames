using System.Xml; //引用命名空间
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


public class XmlHandler : MonoBehaviour
{
	 
	public GameDataAccess Data = new GameDataAccess();

	public bool condition = true;
	//private void Awake()
	//{
	//	LoadXml<activeskill>("XML Files", Data);
	//       setSkill();
	//}
	private void Awake()
	{
		LoadXml<activeskill>("XML Files", Data);
        LoadXml<EnemyBaseAttribute>("XML Files", Data);
		LoadXml<equipments>("XML Files", Data);

	}
	void Start()
    {
		//Xdoc = new XmlDocument();  //实例化
		//Debug.Log("当前目录是：" + Application.dataPath);
		//Xdoc.Load(Application.dataPath + "/123.xml");  //加载XML 文件

		//XmlElement root = Xdoc.DocumentElement;   //获取跟节点
		//Debug.Log("根元素是：" + root.Name);

		//XmlNode dataNode = root.SelectSingleNode("activeskill");  //获取根节点下的子节点
		//Debug.Log("节点名称" + dataNode.Name);

		//foreach (XmlNode node in dataNode.ChildNodes)
		//{
		//    string id = node.Attributes["skillId"].Value;
		//    string lang = node.Attributes["skillName"].Value;
		//    string id = node.SelectSingleNode("skillId").InnerText;
		//    string name = node.SelectSingleNode("skillName").InnerText;
		//    string description = node.SelectSingleNode("Description").InnerText;

		//    Debug.Log("skillId:" + id + " skillName:" + name + " description:" + description );
		//}
		//for (int i = 0; i < dataNode.ChildNodes.Count; i++)
		//{

		//    Debug.Log("文本内容：" + dataNode.ChildNodes[i].InnerText);
		//    string description = dataNode.SelectSingleNode("Description").InnerText;
		//    //Debug.Log( " description:" + description);


		//}

		//Dictionary<int, Skill.ActiveSkillAttack> skills = new Dictionary<int, Skill.ActiveSkillAttack>();
		//List<Skill.ActiveSkillAttack> allskill = new List<Skill.ActiveSkillAttack>();

		//foreach (XmlNode node in root)
		//{

		//    //string id = node.Attributes["id"].Value;
		//    //string name = node.Attributes["name"].Value;
		//    Skill.ActiveSkillAttack item = new Skill.ActiveSkillAttack();
		//    //item.C1.skillID = node.SelectSingleNode("skillId").InnerText;
		//    //string a = node.SelectSingleNode("skillName").InnerText;
		//    //Debug.Log("skillId:" + id + " skillName:" + name+"aaaa:"+a);
		//    //Debug.Log(item.);
		//    item.skillName=node.SelectSingleNode("skillName").InnerText;

		//    //Debug.Log("skillId:" + id + " skillName:" + name );
		//    Debug.Log(item.skillName);

		//    allskill.Add(item);

		//}

		//Data.AddDataMap<Skill.ActiveSkillAttack>(allskill);
		//Data.AddDataMap<Skill.ActiveSkillAttack>(skills);
		////Data.AddDataMap<Skill.ActiveSkillAttack>(allskill);

		//WriteTest();
		//ReadTest();
		//WriteTest();
		//WriteTest2();
  //      LoadXml<activeskill>("XML Files", Data);
		//LoadXml<EnemyBaseAttribute>("XML Files", Data);
		setSkill();
		setEquipOn();
		//activeskill type = Data.GetData<activeskill>(20006);
		//EnemyBaseAttribute type1 = Data.GetData<EnemyBaseAttribute>(5);
		//equipments type1 = Data.GetData<equipments>(31001);
		//Debug.Log(type1.Description);
		//Debug.Log(type1.EnemyName);

		//Debug.Log(type.skillPower);

		getEnemyStatus(1);
		Inventory.instance.HasEquipAttribute();



    }
	void Update()
    {
        if (TurnControl.instance.currentState == TurnControl.GameState.Over)
        {
            if (condition)
            {

				int x = randomEnemy();
                getEnemyStatus(x);
                condition = false;

            }


        }
        else if (TurnControl.instance.currentState == TurnControl.GameState.Game)
        {

            condition = true;
        }
        //Debug.Log(isEnd);
    }


	public int randomEnemy()
    {
        int x = Random.Range(1, 7);
        return x;
    }

	void getEnemyStatus(int x){
		EnemyBaseAttribute enemy = Data.GetData<EnemyBaseAttribute>(x);

		EnemyStatus.instance.BaseStatus.EnemyName = enemy.EnemyName;
		EnemyStatus.instance.BaseStatus.EnemyId = enemy.EnemyId;
		EnemyStatus.instance.BaseStatus.expGive = enemy.expGive;
		EnemyStatus.instance.BaseStatus.LV = enemy.LV;
		EnemyStatus.instance.BaseStatus.HP = enemy.HP;
		EnemyStatus.instance.BaseStatus.MP = enemy.MP;
		EnemyStatus.instance.BaseStatus.S = enemy.S;
		EnemyStatus.instance.BaseStatus.P = enemy.P;
		EnemyStatus.instance.BaseStatus.D = enemy.D;
		EnemyStatus.instance.BaseStatus.A = enemy.A;
		EnemyStatus.instance.BaseStatus.I = enemy.I;
		EnemyStatus.instance.BaseStatus.AtkValue = enemy.AtkValue;
		EnemyStatus.instance.BaseStatus.DefValue = enemy.DefValue;
		EnemyStatus.instance.BaseStatus.AValue = enemy.AValue;
		EnemyStatus.instance.BaseStatus.MagicAtk = enemy.MagicAtk;
		EnemyStatus.instance.BaseStatus.MagicDef = enemy.MagicDef;
		EnemyStatus.instance.BaseStatus.AttackSpeed = enemy.AttackSpeed;
		EnemyStatus.instance.BaseStatus.Exp = enemy.Exp;
		EnemyStatus.instance.BaseStatus.Crit = enemy.Crit;
		EnemyStatus.instance.BaseStatus.CritDamage = enemy.CritDamage;
		EnemyStatus.instance.BaseStatus.Hit = enemy.Hit;
		EnemyStatus.instance.BaseStatus.Agl = enemy.Agl;
		//EnemyStatus.instance.use_activeSkillAttack = enemy.use_activeSkillAttack;
		EnemyStatus.instance.BaseStatus.HPRecoverPerSecond = enemy.HPRecoverPerSecond;
		EnemyStatus.instance.BaseStatus.MPRecoverPerSecond = enemy.MPRecoverPerSecond;
		setSkill_enemy(enemy.use_activeSkillAttack);
        


	}

    void WriteTest()
    {
        //Skill1 demo = new Skill1(100, "ABC");

        List<activeskill> activeskill = new List<activeskill>();
        activeskill a = new activeskill();

        //demo.activeskill = activeskill;
        a.skillName= "激怒";
        a.skillID = 55555;
        
        activeskill.Add(a);

        //demo.activeskill[0] = new activeskill();
        //demo.activeskill[0].skillName = "激怒";
        //demo.activeskill[0].skillID = 30001;
        //activeskill skill123 = new activeskill();
        //skill123.skillName = "激怒";
        FileStream fs = new FileStream(Application.dataPath +"/222.xml", FileMode.OpenOrCreate);
        //XmlSerializer xml = new XmlSerializer(typeof(Skill1));
        XmlSerializer xml = new XmlSerializer(typeof(List<activeskill>));
		//Debug.Log(a.Id);

 

        xml.Serialize(fs, activeskill);
        //xml.Serialize(fs, demo);
        //xml.Serialize(fs,skill123);
        fs.Close();
        Debug.LogError("write done");
    }
	void WriteTest1()
    {
        //Skill1 demo = new Skill1(100, "ABC");

		List<EnemyBaseAttribute> EnemyBaseAttribute = new List<EnemyBaseAttribute>();
		EnemyBaseAttribute a = new EnemyBaseAttribute();

		a.EnemyName = "趴趴熊";
		a.EnemyId = 1;
		a.use_activeSkillAttack = "0000";
		EnemyBaseAttribute.Add(a);
        
        FileStream fs = new FileStream(Application.dataPath + "/222.xml", FileMode.OpenOrCreate);
		XmlSerializer xml = new XmlSerializer(typeof(List<EnemyBaseAttribute>));
      
		xml.Serialize(fs, EnemyBaseAttribute);
        fs.Close();
        Debug.LogError("write done");
    }
	void WriteTest2()
    {
        //Skill1 demo = new Skill1(100, "ABC");

		List<equipments> equipments = new List<equipments>();
		equipments a = new equipments();

		a.Name = "镇魂石";
		a.Id = 123456;
		a.icon = "10001";
		//a.Type = "weapon";
		a.EquipType = "weapon";
		a.Quality = "Normal";
		a.Description="无敌";
		a.skill = "20001";
		equipments.Add(a);

        FileStream fs = new FileStream(Application.dataPath + "/222.xml", FileMode.OpenOrCreate);
		XmlSerializer xml = new XmlSerializer(typeof(List<equipments>));

		xml.Serialize(fs, equipments);
        fs.Close();
        Debug.LogError("write done");
    }

    void ReadTest()
    {
        FileStream fs = new FileStream(Application.dataPath + "/123.xml", FileMode.Open);
        XmlSerializer bf = new XmlSerializer(typeof(Skill1));
        Skill1 demo = bf.Deserialize(fs) as Skill1;
        //Debug.Log(demo.id);
        fs.Close();
        demo.Output();
    }

    public void LoadXml<T>(string folderPath, GameDataAccess access) where T : DataType
    {
        //Debug.Log(string.Format("{0}/{1}", folderPath, typeof(T).ToString()));
        TextAsset ta = Resources.Load<TextAsset>(string.Format("{0}/{1}", folderPath, typeof(T).ToString()));
        //TextAsset ta = Resources.Load<TextAsset>(Application.dataPath + "/123");
        //FileStream ta = new FileStream(Application.dataPath + "/123.xml", FileMode.Open);
        //Debug.Log("3333");
        //Debug.Log(ta);
        if (ta != null)
        {
            using (MemoryStream ms = new MemoryStream(ta.bytes))
            {
                //Debug.Log("1111");
                XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                List<T> data = xs.Deserialize(ms) as List<T>;
				//Debug.Log(data);
                //Debug.Log(data.Count);
                //Debug.Log(data[0].Id);
                if (data !=null){
                    //Debug.Log("2222");
					//Debug.Log(access._allData.Count);
					//access.AddDataMap<T>(data);
					access.AddDataMap<T>(data);
					//access.AddDataMap<activeskill>(data);
                    //access.AddDataMap<T>(data);
                }
            }
        }
        //ta.Close();
    }


	//把读取到的使用技能写入列表
    void setSkill()
    {
		PlayerControl.instance.normalAtk = Data.GetData<activeskill>(20000);
        for (int i = 0; i < 7; i++)
        {
			int x =  HeroStatus.instance.use_activeSkillAttack[i];
			if (x==0){
				//activeskill thisSkill = Data.GetData<activeskill>(x);
				HeroStatus.instance.used_activeskill.Add(PlayerControl.instance.normalAtk);
			}
			else{
				activeskill thisSkill = Data.GetData<activeskill>(x);
                HeroStatus.instance.used_activeskill.Add(thisSkill);
			}         
        }      
    }
	//把读取到的使用技能写入列表
    void setSkill_enemy(string str)
	{
		List<string> use_activeSkillAttack = new List<string>(str.Split(','));//或者
		//EnemyStatus.instance.use_activeSkillAttack = str.Split(',');
		//Debug.Log(use_activeSkillAttack[0]);
		for (int i = 0; i < 7;i++){
			EnemyStatus.instance.use_activeSkillAttack[i] = int.Parse(use_activeSkillAttack[i]);
			//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[i]);
		}
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[0]==20004);
		//EnemyStatus.instance.use_activeSkillAttack = use_activeSkillAttack;
		EnemyControl.instance.normalAtk = Data.GetData<activeskill>(20000);
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[0]);
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[1]);
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[2]);
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[3]);
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[4]);
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[5]);
		//Debug.Log(EnemyStatus.instance.use_activeSkillAttack[6]);
        for (int i = 0; i < 7; i++)
        {
			int x = EnemyStatus.instance.use_activeSkillAttack[i];
            if (x == 0)
            {
                //activeskill thisSkill = Data.GetData<activeskill>(x);
				EnemyStatus.instance.used_activeskill.Add(EnemyControl.instance.normalAtk);
            }
            else
            {
                activeskill thisSkill = Data.GetData<activeskill>(x);
				//Debug.Log(thisSkill.skillName);
				EnemyStatus.instance.used_activeskill.Add(thisSkill);
            }
        }
		//Debug.Log(EnemyStatus.instance.used_activeskill[0].skillName);
    }


	void setEquipOn(){
		HeroStatus.instance.noEquip = Data.GetData<equipments>(30000);
        for (int i = 0; i < 5; i++)
        {
			int x =  HeroStatus.instance.equiped_armor[i];
            if (x==0){
                //activeskill thisSkill = Data.GetData<activeskill>(x);
				HeroStatus.instance.equip_on.Add(HeroStatus.instance.noEquip);
            }
            else{
				equipments thisEquip = Data.GetData<equipments>(x);
				HeroStatus.instance.equip_on.Add(thisEquip);
            }         
        }
		//Debug.Log(HeroStatus.instance.equip_on[0]);
		//Debug.Log(HeroStatus.instance.equip_on[1]);
		//Debug.Log(HeroStatus.instance.equip_on[2]);
		//Debug.Log(HeroStatus.instance.equip_on[3]);
		//Debug.Log(HeroStatus.instance.equip_on[4]);

	}
}
