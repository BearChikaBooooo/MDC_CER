<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER_PAGE/MAIN_UNSEC.Master" CodeBehind="FRM_CMT_SEARCH_UNSEC.aspx.vb" Inherits="FDA_SIP_SPECIFIC.FRM_CMT_SEARCH_UNSEC" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table"><tr><td>เลขจดแจ้ง</td><td>
        <asp:TextBox ID="txt_regnos" runat="server" CssClass="input-lg"></asp:TextBox>
        </td><td rowspan="3">
            <asp:Button ID="Button1" runat="server" Height="222px" Text="ค้นหา" Width="231px" CssClass="btn-lg" />
        </td></tr><tr><td>ชื่อผลิตภัณฑ์ไทย</td><td>
        <asp:TextBox ID="txt_thai" runat="server" CssClass="input-lg"></asp:TextBox>
            </td></tr><tr><td>ชื่อผลิตภัณฑ์อังกฤษ</td><td>
        <asp:TextBox ID="txt_eng" runat="server" CssClass="input-lg"></asp:TextBox>
            </td></tr><tr><td colspan="3">
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" >
<MasterTableView datakeynames="IDA">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>

        <telerik:GridBoundColumn DataField="NewCode" FilterControlAltText="Filter NewCode column" HeaderText="รหัสอ้างอิง" SortExpression="NewCode" UniqueName="NewCode">
        

        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="lctnmno" DataType="System.Int32" FilterControlAltText="Filter lctnmno column" HeaderText="เลขสถานที่" SortExpression="lctnmno" UniqueName="lctnmno">



        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" Display="false" HeaderText="lcnsid" SortExpression="lcnsid" UniqueName="lcnsid">
         

        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="regnos" FilterControlAltText="Filter regnos column" HeaderText="เลขจดแจ้ง" SortExpression="regnos" UniqueName="regnos">
     

     
        </telerik:GridBoundColumn>
 
        <telerik:GridBoundColumn DataField="Brand_Tha" FilterControlAltText="Filter Brand_Tha column" HeaderText="Brand TH" SortExpression="Brand_Tha" UniqueName="Brand_Tha">
     

     
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Brand_Eng" FilterControlAltText="Filter Brand_Eng column" HeaderText="Brand_Eng" SortExpression="Brand_Eng" UniqueName="Brand_Eng">
     

     
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Productmain_tha" FilterControlAltText="Filter Productmain_tha column" HeaderText="ชื่อผลิตภัณฑ์ไทย" SortExpression="Productmain_tha" UniqueName="Productmain_tha">
        

        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Productmain_eng" FilterControlAltText="Filter Productmain_eng column" HeaderText="ชื่อผลิตภัณฑ์อังกฤษ" SortExpression="Productmain_eng" UniqueName="Productmain_eng">

     
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="producttha" FilterControlAltText="Filter producttha column" HeaderText="ชื่อแนบท้ายไทย" SortExpression="producttha" UniqueName="producttha">
     

     
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="producteng" FilterControlAltText="Filter producteng column" HeaderText="ชื่อแนบท้ายอังกฤษ" SortExpression="producteng" UniqueName="producteng">
    
    
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="Itemno" DataType="System.Int32" FilterControlAltText="Filter Itemno column" HeaderText="ลำดับแนบท้าย" SortExpression="Itemno" UniqueName="Itemno">

        </telerik:GridBoundColumn>




        <telerik:GridBoundColumn DataField="appvdate" DataType="System.DateTime" 
            FilterControlAltText="Filter appvdate column" HeaderText="วันที่อนุมัติ" SortExpression="appvdate" UniqueName="appvdate">
           
        </telerik:GridBoundColumn>
   

    
       

    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>
           
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FDA_XMLConnectionString %>" SelectCommand="SELECT * FROM [XML_CMT]"></asp:SqlDataSource>
        </td></tr></table>
</asp:Content>
