<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MASTER_PAGE/MAIN.Master" CodeBehind="FRM_CHOOSE_STAFF.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_CHOOSE_STAFF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <asp:Button ID="btn_staff_1" runat="server" Text="เจ้าหน้าที่รับเรื่อง" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:Button ID="btn_staff_2" runat="server" Text="เจ้าหน้าที่พี่เลี้ยง" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:Button ID="btn_staff_3" runat="server" Text="หัวหนน้าอนุมัติ" />
            </div>
        </div>
    </div>
    
</asp:Content>
