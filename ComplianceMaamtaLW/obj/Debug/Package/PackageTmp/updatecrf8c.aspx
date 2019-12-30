<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updatecrf8c.aspx.cs" Inherits="ComplianceMaamtaLW.updatecrf8c"  Culture="ar-DZ"%>
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
            var chkBox = document.getElementById('<%= chk08.ClientID %>');
            if (chkBox.checked) {
                document.getElementById("TR_Q33").style.display = "table-row";
            }
            else {
                document.getElementById("TR_Q33").style.display = "none";
            }

            if ($('#<%= txtq31.ClientID %> input:checked').val() == '3') {
                document.getElementById("TR_Q31").style.display = 'table-row';
            }
            if ($('#<%= txtq34.ClientID %> input:checked').val() == '6') {
                document.getElementById("TR_Q34").style.display = 'table-row';
            }
            if ($('#<%= txtq34.ClientID %> input:checked').val() == '5') {
                document.getElementById("TR_Q35").style.display = 'table-row';
                document.getElementById("TR_Q36").style.display = 'table-row';
                document.getElementById("TR_Q37").style.display = 'table-row';
                document.getElementById("TR_Q37zzz").style.display = 'table-row';
                document.getElementById("TR_Q38").style.display = 'table-row';
                document.getElementById("TR_Q38zzz").style.display = 'table-row';
            }
            if ($('#<%= txtq37.ClientID %> input:checked').val() == '3') {
                document.getElementById("TR_Q37").style.display = 'table-row';
            }
            if ($('#<%= txtq38.ClientID %> input:checked').val() == '1') {
                document.getElementById("TR_Q38").style.display = 'table-row';
            }
          
        }





        function getChkboxChecked(id) {
            var chk = document.getElementById(id);
            if (chk.checked) {
                document.getElementById("TR_Q33").style.display = "table-row";
            }
            else
                document.getElementById("TR_Q33").style.display = "none";
            document.getElementById("txtq33_other").value = "";
        }




        function RadioButton(id) {

            var Q31 = $('#<%= txtq31.ClientID %> input:checked').val();
            var Q34 = $('#<%= txtq34.ClientID %> input:checked').val();
            var Q37 = $('#<%= txtq37.ClientID %> input:checked').val();
            var Q38 = $('#<%= txtq38.ClientID %> input:checked').val();

            if (id == 'txtq31') {
                if (Q31 != '' && Q31 == '3') {
                    document.getElementById("TR_Q31").style.display = 'table-row';
                }
                else if (Q31 == '' || Q31 != '3') {
                    document.getElementById("TR_Q31").style.display = 'none';
                    document.getElementById("txtq31_other").value = "";
                }
            }
            else if (id == 'txtq34') {
                if (Q34 != '' && Q34 == '6') {
                    document.getElementById("TR_Q34").style.display = 'table-row';
                    document.getElementById("TR_Q35").style.display = 'none';
                    document.getElementById("TR_Q36").style.display = 'none';
                    document.getElementById("TR_Q37").style.display = 'none';
                    document.getElementById("TR_Q37zzz").style.display = 'none';
                    document.getElementById("TR_Q38").style.display = 'none';
                    document.getElementById("TR_Q38zzz").style.display = 'none';
                    document.getElementById("txtq35").value = "";
                    document.getElementById("txtq36").value = "";
                    document.getElementById("txtq37").value = "";
                    document.getElementById("txtq37_other").value = "";
                    document.getElementById("txtq38").value = "";
                    document.getElementById("txtq38_other").value = "";
                }
                else if (Q34 != '' && Q34 == '5') {
                    document.getElementById("TR_Q34").style.display = 'none';
                    document.getElementById("TR_Q35").style.display = 'table-row';
                    document.getElementById("TR_Q36").style.display = 'table-row';
                    document.getElementById("TR_Q37").style.display = 'table-row';
                    document.getElementById("TR_Q37zzz").style.display = 'table-row';
                    document.getElementById("TR_Q38").style.display = 'table-row';
                    document.getElementById("TR_Q38zzz").style.display = 'table-row';
                    document.getElementById("txtq34_other").value = "";
                }
                else if (Q34 == '' || (Q34 != '5' && Q34 != '6')) {
                    document.getElementById("TR_Q34").style.display = 'none';
                    document.getElementById("TR_Q35").style.display = 'none';
                    document.getElementById("TR_Q36").style.display = 'none';
                    document.getElementById("TR_Q37").style.display = 'none';
                    document.getElementById("TR_Q37zzz").style.display = 'none';
                    document.getElementById("TR_Q38").style.display = 'none';
                    document.getElementById("TR_Q38zzz").style.display = 'none';
                    document.getElementById("txtq34_other").value = "";
                    document.getElementById("txtq35").value = "";
                    document.getElementById("txtq36").value = "";
                    document.getElementById("txtq37").value = "";
                    document.getElementById("txtq37_other").value = "";
                    document.getElementById("txtq38").value = "";
                    document.getElementById("txtq38_other").value = "";
                }
            }
            else if (id == 'txtq37') {
                if (Q37 != '' && Q37 == '3') {
                    document.getElementById("TR_Q37").style.display = 'table-row';
                }
                else if (Q37 == '' || Q37 != '3') {
                    document.getElementById("TR_Q37").style.display = 'none';
                    document.getElementById("txtq37_other").value = "";
                }
            }
            else if (id == 'txtq38') {
                if (Q38 != '' && Q38 == '1') {
                    document.getElementById("TR_Q38").style.display = 'table-row';
                }
                else if (Q38 == '' || Q38 != '1') {
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

            var Q3301 = document.getElementById('<%= chk01.ClientID %>');
            var Q3302 = document.getElementById('<%= chk02.ClientID %>');
            var Q3303 = document.getElementById('<%= chk03.ClientID %>');
            var Q3304 = document.getElementById('<%= chk04.ClientID %>');
            var Q3305 = document.getElementById('<%= chk05.ClientID %>');
            var Q3306 = document.getElementById('<%= chk06.ClientID %>');
            var Q3307 = document.getElementById('<%= chk07.ClientID %>');
            var Q3308 = document.getElementById('<%= chk08.ClientID %>');


            if (Validate(document.getElementById("<%=txtq31.ClientID%>")) == false) {
                alert("Select Q31 Value")
                return false;
            }
            else if ($('#<%= txtq31.ClientID %> input:checked').val() == '3' && document.getElementById("txtq31_other").value == '') {
                alert("Enter Description!")
                document.getElementById("txtq31_other").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq32_1a.ClientID%>")) == false) {
                alert("Select Q32_1 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq32_2a.ClientID%>")) == false) {
                alert("Select Q32_2 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq32_3a.ClientID%>")) == false) {
                alert("Select Q32_3 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq32_4a.ClientID%>")) == false) {
                alert("Select Q32_4 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq32_5a.ClientID%>")) == false) {
                alert("Select Q32_5 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq32_5a.ClientID%>")) == false) {
                alert("Select Q32_6 Value")
                return false;
            }


            else if (Q3301.checked == false && Q3302.checked == false && Q3303.checked == false && Q3304.checked == false && Q3305.checked == false && Q3306.checked == false && Q3307.checked == false && Q3308.checked == false) {
                alert("Select values from 1 to 8")
                document.getElementById("chk01").focus();
                return false;
            }

            else if (document.getElementById('<%= chk08.ClientID %>').checked == true && (document.getElementById("txtq33_other").value == '' || document.getElementById("txtq33_other").value.length < 2)) {
                alert("Enter Other Code, or Text!")
                document.getElementById("txtq33_other").focus();
                return false;
            }

            else if (Validate(document.getElementById("<%=txtq34.ClientID%>")) == false) {
                alert("Select Q34 Value")
                return false;
            }

            else if ($('#<%= txtq34.ClientID %> input:checked').val() == '6' && (document.getElementById("txtq34_other").value == '' || document.getElementById("txtq34_other").value.length < 2)) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq34_other").focus();
                return false;
            }

            else if ($('#<%= txtq34.ClientID %> input:checked').val() == '5' && (document.getElementById("txtq35").value == '__-__-____' || document.getElementById("txtq35").value == '')) {
                alert("Enter Date!")
                document.getElementById("txtq35").focus();
                return false;
            }
            else if ($('#<%= txtq34.ClientID %> input:checked').val() == '5' && (document.getElementById("txtq36").value == '' || document.getElementById("txtq36").value == '__:__')) {
                alert("Enter Time!")
                document.getElementById("txtq36").focus();
                return false;
            }



            else if ($('#<%= txtq34.ClientID %> input:checked').val() == '5' && Validate(document.getElementById("<%=txtq37.ClientID%>")) == false) {
                alert("Select Q37 Value")
                return false;
            }

            else if ($('#<%= txtq34.ClientID %> input:checked').val() == '5' && ($('#<%= txtq37.ClientID %> input:checked').val() == '3' && (document.getElementById("txtq37_other").value == '' || document.getElementById("txtq37_other").value.length < 2))) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq37_other").focus();
                return false;
            }

            else if ($('#<%= txtq34.ClientID %> input:checked').val() == '5' && Validate(document.getElementById("<%=txtq38.ClientID%>")) == false) {
                alert("Select Q38 Value")
                return false;
            }
            else if ($('#<%= txtq34.ClientID %> input:checked').val() == '5' && ($('#<%= txtq38.ClientID %> input:checked').val() == '1' && document.getElementById("txtq38_other").value == '')) {
                alert("Enter Details!")
                document.getElementById("txtq38_other").focus();
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
                <td class="TableColumn tdCSS">31. Where did the adverse event happen?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq31" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq31')">
                        <asp:ListItem Text="&nbsp At home" Value="1" />
                        <asp:ListItem Text="&nbsp At health care centre/clinic/hospital" Value="2" />
                        <asp:ListItem Text="&nbsp Others" Value="3" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q31" style="display: none">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq31_other" runat="server" clientidmode="Static" style="height: 50px; width: 80%;" placeholder="Describe the location..."></textarea></td>
            </tr>




            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 16px">Q32. Classify severity or seriousness of adverse events</td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">1. <b>No adverse event</b>
                </td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq32_1a" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>




            <tr class="trCSS">
                <td class="TableColumn tdCSS">2. <b>Mild</b>
                </td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq32_2a" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>



            <tr class="trCSS">
                <td class="TableColumn tdCSS">3. <b>Moderate</b>
                </td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq32_3a" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>


            <tr class="trCSS">
                <td class="TableColumn tdCSS">4. <b>Severe</b>
                </td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq32_4a" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>



            <tr class="trCSS">
                <td class="TableColumn tdCSS">5. <b>Life Threatening</b>
                </td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq32_5a" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>




            <tr class="trCSS">
                <td class="TableColumn tdCSS">6. <b>Fatal</b>

                </td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq32_6a" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp Yes" Value="1" />
                        <asp:ListItem Text="&nbsp No" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>





            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 16px"></td>
            </tr>





            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q33. What was the action taken in terms of trial intervention?</td>
                <td class="Space tdCSS">
                    <asp:CheckBox ID="chk01" Text="&emsp;1.	Nothing, LW continues using LNS regularly" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk02" Text="&emsp;2.	Hold LNS for few days" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk03" Text="&emsp;3.	Discontinued LNS since ADR happened " runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk04" Text="&emsp;4.	LW was hospitalized " runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk05" Text="&emsp;5.	Infant was hospitalised " runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk06" Text="&emsp;6.	Infant on injectable" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk07" Text="&emsp;7.	Not Applicable" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk08" Text="&emsp;8.	Other (specify)" runat="server" ClientIDMode="Static" onclick="getChkboxChecked('chk08')" /><br />
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q33" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq33_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>




            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q34. Outcome of event</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq34" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq34')">
                        <asp:ListItem Text="&nbsp Resolved" Value="1" />
                        <asp:ListItem Text="&nbsp Improved" Value="2" />
                        <asp:ListItem Text="&nbsp Unchanged" Value="3" />
                        <asp:ListItem Text="&nbsp Worsened" Value="4" />
                        <asp:ListItem Text="&nbsp Death" Value="5" />
                        <asp:ListItem Text="&nbsp Other" Value="6" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q34" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq34_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>




            <tr class="trCSS" id="TR_Q35" style="display: none">
                <td class="TableColumn tdCSS">Q35. Date of Death (if died) 88-88-8888 if not applicable</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq35" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq35" />
            </tr>
            <tr class="trCSS" id="TR_Q36" style="display: none">
                <td class="TableColumn tdCSS">Q36. Time of Death</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq36" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq36" />
            </tr>




            <tr class="trCSS" id="TR_Q37zzz" style="display: none">
                <td class="TableColumn tdCSS">Q37. Place of Death</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq37" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq37')">
                        <asp:ListItem Text="&nbsp At home" Value="1" />
                        <asp:ListItem Text="&nbsp At healthcare centre/clinic/Hospital" Value="2" />
                        <asp:ListItem Text="&nbsp Others" Value="3" />
                        <asp:ListItem Text="&nbsp Not applicable" Value="4" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q37" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq37_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>




            <tr class="trCSS" id="TR_Q38zzz" style="display: none">
                <td class="TableColumn tdCSS">Q38. Cause of Death</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq38" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq38')">
                        <asp:ListItem Text="&nbsp Known (If yes, mention in detail below)" Value="1" />
                        <asp:ListItem Text="&nbsp Unknown" Value="2" />
                        <asp:ListItem Text="&nbsp Not applicable" Value="3" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q38" style="display: none">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq38_other" runat="server" clientidmode="Static" style="height: 50px; width: 80%;" placeholder="Details..."></textarea></td>
            </tr>




            <tr class="trCSS">
                <td class="TableColumn tdCSS">Q39. Adverse was related to trial team</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq39" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp LNS supplement" Value="1" />
                        <asp:ListItem Text="&nbsp Azithromycin" Value="2" />
                        <asp:ListItem Text="&nbsp None" Value="3" />
                    </asp:RadioButtonList>
                </td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq40" runat="server" clientidmode="Static" style="height: 80px; width: 80%;" placeholder="Q40. Comments (if any) from Research Specialist..."></textarea></td>
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
