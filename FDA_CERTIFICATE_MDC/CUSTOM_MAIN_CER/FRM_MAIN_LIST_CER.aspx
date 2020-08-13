<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER_PAGE/MAIN.Master" CodeBehind="FRM_MAIN_LIST_CER.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_MAIN_LIST_CER" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../UC/UC_INFORMATION.ascx" tagname="UC_INFORMATION" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style>

.btn-choose:link, .btn-choose:visited {
    background-color:#d9d9d9;
    color: white;
    padding:10px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    width:100%;
    
}
.cb:checked:disabled{
    background-color:black;
    
}


.btn-choose:hover, .btn-choose:active {
    width:100%;
    background-color:#d3eef5;
}

        .btn-down-upload {
            padding:10px 16px;
            width:150px;
            border-style:solid;
            border-color:#D9D9D9;
            cursor:pointer;
            font-size:18px;
            line-height:1.33;
            border-radius:18px;
        }
        .btn-down-upload:hover {
            background-color:#d3eef5;
            border-color:#d3eef5;
        }

        .font_hp{
            color:dodgerblue 
        }
        .font_hp:hover{
            color:cornflowerblue
        }


</style>
    <script type="text/javascript" >
                var getUrlParameter = function getUrlParameter(sParam) {
                    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
                        sURLVariables = sPageURL.split('&'),
                        sParameterName,
                        i;

                    for (i = 0; i < sURLVariables.length; i++) {
                        sParameterName = sURLVariables[i].split('=');

                        if (sParameterName[0] === sParam) {
                            return sParameterName[1] === undefined ? true : sParameterName[1];
                        }
                    }
                };

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

                    function CloseSpin() {
                        $('#spinner').toggle('slow');
                    }

                    $('#ContentPlaceHolder1_BTN_UP').click(function () {

                        //  $('#spinner').toggle('slow');
                        //var paramiter;
                        //paramiter = getUrlParameter('P_ID');
                        //staff_apm = getUrlParameter("STAFF_APM");
                        //Popups2('FRM_POPUP_UPLOAD.aspx?P_ID=' + paramiter + "&STAFF_APM=" + staff_apm);
                        //return false;
                    });

                    $('#ContentPlaceHolder1_BTN_DOWN').click(function () {
                        $('#spinner').fadeIn('slow');

                    });

                    


                });
                function Popups(url) { // สำหรับทำ Div Popup
                    $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                    var i = $('#f1'); // ID ของ iframe   
                    i.attr("src", url); //  url ของ form ที่จะเปิด
                }


                function Popups2(url) { // สำหรับทำ Div Popup
                    $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                    var i = $('#f1'); // ID ของ iframe   
                    i.attr("src", url); //  url ของ form ที่จะเปิด
                }
                function close_modal() { // คำสั่งสั่งปิด PopUp
                    $('#myModal').modal('hide');
                    $('#ContentPlaceHolder1_btn_return').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                    $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                }
                function spin_space() { // คำสั่งสั่งปิด PopUp
                    //    alert('123456');
                    $('#spinner').toggle('slow');
                    //$('#myModal').modal('hide');
                    //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                }
                function closespinner() {
                    $('#spinner').fadeOut('slow');
                    alert('Download Success');
                    $('#ContentPlaceHolder1_Button1').click();

                }
                function open_new_tap() { // คำสั่งสั่งปิด PopUp
                    //$('#myModal').modal('hide');
                    //$('#myModal2').modal('hide');
                    $('#ContentPlaceHolder1_btn_new_pay').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click btn_close_popup btn_close_popup_send
                    //$('#ContentPlaceHolder1_btn_close_popup').click();
                    //$('#ContentPlaceHolder1_btn_close_popup_send').click();
                }
        </script>
    <asp:Button ID="btn_reload" runat="server" Text="reload" style="display:none;"/>
      <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
      <asp:Button ID="btn_new_pay" runat="server" OnClientClick="OpenPopup1();" hidden="true"  Text="Button" />
        <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../Desigh/imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 600px; height: 185px; width: 207px;" />
    </div>

    <%--<uc1:UC_INFORMATION ID="UC_INFORMATION1" runat="server" />--%>
    <table class="table">
        
        <tr><td style="width:40%;">
            
            <%--<asp:Label ID="Label1" runat="server" Text="" Font-Size="XX-Large"></asp:Label>--%>
            
            </td><td style="text-align:right;">
             <%--<asp:Button ID="BTN_EXCEL" runat="server" Text="DOWNLOAD EXCEL" Width="150px"  CssClass="btn-down-upload" />--%>
                
                <asp:Button ID="BTN_DOWN" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px"  CssClass="btn-down-upload" />
&nbsp;
&nbsp;
               <%-- <asp:Button ID="BTN_EXCEL" runat="server" Text="ดาวน์โหลด Excel รายละเอียดเครื่องมือแพทย์" Width="170px"  CssClass="btn-down-upload" />
&nbsp;
&nbsp;--%>
                <asp:Button ID="BTN_UP" runat="server" Text="อัพโหลดคำขอ" Width="170px"  CssClass="btn-down-upload" />
            </td>

        </tr>

        <tr><td colspan="2">
            
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" AutoGenerateColumns="False" >
<MasterTableView DataKeyNames="IDA" >
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" Display="false" 
            FilterControlAltText="Filter IDA column" HeaderText="IDA" ReadOnly="True"
             SortExpression="IDA" UniqueName="IDA">
         
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="RCVNO" DataType="System.String" FilterControlAltText="Filter RCVNO column" HeaderText="เลขรับ" SortExpression="RCVNO" UniqueName="RCVNO">
    
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="RCVDATE" DataType="System.DateTime" FilterControlAltText="Filter RCVDATE column" HeaderText="วันที่รับ" SortExpression="RCVDATE" UniqueName="RCVDATE">
         
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="cer_type" FilterControlAltText="Filter cer_type column" HeaderText="ประเภทใบรับรอง" SortExpression="cer_type" UniqueName="cer_type">

        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="for_type" FilterControlAltText="Filter for_type column" HeaderText="ประเภทเครื่องมือแพทย์" SortExpression="for_type" UniqueName="for_type">
        
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column" HeaderText="เลขที่อ้างอิง" SortExpression="TR_ID" UniqueName="TR_ID">
    
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="COUNTRY" FilterControlAltText="Filter COUNTRY column" HeaderText="COUNTRY" Display="false" SortExpression="COUNTRY" UniqueName="COUNTRY">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_UPLOAD" FilterControlAltText="Filter CITIZEN_UPLOAD column" Display="false"
             HeaderText="CITIZEN_UPLOAD" SortExpression="CITIZEN_UPLOAD" UniqueName="CITIZEN_UPLOAD">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_DOWNLOAD" FilterControlAltText="Filter CITIZEN_DOWNLOAD column"  Display="false"
            HeaderText="CITIZEN_DOWNLOAD" SortExpression="CITIZEN_DOWNLOAD" UniqueName="CITIZEN_DOWNLOAD">
     
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_AUTHORIZE" FilterControlAltText="Filter CITIZEN_AUTHORIZE column"  Display="false"
            HeaderText="CITIZEN_AUTHORIZE" SortExpression="CITIZEN_AUTHORIZE" UniqueName="CITIZEN_AUTHORIZE">
      
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="LCNSID" DataType="System.Int32" FilterControlAltText="Filter LCNSID column" Display="false"
             HeaderText="LCNSID" SortExpression="LCNSID" UniqueName="LCNSID">
        
        </telerik:GridBoundColumn>
       
        <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="รหัสดำเนินการ" SortExpression="XMLNAME" UniqueName="XMLNAME" Display="false">
    
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" Display="false" HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA">
        
         
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column" HeaderText="สถานะ" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
       
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="STATUS_NAME" DataType="System.Int32" FilterControlAltText="Filter STATUS_NAME column" HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
       
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column" Display="false" HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID">

             </telerik:GridBoundColumn>

          <telerik:GridTemplateColumn HeaderText="สถานะชำระเงินค่าธรรมเนียม" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                              <ItemTemplate>
                                  <asp:CheckBox ID="status_pay"  runat="server"  Enabled="false" />
                              </ItemTemplate>
         </telerik:GridTemplateColumn>

         <telerik:GridButtonColumn ButtonType="LinkButton" ButtonCssClass="btn-choose" text="ดูข้อมูล" CommandName="Sel" UniqueName="DeleteColumn">
                                <HeaderStyle Width="100px" />
         </telerik:GridButtonColumn>
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

            <div class="h5" style="padding-left: 90%;">
            <asp:HyperLink ID="hl_pay" runat="server" Target="_blank" CssClass="font_hp">ชำระเงินคลิกที่นี้</asp:HyperLink>
        </div>
        
            
        
            </td></tr>

    </table>

            <!--POPUP-->
            <div align="center">
                <div class="modal fade" id="myModal">
                    <div class="panel panel-info" style="width: 95%;">
                        <div class="panel-heading  text-center"></div>
                        <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                        <div class="panel-body">
                            <iframe id="f1" style="width: 100%; height: 550px;"></iframe>
                        </div>
                        <div class="panel-footer"></div>
                    </div>
                </div>
            </div>
            <!--/POPUP-->

    <asp:HiddenField ID="hid_token" runat="server" />
    
    <script>
        function OpenPopup1() {
       
            var token = document.getElementById("ContentPlaceHolder1_hid_token").value;
     
            window.open('http://164.115.28.127/FDA_FEE/MAIN/check_token.aspx?Token=' + token + '&system=cert3', '_blank');
        }
        </script>
</asp:Content>
