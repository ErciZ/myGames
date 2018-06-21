/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_BagGridSub : GButton
	{
		public Controller m_button;
		public GImage m_n12;
		public GLoader m_icon;
		public GTextField m_title;

		public const string URL = "ui://dt4ij9q6jd5v2i";

		public static UI_BagGridSub CreateInstance()
		{
			return (UI_BagGridSub)UIPackage.CreateObject("main","BagGridSub");
		}

		public UI_BagGridSub()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetController("button");
			m_n12 = (GImage)this.GetChild("n12");
			m_icon = (GLoader)this.GetChild("icon");
			m_title = (GTextField)this.GetChild("title");
		}
	}
}