<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_REMARK_STAFF.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_REMARK_STAFF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Desigh/css/bootstrap.css" rel="stylesheet" />
    <link href="../Desigh/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <style>
        .css-set-font {
            font-size: 30px;
        }
    </style>
    <form id="form1" runat="server">
    <div class="container-fluid" >
    <div class="row">
        <div class="col-lg-12" style="text-align:center;padding:15px;">
            <asp:Label ID="lbl_title" CssClass="css-set-font" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
        <div class="row">
            <div class="col-lg-12" style="text-align:center;">
                <asp:TextBox ID="txt_remark" runat="server" Height="156px" TextMode="MultiLine" Width="742px"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12" style="text-align:center;padding:15px;">
                <asp:Button ID="btn_confirme" runat="server" CssClass="btn-lg" Text="ยืนยัน" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_cancel" CssClass="btn-lg" runat="server" Text="ยกเลิก" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
