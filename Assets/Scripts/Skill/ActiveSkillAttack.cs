using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml; //引用命名空间
using System.IO;
using System.Xml.Serialization;

[SerializeField]
public class activeskill :DataType
{
    //public int id;
    //public string myName;
    //[XmlAttribute]
   


    public int isRecover { get; set; }
    public string skillName { get; set; }
    public int skillID { get; set; }
    public int skillLv { get; set; }
    public float skillLvGrowth { get; set; }
    public string skillIcon { get; set; }
    public int mpUse { get; set; }
    public float baseDam { get; set; }
    public string addAttribute { get; set; }
    public float addValue { get; set; }
    public float multipleDamage { get; set; }
    public string description { get; set; }
    public string typeSkill { get; set; }
    public string damageType { get; set; }
    //public bool speedTuning;
    public float skillPower { get; set; }
    public float cd { get; set; }
    public float cd_check { get; set; }
    public bool isAdd { get; set; }
    [HideInInspector]
    public float castTimer { get; set; }

	//[NoSerialized]
	public CountDownTimer cdCount;


    


    public activeskill(
        //int _id,
        
        //string myName, 
        int _isRecover,
        string _skillName,
        int _skillID ,
        int _skillLv,
        float _skillLvGrowth,
        int _unlockLevel,
        string _skillIcon,
        int _MPUse,
        float _baseDam,
        string _addAttribute,
        float _addValue,
        float _multipleDamage ,
        string _description  ,
        string _typeSkill  ,
        string _damageType ,
        float _skillPower,
        float _cd)
    {
        isRecover= _isRecover;
        skillName= _skillName;
        skillID= _skillID;
        skillLv= _skillLv;
        skillLvGrowth= _skillLvGrowth;
        skillIcon= _skillIcon;
        baseDam= _baseDam;
        addAttribute= _addAttribute;
        addValue= _addValue;
        multipleDamage= _multipleDamage;
        description= _description;
        typeSkill= _typeSkill;
        damageType= _damageType;
        skillPower= _skillPower;
        cd= _cd;
        mpUse = _MPUse;
		//id = _id;
		//myName = myName;
		setId(skillID);


    }
    public activeskill()
    {
		setId(skillID);
    }
    public void Output()
    {
        //Debug.Log(id);
        //Debug.Log(myName);
        Debug.Log(skillID);
        Debug.Log(skillName);
        //Debug.LogError(skillID);
        //Debug.LogError(skillName);
        //Debug.LogError(id);
        //Debug.LogError(myName);
    }

    //public ActiveSkillAttack(int id, string myName)
    //{
    //    id = id;
    //    myName = myName;
    //}
}