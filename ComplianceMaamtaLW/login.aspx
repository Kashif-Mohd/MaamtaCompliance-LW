<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ComplianceMaamtaLW.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CORE DSS</title>
    <link id="Link1" runat="server" rel="icon" href="~/img/green-01.png" type="image/png" />
    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" />
      <style type="text/css">
        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            .forMob {
                padding-left: 20%;
            }
        }

        /* For Web Browser*/

        @media only screen and (min-width: 40em) {
            .forMob {
                padding-left: 38%;
            }
        }
    </style>
</head>
<body>
    <div id="login-page">


        <form id="Form1" class="form-login" runat="server" style="background-color: #101010; border-top-left-radius: 6px; border-top-right-radius: 6px; box-shadow: inset 0 0 1px #bdc3c7, 0 0 3px #95a5a6;">
        
            <h2 class="form-login-heading" style="border-top-left-radius: 0px; border-top-right-radius: 0px;">CORE DSS <br/> & <br/> Maamta-LW Compliance</h2>


            <div class="login-wrap">
                <asp:TextBox ID="txtUserNme" runat="server" class="form-control" placeholder="username" MaxLength="30"></asp:TextBox>
                <br>
                <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control" placeholder="password" MaxLength="18"></asp:TextBox>

                <br>
                <br>
                <br>    

                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" class="btn btn-theme btn-block" Text="SIGN IN" style="padding:10px" />
                <br>
                <hr style="margin-bottom: 10px">
                <a href="http://www.vitalpakistan.org.pk/" target="_blank" style="color: #BFBFBF; text-align: center; font-size: 10px; margin-left: 28%; font-family: Arial">VITAL Pakistan Trust (VPT)</a>
            </div>

        </form>
    </div>











    <!-- js placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("assets/img/background.jpg", { speed: 500 });
    </script>
</body>
</html>
