<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_STRFF_COMMENT_ADMIN.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_STRFF_COMMENT_ADMIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
        /*#Text1 {
            height: 134px;
            width: 530px;
        }*/
         .btn-down-upload {
            padding:10px 16px;
            width:150px;
            border-style:solid;
            border-color:#D9D9D9;
            cursor:pointer;
            font-size:18px;
            line-height:1.33;
            border-radius:18px;
            margin:10px;"
        }
        .btn-down-upload:hover {
            background-color:#d3eef5;
            border-color:#d3eef5;
        }
    </style>
    
</head>
<body>
 
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td colspan="2"><h3>หมายเหตุ : กรณีคืนคำขอ</h3></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <asp:TextBox ID="txt_comment_cancel" runat="server" Height="200px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Button ID="btn_save_cancel" CssClass="btn-down-upload" runat="server" Text="บันทึก" />
                </td><td>
                    <asp:Button ID="btn_cancel"  CssClass="btn-down-upload" runat="server" Text="ยกเลิก" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
