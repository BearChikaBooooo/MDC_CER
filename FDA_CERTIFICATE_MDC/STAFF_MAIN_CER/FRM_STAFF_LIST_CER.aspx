<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER_PAGE/MAIN_STAFF.Master" CodeBehind="FRM_STAFF_LIST_CER.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_STAFF_LIST_CER" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 20px;
        }
        .chkbox {
            color:black;
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
        <tr>
            <td colspan="5"><h3><asp:Label ID="lbl_tltle_head_table"  runat="server"></asp:Label></h3></td>
        </tr>
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
             <td></td>
            <td class="ob-margin">
                <asp:Button ID="Button1" runat="server" Text="ค้นหาผลิตภัณฑ์" CssClass=" btn_sreach" />
            </td>
            <td class="ob-margin"><asp:Label ID="lbl_text_namecom" runat="server" Text="ชื่อบริษัท" ></asp:Label></td>
            <td><asp:TextBox ID="txt_namecom" runat="server" CssClass=" txt_sreach"></asp:TextBox></td>
            <td></td>
        </tr>
        
        <tr>
            <td class="rad_table ob-margin"><asp:Label ID="lbl_text_rcvno" runat="server" ></asp:Label>

            </td>
            <td><asp:TextBox ID="txt_rcvno" runat="server" CssClass="txt_sreach"></asp:TextBox>

            </td>
            <td class="ob-margin"><asp:Label ID="lbl_text_ref_code" runat="server" ></asp:Label>

            </td>
            <td><asp:TextBox ID="txt_ref_code" runat="server" CssClass=" txt_sreach"></asp:TextBox>

            </td>
            <td class="ob-margin"><asp:Button ID="btn_sreach" runat="server" Text="ค้นหา" CssClass=" btn_sreach" />

            </td>
        </tr>
        <tr>
            <td class="ob-margin">
                <asp:Button ID="Button2" runat="server" Text="CHECK_LIST10" CssClass=" btn_sreach" />
            </td>
        </tr>
        <tr >
            <td colspan="5" class="rad_table">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None"  AutoGenerateColumns="false" Width="100%" 
                    AllowSorting="true" AllowFilteringByColumn="false" ShowFooter="true" PagerStyle-AlwaysVisible="true">
                    <GroupingSettings CaseSensitive="false"/>
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" ShowFooter="true">
                            
                          
                            <Columns>
                                <telerik:GridMaskedColumn DataField="IDA" DataType="System.Int32" Display="false"
                                    FilterControlAltText="Filter IDA column" HeaderText="IDA" ReadOnly="True" FilterControlWidth="50px"
                                   AutoPostBackOnFilter="true"  ShowFilterIcon="false"
                                    SortExpression="IDA" UniqueName="IDA">
                                </telerik:GridMaskedColumn>
                                <telerik:GridBoundColumn DataField="RCVNO" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    FilterControlAltText="Filter RCVNO column" HeaderText="เลขรับ" SortExpression="RCVNO" UniqueName="RCVNO">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RCVDATE" ShowFilterIcon="false" AllowFiltering="false" DataType="System.DateTime"
                                    FilterControlAltText="Filter RCVDATE column" HeaderText="วันที่รับ" SortExpression="RCVDATE" UniqueName="RCVDATE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="cer_type" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    FilterControlAltText="Filter cer_type column" HeaderText="ประเภทใบรับรอง" SortExpression="cer_type" UniqueName="cer_type">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="for_type"  ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    FilterControlAltText="Filter for_type column" HeaderText="ประเภทเครื่องมือแพทย์" SortExpression="for_type" UniqueName="for_type">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TR_ID" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                    DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="เลขที่อ้างอิง" SortExpression="TR_ID" UniqueName="TR_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="COUNTRY" FilterControlAltText="Filter COUNTRY column" HeaderText="COUNTRY" Display="false" SortExpression="COUNTRY" UniqueName="COUNTRY">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="CITIZEN_UPLOAD" FilterControlAltText="Filter CITIZEN_UPLOAD column" Display="false"
                                    HeaderText="CITIZEN_UPLOAD" SortExpression="CITIZEN_UPLOAD" UniqueName="CITIZEN_UPLOAD">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="CITIZEN_DOWNLOAD" FilterControlAltText="Filter CITIZEN_DOWNLOAD column" Display="false"
                                    HeaderText="CITIZEN_DOWNLOAD" SortExpression="CITIZEN_DOWNLOAD" UniqueName="CITIZEN_DOWNLOAD">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="CITIZEN_AUTHORIZE" FilterControlAltText="Filter CITIZEN_AUTHORIZE column" Display="false"
                                    HeaderText="CITIZEN_AUTHORIZE" SortExpression="CITIZEN_AUTHORIZE" UniqueName="CITIZEN_AUTHORIZE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="LCNSID" DataType="System.Int32" FilterControlAltText="Filter LCNSID column" Display="false"
                                    HeaderText="LCNSID" SortExpression="LCNSID" UniqueName="LCNSID">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="process_id"  FilterControlAltText="Filter process_id column" HeaderText="process_id" SortExpression="process_id" UniqueName="process_id" Display="false" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="รหัสดำเนินการ" SortExpression="XMLNAME" UniqueName="XMLNAME" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" Display="false" HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS_NAME" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    FilterControlAltText="Filter STATUS_NAME column" HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column" 
                                     HeaderText="สถานะ" SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column" Display="false" HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="REGISTER_NEWCODE" FilterControlAltText="Filter REGISTER_NEWCODE column" HeaderText="REGISTER_NEWCODE" SortExpression="REGISTER_NEWCODE" UniqueName="REGISTER_NEWCODE" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="company_name"  ShowFilterIcon="false" FilterControlAltText="Filter company_name column" CurrentFilterFunction="Contains"
                                    HeaderText="ชื่อบริษัท" SortExpression="company_name" UniqueName="company_name" Display="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="สถานะชำระเงินค่าธรรมเนียม" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  AllowFiltering="false">
                              <ItemTemplate>
                                  <asp:CheckBox ID="status_pay"  runat="server"  Enabled="false"/>
                              </ItemTemplate>
         </telerik:GridTemplateColumn>
                           
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
