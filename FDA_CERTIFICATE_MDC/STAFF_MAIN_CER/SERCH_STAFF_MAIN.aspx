<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER_PAGE/MAIN_STAFF.Master" CodeBehind="SERCH_STAFF_MAIN.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.SERCH_STAFF_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 20px;
        }
        .chkbox {
            color:black;
        }
        .textcenter{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../Desigh/css/StyleCer.css" rel="stylesheet" />
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

        });

        function Popups(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        // ปิด spin
        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('ดาวน์โหลดเรียบร้อยแล้ว');
            $('#ContentPlaceHolder1_bnt_Close').click();

        }
    </script>
    <asp:Button ID="btn_reload" runat="server" Text="reload" style="display:none;"/>
    
    <table width="100%"><%--                <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CssClass=" btn_sreach" />--%>
        <%--<tr>
            <td colspan="5" class="textcenter"><h3><asp:Label ID="lbl_tltle_head_table"  runat="server"></asp:Label></h3></td>
        </tr>--%>
       <%-- <tr>
            <td class="rad_table ob-margin"><asp:Label ID="Label3" runat="server" Text="เลขที่รับ :" ></asp:Label></td>
            <td><asp:TextBox ID="TextBox3" runat="server" CssClass="txt_sreach"></asp:TextBox></td>
            <td class="ob-margin"><asp:Label ID="Label4" runat="server" Text="ถึงเลขที่รับ" ></asp:Label></td>
            <td><asp:TextBox ID="TextBox4" runat="server" CssClass=" txt_sreach"></asp:TextBox></td>
            <td></td>
        </tr>
         <tr>
            <td class="rad_table ob-margin"><asp:Label ID="Label2" runat="server" Text="ตั้งแต่เลขที่หนังสือ :" ></asp:Label></td>
             <td><asp:TextBox ID="TextBox2" runat="server" CssClass="txt_sreach"></asp:TextBox></td>
            <td class="ob-margin"><asp:Label ID="Label5" runat="server" Text="ถึงเลขที่หนังสือ" ></asp:Label></td
                ><td><asp:TextBox ID="TextBox5" runat="server" CssClass=" txt_sreach"></asp:TextBox></td>
            <td></td>
        </tr>
        
          <tr>
            <td class="rad_table ob-margin"><asp:Label ID="Label9" runat="server" Text="ชื่อผู้รับอนุญาต :" ></asp:Label></td>
              <td><asp:TextBox ID="TextBox9" runat="server" CssClass="txt_sreach"></asp:TextBox></td>
         <td class="rad_table ob-margin"><asp:Label ID="Label15" runat="server" Text="ผลการพิจารณา :" ></asp:Label></td>
            <td><asp:TextBox ID="TextBox15" runat="server" CssClass="txt_sreach"></asp:TextBox></td>
          
            <td></td>
        </tr>--%>
          <%--<tr>
            <td class="rad_table ob-margin"><asp:Label ID="Label11" runat="server" Text="วันที่รับ :" ></asp:Label></td>
              <td><asp:TextBox ID="TextBox11" runat="server" CssClass="txt_sreach"></asp:TextBox></td>
            <td class="ob-margin"><asp:Label ID="Label12" runat="server" Text="ถึง :" ></asp:Label></td>
              <td><asp:TextBox ID="TextBox12" runat="server" CssClass=" txt_sreach"></asp:TextBox></td>
            <td></td>
        </tr>--%>
        <tr>
            
            <td class="ob-margin"><asp:Label ID="Label1" runat="server" Text="ชื่อผลิตภัณฑ์" ></asp:Label></td>
            <td><asp:TextBox ID="txt_Product" runat="server" CssClass=" txt_sreach"></asp:TextBox></td>
            <td class="ob-margin"><asp:Button ID="btn_sreach" runat="server" Text="ค้นหา" CssClass=" btn_sreach" />

            </td>
        </tr>
        
        <tr >
            <td colspan="5" class="rad_table">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" AutoGenerateColumns="False" >
<MasterTableView DataKeyNames="IDA" PagerStyle-AlwaysVisible="true" >
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridMaskedColumn DataField="row_num" DataType="System.Int32" Display="true"
                                    FilterControlAltText="Filter row_num column" HeaderText="ลำดับ" ReadOnly="True" FilterControlWidth="10px"
                                   AutoPostBackOnFilter="true"  ShowFilterIcon="false"
                                    SortExpression="row_num" UniqueName="row_num">
                                </telerik:GridMaskedColumn>




                                <telerik:GridMaskedColumn DataField="IDA" DataType="System.Int32" Display="false"
                                    FilterControlAltText="Filter IDA column" HeaderText="ลำดับ" ReadOnly="false" FilterControlWidth="10px"
                                   AutoPostBackOnFilter="false"  ShowFilterIcon="false"
                                    SortExpression="IDA" UniqueName="IDA">
                                </telerik:GridMaskedColumn>
                                <telerik:GridMaskedColumn DataField="TR_ID" DataType="System.Int32" Display="false"
                                    FilterControlAltText="Filter TR_ID column" HeaderText="ลำดับ" ReadOnly="false" FilterControlWidth="10px"
                                   AutoPostBackOnFilter="false"  ShowFilterIcon="false"
                                    SortExpression="TR_ID" UniqueName="TR_ID">
                                </telerik:GridMaskedColumn>
                                <telerik:GridMaskedColumn DataField="process_id" DataType="System.Int32" Display="false"
                                    FilterControlAltText="Filter process_id column" HeaderText="ลำดับ" ReadOnly="false" FilterControlWidth="10px"
                                   AutoPostBackOnFilter="false"  ShowFilterIcon="false"
                                    SortExpression="process_id" UniqueName="process_id">
                                </telerik:GridMaskedColumn>






                                <telerik:GridBoundColumn DataField="display_name" FilterControlAltText="Filter display_name column" Display="true"
                                    HeaderText="ชื่อผลิตภัณฑ์" SortExpression="display_name" UniqueName="display_name">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="producer_name" FilterControlAltText="Filter producer_name column" Display="true"
                                    HeaderText="ชื่อผู้ผลิต" SortExpression="producer_name" UniqueName="producer_name">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="Require" FilterControlAltText="Filter CITIZEN_AUTHORIZE column" Display="true"
                                    HeaderText="ชื่อผู้ขอ" SortExpression="CITIZEN_AUTHORIZE" UniqueName="CITIZEN_AUTHORIZE">
                                </telerik:GridBoundColumn>
                                                           
                                <telerik:GridButtonColumn ButtonType="LinkButton" ButtonCssClass="btn-choose" 
                                    CommandName="Sel" Text="ดูข้อมูล" UniqueName="DeleteColumn">
                                    <HeaderStyle Width="100px" />
                                </telerik:GridButtonColumn>
                            </Columns>

                            <%--<EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>--%>

<%--                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>--%>
                        </MasterTableView>
          
                        <%--<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                        <FilterMenu EnableImageSprites="False"></FilterMenu>--%>
                    </telerik:RadGrid>
                </td> 
            </tr>
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
</asp:Content>
