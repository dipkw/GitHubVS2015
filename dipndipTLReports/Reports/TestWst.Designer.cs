namespace dipndipTLReports.Reports
{
    partial class TestWst
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestWst));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ck_item_codeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_item_descCaptionTextBox = new Telerik.Reporting.TextBox();
            this.wastage_qtyCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_item_unit_costCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ck_item_total_costCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.ck_item_codeDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_item_descDataTextBox = new Telerik.Reporting.TextBox();
            this.wastage_qtyDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_item_unit_costDataTextBox = new Telerik.Reporting.TextBox();
            this.ck_item_total_costDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "dipndipTLReports.Properties.Settings.dipckcon";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.SelectCommand = resources.GetString("sqlDataSource1.SelectCommand");
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ck_item_codeCaptionTextBox,
            this.ck_item_descCaptionTextBox,
            this.wastage_qtyCaptionTextBox,
            this.ck_item_unit_costCaptionTextBox,
            this.ck_item_total_costCaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // ck_item_codeCaptionTextBox
            // 
            this.ck_item_codeCaptionTextBox.CanGrow = true;
            this.ck_item_codeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_codeCaptionTextBox.Name = "ck_item_codeCaptionTextBox";
            this.ck_item_codeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_codeCaptionTextBox.StyleName = "Caption";
            this.ck_item_codeCaptionTextBox.Value = "ck_item_code";
            // 
            // ck_item_descCaptionTextBox
            // 
            this.ck_item_descCaptionTextBox.CanGrow = true;
            this.ck_item_descCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3083332777023315D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_descCaptionTextBox.Name = "ck_item_descCaptionTextBox";
            this.ck_item_descCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_descCaptionTextBox.StyleName = "Caption";
            this.ck_item_descCaptionTextBox.Value = "ck_item_desc";
            // 
            // wastage_qtyCaptionTextBox
            // 
            this.wastage_qtyCaptionTextBox.CanGrow = true;
            this.wastage_qtyCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5958333015441895D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.wastage_qtyCaptionTextBox.Name = "wastage_qtyCaptionTextBox";
            this.wastage_qtyCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wastage_qtyCaptionTextBox.StyleName = "Caption";
            this.wastage_qtyCaptionTextBox.Value = "wastage_qty";
            // 
            // ck_item_unit_costCaptionTextBox
            // 
            this.ck_item_unit_costCaptionTextBox.CanGrow = true;
            this.ck_item_unit_costCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8833334445953369D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_unit_costCaptionTextBox.Name = "ck_item_unit_costCaptionTextBox";
            this.ck_item_unit_costCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_unit_costCaptionTextBox.StyleName = "Caption";
            this.ck_item_unit_costCaptionTextBox.Value = "ck_item_unit_cost";
            // 
            // ck_item_total_costCaptionTextBox
            // 
            this.ck_item_total_costCaptionTextBox.CanGrow = true;
            this.ck_item_total_costCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_total_costCaptionTextBox.Name = "ck_item_total_costCaptionTextBox";
            this.ck_item_total_costCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_total_costCaptionTextBox.StyleName = "Caption";
            this.ck_item_total_costCaptionTextBox.Value = "ck_item_total_cost";
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
            this.reportNameTextBox.Value = "TestWst";
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
            this.titleTextBox.Value = "TestWst";
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
            this.ck_item_codeDataTextBox,
            this.ck_item_descDataTextBox,
            this.wastage_qtyDataTextBox,
            this.ck_item_unit_costDataTextBox,
            this.ck_item_total_costDataTextBox});
            this.detail.Name = "detail";
            // 
            // ck_item_codeDataTextBox
            // 
            this.ck_item_codeDataTextBox.CanGrow = true;
            this.ck_item_codeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_codeDataTextBox.Name = "ck_item_codeDataTextBox";
            this.ck_item_codeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_codeDataTextBox.StyleName = "Data";
            this.ck_item_codeDataTextBox.Value = "= Fields.ck_item_code";
            // 
            // ck_item_descDataTextBox
            // 
            this.ck_item_descDataTextBox.CanGrow = true;
            this.ck_item_descDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3083332777023315D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_descDataTextBox.Name = "ck_item_descDataTextBox";
            this.ck_item_descDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_descDataTextBox.StyleName = "Data";
            this.ck_item_descDataTextBox.Value = "= Fields.ck_item_desc";
            // 
            // wastage_qtyDataTextBox
            // 
            this.wastage_qtyDataTextBox.CanGrow = true;
            this.wastage_qtyDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5958333015441895D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.wastage_qtyDataTextBox.Name = "wastage_qtyDataTextBox";
            this.wastage_qtyDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.wastage_qtyDataTextBox.StyleName = "Data";
            this.wastage_qtyDataTextBox.Value = "= Fields.wastage_qty";
            // 
            // ck_item_unit_costDataTextBox
            // 
            this.ck_item_unit_costDataTextBox.CanGrow = true;
            this.ck_item_unit_costDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8833334445953369D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_unit_costDataTextBox.Name = "ck_item_unit_costDataTextBox";
            this.ck_item_unit_costDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_unit_costDataTextBox.StyleName = "Data";
            this.ck_item_unit_costDataTextBox.Value = "= Fields.ck_item_unit_cost";
            // 
            // ck_item_total_costDataTextBox
            // 
            this.ck_item_total_costDataTextBox.CanGrow = true;
            this.ck_item_total_costDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1708331108093262D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.ck_item_total_costDataTextBox.Name = "ck_item_total_costDataTextBox";
            this.ck_item_total_costDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2666666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ck_item_total_costDataTextBox.StyleName = "Data";
            this.ck_item_total_costDataTextBox.Value = "= Fields.ck_item_total_cost";
            // 
            // TestWst
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "TestWst";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
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

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox ck_item_codeCaptionTextBox;
        private Telerik.Reporting.TextBox ck_item_descCaptionTextBox;
        private Telerik.Reporting.TextBox wastage_qtyCaptionTextBox;
        private Telerik.Reporting.TextBox ck_item_unit_costCaptionTextBox;
        private Telerik.Reporting.TextBox ck_item_total_costCaptionTextBox;
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
        private Telerik.Reporting.TextBox ck_item_codeDataTextBox;
        private Telerik.Reporting.TextBox ck_item_descDataTextBox;
        private Telerik.Reporting.TextBox wastage_qtyDataTextBox;
        private Telerik.Reporting.TextBox ck_item_unit_costDataTextBox;
        private Telerik.Reporting.TextBox ck_item_total_costDataTextBox;
    }
}