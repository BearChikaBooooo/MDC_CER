<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER_PAGE/MAIN_STAFF.Master"   CodeBehind="REPLACEMENT_STATION.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.REPLACEMENT_STATION" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             $(window).load(function () {
                 $.ajax({
                     type: 'POST',
                     data: { submit: true },
                     success: function (result) {
                         $('#spinner').fadeOut('slow');
                     }
                 });
             });

             $('#ContentPlaceHolder1_btn_download').click(function () {
                 $('#spinner').fadeIn('slow');
             });

             $('#ContentPlaceHolder1_btn_download_keep').click(function () {
                 $('#spinner').fadeIn('slow');
             });
         });

         function Popups(url) { // สำหรับทำ Div Popup
             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }

         function close_modal() { // คำสั่งสั่งปิด PopUp
             $('#myModal').modal('hide');
             //alert('เข้ามั๊ย');
             $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }

         function close_modal_keep() { // คำสั่งสั่งปิด PopUp
             $('#myModal').modal('hide');
             $('#ContentPlaceHolder1_btn_reload_keep').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }

         //ปิด spin
         function closespinner() {
             $('#spinner').fadeOut('slow');
             alert('ดาวน์โหลดเรียบร้อยแล้ว');
             $('#ContentPlaceHolder1_bnt_Close').click();

         }

         //ปิด spin
         function redownload() {
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_bnt_Close').click();

         }

         //ปิด spin
         function closespinner_keep() {
             $('#spinner').fadeOut('slow');
             alert('ดาวน์โหลดเรียบร้อยแล้ว');
             $('#ContentPlaceHolder1_bnt_Close_keep').click();

         }

         //ปิด spin
         function redownload_keep() {
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_bnt_Close_keep').click();

         }
    </script>
    <div class="panel panel-default">
        <div class="panel-heading">ใบรับเรื่องแทนผู้ประกอบการ (<asp:Label ID="lbl_process" runat="server" Text=""></asp:Label>) </div>
            <hr />
      
    <table class="table" style="width:100%;">
        <tr>
            <td style="width:25%;"></td>
            <td style="width:25%;">เลขนิติบุคคล/เลขบัตรประชาชน ผู้รับอนุญาต</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_search" runat="server"  CssClass="input-lg" ></asp:TextBox></td>
            <td style="width:25%;"> </td>
               
        </tr>
          <tr>
            <td style="width:25%;"></td>
            <td style="width:25%;">เลขบัตรประชาชน ผู้ดำเนินกิจการ</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_bsn" runat="server"  CssClass="input-lg" ></asp:TextBox></td>
            <td style="width:25%;">
                </td>
        </tr>
          <tr>
            <td  colspan="4" style="text-align:center;">
                 <asp:Button ID="btn_SEARCH" runat="server" Text="ค้นหา" CssClass="input-lg" />

            </td>
          
        </tr>
          <tr>
            <td colspan="4">
    <p class="h3">ชื่อผู้ประกอบการ</p>
                <hr />
    <telerik:RadGrid ID="rg_name" runat="server">
<MasterTableView autogeneratecolumns="False" datakeynames="ID">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid" 
            SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="ID_main" DataType="System.Int32" FilterControlAltText="Filter ID_main column" HeaderText="ID_main" 
            SortExpression="ID_main" UniqueName="ID_main" Display="false">
        
        </telerik:GridBoundColumn>
                  
         <telerik:GridBoundColumn DataField="fullname" FilterControlAltText="Filter fullname column" HeaderText="ชื่อผู้ประกอบการ" ReadOnly="True" SortExpression="fullname" UniqueName="fullname">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
               


        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column"
             HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
     
        <telerik:GridBoundColumn DataField="IDENTIFY" FilterControlAltText="Filter IDENTIFY column" 
            HeaderText="IDENTIFY" SortExpression="IDENTIFY" UniqueName="IDENTIFY" Display="true">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

 
              
        <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:Button ID="btn_SELECT" runat="server" Text="เลือกข้อมูล" CommandName="sel" />
                <%--<asp:HyperLink ID="HL_SELECT"  runat="server">เลือกข้อมูล</asp:HyperLink>--%>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
            
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
           </telerik:RadGrid>


                <br />
                 
        </tr>
        <tr>
            <td  colspan="4">
            <%--<p class="h3">สถานประกอบการ</p>--%>
                <hr />
    <telerik:RadGrid ID="rg_local" runat="server">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA" 
            SortExpression="IDA" UniqueName="IDA" Display="false">
        
        </telerik:GridBoundColumn>
       
        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid" 
SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
       
        </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="rgtno_display" FilterControlAltText="Filter rgtno_display column" HeaderText="เลขที่อนุญาต" ReadOnly="True" SortExpression="rgtno_display" UniqueName="rgtno_display">
        
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="rgtno" FilterControlAltText="Filter rgtno column" HeaderText="rgtno" ReadOnly="True" SortExpression="rgtno" UniqueName="rgtno" Display="false">
       
        </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="rgttpcd" FilterControlAltText="Filter rgttpcd column" HeaderText="rgttpcd" ReadOnly="True" SortExpression="rgttpcd" UniqueName="rgttpcd" Display="false">
          
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column" HeaderText="ชื่อสถานประกอบการ" ReadOnly="True" SortExpression="thanm" UniqueName="thanm">
        </telerik:GridBoundColumn>
               
     
        <telerik:GridBoundColumn DataField="IDENTIFY" FilterControlAltText="Filter IDENTIFY column" 
            HeaderText="IDENTIFY" SortExpression="IDENTIFY" UniqueName="IDENTIFY" Display="true">
        </telerik:GridBoundColumn>              
        <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:Button ID="btn_SELECT_2" runat="server" Text="เลือกข้อมูล" CommandName="Select" />
                <%--<asp:HyperLink ID="HL_SELECT"  runat="server">เลือกข้อมูล</asp:HyperLink>--%>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
            
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
           </telerik:RadGrid>
            </td>
        </tr>
          </table>
        </div>

 
</asp:Content>
