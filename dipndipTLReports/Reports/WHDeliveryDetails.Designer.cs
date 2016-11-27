namespace dipndipTLReports.Reports
{
    partial class WHDeliveryDetails
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WHDeliveryDetails));
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
            this.OrderDetailsqlDataSource = new Telerik.Reporting.SqlDataSource();
            this.order_noGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.order_noGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.order_dateDateGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.order_dateDateGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.issue_dateDateGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.issue_dateDateGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.wh_item_codeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.wh_item_descriptionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.wh_unit_descriptionCaptionTextBox = new Telerik.Reporting.TextBox();
            this.qtyCaptionTextBox = new Telerik.Reporting.TextBox();
            this.qty_issuedCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.wh_item_codeDataTextBox = new Telerik.Reporting.TextBox();
            this.wh_item_descriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.wh_unit_descriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.qtyDataTextBox = new Telerik.Reporting.TextBox();
            this.qty_issuedDataTextBox = new Telerik.Reporting.TextBox();
            this.ParamsqlDataSource = new Telerik.Reporting.SqlDataSource();
            this.shape2 = new Telerik.Reporting.Shape();
            this.shape1 = new Telerik.Reporting.Shape();
            this.shape3 = new Telerik.Reporting.Shape();
            this.shape4 = new Telerik.Reporting.Shape();
            this.shape5 = new Telerik.Reporting.Shape();
            this.shape6 = new Telerik.Reporting.Shape();
            this.shape7 = new Telerik.Reporting.Shape();
            this.shape8 = new Telerik.Reporting.Shape();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // OrderDetailsqlDataSource
            // 
            this.OrderDetailsqlDataSource.ConnectionString = "dipndipTLReports.Properties.Settings.dipckConnectionString";
            this.OrderDetailsqlDataSource.Name = "OrderDetailsqlDataSource";
            this.OrderDetailsqlDataSource.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@order_no", System.Data.DbType.String, "= Parameters.order_no.Value")});
            this.OrderDetailsqlDataSource.SelectCommand = resources.GetString("OrderDetailsqlDataSource.SelectCommand");
            // 
            // order_noGroupHeaderSection
            // 
            this.order_noGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.order_noGroupHeaderSection.Name = "order_noGroupHeaderSection";
            // 
            // order_noGroupFooterSection
            // 
            this.order_noGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.order_noGroupFooterSection.Name = "order_noGroupFooterSection";
            // 
            // order_dateDateGroupHeaderSection
            // 
            this.order_dateDateGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.order_dateDateGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox4,
            this.textBox2,
            this.textBox1});
            this.order_dateDateGroupHeaderSection.Name = "order_dateDateGroupHeaderSection";
            // 
            // order_dateDateGroupFooterSection
            // 
            this.order_dateDateGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.order_dateDateGroupFooterSection.Name = "order_dateDateGroupFooterSection";
            // 
            // issue_dateDateGroupHeaderSection
            // 
            this.issue_dateDateGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.issue_dateDateGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox6});
            this.issue_dateDateGroupHeaderSection.Name = "issue_dateDateGroupHeaderSection";
            // 
            // issue_dateDateGroupFooterSection
            // 
            this.issue_dateDateGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.issue_dateDateGroupFooterSection.Name = "issue_dateDateGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77916675806045532D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Order No";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416667938232422D), Telerik.Reporting.Drawing.Unit.Inch(0.024949708953499794D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.order_no";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2208337783813477D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77916675806045532D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.StyleName = "Caption";
            this.textBox3.Value = "Order Date";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Format = "{0:dd/MM/yyyy}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "= Fields.order_date.Date";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2207545042037964D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "Delivery Date";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Format = "{0:dd/MM/yyyy}";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2416666746139526D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6583335399627686D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "= Fields.issue_date.Date";
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.wh_item_codeCaptionTextBox,
            this.wh_item_descriptionCaptionTextBox,
            this.wh_unit_descriptionCaptionTextBox,
            this.qtyCaptionTextBox,
            this.qty_issuedCaptionTextBox,
            this.shape1,
            this.shape3,
            this.shape5,
            this.shape7});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            this.labelsGroupHeaderSection.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelsGroupHeaderSection.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.labelsGroupHeaderSection.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // wh_item_codeCaptionTextBox
            // 
            this.wh_item_codeCaptionTextBox.CanGrow = true;
            this.wh_item_codeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wh_item_codeCaptionTextBox.Name = "wh_item_codeCaptionTextBox";
            this.wh_item_codeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87916672229766846D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_codeCaptionTextBox.Style.Font.Bold = true;
            this.wh_item_codeCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_item_codeCaptionTextBox.StyleName = "Caption";
            this.wh_item_codeCaptionTextBox.Value = "Item Code";
            // 
            // wh_item_descriptionCaptionTextBox
            // 
            this.wh_item_descriptionCaptionTextBox.CanGrow = true;
            this.wh_item_descriptionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wh_item_descriptionCaptionTextBox.Name = "wh_item_descriptionCaptionTextBox";
            this.wh_item_descriptionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_descriptionCaptionTextBox.Style.Font.Bold = true;
            this.wh_item_descriptionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_item_descriptionCaptionTextBox.StyleName = "Caption";
            this.wh_item_descriptionCaptionTextBox.Value = "Description";
            // 
            // wh_unit_descriptionCaptionTextBox
            // 
            this.wh_unit_descriptionCaptionTextBox.CanGrow = true;
            this.wh_unit_descriptionCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1000792980194092D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.wh_unit_descriptionCaptionTextBox.Name = "wh_unit_descriptionCaptionTextBox";
            this.wh_unit_descriptionCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80408728122711182D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_unit_descriptionCaptionTextBox.Style.Font.Bold = true;
            this.wh_unit_descriptionCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_unit_descriptionCaptionTextBox.StyleName = "Caption";
            this.wh_unit_descriptionCaptionTextBox.Value = "Unit";
            // 
            // qtyCaptionTextBox
            // 
            this.qtyCaptionTextBox.CanGrow = true;
            this.qtyCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.10007905960083D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.qtyCaptionTextBox.Name = "qtyCaptionTextBox";
            this.qtyCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.91658806800842285D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qtyCaptionTextBox.Style.Font.Bold = true;
            this.qtyCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.qtyCaptionTextBox.StyleName = "Caption";
            this.qtyCaptionTextBox.Value = "Order Qty";
            // 
            // qty_issuedCaptionTextBox
            // 
            this.qty_issuedCaptionTextBox.CanGrow = true;
            this.qty_issuedCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.039999999105930328D));
            this.qty_issuedCaptionTextBox.Name = "qty_issuedCaptionTextBox";
            this.qty_issuedCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2291668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedCaptionTextBox.Style.Font.Bold = true;
            this.qty_issuedCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.qty_issuedCaptionTextBox.StyleName = "Caption";
            this.qty_issuedCaptionTextBox.Value = "Delivered Qty";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
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
            this.reportNameTextBox.Value = "WHDeliveryDetails";
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
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.50000005960464478D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.40000012516975403D));
            this.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Warehouse Delivery Details";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.wh_item_codeDataTextBox,
            this.wh_item_descriptionDataTextBox,
            this.wh_unit_descriptionDataTextBox,
            this.qtyDataTextBox,
            this.qty_issuedDataTextBox,
            this.shape2,
            this.shape4,
            this.shape6,
            this.shape8});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // wh_item_codeDataTextBox
            // 
            this.wh_item_codeDataTextBox.CanGrow = true;
            this.wh_item_codeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D));
            this.wh_item_codeDataTextBox.Name = "wh_item_codeDataTextBox";
            this.wh_item_codeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87916654348373413D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_codeDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_item_codeDataTextBox.StyleName = "Data";
            this.wh_item_codeDataTextBox.Value = "= Fields.wh_item_code";
            // 
            // wh_item_descriptionDataTextBox
            // 
            this.wh_item_descriptionDataTextBox.CanGrow = true;
            this.wh_item_descriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D));
            this.wh_item_descriptionDataTextBox.Multiline = false;
            this.wh_item_descriptionDataTextBox.Name = "wh_item_descriptionDataTextBox";
            this.wh_item_descriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_item_descriptionDataTextBox.StyleName = "Data";
            this.wh_item_descriptionDataTextBox.Value = "= Fields.wh_item_description";
            // 
            // wh_unit_descriptionDataTextBox
            // 
            this.wh_unit_descriptionDataTextBox.CanGrow = true;
            this.wh_unit_descriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1000792980194092D), Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D));
            this.wh_unit_descriptionDataTextBox.Name = "wh_unit_descriptionDataTextBox";
            this.wh_unit_descriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80408728122711182D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wh_unit_descriptionDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.wh_unit_descriptionDataTextBox.StyleName = "Data";
            this.wh_unit_descriptionDataTextBox.Value = "= Fields.wh_unit_description";
            // 
            // qtyDataTextBox
            // 
            this.qtyDataTextBox.CanGrow = true;
            this.qtyDataTextBox.Format = "{0:N0}";
            this.qtyDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D));
            this.qtyDataTextBox.Name = "qtyDataTextBox";
            this.qtyDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.59992086887359619D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qtyDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.qtyDataTextBox.StyleName = "Data";
            this.qtyDataTextBox.Value = "= Fields.qty";
            // 
            // qty_issuedDataTextBox
            // 
            this.qty_issuedDataTextBox.CanGrow = true;
            this.qty_issuedDataTextBox.Format = "{0:N0}";
            this.qty_issuedDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D));
            this.qty_issuedDataTextBox.Name = "qty_issuedDataTextBox";
            this.qty_issuedDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.qty_issuedDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.qty_issuedDataTextBox.StyleName = "Data";
            this.qty_issuedDataTextBox.Value = "= Fields.qty_issued";
            // 
            // ParamsqlDataSource
            // 
            this.ParamsqlDataSource.ConnectionString = "dipndipTLReports.Properties.Settings.dipckConnectionString";
            this.ParamsqlDataSource.Name = "ParamsqlDataSource";
            this.ParamsqlDataSource.SelectCommand = "SELECT  order_no \r\nFROM orders";
            // 
            // shape2
            // 
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90000009536743164D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90000009536743164D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // shape3
            // 
            this.shape3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape3.Name = "shape3";
            this.shape3.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // shape4
            // 
            this.shape4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape4.Name = "shape4";
            this.shape4.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // shape5
            // 
            this.shape5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape5.Name = "shape5";
            this.shape5.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // shape6
            // 
            this.shape6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape6.Name = "shape6";
            this.shape6.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // shape7
            // 
            this.shape7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape7.Name = "shape7";
            this.shape7.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // shape8
            // 
            this.shape8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.shape8.Name = "shape8";
            this.shape8.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.shape8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.31000000238418579D));
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5791668891906738D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // WHDeliveryDetails
            // 
            this.DataSource = this.OrderDetailsqlDataSource;
            group1.GroupFooter = this.order_noGroupFooterSection;
            group1.GroupHeader = this.order_noGroupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.order_no"));
            group1.Name = "order_noGroup";
            group2.GroupFooter = this.order_dateDateGroupFooterSection;
            group2.GroupHeader = this.order_dateDateGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.order_date.Date"));
            group2.Name = "order_dateDateGroup";
            group3.GroupFooter = this.issue_dateDateGroupFooterSection;
            group3.GroupHeader = this.issue_dateDateGroupHeaderSection;
            group3.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.issue_date.Date"));
            group3.Name = "issue_dateDateGroup";
            group4.GroupFooter = this.labelsGroupFooterSection;
            group4.GroupHeader = this.labelsGroupHeaderSection;
            group4.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2,
            group3,
            group4});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.order_noGroupHeaderSection,
            this.order_noGroupFooterSection,
            this.order_dateDateGroupHeaderSection,
            this.order_dateDateGroupFooterSection,
            this.issue_dateDateGroupHeaderSection,
            this.issue_dateDateGroupFooterSection,
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "WHDeliveryDetails";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AvailableValues.DataSource = this.ParamsqlDataSource;
            reportParameter1.AvailableValues.DisplayMember = "= Fields.order_no";
            reportParameter1.AvailableValues.ValueMember = "= Fields.order_no";
            reportParameter1.Name = "order_no";
            reportParameter1.Text = "Order No";
            reportParameter1.Value = "= Fields.order_no";
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
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource OrderDetailsqlDataSource;
        private Telerik.Reporting.GroupHeaderSection order_noGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection order_noGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection order_dateDateGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.GroupFooterSection order_dateDateGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection issue_dateDateGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.GroupFooterSection issue_dateDateGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox wh_item_codeCaptionTextBox;
        private Telerik.Reporting.TextBox wh_item_descriptionCaptionTextBox;
        private Telerik.Reporting.TextBox wh_unit_descriptionCaptionTextBox;
        private Telerik.Reporting.TextBox qtyCaptionTextBox;
        private Telerik.Reporting.TextBox qty_issuedCaptionTextBox;
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
        private Telerik.Reporting.TextBox wh_item_codeDataTextBox;
        private Telerik.Reporting.TextBox wh_item_descriptionDataTextBox;
        private Telerik.Reporting.TextBox wh_unit_descriptionDataTextBox;
        private Telerik.Reporting.TextBox qtyDataTextBox;
        private Telerik.Reporting.TextBox qty_issuedDataTextBox;
        private Telerik.Reporting.SqlDataSource ParamsqlDataSource;
        private Telerik.Reporting.Shape shape2;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.Shape shape3;
        private Telerik.Reporting.Shape shape4;
        private Telerik.Reporting.Shape shape5;
        private Telerik.Reporting.Shape shape7;
        private Telerik.Reporting.Shape shape6;
        private Telerik.Reporting.Shape shape8;
        private Telerik.Reporting.PictureBox pictureBox1;
    }
}