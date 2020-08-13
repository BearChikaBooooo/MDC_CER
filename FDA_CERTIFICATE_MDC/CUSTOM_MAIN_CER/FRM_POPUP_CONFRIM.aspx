<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_CONFRIM.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_CONFRIM" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../Desigh/css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <style>
        .btn-disable {
            color:#acacac;
        }
        .txt_fitty {
            width:50px;
            border-radius:5px;

        }
        .txt_width {
            width:100%;
        }
        .css-set-status {
            text-align: center;
            color: red;
        }
        .css-status{
            text-align: center;
        }
         .css-set-status_payable {
            text-align: center;
            color: green;
        }
    </style>
    <form id="form1" runat="server">
        <table width="100%">
         
        <tr>
            <td width="70%" style="vertical-align: top;">
               <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td valign="top" >
                <table  style="margin-left:10px;margin-right:10px; width: 350px;">
                    <tr>
                        <td>
                            <table class="table" style="width: 101%">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_status" runat="server" Text="" CssClass="css-status"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="2">
                                       <%-- <asp:Button ID="Button1" runat="server" Text="จ่ายเงิน" />--%>
                                        
                                        <asp:Button ID="btn_bill_pay" runat="server" CssClass="btn-lg" Width="100%" Text="พิมพ์ใบสั่งชำระ"  OnClientClick="OpenPopup1();" />
                                        
                                    </td>
                                </tr>
                              <%--  <tr>
                                     <td>
                                        <asp:Label ID="lbl_type_title" runat="server" Text="ประเภท"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_type" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr id ="check_pay" runat="server">
                                    <td class="auto-style2">
                                        <asp:TextBox ID="txt_check_pay" runat="server" Width="125px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_check_pay" runat="server" Text="ยืนยัน" />
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
                                        <asp:Label ID="lbl_topic_datercvno" runat="server" Text="วันที่รับ" Font-Bold="True"></asp:Label>     
                                    </td>
                                    <td>
                                          <asp:Label ID="lbl_datercvno" runat="server" Text=""></asp:Label>
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
                                        <asp:Label ID="lbl_topic_namecom" runat="server" Text="ชื่อบริษัท" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_namecom" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                             <%--   <tr>
                                     <td class="auto-style2">
                                         <asp:Label ID="lbl_topic_namelocate" runat="server" Text="ทะเบียน" Font-Bold="True"></asp:Label>
                                         
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_namelocate" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
      --%>                          <tr>
                                     <td class="auto-style3">
                                         <asp:Label ID="lbl_topic_nameperson" runat="server" Text="ผู้ยื่น" Font-Bold="True"></asp:Label>
                                       
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="lbl_nameperson" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <%--  <tr>
                                     <td class="auto-style3">
                                         <asp:Label ID="lbl_unit_cer_title" runat="server" Text="สำเนา" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_unit" CssClass="txt_fitty" runat="server" TextMode="Number"></asp:TextBox>&nbsp;<asp:Label ID="lbl_suffix" runat="server" Text="ใบ"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                     <td colspan="2">
                                         <asp:Label ID="lbl_remark_title" runat="server" Text="หมายเหตุ" Font-Bold="True"></asp:Label><br>
                                        <asp:TextBox ID="txt_remark" CssClass="txt_width"  runat="server" Height="111px" TextMode="MultiLine" ></asp:TextBox>
                                    </td>
                                </tr>
                              <%--  <tr>
                                    <td colspan="2" style="text-align:center;">
                                        <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                 <%--<tr>
                                    <td colspan="2" class="auto-style4">
                                        <asp:Label ID="lbl_comment_business_title" runat="server" Text="หมายเหตุ" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="txt_comment_business" runat="server" Height="150px" Width="100%" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btn_confirm" runat="server" Text="ส่งคำขอ" CssClass="btn-lg" Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btn_cancel" runat="server" CssClass="btn-lg" Width="100%" Text="ยกเลิกคำขอ" />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btn_export" runat="server" Text="Export Word" CssClass="btn-lg" Width="100%"  />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="100%"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                           <asp:Panel ID="Panel1" runat="server">
                                               <table width="100%">
                                                   <tr>
                                                       <td>
                                                      <asp:Button ID="Button1" runat="server" Text="ตรวจสอบไฟล์แนบ" CssClass="btn-lg" Width="100%"  />

                                                       </td>
                                                   </tr>
                                                        <asp:Literal ID="ltl_attach_name" runat="server"></asp:Literal>
                                               </table>
                                           </asp:Panel>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                           <asp:Panel ID="Panel2" runat="server">
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
                                           <asp:Panel ID="Panel3" runat="server">
                                               <table width="100%">
                                                   <tr>
                                                       <td>
                                                      <asp:Button ID="Preview_Origi" runat="server" Text="ใบคำขอ" CssClass="btn-lg" Width="100%"  />

                                                       </td>
                                                   </tr>
                                                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                               </table>
                                           </asp:Panel>
                                    </td>
                                </tr>
                                

                            </table>

                         

                        </td>
                    </tr>
                    <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" Visible="true" />
                </table>
            </td>
           
        </tr>

    </table>
        
    </form>
</body>
</html>
