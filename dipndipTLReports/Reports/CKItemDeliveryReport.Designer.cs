namespace dipndipTLReports.Reports
{
    partial class CKItemDeliveryReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CKItemDeliveryReport));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group3 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group4 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group5 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group6 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group7 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group8 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.CKItemDeliverysqlDataSource = new Telerik.Reporting.SqlDataSource();
            this.ck_issue_codeGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.ck_issue_codeGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.branch_order_dateGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.branch_order_dateGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ck_issue_dateGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.ck_issue_dateGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.site_nameGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.site_nameGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ck_item_codeGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.ck_item_codeGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ck_item_descGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.ck_item_descGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.unit_descriptionGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.unit_descriptionGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.qty_issuedSumFunctionTextBox = new Telerik.Reporting.TextBox();
            this.qty_issuedSumFunctionTextBox1 = new Telerik.Reporting.TextBox();
            this.qty_issuedSumFunctionTextBox2 = new Telerik.Reporting.TextBox();
            this.qty_issuedSumFunctionTextBox3 = new Telerik.Reporting.TextBox();
            this.qty_issuedSumFunctionTextBox4 = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.qty_issuedSumFunctionTextBox7 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ck_prod_codeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_batch_noCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_prod_dateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_exp_dateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.qty_issuedCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.ck_prod_codeDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_batch_noDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_prod_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_exp_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.qty_issuedDataTextBox = new Telerik.Reporting.TextBox();
            this.qty_issuedSumFunctionTextBox6 = new Telerik.Reporting.TextBox();
            this.qty_issuedSumFunctionTextBox5 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // CKItemDeliverysqlDataSource
            // 
            this.CKItemDeliverysqlDataSource.ConnectionString = "dipndipTLReports.Properties.Settings.dipckConnectionString";
            this.CKItemDeliverysqlDataSource.Name = "CKItemDeliverysqlDataSource";
            this.CKItemDeliverysqlDataSource.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@ck_issue_code", System.Data.DbType.String, "= Parameters.ck_issue_code.Value")});
            this.CKItemDeliverysqlDataSource.SelectCommand = resources.GetString("CKItemDeliverysqlDataSource.SelectCommand");
            // 
            // ck_issue_codeGroupHeaderSection
            // 
            this.ck_issue_codeGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_issue_codeGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2});
            this.ck_issue_codeGroupHeaderSection.Name = "ck_issue_codeGroupHeaderSection";
            // 
            // ck_issue_codeGroupFooterSection
            // 
            this.ck_issue_codeGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_issue_codeGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox});
            this.ck_issue_codeGroupFooterSection.Name = "ck_issue_codeGroupFooterSection";
            this.ck_issue_codeGroupFooterSection.Style.Visible = false;
            // 
            // branch_order_dateGroupHeaderSection
            // 
            this.branch_order_dateGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.branch_order_dateGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox4});
            this.branch_order_dateGroupHeaderSection.Name = "branch_order_dateGroupHeaderSection";
            // 
            // branch_order_dateGroupFooterSection
            // 
            this.branch_order_dateGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.branch_order_dateGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox1});
            this.branch_order_dateGroupFooterSection.Name = "branch_order_dateGroupFooterSection";
            this.branch_order_dateGroupFooterSection.Style.Visible = false;
            // 
            // ck_issue_dateGroupHeaderSection
            // 
            this.ck_issue_dateGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_issue_dateGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox6});
            this.ck_issue_dateGroupHeaderSection.Name = "ck_issue_dateGroupHeaderSection";
            // 
            // ck_issue_dateGroupFooterSection
            // 
            this.ck_issue_dateGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_issue_dateGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox2});
            this.ck_issue_dateGroupFooterSection.Name = "ck_issue_dateGroupFooterSection";
            this.ck_issue_dateGroupFooterSection.Style.Visible = false;
            // 
            // site_nameGroupHeaderSection
            // 
            this.site_nameGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.site_nameGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox8});
            this.site_nameGroupHeaderSection.Name = "site_nameGroupHeaderSection";
            // 
            // site_nameGroupFooterSection
            // 
            this.site_nameGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.site_nameGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox3});
            this.site_nameGroupFooterSection.Name = "site_nameGroupFooterSection";
            this.site_nameGroupFooterSection.Style.Visible = false;
            // 
            // ck_item_codeGroupHeaderSection
            // 
            this.ck_item_codeGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_item_codeGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox9,
            this.textBox10});
            this.ck_item_codeGroupHeaderSection.Name = "ck_item_codeGroupHeaderSection";
            // 
            // ck_item_codeGroupFooterSection
            // 
            this.ck_item_codeGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_item_codeGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox4});
            this.ck_item_codeGroupFooterSection.Name = "ck_item_codeGroupFooterSection";
            // 
            // ck_item_descGroupHeaderSection
            // 
            this.ck_item_descGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_item_descGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox11,
            this.textBox12});
            this.ck_item_descGroupHeaderSection.Name = "ck_item_descGroupHeaderSection";
            // 
            // ck_item_descGroupFooterSection
            // 
            this.ck_item_descGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_item_descGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox5});
            this.ck_item_descGroupFooterSection.Name = "ck_item_descGroupFooterSection";
            this.ck_item_descGroupFooterSection.Style.Visible = false;
            // 
            // unit_descriptionGroupHeaderSection
            // 
            this.unit_descriptionGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.unit_descriptionGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13,
            this.textBox14});
            this.unit_descriptionGroupHeaderSection.Name = "unit_descriptionGroupHeaderSection";
            // 
            // unit_descriptionGroupFooterSection
            // 
            this.unit_descriptionGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.unit_descriptionGroupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox6});
            this.unit_descriptionGroupFooterSection.Name = "unit_descriptionGroupFooterSection";
            this.unit_descriptionGroupFooterSection.Style.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "ck_issue_code:";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.ck_issue_code";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.StyleName = "Caption";
            this.textBox3.Value = "branch_order_date:";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "= Fields.branch_order_date";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "ck_issue_date:";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "= Fields.ck_issue_date";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox7.StyleName = "Caption";
            this.textBox7.Value = "site_name:";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "= Fields.site_name";
            // 
            // textBox9
            // 
            this.textBox9.CanGrow = true;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox9.StyleName = "Caption";
            this.textBox9.Value = "ck_item_code:";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "= Fields.ck_item_code";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = true;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox11.StyleName = "Caption";
            this.textBox11.Value = "ck_item_desc:";
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = true;
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "= Fields.ck_item_desc";
            // 
            // textBox13
            // 
            this.textBox13.CanGrow = true;
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.StyleName = "Caption";
            this.textBox13.Value = "unit_description:";
            // 
            // textBox14
            // 
            this.textBox14.CanGrow = true;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox14.StyleName = "Data";
            this.textBox14.Value = "= Fields.unit_description";
            // 
            // qty_issuedSumFunctionTextBox
            // 
            this.qty_issuedSumFunctionTextBox.CanGrow = true;
            this.qty_issuedSumFunctionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox.Name = "qty_issuedSumFunctionTextBox";
            this.qty_issuedSumFunctionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox.Value = "= Sum(Fields.qty_issued)";
            // 
            // qty_issuedSumFunctionTextBox1
            // 
            this.qty_issuedSumFunctionTextBox1.CanGrow = true;
            this.qty_issuedSumFunctionTextBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox1.Name = "qty_issuedSumFunctionTextBox1";
            this.qty_issuedSumFunctionTextBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox1.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox1.Value = "= Sum(Fields.qty_issued)";
            // 
            // qty_issuedSumFunctionTextBox2
            // 
            this.qty_issuedSumFunctionTextBox2.CanGrow = true;
            this.qty_issuedSumFunctionTextBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox2.Name = "qty_issuedSumFunctionTextBox2";
            this.qty_issuedSumFunctionTextBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox2.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox2.Value = "= Sum(Fields.qty_issued)";
            // 
            // qty_issuedSumFunctionTextBox3
            // 
            this.qty_issuedSumFunctionTextBox3.CanGrow = true;
            this.qty_issuedSumFunctionTextBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox3.Name = "qty_issuedSumFunctionTextBox3";
            this.qty_issuedSumFunctionTextBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox3.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox3.Value = "= Sum(Fields.qty_issued)";
            // 
            // qty_issuedSumFunctionTextBox4
            // 
            this.qty_issuedSumFunctionTextBox4.CanGrow = true;
            this.qty_issuedSumFunctionTextBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox4.Name = "qty_issuedSumFunctionTextBox4";
            this.qty_issuedSumFunctionTextBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox4.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox4.Value = "= Sum(Fields.qty_issued)";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.qty_issuedSumFunctionTextBox7});
            this.reportFooter.Name = "reportFooter";
            this.reportFooter.Style.Visible = false;
            // 
            // qty_issuedSumFunctionTextBox7
            // 
            this.qty_issuedSumFunctionTextBox7.CanGrow = true;
            this.qty_issuedSumFunctionTextBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox7.Name = "qty_issuedSumFunctionTextBox7";
            this.qty_issuedSumFunctionTextBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox7.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox7.Value = "= Sum(Fields.qty_issued)";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ck_prod_codeCaptionTextBox,
            this.ck_batch_noCaptionTextBox,
            this.ck_prod_dateCaptionTextBox,
            this.ck_exp_dateCaptionTextBox,
            this.qty_issuedCaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // ck_prod_codeCaptionTextBox
            // 
            this.ck_prod_codeCaptionTextBox.CanGrow = true;
            this.ck_prod_codeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_prod_codeCaptionTextBox.Name = "ck_prod_codeCaptionTextBox";
            this.ck_prod_codeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_codeCaptionTextBox.StyleName = "Caption";
            this.ck_prod_codeCaptionTextBox.Value = "ck_prod_code";
            // 
            // ck_batch_noCaptionTextBox
            // 
            this.ck_batch_noCaptionTextBox.CanGrow = true;
            this.ck_batch_noCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3083332777023315D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_batch_noCaptionTextBox.Name = "ck_batch_noCaptionTextBox";
            this.ck_batch_noCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_batch_noCaptionTextBox.StyleName = "Caption";
            this.ck_batch_noCaptionTextBox.Value = "ck_batch_no";
            // 
            // ck_prod_dateCaptionTextBox
            // 
            this.ck_prod_dateCaptionTextBox.CanGrow = true;
            this.ck_prod_dateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5958333015441895D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_prod_dateCaptionTextBox.Name = "ck_prod_dateCaptionTextBox";
            this.ck_prod_dateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_dateCaptionTextBox.StyleName = "Caption";
            this.ck_prod_dateCaptionTextBox.Value = "ck_prod_date";
            // 
            // ck_exp_dateCaptionTextBox
            // 
            this.ck_exp_dateCaptionTextBox.CanGrow = true;
            this.ck_exp_dateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8833334445953369D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_exp_dateCaptionTextBox.Name = "ck_exp_dateCaptionTextBox";
            this.ck_exp_dateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_exp_dateCaptionTextBox.StyleName = "Caption";
            this.ck_exp_dateCaptionTextBox.Value = "ck_exp_date";
            // 
            // qty_issuedCaptionTextBox
            // 
            this.qty_issuedCaptionTextBox.CanGrow = true;
            this.qty_issuedCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedCaptionTextBox.Name = "qty_issuedCaptionTextBox";
            this.qty_issuedCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedCaptionTextBox.StyleName = "Caption";
            this.qty_issuedCaptionTextBox.Value = "qty_issued";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "CKItemDeliveryReport";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2395832538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.80823493003845215D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "CKItemDeliveryReport";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ck_prod_codeDataTextBox,
            this.ck_batch_noDataTextBox,
            this.ck_prod_dateDataTextBox,
            this.ck_exp_dateDataTextBox,
            this.qty_issuedDataTextBox});
            this.detail.Name = "detail";
            // 
            // ck_prod_codeDataTextBox
            // 
            this.ck_prod_codeDataTextBox.CanGrow = true;
            this.ck_prod_codeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_prod_codeDataTextBox.Name = "ck_prod_codeDataTextBox";
            this.ck_prod_codeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_codeDataTextBox.StyleName = "Data";
            this.ck_prod_codeDataTextBox.Value = "= Fields.ck_prod_code";
            // 
            // ck_batch_noDataTextBox
            // 
            this.ck_batch_noDataTextBox.CanGrow = true;
            this.ck_batch_noDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3083332777023315D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_batch_noDataTextBox.Name = "ck_batch_noDataTextBox";
            this.ck_batch_noDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_batch_noDataTextBox.StyleName = "Data";
            this.ck_batch_noDataTextBox.Value = "= Fields.ck_batch_no";
            // 
            // ck_prod_dateDataTextBox
            // 
            this.ck_prod_dateDataTextBox.CanGrow = true;
            this.ck_prod_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5958333015441895D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_prod_dateDataTextBox.Name = "ck_prod_dateDataTextBox";
            this.ck_prod_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_dateDataTextBox.StyleName = "Data";
            this.ck_prod_dateDataTextBox.Value = "= Fields.ck_prod_date";
            // 
            // ck_exp_dateDataTextBox
            // 
            this.ck_exp_dateDataTextBox.CanGrow = true;
            this.ck_exp_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8833334445953369D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_exp_dateDataTextBox.Name = "ck_exp_dateDataTextBox";
            this.ck_exp_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_exp_dateDataTextBox.StyleName = "Data";
            this.ck_exp_dateDataTextBox.Value = "= Fields.ck_exp_date";
            // 
            // qty_issuedDataTextBox
            // 
            this.qty_issuedDataTextBox.CanGrow = true;
            this.qty_issuedDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedDataTextBox.Name = "qty_issuedDataTextBox";
            this.qty_issuedDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedDataTextBox.StyleName = "Data";
            this.qty_issuedDataTextBox.Value = "= Fields.qty_issued";
            // 
            // qty_issuedSumFunctionTextBox6
            // 
            this.qty_issuedSumFunctionTextBox6.CanGrow = true;
            this.qty_issuedSumFunctionTextBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox6.Name = "qty_issuedSumFunctionTextBox6";
            this.qty_issuedSumFunctionTextBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox6.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox6.Value = "= Sum(Fields.qty_issued)";
            // 
            // qty_issuedSumFunctionTextBox5
            // 
            this.qty_issuedSumFunctionTextBox5.CanGrow = true;
            this.qty_issuedSumFunctionTextBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.qty_issuedSumFunctionTextBox5.Name = "qty_issuedSumFunctionTextBox5";
            this.qty_issuedSumFunctionTextBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedSumFunctionTextBox5.StyleName = "Data";
            this.qty_issuedSumFunctionTextBox5.Value = "= Sum(Fields.qty_issued)";
            // 
            // CKItemDeliveryReport
            // 
            this.DataSource = this.CKItemDeliverysqlDataSource;
            group1.GroupFooter = this.ck_issue_codeGroupFooterSection;
            group1.GroupHeader = this.ck_issue_codeGroupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.ck_issue_code"));
            group1.Name = "ck_issue_codeGroup";
            group2.GroupFooter = this.branch_order_dateGroupFooterSection;
            group2.GroupHeader = this.branch_order_dateGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.branch_order_date"));
            group2.Name = "branch_order_dateGroup";
            group3.GroupFooter = this.ck_issue_dateGroupFooterSection;
            group3.GroupHeader = this.ck_issue_dateGroupHeaderSection;
            group3.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.ck_issue_date"));
            group3.Name = "ck_issue_dateGroup";
            group4.GroupFooter = this.site_nameGroupFooterSection;
            group4.GroupHeader = this.site_nameGroupHeaderSection;
            group4.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.site_name"));
            group4.Name = "site_nameGroup";
            group5.GroupFooter = this.ck_item_codeGroupFooterSection;
            group5.GroupHeader = this.ck_item_codeGroupHeaderSection;
            group5.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.ck_item_code"));
            group5.Name = "ck_item_codeGroup";
            group6.GroupFooter = this.ck_item_descGroupFooterSection;
            group6.GroupHeader = this.ck_item_descGroupHeaderSection;
            group6.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.ck_item_desc"));
            group6.Name = "ck_item_descGroup";
            group7.GroupFooter = this.unit_descriptionGroupFooterSection;
            group7.GroupHeader = this.unit_descriptionGroupHeaderSection;
            group7.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.unit_description"));
            group7.Name = "unit_descriptionGroup";
            group8.GroupFooter = this.labelsGroupFooterSection;
            group8.GroupHeader = this.labelsGroupHeaderSection;
            group8.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2,
            group3,
            group4,
            group5,
            group6,
            group7,
            group8});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ck_issue_codeGroupHeaderSection,
            this.ck_issue_codeGroupFooterSection,
            this.branch_order_dateGroupHeaderSection,
            this.branch_order_dateGroupFooterSection,
            this.ck_issue_dateGroupHeaderSection,
            this.ck_issue_dateGroupFooterSection,
            this.site_nameGroupHeaderSection,
            this.site_nameGroupFooterSection,
            this.ck_item_codeGroupHeaderSection,
            this.ck_item_codeGroupFooterSection,
            this.ck_item_descGroupHeaderSection,
            this.ck_item_descGroupFooterSection,
            this.unit_descriptionGroupHeaderSection,
            this.unit_descriptionGroupFooterSection,
            this.reportFooter,
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.detail});
            this.Name = "CKItemDeliveryReport";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "ck_issue_code";
            reportParameter1.Value = "CKIS-0011";
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Italic = false;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule2.Style.Font.Strikeout = false;
            styleRule2.Style.Font.Underline = false;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Font.Name = "Tahoma";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource CKItemDeliverysqlDataSource;
        private Telerik.Reporting.GroupHeaderSection ck_issue_codeGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection ck_issue_codeGroupFooterSection;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox;
        private Telerik.Reporting.GroupHeaderSection branch_order_dateGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.GroupFooterSection branch_order_dateGroupFooterSection;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox1;
        private Telerik.Reporting.GroupHeaderSection ck_issue_dateGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.GroupFooterSection ck_issue_dateGroupFooterSection;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox2;
        private Telerik.Reporting.GroupHeaderSection site_nameGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.GroupFooterSection site_nameGroupFooterSection;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox3;
        private Telerik.Reporting.GroupHeaderSection ck_item_codeGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.GroupFooterSection ck_item_codeGroupFooterSection;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox4;
        private Telerik.Reporting.GroupHeaderSection ck_item_descGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.GroupFooterSection ck_item_descGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection unit_descriptionGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.GroupFooterSection unit_descriptionGroupFooterSection;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox7;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox ck_prod_codeCaptionTextBox;
        private Telerik.Reporting.TextBox ck_batch_noCaptionTextBox;
        private Telerik.Reporting.TextBox ck_prod_dateCaptionTextBox;
        private Telerik.Reporting.TextBox ck_exp_dateCaptionTextBox;
        private Telerik.Reporting.TextBox qty_issuedCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox ck_prod_codeDataTextBox;
        private Telerik.Reporting.TextBox ck_batch_noDataTextBox;
        private Telerik.Reporting.TextBox ck_prod_dateDataTextBox;
        private Telerik.Reporting.TextBox ck_exp_dateDataTextBox;
        private Telerik.Reporting.TextBox qty_issuedDataTextBox;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox5;
        private Telerik.Reporting.TextBox qty_issuedSumFunctionTextBox6;
    }
}