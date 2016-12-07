namespace dipndipTLReports.Reports
{
    partial class CKWastageReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CKWastageReport));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group3 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group4 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.CKWastagesqlDataSource = new Telerik.Reporting.SqlDataSource();
            this.ck_wastage_codeGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.ck_wastage_codeGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.wastage_dateGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.wastage_dateGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ck_item_codeGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.ck_item_codeGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ck_item_descCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_prod_codeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_batch_noCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_prod_dateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_exp_dateCaptionTextBox = new Telerik.Reporting.TextBox();
            this.wastage_qtyCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.ck_item_descDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_prod_codeDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_batch_noDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_prod_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_exp_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.wastage_qtyDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.shape2 = new Telerik.Reporting.Shape();
            this.shape3 = new Telerik.Reporting.Shape();
            this.shape4 = new Telerik.Reporting.Shape();
            this.shape5 = new Telerik.Reporting.Shape();
            this.shape6 = new Telerik.Reporting.Shape();
            this.shape7 = new Telerik.Reporting.Shape();
            this.shape8 = new Telerik.Reporting.Shape();
            this.shape9 = new Telerik.Reporting.Shape();
            this.shape10 = new Telerik.Reporting.Shape();
            this.shape11 = new Telerik.Reporting.Shape();
            this.shape12 = new Telerik.Reporting.Shape();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // CKWastagesqlDataSource
            // 
            this.CKWastagesqlDataSource.ConnectionString = "dipndipTLReports.Properties.Settings.dipckConnectionString";
            this.CKWastagesqlDataSource.Name = "CKWastagesqlDataSource";
            this.CKWastagesqlDataSource.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@ck_wastage_code", System.Data.DbType.String, "= Parameters.ck_wastage_code.Value")});
            this.CKWastagesqlDataSource.SelectCommand = resources.GetString("CKWastagesqlDataSource.SelectCommand");
            // 
            // ck_wastage_codeGroupHeaderSection
            // 
            this.ck_wastage_codeGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_wastage_codeGroupHeaderSection.Name = "ck_wastage_codeGroupHeaderSection";
            // 
            // ck_wastage_codeGroupFooterSection
            // 
            this.ck_wastage_codeGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_wastage_codeGroupFooterSection.Name = "ck_wastage_codeGroupFooterSection";
            // 
            // wastage_dateGroupHeaderSection
            // 
            this.wastage_dateGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.wastage_dateGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox4,
            this.textBox1,
            this.textBox2});
            this.wastage_dateGroupHeaderSection.Name = "wastage_dateGroupHeaderSection";
            // 
            // wastage_dateGroupFooterSection
            // 
            this.wastage_dateGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.wastage_dateGroupFooterSection.Name = "wastage_dateGroupFooterSection";
            // 
            // ck_item_codeGroupHeaderSection
            // 
            this.ck_item_codeGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_item_codeGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox6});
            this.ck_item_codeGroupHeaderSection.Name = "ck_item_codeGroupHeaderSection";
            this.ck_item_codeGroupHeaderSection.Style.Visible = false;
            // 
            // ck_item_codeGroupFooterSection
            // 
            this.ck_item_codeGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.ck_item_codeGroupFooterSection.Name = "ck_item_codeGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.016716957092285156D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67916673421859741D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Doc. No.";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.016716957092285156D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1583335399627686D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.ck_wastage_code";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.37916669249534607D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.StyleName = "Caption";
            this.textBox3.Value = "Date";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Format = "{0:dd/MM/yyyy}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.4791674613952637D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.89999967813491821D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "= Fields.wastage_date";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "ck_item_code:";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1750001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "= Fields.ck_item_code";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ck_item_descCaptionTextBox,
            this.ck_prod_codeCaptionTextBox,
            this.ck_batch_noCaptionTextBox,
            this.ck_prod_dateCaptionTextBox,
            this.ck_exp_dateCaptionTextBox,
            this.wastage_qtyCaptionTextBox,
            this.textBox8,
            this.shape1,
            this.shape2,
            this.shape3,
            this.shape4,
            this.shape5,
            this.shape6});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            this.labelsGroupHeaderSection.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelsGroupHeaderSection.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // ck_item_descCaptionTextBox
            // 
            this.ck_item_descCaptionTextBox.CanGrow = true;
            this.ck_item_descCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_item_descCaptionTextBox.Name = "ck_item_descCaptionTextBox";
            this.ck_item_descCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0520833730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_descCaptionTextBox.Style.Font.Bold = true;
            this.ck_item_descCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ck_item_descCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ck_item_descCaptionTextBox.StyleName = "Caption";
            this.ck_item_descCaptionTextBox.Value = "Description";
            // 
            // ck_prod_codeCaptionTextBox
            // 
            this.ck_prod_codeCaptionTextBox.CanGrow = true;
            this.ck_prod_codeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_prod_codeCaptionTextBox.Name = "ck_prod_codeCaptionTextBox";
            this.ck_prod_codeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.75208348035812378D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_codeCaptionTextBox.Style.Font.Bold = true;
            this.ck_prod_codeCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ck_prod_codeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ck_prod_codeCaptionTextBox.StyleName = "Caption";
            this.ck_prod_codeCaptionTextBox.Value = "Prod.Code";
            // 
            // ck_batch_noCaptionTextBox
            // 
            this.ck_batch_noCaptionTextBox.CanGrow = true;
            this.ck_batch_noCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_batch_noCaptionTextBox.Name = "ck_batch_noCaptionTextBox";
            this.ck_batch_noCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.85208350419998169D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_batch_noCaptionTextBox.Style.Font.Bold = true;
            this.ck_batch_noCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ck_batch_noCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ck_batch_noCaptionTextBox.StyleName = "Caption";
            this.ck_batch_noCaptionTextBox.Value = "Batch No";
            // 
            // ck_prod_dateCaptionTextBox
            // 
            this.ck_prod_dateCaptionTextBox.CanGrow = true;
            this.ck_prod_dateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_prod_dateCaptionTextBox.Name = "ck_prod_dateCaptionTextBox";
            this.ck_prod_dateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.76041668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_dateCaptionTextBox.Style.Font.Bold = true;
            this.ck_prod_dateCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ck_prod_dateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ck_prod_dateCaptionTextBox.StyleName = "Caption";
            this.ck_prod_dateCaptionTextBox.Value = "Prod.Date";
            // 
            // ck_exp_dateCaptionTextBox
            // 
            this.ck_exp_dateCaptionTextBox.CanGrow = true;
            this.ck_exp_dateCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_exp_dateCaptionTextBox.Name = "ck_exp_dateCaptionTextBox";
            this.ck_exp_dateCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78750038146972656D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_exp_dateCaptionTextBox.Style.Font.Bold = true;
            this.ck_exp_dateCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.ck_exp_dateCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ck_exp_dateCaptionTextBox.StyleName = "Caption";
            this.ck_exp_dateCaptionTextBox.Value = "Exp.Date";
            // 
            // wastage_qtyCaptionTextBox
            // 
            this.wastage_qtyCaptionTextBox.CanGrow = true;
            this.wastage_qtyCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wastage_qtyCaptionTextBox.Name = "wastage_qtyCaptionTextBox";
            this.wastage_qtyCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4375D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wastage_qtyCaptionTextBox.Style.Font.Bold = true;
            this.wastage_qtyCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.wastage_qtyCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wastage_qtyCaptionTextBox.StyleName = "Caption";
            this.wastage_qtyCaptionTextBox.Value = "Qty";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox,
            this.pictureBox1});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.Style.Visible = false;
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "CKWastageReport";
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
            this.titleTextBox,
            this.textBox9});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.318671315908432D));
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "CK Wastage Report";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ck_item_descDataTextBox,
            this.ck_prod_codeDataTextBox,
            this.ck_batch_noDataTextBox,
            this.ck_prod_dateDataTextBox,
            this.ck_exp_dateDataTextBox,
            this.wastage_qtyDataTextBox,
            this.textBox7,
            this.shape7,
            this.shape8,
            this.shape9,
            this.shape10,
            this.shape11,
            this.shape12});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // ck_item_descDataTextBox
            // 
            this.ck_item_descDataTextBox.CanGrow = true;
            this.ck_item_descDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_item_descDataTextBox.Name = "ck_item_descDataTextBox";
            this.ck_item_descDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0520833730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_descDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.ck_item_descDataTextBox.StyleName = "Data";
            this.ck_item_descDataTextBox.Value = "= Fields.ck_item_desc";
            // 
            // ck_prod_codeDataTextBox
            // 
            this.ck_prod_codeDataTextBox.CanGrow = true;
            this.ck_prod_codeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_prod_codeDataTextBox.Name = "ck_prod_codeDataTextBox";
            this.ck_prod_codeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.75208348035812378D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_codeDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.ck_prod_codeDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ck_prod_codeDataTextBox.StyleName = "Data";
            this.ck_prod_codeDataTextBox.Value = "= Fields.ck_prod_code";
            // 
            // ck_batch_noDataTextBox
            // 
            this.ck_batch_noDataTextBox.CanGrow = true;
            this.ck_batch_noDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_batch_noDataTextBox.Name = "ck_batch_noDataTextBox";
            this.ck_batch_noDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.85208350419998169D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_batch_noDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.ck_batch_noDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ck_batch_noDataTextBox.StyleName = "Data";
            this.ck_batch_noDataTextBox.Value = "= Fields.ck_batch_no";
            // 
            // ck_prod_dateDataTextBox
            // 
            this.ck_prod_dateDataTextBox.CanGrow = true;
            this.ck_prod_dateDataTextBox.Format = "{0:dd/MM/yyyy}";
            this.ck_prod_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_prod_dateDataTextBox.Name = "ck_prod_dateDataTextBox";
            this.ck_prod_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.76041668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_prod_dateDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.ck_prod_dateDataTextBox.StyleName = "Data";
            this.ck_prod_dateDataTextBox.Value = "= Fields.ck_prod_date";
            // 
            // ck_exp_dateDataTextBox
            // 
            this.ck_exp_dateDataTextBox.CanGrow = true;
            this.ck_exp_dateDataTextBox.Format = "{0:dd/MM/yyyy}";
            this.ck_exp_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.ck_exp_dateDataTextBox.Name = "ck_exp_dateDataTextBox";
            this.ck_exp_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7645832896232605D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_exp_dateDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.ck_exp_dateDataTextBox.StyleName = "Data";
            this.ck_exp_dateDataTextBox.Value = "= Fields.ck_exp_date";
            // 
            // wastage_qtyDataTextBox
            // 
            this.wastage_qtyDataTextBox.CanGrow = true;
            this.wastage_qtyDataTextBox.Format = "{0:N3}";
            this.wastage_qtyDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wastage_qtyDataTextBox.Name = "wastage_qtyDataTextBox";
            this.wastage_qtyDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4375D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wastage_qtyDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.wastage_qtyDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.wastage_qtyDataTextBox.StyleName = "Data";
            this.wastage_qtyDataTextBox.Value = "= Fields.wastage_qty";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000007152557373D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.StyleName = "Data";
            this.textBox7.Value = "= Fields.ck_item_code";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.StyleName = "Caption";
            this.textBox8.Value = "Item Code";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.518750011920929D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4375D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Value = "= Fields.site_name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5791668891906738D), Telerik.Reporting.Drawing.Unit.Inch(0.48117128014564514D));
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90007877349853516D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape2
            // 
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape3
            // 
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape4
            // 
            this.shape4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D));
            this.shape4.Name = "shape4";
            this.shape4.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape5
            // 
            this.shape5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D));
            this.shape5.Name = "shape5";
            this.shape5.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape6
            // 
            this.shape6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.8000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D));
            this.shape6.Name = "shape6";
            this.shape6.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape7
            // 
            this.shape7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.89992111921310425D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape7.Name = "shape7";
            this.shape7.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape8
            // 
            this.shape8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.0999212265014648D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape8.Name = "shape8";
            this.shape8.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape9
            // 
            this.shape9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape9.Name = "shape9";
            this.shape9.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape10
            // 
            this.shape10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape10.Name = "shape10";
            this.shape10.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape11
            // 
            this.shape11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape11.Name = "shape11";
            this.shape11.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape12
            // 
            this.shape12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.8000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape12.Name = "shape12";
            this.shape12.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // CKWastageReport
            // 
            this.DataSource = this.CKWastagesqlDataSource;
            group1.GroupFooter = this.ck_wastage_codeGroupFooterSection;
            group1.GroupHeader = this.ck_wastage_codeGroupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.ck_wastage_code"));
            group1.Name = "ck_wastage_codeGroup";
            group2.GroupFooter = this.wastage_dateGroupFooterSection;
            group2.GroupHeader = this.wastage_dateGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.wastage_date"));
            group2.Name = "wastage_dateGroup";
            group3.GroupFooter = this.ck_item_codeGroupFooterSection;
            group3.GroupHeader = this.ck_item_codeGroupHeaderSection;
            group3.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.ck_item_code"));
            group3.Name = "ck_item_codeGroup";
            group4.GroupFooter = this.labelsGroupFooterSection;
            group4.GroupHeader = this.labelsGroupHeaderSection;
            group4.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2,
            group3,
            group4});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ck_wastage_codeGroupHeaderSection,
            this.ck_wastage_codeGroupFooterSection,
            this.wastage_dateGroupHeaderSection,
            this.wastage_dateGroupFooterSection,
            this.ck_item_codeGroupHeaderSection,
            this.ck_item_codeGroupFooterSection,
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "CKWastageReport";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "ck_wastage_code";
            reportParameter1.Text = "ckwastagecode";
            reportParameter1.Visible = true;
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
            this.NeedDataSource += new System.EventHandler(this.CKWastageReport_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource CKWastagesqlDataSource;
        private Telerik.Reporting.GroupHeaderSection ck_wastage_codeGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection ck_wastage_codeGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection wastage_dateGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.GroupFooterSection wastage_dateGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection ck_item_codeGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.GroupFooterSection ck_item_codeGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox ck_item_descCaptionTextBox;
        private Telerik.Reporting.TextBox ck_prod_codeCaptionTextBox;
        private Telerik.Reporting.TextBox ck_batch_noCaptionTextBox;
        private Telerik.Reporting.TextBox ck_prod_dateCaptionTextBox;
        private Telerik.Reporting.TextBox ck_exp_dateCaptionTextBox;
        private Telerik.Reporting.TextBox wastage_qtyCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox ck_item_descDataTextBox;
        private Telerik.Reporting.TextBox ck_prod_codeDataTextBox;
        private Telerik.Reporting.TextBox ck_batch_noDataTextBox;
        private Telerik.Reporting.TextBox ck_prod_dateDataTextBox;
        private Telerik.Reporting.TextBox ck_exp_dateDataTextBox;
        private Telerik.Reporting.TextBox wastage_qtyDataTextBox;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.Shape shape3;
        private Telerik.Reporting.Shape shape4;
        private Telerik.Reporting.Shape shape5;
        private Telerik.Reporting.Shape shape6;
        private Telerik.Reporting.Shape shape7;
        private Telerik.Reporting.Shape shape8;
        private Telerik.Reporting.Shape shape9;
        private Telerik.Reporting.Shape shape10;
        private Telerik.Reporting.Shape shape11;
        private Telerik.Reporting.Shape shape12;
    }
}