<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_REMARK_STAFF_REQUST.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_REMARK_STAFF_REQUST" %>
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
        .css-set-100 {
            width:100%;
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
            <div class="col-lg-7" style="text-align:left;">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
               <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" AllowPaging="True" AllowMultiRowSelection="true" >
        <ClientSettings  Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true" AllowDragToGroup="true"  EnableRowHoverStyle="true" ClientEvents-OnRowSelected="onGridRowSelected">
                        <Selecting AllowRowSelect="true" UseClientSelectColumnOnly="true"  />
                    </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
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
                                <telerik:GridBoundColumn DataField="RCVNO" FilterControlAltText="Filter RCVNO column" HeaderText="เลขรับ" SortExpression="RCVNO" UniqueName="RCVNO">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="datercvno" DataType="System.DateTime" FilterControlAltText="Filter datercvno column" HeaderText="วันที่รับ" SortExpression="datercvno" UniqueName="datercvno">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PROCESS_DESCRIPTION" FilterControlAltText="Filter PROCESS_DESCRIPTION column" HeaderText="ประเภท CER" SortExpression="PROCESS_DESCRIPTION" UniqueName="PROCESS_DESCRIPTION">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" Display="false" HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID">
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
                                <telerik:GridBoundColumn DataField="REF_CODE" FilterControlAltText="Filter REF_CODE column" HeaderText="Ref.No" SortExpression="REF_CODE" UniqueName="REF_CODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_PROCESS_ID" FilterControlAltText="Filter FK_PROCESS_ID column" HeaderText="FK_PROCESS_ID" SortExpression="FK_PROCESS_ID" UniqueName="FK_PROCESS_ID" Display="false" >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="XML_NAME" FilterControlAltText="Filter XML_NAME column" HeaderText="รหัสดำเนินการ" SortExpression="XML_NAME" UniqueName="XML_NAME">
                                </telerik:GridBoundColumn>
                               
                                <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" Display="false" HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS_NAME"  FilterControlAltText="Filter STATUS_NAME column" HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column" Display="false" HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" ButtonCssClass="btn-choose" 
                                    CommandName="Sel" Text="ดูข้อมูล" UniqueName="DeleteColumn">
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
            </div>
            <div class="col-lg-3">
               
                    <div class="row">
                         <div class="col-lg-12">
                         <asp:TextBox ID="txt_remark" runat="server" CssClass="css-set-100" Height="156px" TextMode="MultiLine" ></asp:TextBox>
                      </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Button ID="btn_add" runat="server" Text="เพิ่ม" />
                        </div>
                    </div>
                    
          
               
            </div>
            
        </div>

        <div class="row">
            <div class="col-lg-12" style="text-align:center;padding:15px;">
                <asp:Button ID="btn_confirme" runat="server" CssClass="btn-lg" Text="บันทึก" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_cancel" CssClass="btn-lg" runat="server" Text="ยกเลิก" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
