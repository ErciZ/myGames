/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_TiaoZhanBOSS : GButton
	{
		public Controller m_button;
		public GImage m_n1;
		public GTextField m_title;

		public const string URL = "ui://dt4ij9q6ukf03g";

		public static UI_TiaoZhanBOSS CreateInstance()
		{
			return (UI_TiaoZhanBOSS)UIPackage.CreateObject("main","挑战BOSS");
		}

		public UI_TiaoZhanBOSS()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetController("button");
			m_n1 = (GImage)this.GetChild("n1");
			m_title = (GTextField)this.GetChild("title");
		}
	}
}