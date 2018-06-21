using UnityEngine;
using FairyGUI;

public class MailItem : GButton
{
	GTextField _timeText;
	//Controller _readController;
	//Controller _fetchController;
	Transition _trans;

	public override void ConstructFromXML(FairyGUI.Utils.XML cxml)
	{
		base.ConstructFromXML(cxml);

        _timeText = this.GetChild("battle_text").asTextField;
		//_readController = this.GetController("IsRead");
		//_fetchController = this.GetController("c1");
		_trans = this.GetTransition("t0");
	}

	public void setText(string value)
	{
		_timeText.text = value;
	}



	public void PlayEffect(float delay)
	{
		this.visible = false;
		_trans.Play(1, delay, null);
	}
}
