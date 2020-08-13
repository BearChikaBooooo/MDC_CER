<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_REMARK_STAFF_LIST.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_REMARK_STAFF_LIST" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        <div class="col-lg-12" >
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" AllowPaging="True" AllowMultiRowSelection="True" >
        <ClientSettings  Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true"  EnableRowHoverStyle="true" ClientEvents-OnRowSelected="onGridRowSelected">
                        <Selecting AllowRowSelect="true" UseClientSelectColumnOnly="true"  />

<ClientEvents OnRowSelected="onGridRowSelected"></ClientEvents>
                    </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" DataSourceID="">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>

                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32"
                                    FilterControlAltText="Filter IDA column" HeaderText="IDA" ReadOnly="True"
                                    SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_IDA" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" DataType="System.Int32" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column" HeaderText="REMARK" SortExpression="REMARK" UniqueName="REMARK">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DATE_TIME" FilterControlAltText="Filter DATE_TIME column" HeaderText="DATE_TIME" SortExpression="DATE_TIME" UniqueName="DATE_TIME" DataType="System.DateTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" DataType="System.Int32" FilterControlAltText="Filter STATUS column" HeaderText="STATUS" SortExpression="STATUS" UniqueName="STATUS" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STAFF_CITIZEN" FilterControlAltText="Filter STAFF_CITIZEN column" HeaderText="STAFF_CITIZEN" SortExpression="STAFF_CITIZEN" UniqueName="STAFF_CITIZEN" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STAFF_TYPE" FilterControlAltText="Filter STAFF_TYPE column"
                                    HeaderText="STAFF_TYPE" SortExpression="STAFF_TYPE" UniqueName="STAFF_TYPE" DataType="System.Int32" Display="false">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                    HeaderText="STATUS_NAME" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="STAFF_NAME" FilterControlAltText="Filter STAFF_NAME column"
                                    HeaderText="STAFF_NAME" SortExpression="STAFF_NAME" UniqueName="STAFF_NAME">
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
        </div>
    </div>
      
    </div>
    </form>
</body>
</html>
