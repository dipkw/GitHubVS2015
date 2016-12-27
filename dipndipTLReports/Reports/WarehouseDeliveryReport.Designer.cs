namespace dipndipTLReports.Reports
{
    partial class WarehouseDeliveryReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseDeliveryReport));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.WHDeliverysqlDataSource = new Telerik.Reporting.SqlDataSource();
            this.order_noGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.order_noGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.wh_item_descriptionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.unit_descriptionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.wh_item_unit_idCaptionTextBox = new Telerik.Reporting.TextBox();
            this.order_qtyCaptionTextBox = new Telerik.Reporting.TextBox();
            this.delivered_qtyCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.wh_item_descriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.unit_descriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.wh_item_unit_idDataTextBox = new Telerik.Reporting.TextBox();
            this.order_qtyDataTextBox = new Telerik.Reporting.TextBox();
            this.delivered_qtyDataTextBox = new Telerik.Reporting.TextBox();
            this.paramsqlDataSource = new Telerik.Reporting.SqlDataSource();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.shape2 = new Telerik.Reporting.Shape();
            this.shape3 = new Telerik.Reporting.Shape();
            this.shape4 = new Telerik.Reporting.Shape();
            this.shape5 = new Telerik.Reporting.Shape();
            this.shape6 = new Telerik.Reporting.Shape();
            this.shape7 = new Telerik.Reporting.Shape();
            this.shape8 = new Telerik.Reporting.Shape();
            this.textBox7 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // WHDeliverysqlDataSource
            // 
            this.WHDeliverysqlDataSource.ConnectionString = "dipndipTLReports.Properties.Settings.dipckConnectionString";
            this.WHDeliverysqlDataSource.Name = "WHDeliverysqlDataSource";
            this.WHDeliverysqlDataSource.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@param_order_no", System.Data.DbType.String, "= Parameters.param_order_no.Value")});
            this.WHDeliverysqlDataSource.SelectCommand = resources.GetString("WHDeliverysqlDataSource.SelectCommand");
            // 
            // order_noGroupHeaderSection
            // 
            this.order_noGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.order_noGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6});
            this.order_noGroupHeaderSection.Name = "order_noGroupHeaderSection";
            // 
            // order_noGroupFooterSection
            // 
            this.order_noGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.375D);
            this.order_noGroupFooterSection.Name = "order_noGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77908796072006226D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Order No";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.79999995231628418D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0583336353302002D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.order_no";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.wh_item_descriptionCaptionTextBox,
            this.unit_descriptionCaptionTextBox,
            this.wh_item_unit_idCaptionTextBox,
            this.order_qtyCaptionTextBox,
            this.delivered_qtyCaptionTextBox,
            this.shape1,
            this.shape2,
            this.shape3,
            this.shape4});
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
            // wh_item_descriptionCaptionTextBox
            // 
            this.wh_item_descriptionCaptionTextBox.CanGrow = true;
            this.wh_item_descriptionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wh_item_descriptionCaptionTextBox.Name = "wh_item_descriptionCaptionTextBox";
            this.wh_item_descriptionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0791666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_descriptionCaptionTextBox.Style.Font.Bold = true;
            this.wh_item_descriptionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_item_descriptionCaptionTextBox.StyleName = "Caption";
            this.wh_item_descriptionCaptionTextBox.Value = "Item Code";
            // 
            // unit_descriptionCaptionTextBox
            // 
            this.unit_descriptionCaptionTextBox.CanGrow = true;
            this.unit_descriptionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.unit_descriptionCaptionTextBox.Name = "unit_descriptionCaptionTextBox";
            this.unit_descriptionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1999213695526123D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.unit_descriptionCaptionTextBox.Style.Font.Bold = true;
            this.unit_descriptionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.unit_descriptionCaptionTextBox.StyleName = "Caption";
            this.unit_descriptionCaptionTextBox.Value = "Description";
            // 
            // wh_item_unit_idCaptionTextBox
            // 
            this.wh_item_unit_idCaptionTextBox.CanGrow = true;
            this.wh_item_unit_idCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wh_item_unit_idCaptionTextBox.Name = "wh_item_unit_idCaptionTextBox";
            this.wh_item_unit_idCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_unit_idCaptionTextBox.Style.Font.Bold = true;
            this.wh_item_unit_idCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_item_unit_idCaptionTextBox.StyleName = "Caption";
            this.wh_item_unit_idCaptionTextBox.Value = "Unit";
            // 
            // order_qtyCaptionTextBox
            // 
            this.order_qtyCaptionTextBox.CanGrow = true;
            this.order_qtyCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.order_qtyCaptionTextBox.Name = "order_qtyCaptionTextBox";
            this.order_qtyCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.9466666579246521D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.order_qtyCaptionTextBox.Style.Font.Bold = true;
            this.order_qtyCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.order_qtyCaptionTextBox.StyleName = "Caption";
            this.order_qtyCaptionTextBox.Value = "Qty Ordered";
            // 
            // delivered_qtyCaptionTextBox
            // 
            this.delivered_qtyCaptionTextBox.CanGrow = true;
            this.delivered_qtyCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.delivered_qtyCaptionTextBox.Name = "delivered_qtyCaptionTextBox";
            this.delivered_qtyCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0375000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.delivered_qtyCaptionTextBox.Style.Font.Bold = true;
            this.delivered_qtyCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.delivered_qtyCaptionTextBox.StyleName = "Caption";
            this.delivered_qtyCaptionTextBox.Value = "Qty Delivered";
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
            this.reportNameTextBox.Value = "WarehouseDeliveryReport";
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
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.textBox7});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Warehouse Delivery Report";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.wh_item_descriptionDataTextBox,
            this.unit_descriptionDataTextBox,
            this.wh_item_unit_idDataTextBox,
            this.order_qtyDataTextBox,
            this.delivered_qtyDataTextBox,
            this.shape5,
            this.shape6,
            this.shape7,
            this.shape8});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // wh_item_descriptionDataTextBox
            // 
            this.wh_item_descriptionDataTextBox.CanGrow = true;
            this.wh_item_descriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wh_item_descriptionDataTextBox.Name = "wh_item_descriptionDataTextBox";
            this.wh_item_descriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0791666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_descriptionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_item_descriptionDataTextBox.StyleName = "Data";
            this.wh_item_descriptionDataTextBox.Value = "= Fields.wh_item_code";
            // 
            // unit_descriptionDataTextBox
            // 
            this.unit_descriptionDataTextBox.CanGrow = false;
            this.unit_descriptionDataTextBox.CanShrink = true;
            this.unit_descriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.unit_descriptionDataTextBox.Name = "unit_descriptionDataTextBox";
            this.unit_descriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1999213695526123D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.unit_descriptionDataTextBox.StyleName = "Data";
            this.unit_descriptionDataTextBox.Value = "= Fields.wh_item_description";
            // 
            // wh_item_unit_idDataTextBox
            // 
            this.wh_item_unit_idDataTextBox.CanGrow = true;
            this.wh_item_unit_idDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wh_item_unit_idDataTextBox.Name = "wh_item_unit_idDataTextBox";
            this.wh_item_unit_idDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.46041673421859741D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_unit_idDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_item_unit_idDataTextBox.StyleName = "Data";
            this.wh_item_unit_idDataTextBox.Value = "= Fields.unit_description";
            // 
            // order_qtyDataTextBox
            // 
            this.order_qtyDataTextBox.CanGrow = true;
            this.order_qtyDataTextBox.Format = "{0:N0}";
            this.order_qtyDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.5000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.order_qtyDataTextBox.Name = "order_qtyDataTextBox";
            this.order_qtyDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49999961256980896D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.order_qtyDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.order_qtyDataTextBox.StyleName = "Data";
            this.order_qtyDataTextBox.Value = "= Fields.order_qty";
            // 
            // delivered_qtyDataTextBox
            // 
            this.delivered_qtyDataTextBox.CanGrow = true;
            this.delivered_qtyDataTextBox.Format = "{0:N0}";
            this.delivered_qtyDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.delivered_qtyDataTextBox.Name = "delivered_qtyDataTextBox";
            this.delivered_qtyDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5000002384185791D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.delivered_qtyDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.delivered_qtyDataTextBox.StyleName = "Data";
            this.delivered_qtyDataTextBox.Value = "= Fields.delivered_qty";
            // 
            // paramsqlDataSource
            // 
            this.paramsqlDataSource.ConnectionString = "dipndipTLReports.Properties.Settings.dipckConnectionString";
            this.paramsqlDataSource.Name = "paramsqlDataSource";
            this.paramsqlDataSource.SelectCommand = "SELECT [order_no]\r\n  FROM [dipck].[dbo].[orders]\r\n  WHERE active = 1 AND order_fr" +
    "om_site_id = 3";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Format = "{0:dd/MM/yyyy}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.010515213012695313D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1583335399627686D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.StyleName = "Data";
            this.textBox3.Value = "= Fields.order_date.Date.Date";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Format = "{0:dd/MM/yyyy}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.010515213012695313D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1583335399627686D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "= Fields.issue_date.Date.Date";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8584123849868774D), Telerik.Reporting.Drawing.Unit.Inch(0.010515213012695313D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.94158768653869629D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "Order Date";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.010515213012695313D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1499996185302734D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.StyleName = "Caption";
            this.textBox6.Value = "Delivered Date";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5791668891906738D), Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D));
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1000789403915405D), Telerik.Reporting.Drawing.Unit.Inch(0.0012105306377634406D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape2
            // 
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.4000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape3
            // 
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape4
            // 
            this.shape4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape4.Name = "shape4";
            this.shape4.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape5
            // 
            this.shape5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape5.Name = "shape5";
            this.shape5.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape6
            // 
            this.shape6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.4000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape6.Name = "shape6";
            this.shape6.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape7
            // 
            this.shape7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape7.Name = "shape7";
            this.shape7.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // shape8
            // 
            this.shape8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3000006675720215D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape8.Name = "shape8";
            this.shape8.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.020833397284150124D), Telerik.Reporting.Drawing.Unit.Inch(0.44999998807907104D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Value = "Delivered To {Fields.site_name}";
            // 
            // WarehouseDeliveryReport
            // 
            this.DataSource = this.WHDeliverysqlDataSource;
            group1.GroupFooter = this.order_noGroupFooterSection;
            group1.GroupHeader = this.order_noGroupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.order_no"));
            group1.Name = "order_noGroup";
            group2.GroupFooter = this.labelsGroupFooterSection;
            group2.GroupHeader = this.labelsGroupHeaderSection;
            group2.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.order_noGroupHeaderSection,
            this.order_noGroupFooterSection,
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "WarehouseDeliveryReport";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AllowNull = true;
            reportParameter1.AvailableValues.DataSource = this.paramsqlDataSource;
            reportParameter1.AvailableValues.DisplayMember = "= Fields.order_no";
            reportParameter1.AvailableValues.ValueMember = "= Fields.order_no";
            reportParameter1.Name = "param_order_no";
            reportParameter1.Text = "Order No";
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
            this.NeedDataSource += new System.EventHandler(this.WarehouseDeliveryReport_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource WHDeliverysqlDataSource;
        private Telerik.Reporting.GroupHeaderSection order_noGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection order_noGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox wh_item_descriptionCaptionTextBox;
        private Telerik.Reporting.TextBox unit_descriptionCaptionTextBox;
        private Telerik.Reporting.TextBox wh_item_unit_idCaptionTextBox;
        private Telerik.Reporting.TextBox order_qtyCaptionTextBox;
        private Telerik.Reporting.TextBox delivered_qtyCaptionTextBox;
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
        private Telerik.Reporting.TextBox wh_item_descriptionDataTextBox;
        private Telerik.Reporting.TextBox unit_descriptionDataTextBox;
        private Telerik.Reporting.TextBox wh_item_unit_idDataTextBox;
        private Telerik.Reporting.TextBox order_qtyDataTextBox;
        private Telerik.Reporting.TextBox delivered_qtyDataTextBox;
        private Telerik.Reporting.SqlDataSource paramsqlDataSource;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.Shape shape3;
        private Telerik.Reporting.Shape shape4;
        private Telerik.Reporting.Shape shape5;
        private Telerik.Reporting.Shape shape6;
        private Telerik.Reporting.Shape shape7;
        private Telerik.Reporting.Shape shape8;
        private Telerik.Reporting.TextBox textBox7;
    }
}