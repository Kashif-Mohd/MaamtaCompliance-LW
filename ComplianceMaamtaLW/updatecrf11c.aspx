<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updatecrf11c.aspx.cs" Inherits="ComplianceMaamtaLW.updatecrf11c" Culture="en-GB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*change Color of Radio Button*/

        .textDropDownCSS {
            font-size: 1.0em;
            font-family: Calibri;
            Height: 2.3em;
            color: #16a085;
        }

        .RomanEnglish {
            color: #BE90D4;
            margin-top: 0.5em;
        }

        /* For Label CSS */
        .labelCSS {
            font-family: Calibri;
            font-size: 1.1em;
            color: #446CB3;
            /*#3A539B*/
        }

        /* For Textbox CSS */
        .textBoxCSS {
            font-size: 1em;
            font-family: Calibri;
            Height: 2.4em;
            color: #446CB3;
        }


        /* For First Column of Table (Questions)*/
        .TableColumn {
            color: black;
            font-family: Trebuchet MS;
            font-size: 1.2em;
            height: auto;
        }

        /* For Last Column of Table Row Distance*/
        .Space {
            margin-bottom: 1.5%;
        }

        /* Radio Button Space */
        .RadioSpace label {
            font-family: Calibri;
            margin-left: 10px;
            color: #486591;
            font-size: 1em;
        }



        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {

            thead th {
                display: none;
            }

            td[data-th]:before {
                content: attr(data-th);
            }



            /* own design*/
            table {
                border-collapse: collapse;
                width: 100%;
            }

            .trCSS {
                border-bottom: 1px solid #ddd;
            }

            .tdCSS, th {
                margin-top: 1em;
                display: block;
                font-family: Trebuchet MS;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }

            .ColumTOP {
                padding-top: 2.2em;
            }

            .ColumBOTTOM {
                padding-bottom: 1em;
            }
        }







        /* For Web Browser*/

        @media only screen and (min-width: 40em) {
            .buttonWeb {
                width: 22%;
                margin-left: 38%;
            }

            table {
                border-collapse: collapse;
                width: 100%;
            }

            .tdCSS {
                width: 50%;
                padding: 7px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .Mobile {
                padding-left: 5%;
                text-align: center;
                width: 95%;
            }

            .trCSS {
                height: 50px;
            }
        }
    </style>


    <script type="text/javascript">

        window.onload = function () {
            if (document.getElementById("txtq58").value == '1') {
                document.getElementById("divQ59a").style.display = 'table-row';
                document.getElementById("divQ59b").style.display = 'table-row';
                document.getElementById("divQ59c").style.display = 'table-row';
            }
        }




        function enable(id) {
            var val = document.getElementById(id).value;
            if (id == 'txtq58') {
                if (val != "" && val == 1) {
                    document.getElementById("divQ59a").style.display = 'table-row';
                    document.getElementById("divQ59b").style.display = 'table-row';
                    document.getElementById("divQ59c").style.display = 'table-row';
                }
                else if (val == "" || val != "1") {
                    document.getElementById("divQ59a").style.display = 'none';
                    document.getElementById("divQ59b").style.display = 'none';
                    document.getElementById("divQ59c").style.display = 'none';
                    document.getElementById("txtq59a").value = "";
                    document.getElementById("txtq59b").value = "";
                    document.getElementById("txtq59c").value = "";
                    document.getElementById("txtq59d").value = "";
                }
            }
        }










        function clicknext() {

            if (document.getElementById("txtq33").value == '' || document.getElementById("txtq33").value.length < 4) {
                alert("Enter Weight, 4 digit long !")
                document.getElementById("txtq33").focus();
                return false;
            }
            else if (document.getElementById("txtq34").value == '' || document.getElementById("txtq34").value.length < 3) {
                alert("Enter Value, 3 digit long !")
                document.getElementById("txtq34").focus();
                return false;
            }
            else if (document.getElementById("txtq35").value == '' || document.getElementById("txtq35").value.length < 3) {
                alert("Enter Value, 3 digit long !")
                document.getElementById("txtq35").focus();
                return false;
            }
            else if (document.getElementById("txtq36a").value == '' || document.getElementById("txtq36a").value.length < 3) {
                alert("Enter Value, 3 digit long !")
                document.getElementById("txtq36a").focus();
                return false;
            }
            else if (document.getElementById("txtq36b").value != '' && document.getElementById("txtq36b").value.length < 3) {
                alert("Enter Value, 3 digit long !")
                document.getElementById("txtq36b").focus();
                return false;
            }
            else if (document.getElementById("txtq37").value == '' || (document.getElementById("txtq37").value != '1' && document.getElementById("txtq37").value != '2')) {
                alert("Enter Value between 1 or 2")
                document.getElementById("txtq37").value = '';
                document.getElementById("txtq37").focus();
                return false;
            }
            else if (document.getElementById("txtq38a").value == '' || document.getElementById("txtq38a").value == '__._') {
                alert("Enter Value !")
                document.getElementById("txtq38a").focus();
                return false;
            }
            else if (document.getElementById("txtq38b").value != '' && document.getElementById("txtq38b").value == '__._') {
                alert("Enter Value !")
                document.getElementById("txtq38b").focus();
                return false;
            }
            else if (document.getElementById("txtq39").value == '' || (document.getElementById("txtq39").value < 1 || document.getElementById("txtq39").value > 3)) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtq39").value = '';
                document.getElementById("txtq39").focus();
                return false;
            }
            else if (document.getElementById("txtq40").value == '' || (document.getElementById("txtq40").value < 1 || document.getElementById("txtq40").value > 3)) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtq40").value = '';
                document.getElementById("txtq40").focus();
                return false;
            }
            else if (document.getElementById("txtq41a").value == '' || (document.getElementById("txtq41a").value < 1 || document.getElementById("txtq41a").value > 5)) {
                alert("Enter Value between 1 to 5")
                document.getElementById("txtq41a").value = '';
                document.getElementById("txtq41a").focus();
                return false;
            }
            else if (document.getElementById("txtq41b").value == '' || (document.getElementById("txtq41b").value < 1 || document.getElementById("txtq41b").value > 3)) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtq41b").value = '';
                document.getElementById("txtq41b").focus();
                return false;
            }
            else if (document.getElementById("txtq42").value == '' || (document.getElementById("txtq42").value < 1 || document.getElementById("txtq42").value > 3)) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtq42").value = '';
                document.getElementById("txtq42").focus();
                return false;
            }
            else if (document.getElementById("txtq43").value == '' || (document.getElementById("txtq43").value < 1 || document.getElementById("txtq43").value > 3)) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtq43").value = '';
                document.getElementById("txtq43").focus();
                return false;
            }
            else if (document.getElementById("txtq44").value == '' || (document.getElementById("txtq44").value < 1 || document.getElementById("txtq44").value > 4)) {
                alert("Enter Value between 1 to 4")
                document.getElementById("txtq44").value = '';
                document.getElementById("txtq44").focus();
                return false;
            }
            else if (document.getElementById("txtq45").value == '' || (document.getElementById("txtq45").value < 1 || document.getElementById("txtq45").value > 4)) {
                alert("Enter Value between 1 to 4")
                document.getElementById("txtq45").value = '';
                document.getElementById("txtq45").focus();
                return false;
            }
            else if (document.getElementById("txtq46").value == '' || (document.getElementById("txtq46").value < 1 || document.getElementById("txtq46").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq46").value = '';
                document.getElementById("txtq46").focus();
                return false;
            }
            else if (document.getElementById("txtq47").value == '' || (document.getElementById("txtq47").value < 1 || document.getElementById("txtq47").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq47").value = '';
                document.getElementById("txtq47").focus();
                return false;
            }
            else if (document.getElementById("txtq48").value == '' || (document.getElementById("txtq48").value < 1 || document.getElementById("txtq48").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq48").value = '';
                document.getElementById("txtq48").focus();
                return false;
            }
            else if (document.getElementById("txtq49").value == '' || (document.getElementById("txtq49").value < 1 || document.getElementById("txtq49").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq49").value = '';
                document.getElementById("txtq49").focus();
                return false;
            }
            else if (document.getElementById("txtq50").value == '' || (document.getElementById("txtq50").value < 1 || document.getElementById("txtq50").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq50").value = '';
                document.getElementById("txtq50").focus();
                return false;
            }
            else if (document.getElementById("txtq51").value == '' || (document.getElementById("txtq51").value < 1 || document.getElementById("txtq51").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq51").value = '';
                document.getElementById("txtq51").focus();
                return false;
            }
            else if (document.getElementById("txtq52").value == '' || (document.getElementById("txtq52").value < 1 || document.getElementById("txtq52").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq52").value = '';
                document.getElementById("txtq52").focus();
                return false;
            }
            else if (document.getElementById("txtq53").value == '' || (document.getElementById("txtq53").value < 1 || document.getElementById("txtq53").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq53").value = '';
                document.getElementById("txtq53").focus();
                return false;
            }
            else if (document.getElementById("txtq54").value == '' || (document.getElementById("txtq54").value < 1 || document.getElementById("txtq54").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq54").value = '';
                document.getElementById("txtq54").focus();
                return false;
            }
            else if (document.getElementById("txtq55").value == '' || (document.getElementById("txtq55").value < 1 || document.getElementById("txtq55").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq55").value = '';
                document.getElementById("txtq55").focus();
                return false;
            }
            else if (document.getElementById("txtq56").value == '' || (document.getElementById("txtq56").value < 1 || document.getElementById("txtq56").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq56").value = '';
                document.getElementById("txtq56").focus();
                return false;
            }
            else if (document.getElementById("txtq57").value == '' || (document.getElementById("txtq57").value < 1 || document.getElementById("txtq57").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq57").value = '';
                document.getElementById("txtq57").focus();
                return false;
            }
            else if (document.getElementById("txtq58").value == '' || (document.getElementById("txtq58").value < 1 || document.getElementById("txtq58").value > 4)) {
                alert("Enter Value 1 or 2")
                document.getElementById("txtq58").value = '';
                document.getElementById("txtq58").focus();
                return false;
            }
            else if (document.getElementById("txtq58").value == '1' && (document.getElementById("txtq59a").value == '' || document.getElementById("txtq59a").value.length < 2)) {
                alert("Enter Code Specify!")
                document.getElementById("txtq59a").focus();
                return false;
            }
            else if (document.getElementById("txtq58").value == '1' && (document.getElementById("txtq59b").value != '' && document.getElementById("txtq59b").value.length < 2)) {
                alert("Enter Code Specify!")
                document.getElementById("txtq59b").focus();
                return false;
            }
            else if (document.getElementById("txtq58").value == '1' && (document.getElementById("txtq59c").value != '' && document.getElementById("txtq59c").value.length < 2)) {
                alert("Enter Code Specify!")
                document.getElementById("txtq59c").focus();
                return false;
            }
            else if (document.getElementById("txtq58").value == '1' && (document.getElementById("txtq59d").value != '' && document.getElementById("txtq59d").value.length < 2)) {
                alert("Enter Code Specify!")
                document.getElementById("txtq59d").focus();
                return false;
            }
            else if (document.getElementById("txtq60").value != '' && document.getElementById("txtq60").value.length < 2) {
                alert("Enter Code Specify!")
                document.getElementById("txtq60").focus();
                return false;
            }
            else if (document.getElementById("txtq61").value != '' && document.getElementById("txtq61").value.length < 2) {
                alert("Enter Code Specify!")
                document.getElementById("txtq61").focus();
                return false;
            }

            else if (document.getElementById("txtq62").value != '' && document.getElementById("txtq62").value.length < 2) {
                alert("Enter Code Specify!")
                document.getElementById("txtq62").focus();
                return false;
            }

            else if (document.getElementById("txtq63").value != '' && document.getElementById("txtq63").value.length < 2) {
                alert("Enter Code Specify!")
                document.getElementById("txtq63").focus();
                return false;
            }
        }

    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <%--Entry Forms--%>

    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnNext" Visible="true">

        <table style="width: 100%; color: #4f5963; text-align: left;">

            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px">Newborn/Infant  Clinical  Assessment</td>
            </tr>



            <tr class="trCSS">
                <td class="TableColumn tdCSS">33. Current weight of the child</td>
                <td class="Space tdCSS">
                    <asp:TextBox ID="txtq33" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="4" placeholder="gram" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                </td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">34. Oxygen saturation</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq34" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="%" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">35. Heart rate</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq35" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="beats/min" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">36. Respiratory rate</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq36a" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="breaths/min" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq36b" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="breaths/min" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">37. Severe chest Indrawing</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq37" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">38. Axillary temperature</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq38a" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="98.0°C" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99.9" MaskType="Number" TargetControlID="txtq38a" />
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq38b" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="98.0°C" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99.9" MaskType="Number" TargetControlID="txtq38b" />
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">39. Level of consciousness of the baby and movement</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq39" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 3" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">40. Convulsions</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq40" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 3" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">41. Perform feeding assessment by observing breast feeding</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq41a" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 5" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq41b" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 3" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">42. Skin pustules</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq42" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 3" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">43. Is there pus (white or yellow) discharge present in the umbilicus?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq43" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 3" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">44. Is the cord or the base of umbilical stump red?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq44" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 4" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">45. Is the baby suffering from jaundice </td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq45" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 to 4" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">46. Apnoea</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq46" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">47. Cyanosis</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq47" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">48. Unable to cry</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq48" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">49. Bulging fontanelle</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq49" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">50. Prolonged capillary refill</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq50" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">51. Persistent vomiting</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq51" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">52. Diarrhoea</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq52" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">53. Runny nose</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq53" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">54. Conjunctivitis</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq54" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">55. Wheeze</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq55" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">56. White patches in mouth</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq56" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">57. Diaper dermatitis</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq57" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">58. Presence of congenital anomalies</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq58" ClientIDMode="Static" onkeyup="enable('txtq58')" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="1 / 2" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>

            <tr class="trCSS" id="divQ59a">
                <td class="TableColumn tdCSS" colspan="2">59. If congenital anomalies yes, specify </td>
            </tr>
            <tr class="trCSS" id="divQ59b">
                <td class="TableColumn tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq59a" ClientIDMode="Static" onkeyup="enable('txtq58')" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq59b" ClientIDMode="Static" onkeyup="enable('txtq58')" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS" id="divQ59c">
                <td class="TableColumn tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq59c" ClientIDMode="Static" onkeyup="enable('txtq58')" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq59d" ClientIDMode="Static" onkeyup="enable('txtq58')" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">60. Any Other Sign,  specify</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq60" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">61. Any Other Sign,  specify</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq61" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">62. Any Significant maternal history,  specify</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq62" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="specify reason" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">63. Any Significant maternal history,  specify</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq63" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="specify reason" runat="server"></asp:TextBox></td>
            </tr>
        </table>


        <br />
        <div class="buttonWeb">
            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-theme btn-lg btn-block" OnClick="next_Click" OnClientClick="return clicknext();" />
        </div>

        <br />
        <br />

    </asp:Panel>

</asp:Content>