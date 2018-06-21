/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_mailItem : GButton
	{
		public GImage m_n14;
		public GTextField m_battle_text;
		public Transition m_t0;

		public const string URL = "ui://dt4ij9q6twi73a";

		public static UI_mailItem CreateInstance()
		{
			return (UI_mailItem)UIPackage.CreateObject("main","mailItem");
		}

		public UI_mailItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n14 = (GImage)this.GetChild("n14");
			m_battle_text = (GTextField)this.GetChild("battle_text");
			m_t0 = this.GetTransition("t0");
		}
	}
}