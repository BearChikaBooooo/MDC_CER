<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_STAFF_CONFRIME_ATTACH.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_STAFF_CONFRIME_ATTACH" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
         .radgrid-ui{
             width:100%;
         }
    </style>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <table width="100%">
           <tr>
               <td>
      
       <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" CssClass="radgrid-ui" AutoGenerateColumns="False" >
<MasterTableView DataKeyNames="IDA" >
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="NO" DataType="System.String" Display="true" 
            FilterControlAltText="Filter NO column" HeaderText="NO" ReadOnly="True"
             SortExpression="NO" UniqueName="NO">
         
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Product_Name" DataType="System.String" 
            FilterControlAltText="Filter Product_Name column" HeaderText="Product_Name"
            SortExpression="Product_Name" UniqueName="Product_Name">
            </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Product_Detail" DataType="System.String"
            FilterControlAltText="Filter Product_Detail column" HeaderText="Product_Detail"
            SortExpression="Product_Detail" UniqueName="Product_Detail">
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
              </td>

           </tr>
          
            </table> 
        <div style="text-align:center"> 
            <asp:Button id="btn_back" runat="server" Text="ย้อนกลับ" />
        </div>
    </form>
</body>
</html>
