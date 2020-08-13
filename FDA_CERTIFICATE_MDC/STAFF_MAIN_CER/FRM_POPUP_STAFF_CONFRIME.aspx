<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_STAFF_CONFRIME.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_STAFF_CONFRIME" %>

<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="../DESIGH/css/bootstrap.css" rel="stylesheet" />
    <link href="../DESIGH/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../DESIGH/css/custom-bootstrap.css" rel="stylesheet" />



    <script src="../Desigh/js/jquery.js"></script>
    <script src="../Desigh/js/bootstrap.min.js"></script>
    <%--<link href="../Desigh/css_date/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <script src="../Desigh/js_date/jquery-ui-1.7.2.custom.min.js"></script>
    <script src="../Desigh/js_date/jquery-1.3.2.min.js"></script>--%>
</head>
<body>

    <p>
        &nbsp;</p>

    <style>
        .btn-disable {
            color: #ccced0;
        }

        .txt_fitty {
            width: 50px;
        }

        .txt_full {
            width: 100%
        }

        .auto-style1 {
            height: 39px;
        }

        .txt_width {
            width: 100%;
        }

        h5 {
            color: red;
        }
    </style>
    <%--<script>
         $(function () {
             // แทรกโค้ต jquery
             $("#txt_date_approved").datepicker({
                 dateFormat: 'dd-mm-yy',
                 monthNames: ["มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"]
                
             });
         })
     </script>--%>
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td width="70%">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
                <td valign="top">
                    <table style="margin-top: 70px; margin-left: 10px; margin-right: 10px; width: 350px;">
                        <tr>
                            <td>
                                <table class="table" style="width: 101%">
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="lbl_condate_topic" runat="server" Text="วันที่ยื่น" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_condate" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="lbl_topic_refno" runat="server" Text="เลขที่อ้างอิง" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_refno" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="lbl_topic_datercvno" runat="server" Text="วันที่รับ" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_datercvno" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="lbl_topic_rcvno" runat="server" Text="เลขที่รับ" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_rcvno" runat="server"></asp:Label>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td class="auto-style2">
                                            <asp:Label ID="lbl_topic_namecom" runat="server" Text="ชื่อบริษัท" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl_namecom" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                     <td class="auto-style2">
                                         <asp:Label ID="lbl_topic_namelocate" runat="server" Text="ทะเบียน" Font-Bold="True"></asp:Label>
                                         
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_namelocate" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>--%>
                                    <tr>
                                        <td class="auto-style3">
                                            <asp:Label ID="lbl_topic_nameperson" runat="server" Text="ผู้ยืน" Font-Bold="True"></asp:Label>

                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="lbl_nameperson" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">
                                            <asp:Label ID="Label1" runat="server" Text="สถานะ" Font-Bold="True"></asp:Label>

                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="lbl_status" runat="server" Text=""></asp:Label>
                                            <asp:DropDownList ID="drp_status" CssClass="txt_full" DataTextField="STATUS_NAME" DataValueField="STATUS_ID" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="tr_remark" runat="server">
                                        <td colspan="2">
                                            <asp:Label ID="lbl_remark_title" runat="server" Text="หมายเหตุ" Font-Bold="True"></asp:Label><br>
                                            <asp:TextBox ID="txt_remark" CssClass="txt_width" runat="server" Height="111px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                     <td class="auto-style3">
                                         <asp:Label ID="lbl_edit_description" runat="server" Text="แก้ไขลักษณะ"></asp:Label>
                                         
                                       
                                    </td>
                                    <td >
                                        <asp:CheckBox ID="chk_edit_discription" onclick="check_edit_discription();" runat="server" Text="แก้ไขรลักษณะ" />
                                        <asp:TextBox ID="txt_edit_discription" CssClass="txt_full"  runat="server" TextMode="MultiLine"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lbl_edit_unit" runat="server" Text="แก้ไขหน่วย" Font-Bold="True"></asp:Label></td>
                                    <td><asp:CheckBox ID="chk_edit_unit" onclick="check_edit_unit();" runat="server" Text="แก้ไขหน่วย" />
                                        <asp:TextBox ID="txt_edit_unit" CssClass="txt_full"  runat="server"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                     <td class="auto-style3">
                                         <asp:Label ID="lbl_unit_cer_title" runat="server" Text="สำเนา" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txt_unit" CssClass="txt_fitty" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="lbl_suffix" runat="server" Text="ใบ"></asp:Label>
                                    </td>
                                </tr>--%>
                                    <%--<tr id="tr_approve_date" runat="server">
                                     <td class="auto-style1">

                                         <asp:Label ID="lbl_date_approved_title" runat="server" Text="วันอนุมัติ" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:CheckBox ID="chk_edit_date" onclick="check_edit();" runat="server" Text="แก้ไขวันที่อนุมัติ" />
                                        <asp:TextBox ID="txt_date_approved" CssClass="txt_full" runat="server" TextMode="Date"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                    <%--<tr>type="date" id="myDate"
                                    <td colspan="2" style="text-align:center;">
                                        <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                    <tr id="tr_approve_name" runat="server">
                                        <td class="auto-style1">
                                            <asp:Label ID="AdminApprove" runat="server" Text="ผู้ลงนาม"></asp:Label></br>

                                        </td>
                                        <td>
                                            <%--<asp:DropDownList ID="drp_staff_approve" CssClass="txt_full" runat="server" DataSourceID="SqlDataSource1" DataTextField="ENG_POSITION_NAME" DataValueField="IDA"></asp:DropDownList>--%>
                                            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LGT_DRUGConnectionString %>" SelectCommand="SP_GET_NAME_STRFF_APPROVE" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
                                            <asp:DropDownList ID="drp_staff_approve" CssClass="txt_full" runat="server" Height="57px" Width="100%">
                                                <asp:ListItem Value="7">Mrs. Sittaya Sumananont</asp:ListItem>
                                                <asp:ListItem Value="1">Mrs. Korrapat Trisarnsri</asp:ListItem>
                                                <asp:ListItem Value="2">Miss Ubonrat Sakolwittayanon</asp:ListItem>
                                                <asp:ListItem Value="3">Mrs. Nutchnat Kitiwouranon</asp:ListItem>
                                                <asp:ListItem Value="4">Mrs. Pimonvan Tantawiwattananon</asp:ListItem>
                                                <asp:ListItem Value="5">Mrs. Sirinmas Katchamart</asp:ListItem>
                                                <asp:ListItem Value="6">Mr. Nakorn Tangwancharoenchai</asp:ListItem>
                                                <asp:ListItem Value="8">Mr. Charanchai Porrapagpalai</asp:ListItem>
                                                <%--      <asp:ListItem Value="7">นางสาวสุฮวง ฐิติสัตยากร</asp:ListItem>
                                 <asp:ListItem Value="8">นางสาวอุบลรัตน์ สกลวิทยานนท์</asp:ListItem>
                                 <asp:ListItem Value="9">นางศันสนีย์ ปิ่นทอง</asp:ListItem>
                                 <asp:ListItem Value="10">นางสาววนิดา แก้วผนึกรังษี</asp:ListItem>
                                 <asp:ListItem Value="11">นางพิมลวรรณ ทันตวิวัฒนานนท์</asp:ListItem>
                                 <asp:ListItem Value="12">นางกรภัทร ตรีสารศรี</asp:ListItem>
                                 <asp:ListItem Value="13">นายนคร ตั้งวันเจริญชัย</asp:ListItem>
                                 <asp:ListItem Value="14">นางสิรินมาส คัชมาตย์</asp:ListItem>
                                 <asp:ListItem Value="15">นางวิมล สุวรรณเกษาวงษ์</asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <%--<asp:DropDownList ID="drp_staff_status" CssClass="txt_full" runat="server" DataSourceID="SqlDataSource1" DataTextField="ENG_POSITION_NAME" DataValueField="IDA"></asp:DropDownList>--%>
                                       
                                        </td>

                                    </tr>
                                    <tr id="tr_approve_status" runat="server">
                                        <td>
                                            <asp:Label ID="AdminStatus" runat="server" Text="ตำแหน่งผู้ลงนาม"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drp_staff_status" CssClass="txt_full" runat="server" Height="44px" Width="100%">
                                                 <asp:ListItem Value="3">Pharmacist, Professional Level Person designated by the Secretary-General of the Food and Drug Administration
                                                </asp:ListItem>
                                                <asp:ListItem Value="1">Pharmacist, Senior Professional Level Person designated by the Secretary-General of the Food and Drug Administration
                                                </asp:ListItem>
                                                <asp:ListItem Value="2">Director of Medical Device Control Division For Secretary-General of Food and Drug Administration
                                                </asp:ListItem>
                                               
                                                <%-- <asp:ListItem Value="3">เภสัชกรชำนาญการพิเศษ รักษาราชการแทนผู้อำนวยการกองควบคุมเครื่องมือแพทย์ ปฏิบัติราชการแทนเลขาธิการคณะกรรมการอาหารและยา</asp:ListItem>
                                  <asp:ListItem Value="4">เภสัชกรชำนาญการพิเศษ รักษาการในตำแหน่ง ผู้เชี่ยวชาญด้านความปลอดภัยของเครื่องมือแพทย์</asp:ListItem>
                                  <asp:ListItem Value="5">รองเลขาธิการ ปฏิบัติราชการแทน เลขาธิการคณะกรรมการอาหารและยา</asp:ListItem>
                                 <asp:ListItem Value="6">ผู้เชี่ยวชาญด้านมาตรฐานยา รักษาราชการแทนรองเลขาธิการคณะกรรมการอาหารและยา ปฏิบัติราชการแทนเลขาธิการคณะกรรมการอาหารและยา</asp:ListItem>
                                 <asp:ListItem Value="7">รักษาราชการแทนรองเลขาธิการคณะกรรมการอาหารและยา ปฏิบัติราชการแทนเลขาธิการคณะกรรมการอาหารและยา</asp:ListItem>
                             	 <asp:ListItem Value="8">เภสัชกรชำนาญการพิเศษ ปฏิบัติราชการแทนเลขาธิการคณะกรรมการอาหารและยา</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btn_confirm" runat="server" Text="บันทึก" CssClass="btn-lg" Width="100%" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btn_export" runat="server" Text="Export Word" CssClass="btn-lg" Width="100%" />
                                        </td>
                                    </tr>
                                    <%--<asp:Panel ID="pnl_font_paper" runat="server">
                                 <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btn_font_paper" runat="server" Text="ใบปะหน้า" CssClass="btn-lg" Width="100%" />
                                    </td>
                                </tr>
                                </asp:Panel>--%>
                                    <%--<tr>
                                    <td colspan="2">
                                        <asp:Button ID="btn_cancel" runat="server" CssClass="btn-lg" Width="100%" Text="คืนคำขอ" />
                                    </td>
                                </tr>
                                <tr>--%>
                                <td colspan="2">
                                    <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="100%" />
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel1" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="ตรวจสอบไฟล์แนบ" CssClass="btn-lg" Width="100%" />

                                            </td>
                                        </tr>
                                        <asp:Literal ID="ltl_attach_name" runat="server"></asp:Literal>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                                    <td colspan="2">
                                           <asp:Panel ID="Panel3" runat="server">
                                               <table width="100%">
                                                   <tr>
                                                       <td>
                                                      <asp:Button ID="Preview_Export" runat="server" Text="Preview Export " CssClass="btn-lg" Width="100%"  />

                                                       </td>
                                                   </tr>
                                                        <asp:Literal ID="Preview" runat="server"></asp:Literal>
                                               </table>
                                           </asp:Panel>
                                    </td>
                                </tr>


                                <tr>
                                    <td colspan="2">
                                           <asp:Panel ID="Panel4" runat="server">
                                               <table width="100%">
                                                   <tr>
                                                       <td>
                                                      <asp:Button ID="Preview_Origi" runat="server" Text="ใบคำขอ" CssClass="btn-lg" Width="100%"  />

                                                       </td>
                                                   </tr>
                                                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                               </table>
                                           </asp:Panel>
                                    </td>
                                </tr>

                        
                               


                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel2" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td>อัพโหลดใบ Certificate</td>
                                            <td>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                            </td>
                                        </tr>
                                        <asp:Literal ID="Literal2" runat="server">
                                        </asp:Literal>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>

                        <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" Visible="true" />

                    </table>



                </td>
            </tr>
        </table>


    </form>


    <script>
        function check_edit() {
            var value = document.getElementById("chk_edit_date").checked;

            if (value == true) {
                alert("เปิดการแก้ไขวันที่อนุมัติ");
                document.getElementById("txt_date_approved").disabled = false;
            }
            else {

                document.getElementById("txt_date_approved").disabled = true;
            }
        }

        function check_edit_unit() {
            var value = document.getElementById("chk_edit_unit").checked;

            if (value == true) {
                alert("เปิดการแก้ไขหน่วย");
                document.getElementById("txt_edit_unit").disabled = false;
            }
            else {

                document.getElementById("txt_edit_unit").disabled = true;
            }
        }
        function check_edit_discription() {
            var value = document.getElementById("chk_edit_discription").checked;

            if (value == true) {
                alert("เปิดการแก้ไขลักษณะ");
                document.getElementById("txt_edit_discription").disabled = false;
            }
            else {

                document.getElementById("txt_edit_discription").disabled = true;
            }
        }
    </script>

</body>
</html>
