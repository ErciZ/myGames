/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_dot : GButton
	{
		public Controller m_button;
		public GGraph m_n23;
		public GGraph m_n22;

		public const string URL = "ui://dt4ij9q6jd5v2m";

		public static UI_dot CreateInstance()
		{
			return (UI_dot)UIPackage.CreateObject("main","dot");
		}

		public UI_dot()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetController("button");
			m_n23 = (GGraph)this.GetChild("n23");
			m_n22 = (GGraph)this.GetChild("n22");
		}
	}
}