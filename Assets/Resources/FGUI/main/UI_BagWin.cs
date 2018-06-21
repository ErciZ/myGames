/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_BagWin : GComponent
	{
		public Controller m_page;
		public UI_WindowFrame m_frame;
		public GList m_list;
		public GImage m_n9;
		public GImage m_n10;
		public GLoader m_n11;
		public GTextField m_n12;
		public GTextField m_n13;
		public GList m_n25;

		public const string URL = "ui://dt4ij9q6jd5v2j";

		public static UI_BagWin CreateInstance()
		{
			return (UI_BagWin)UIPackage.CreateObject("main","BagWin");
		}

		public UI_BagWin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_page = this.GetController("page");
			m_frame = (UI_WindowFrame)this.GetChild("frame");
			m_list = (GList)this.GetChild("list");
			m_n9 = (GImage)this.GetChild("n9");
			m_n10 = (GImage)this.GetChild("n10");
			m_n11 = (GLoader)this.GetChild("n11");
			m_n12 = (GTextField)this.GetChild("n12");
			m_n13 = (GTextField)this.GetChild("n13");
			m_n25 = (GList)this.GetChild("n25");
		}
	}
}