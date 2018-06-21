/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_mainstage : GComponent
	{
		public Controller m_c1;
		public GImage m_ui;
		public GImage m_background;
		public UI_BagButton m_bagBtn;
		public GImage m_n57;
		public UI_JinHuaYeMianAnNiu m_n94;
		public UI_JingJiYeMianAnNiu m_n95;
		public UI_ShangDianYeMian m_n97;
		public GGroup m_n70;
		public GImage m_gold_table;
		public GTextField m_gold_text;
		public GImage m_gold;
		public GGroup m_gold_show;
		public GImage m_lv;
		public GTextField m_n26;
		public GGroup m_lv_show;
		public GImage m_name_table;
		public GTextField m_name;
		public GGroup m_name_show;
		public GImage m_diamond_table;
		public GImage m_diamond;
		public GTextField m_diamond_text;
		public GGroup m_diamond_show;
		public UI_SheZhi m_n108;
		public UI_DuanZaoYeMianAnNiu m_n88;
		public UI_JiNengYeMianAnNiu m_n89;
		public UI_JiangLiYeMianAnNiu m_n90;
		public UI_JunTuanYeMianAnNiu m_n91;
		public UI_RenWuYeMianAnNiu m_n92;
		public GGroup m_button_scence;
		public GImage m_n106;
		public GImage m_hero;
		public GImage m_n111;
		public UI_TanSuoShiJie m_n115;
		public UI_TiaoZhanBOSS m_n113;
		public UI_WuDaoDaHui m_n116;
		public GImage m_enemy;
		public UI_TongTianMoTa m_n117;
		public UI_HeadBar m_hero_headbar;
		public UI_HeadBar m_enemy_headbar;
		public GGroup m_n114;
		public GList m_mailList;

		public const string URL = "ui://dt4ij9q6x1cu0";

		public static UI_mainstage CreateInstance()
		{
			return (UI_mainstage)UIPackage.CreateObject("main","mainstage");
		}

		public UI_mainstage()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetController("c1");
			m_ui = (GImage)this.GetChild("ui");
			m_background = (GImage)this.GetChild("background");
			m_bagBtn = (UI_BagButton)this.GetChild("bagBtn");
			m_n57 = (GImage)this.GetChild("n57");
			m_n94 = (UI_JinHuaYeMianAnNiu)this.GetChild("n94");
			m_n95 = (UI_JingJiYeMianAnNiu)this.GetChild("n95");
			m_n97 = (UI_ShangDianYeMian)this.GetChild("n97");
			m_n70 = (GGroup)this.GetChild("n70");
			m_gold_table = (GImage)this.GetChild("gold_table");
			m_gold_text = (GTextField)this.GetChild("gold_text");
			m_gold = (GImage)this.GetChild("gold");
			m_gold_show = (GGroup)this.GetChild("gold_show");
			m_lv = (GImage)this.GetChild("lv");
			m_n26 = (GTextField)this.GetChild("n26");
			m_lv_show = (GGroup)this.GetChild("lv_show");
			m_name_table = (GImage)this.GetChild("name_table");
			m_name = (GTextField)this.GetChild("name");
			m_name_show = (GGroup)this.GetChild("name_show");
			m_diamond_table = (GImage)this.GetChild("diamond_table");
			m_diamond = (GImage)this.GetChild("diamond");
			m_diamond_text = (GTextField)this.GetChild("diamond_text");
			m_diamond_show = (GGroup)this.GetChild("diamond_show");
			m_n108 = (UI_SheZhi)this.GetChild("n108");
			m_n88 = (UI_DuanZaoYeMianAnNiu)this.GetChild("n88");
			m_n89 = (UI_JiNengYeMianAnNiu)this.GetChild("n89");
			m_n90 = (UI_JiangLiYeMianAnNiu)this.GetChild("n90");
			m_n91 = (UI_JunTuanYeMianAnNiu)this.GetChild("n91");
			m_n92 = (UI_RenWuYeMianAnNiu)this.GetChild("n92");
			m_button_scence = (GGroup)this.GetChild("button_scence");
			m_n106 = (GImage)this.GetChild("n106");
			m_hero = (GImage)this.GetChild("hero");
			m_n111 = (GImage)this.GetChild("n111");
			m_n115 = (UI_TanSuoShiJie)this.GetChild("n115");
			m_n113 = (UI_TiaoZhanBOSS)this.GetChild("n113");
			m_n116 = (UI_WuDaoDaHui)this.GetChild("n116");
			m_enemy = (GImage)this.GetChild("enemy");
			m_n117 = (UI_TongTianMoTa)this.GetChild("n117");
			m_hero_headbar = (UI_HeadBar)this.GetChild("hero_headbar");
			m_enemy_headbar = (UI_HeadBar)this.GetChild("enemy_headbar");
			m_n114 = (GGroup)this.GetChild("n114");
			m_mailList = (GList)this.GetChild("mailList");
		}
	}
}