/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_CloseButton : GButton
	{
		public Controller m_button;
		public Controller m_c1;
		public GImage m_n6;
		public GImage m_n4;

		public const string URL = "ui://dt4ij9q6jd5v2l";

		public static UI_CloseButton CreateInstance()
		{
			return (UI_CloseButton)UIPackage.CreateObject("main","CloseButton");
		}

		public UI_CloseButton()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetController("button");
			m_c1 = this.GetController("c1");
			m_n6 = (GImage)this.GetChild("n6");
			m_n4 = (GImage)this.GetChild("n4");
		}
	}
}