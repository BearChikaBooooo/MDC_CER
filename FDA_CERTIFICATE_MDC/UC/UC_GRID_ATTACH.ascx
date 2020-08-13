<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_GRID_ATTACH.ascx.vb" Inherits="FDA_CERTIFICATE_MDC.UC_GRID_ATTACH" %>


<asp:GridView ID="gv" runat="server" Width="100%" DataKeyNames="IDA" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="None">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                          <asp:BoundField  HeaderText="ชื่อไฟล์แนบ" ItemStyle-Width="70%" DataField="Description">

<ItemStyle Width="70%"></ItemStyle>
                          </asp:BoundField>

                           <asp:TemplateField ItemStyle-Width="30%">
                     <ItemTemplate>
                          
                        <asp:HyperLink ID="btn_Select" runat="server"  Target="_blank" CssClass="btn-control" CommandName="sel" Width="100%"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  >ดูข้อมูล</asp:HyperLink>
                           </ItemTemplate>


<ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>
                      </Columns>
                        <EditRowStyle BackColor="white" />
    <FooterStyle BackColor="white" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" CssClass="black" VerticalAlign="Middle" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="White" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 </asp:GridView>