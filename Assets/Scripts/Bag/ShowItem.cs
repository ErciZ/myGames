using UnityEngine;
using FairyGUI;

public class ShowItem : GButton
{
 

    public override void ConstructFromXML(FairyGUI.Utils.XML cxml)
    {
        base.ConstructFromXML(cxml);
        //_timeText = this.GetChild("battle_text").asTextField;

    }

    public void setIcon(int index,string value)
    {       
        this.icon = "i" + UnityEngine.Random.Range(0, 10);//n11   物品图标
            
    }
    public void setNumber(int index,string value)
    {
        this.title = value;//name 物品数量
       
    }


}