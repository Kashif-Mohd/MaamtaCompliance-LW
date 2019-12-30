<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updatecrf8d.aspx.cs" Inherits="ComplianceMaamtaLW.updatecrf8d" Culture="ar-DZ" %>

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
            if (document.getElementById("txtq31").value == '3') {
                document.getElementById("TR_Q31").style.display = 'table-row';
            }
            if (document.getElementById("txtq33").value == '6') {
                document.getElementById("TR_Q33").style.display = 'table-row';
            }
            if (document.getElementById("txtq34").value == '6') {
                document.getElementById("TR_Q34").style.display = 'table-row';
            }
            if (document.getElementById("txtq34").value == '5') {
                document.getElementById("TR_Q35").style.display = 'table-row';
                document.getElementById("TR_Q36").style.display = 'table-row';
            }
            if (document.getElementById("txtq37").value == '3') {
                document.getElementById("TR_Q37").style.display = 'table-row';
            }
            if (document.getElementById("txtq38").value == '1') {
                document.getElementById("TR_Q38").style.display = 'table-row';
            }
        }



        function enable(id) {
            var val = document.getElementById(id).value;
            if (id == 'txtq31') {
                if (val != "" && val == 3) {
                    document.getElementById("TR_Q31").style.display = 'table-row';
                }
                else if (val == "" || val != "3") {
                    document.getElementById("TR_Q31").style.display = 'none';
                    document.getElementById("txtq31_other").value = "";
                }
            }
            else if (id == 'txtq33') {
                if (val != "" && val == 6) {
                    document.getElementById("TR_Q33").style.display = 'table-row';
                }
                else if (val == "" || val != "6") {
                    document.getElementById("TR_Q33").style.display = 'none';
                    document.getElementById("txtq33_other").value = "";
                }
            }
            else if (id == 'txtq34') {
                if (val != "" && val == 6) {
                    document.getElementById("TR_Q34").style.display = 'table-row';
                    document.getElementById("TR_Q35").style.display = 'none';
                    document.getElementById("TR_Q36").style.display = 'none';
                    document.getElementById("txtq35").value = "";
                    document.getElementById("txtq36").value = "";
                }
                else if (val != "" && val == 5) {
                    document.getElementById("TR_Q34").style.display = 'none';
                    document.getElementById("TR_Q35").style.display = 'table-row';
                    document.getElementById("TR_Q36").style.display = 'table-row';
                    document.getElementById("txtq34_other").value = "";
                }
                else if (val == "" || (val != "5" && val != "6")) {
                    document.getElementById("TR_Q34").style.display = 'none';
                    document.getElementById("TR_Q35").style.display = 'none';
                    document.getElementById("TR_Q36").style.display = 'none';
                    document.getElementById("txtq34_other").value = "";
                    document.getElementById("txtq35").value = "";
                    document.getElementById("txtq36").value = "";
                }
            }
            else if (id == 'txtq37') {
                if (val != "" && val == 3) {
                    document.getElementById("TR_Q37").style.display = 'table-row';
                }
                else if (val == "" || val != "3") {
                    document.getElementById("TR_Q37").style.display = 'none';
                    document.getElementById("txtq37_other").value = "";
                }
            }
            else if (id == 'txtq38') {
                if (val != "" && val == 1) {
                    document.getElementById("TR_Q38").style.display = 'table-row';
                }
                else if (val == "" || val != "1") {
                    document.getElementById("TR_Q38").style.display = 'none';
                    document.getElementById("txtq38_other").value = "";
                }
            }
        }








        function Validate(rb) {
            var rb;
            var radio = rb.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    isChecked = true;
                    break;
                }
            }
            return isChecked;
        }






        function clicknext() {

            if (Validate(document.getElementById("<%=txtq41.ClientID%>")) == false) {
                alert("Select Q41 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq42.ClientID%>")) == false) {
                alert("Select Q42 Value")
                return false;
            }
            else if (document.getElementById("txtq43").value == '__-__-____' || document.getElementById("txtq43").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq43").focus();
                return false;
            }
            else if (document.getElementById("txtq45").value == '__-__-____' || document.getElementById("txtq45").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq45").focus();
                return false;
            }
            else if (document.getElementById("txtq4701").value == '' || document.getElementById("txtq4701").value.length < 2) {
                alert("Enter Q47 Code!")
                document.getElementById("txtq4701").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq48.ClientID%>")) == false) {
                alert("Select Q48 Value")
                document.getElementById("txtq48").focus();
                return false;
            }
            else if (Q49_01.checked == false && Q49_02.checked == false && Q49_03.checked == false) {
                alert("Select Q49 values from 1 to 3")
                document.getElementById("chkQ49_01").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq50.ClientID%>")) == false) {
                alert("Select Q50 Value")
                document.getElementById("txtq50").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq51.ClientID%>")) == false) {
                alert("Select Q51 Value")
                document.getElementById("txtq51").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq52.ClientID%>")) == false) {
                alert("Select Q52 Value")
                document.getElementById("txtq52").focus();
                return false;
            }

}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--Entry Forms--%>

    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit" Visible="true">
        <table style="width: 100%; color: #4f5963; text-align: left;">

            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 16px">To be verified by the PI</td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q41. Relation to study interventions - Maamta</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq41" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp None" Value="1" />
                        <asp:ListItem Text="&nbsp Remote" Value="2" />
                        <asp:ListItem Text="&nbsp Possible" Value="3" />
                        <asp:ListItem Text="&nbsp Probable" Value="4" />
                        <asp:ListItem Text="&nbsp Definite" Value="5" />
                        <asp:ListItem Text="&nbsp Not assessed" Value="6" />
                        <asp:ListItem Text="&nbsp Not applicable" Value="7" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q42. Relation to study interventions - Azihtomycin</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq42" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp None" Value="1" />
                        <asp:ListItem Text="&nbsp Remote" Value="2" />
                        <asp:ListItem Text="&nbsp Possible" Value="3" />
                        <asp:ListItem Text="&nbsp Probable" Value="4" />
                        <asp:ListItem Text="&nbsp Definite" Value="5" />
                        <asp:ListItem Text="&nbsp Not assessed" Value="6" />
                        <asp:ListItem Text="&nbsp Not applicable" Value="7" />
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q43. Date when ADR was reported to DSMB</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq43" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq43" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq44" runat="server" clientidmode="Static" style="height: 50px; width: 80%;" placeholder="Q44. Comments if Any from DSMB..."></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q45. Date when ADR was reported to IRB/ERC</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq45" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq45" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq46" runat="server" clientidmode="Static" style="height: 50px; width: 80%;" placeholder="Q46. Comments if Any from IRB..."></textarea></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q47. SAE characteristics or diagnosis by study physician or key danger sign/s or details from medical record</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq4701" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="2" runat="server"></asp:TextBox>
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq4702" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="2" runat="server"></asp:TextBox>
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq4703" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="2" runat="server"></asp:TextBox>
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq4704" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="2" runat="server"></asp:TextBox>
                </td>
            </tr>


            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q48. Status of proposed treatment after SAEs appear</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq48" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Completed" Value="1" />
                        <asp:ListItem Text="&nbsp Still hospitalized" Value="2" />
                        <asp:ListItem Text="&nbsp Death" Value="3" />
                        <asp:ListItem Text="&nbsp LAMA" Value="4" />
                        <asp:ListItem Text="&nbsp On going" Value="5" />
                        <asp:ListItem Text="&nbsp Sudden Death" Value="6" />
                        <asp:ListItem Text="&nbsp Died at AKUH" Value="7" />
                        <asp:ListItem Text="&nbsp Discharged on medication and died later" Value="8" />
                        <asp:ListItem Text="&nbsp Refused" Value="9" />
                        <asp:ListItem Text="&nbsp Persist" Value="10" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q49. Categorization of SAE (Multiple Option)</td>
                <td class="Space tdCSS" style="font-size: 15px;">
                    <asp:CheckBox ID="chkQ49_01" Text="&emsp;1.	IM/IV injectable" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ49_02" Text="&emsp;2.	Hospitalization" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chkQ49_03" Text="&emsp;3.	Fatal" runat="server" ClientIDMode="Static" /><br />
                </td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q50. Event abated after discontinuation of the study intervention</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq50" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                        <asp:ListItem Text="&nbsp Not Applicable" Value="3" />
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q51. Event reappeared after reintroducing study intervention</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq51" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                        <asp:ListItem Text="&nbsp Not Applicable" Value="3" />
                    </asp:RadioButtonList>
                </td>
            </tr>
                        <tr class="trCSS">
                <td class="TableColumn tdCSS">Q52. Participant withdrawn from study follow-ups</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq52" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>


        </table>

        <br />
        <div class="buttonWeb">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" OnClientClick="return clicknext();" />
        </div>

        <br />
        <br />

    </asp:Panel>
</asp:Content>
