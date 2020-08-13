<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER_PAGE/MAIN_NODE.Master" CodeBehind="FRM_SELECT_LCN.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.WebForm22" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <div class="row">
            <div class="col-lg-12">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GV_lcnno" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="2" CssClass="table" DataKeyNames="ID" Font-Size="10pt" ForeColor="#333333" GridLines="None" PageSize="20" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="0%" Visible="false">
                            <ItemTemplate>
                                <asp:Button ID="btn_pdf" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="pdf" CssClass="btn-link" Text="ดาวโหลดPDF" Visible="false" Width="80%" />

                            </ItemTemplate><ItemStyle Width="0%" />

                        </asp:TemplateField>
                        <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width="10%" Visible="false"><ItemStyle Width="10%" />

                        </asp:BoundField>
                        <asp:BoundField DataField="lcnno" HeaderText="เลขที่ใบอนุญาต" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="0%" Visible="false">
                            <ItemStyle HorizontalAlign="Left" Width="0%" />
                         </asp:BoundField>
                        <asp:TemplateField HeaderText="เลขที่ใบอนุญาต" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbl_lcnno" runat="server">

                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ประเภทใบอนุญาต" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbl_lcntype" runat="server">

                                </asp:Label>

                            </ItemTemplate>
                            <ItemStyle Width="10%" />

                        </asp:TemplateField>
                        <asp:BoundField DataField="nameplace" HeaderText="ชื่อสถานที่" ItemStyle-Width="50%"><ItemStyle Width="10%" />

                        </asp:BoundField>
                        <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width="50%"><ItemStyle Width="40%" /></asp:BoundField><asp:BoundField DataField="rcvno" HeaderText="เลขรับ" /><asp:BoundField DataField="xmlnm" HeaderText="เลข Transection" /><asp:TemplateField HeaderText="สถานะ" ItemStyle-Width="10%"><ItemTemplate><asp:Label ID="lbl_status" runat="server"></asp:Label></ItemTemplate><ItemStyle Width="10%" /></asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Button ID="btn_lcn" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                     CommandName="lcno" CssClass="btn-link" Text="เลือก" Width="100%" />

                            </ItemTemplate><ItemStyle Width="10%" />

                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#2461BF" /><FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#034EA2 " CssClass="row" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#EFF3FB" CssClass="row" /><SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /><SortedAscendingCellStyle BackColor="#F5F7FB" /><SortedAscendingHeaderStyle BackColor="#6D95E1" /><SortedDescendingCellStyle BackColor="#E9EBEF" /><SortedDescendingHeaderStyle BackColor="#4870BE" /></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
