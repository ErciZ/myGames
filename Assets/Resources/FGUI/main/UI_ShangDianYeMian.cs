/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_ShangDianYeMian : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://dt4ij9q6s2nm34";

		public static UI_ShangDianYeMian CreateInstance()
		{
			return (UI_ShangDianYeMian)UIPackage.CreateObject("main","商店页面");
		}

		public UI_ShangDianYeMian()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetController("button");
			m_n1 = (GImage)this.GetChild("n1");
		}
	}
}