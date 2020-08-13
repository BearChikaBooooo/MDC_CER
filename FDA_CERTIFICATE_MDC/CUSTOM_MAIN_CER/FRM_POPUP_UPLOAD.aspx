<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_POPUP_UPLOAD.aspx.vb" Inherits="FDA_CERTIFICATE_MDC.FRM_POPUP_UPLOAD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href="../Desigh/css/bootstrap.css" rel="stylesheet" />
    <link href="../Desigh/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Desigh/css/custom-bootstrap.css" rel="stylesheet" />
     <style>
        .btn-upload {
            margin-top:10px;
            margin-bottom:10px;
            height:40px;
            width:100%;
            border: solid 1px;
            background-color:#808080;
            border-radius:5px;
        }
        .btn-button {
             margin:10px;
            border-radius:5px;
            height:40px;
            width:150px;
        }
        .container {
            margin-top:auto;
            text-align:center;
        }
        .table{
            border:none;
            margin-top:100px;
            text-align:right;
        }
    </style>
     <script type="text/javascript" >

         jQuery.fn.center = function () {
             this.css("position", "absolute");

             this.css("top", Math.max(0, (($(window).height() / 2.0)) +
                                                         $(window).scrollTop()) + "px");
             this.css("left", Math.max(0, (($(window).width() / 2.0)) +
                                                         $(window).scrollLeft()) + "px");
             return this;
         }

         $(document).ready(function () {
             $(window).load(function () {
                 $.ajax({
                     type: 'POST',
                     data: { submit: true },
                     success: function (result) {
                         //   $('#spinner').center();
                         $('#spinner').fadeOut('slow');
                     }
                 });
             });



             $('#ContentPlaceHolder1_btn_Upload').click(function () {
                 //    $('#spinner').center();
                 $('#spinner').fadeIn('slow');
                 //   alert('123');
             });



         });


        </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <table class="table">
            <td></td>
        <tr>
            <td style="width:50%"> <asp:Label ID="Label1" runat="server" Text="PDF ใบคำขอ"></asp:Label></td>
            <td><asp:FileUpload ID="FileUpload1" runat="server"  /></td>

        </tr>
            <tr >
                <td style="width:50%"> <asp:Label ID="Label2" runat="server" Text="XML รายละเอียดเครื่องมือแพทย์"></asp:Label></td>
                <td><asp:FileUpload ID="FileUpload2" runat="server"  /></td>
            </tr>
                
           


        <%--<tr ><td colspan="3"> 
            XML Product Export 
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <br />
            หมายเหตุ : แนบไฟล์นามสกุล XML เท่านั้น</td>
            </tr>--%>
        </table>

      <asp:Button ID="btn_Upload" runat="server" Text="ยืนยัน"   CssClass=" btn-lg" Width="100px" />
             &nbsp;<asp:Button ID="btn_Upload0" runat="server" Text="ย้อนกลับ"   CssClass=" btn-lg" Width="100px"  />
            
    <h4>
        หมายเหตุ : หากต้องการติดต่อเจ้าหน้าที่กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้วเพื่อใช้ในการติดต่อ
    </h4>
    </div>
    </form>
</body>
</html>
