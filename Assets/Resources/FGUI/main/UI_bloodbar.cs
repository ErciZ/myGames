/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_bloodbar : GProgressBar
	{
		public GImage m_n2;
		public GImage m_bar;

		public const string URL = "ui://dt4ij9q6ukf03n";

		public static UI_bloodbar CreateInstance()
		{
			return (UI_bloodbar)UIPackage.CreateObject("main","bloodbar");
		}

		public UI_bloodbar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n2 = (GImage)this.GetChild("n2");
			m_bar = (GImage)this.GetChild("bar");
		}
	}
}