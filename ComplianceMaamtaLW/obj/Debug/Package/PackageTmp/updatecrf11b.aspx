<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updatecrf11b.aspx.cs" Inherits="ComplianceMaamtaLW.updatecrf11b" Culture="en-GB"%>
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
            if (document.getElementById("txtq15").value == '9') {
                document.getElementById("Q15other").style.display = 'table-row';
            }
            if (document.getElementById("txtq31").value == '1') {
                document.getElementById("divQ32").style.display = 'block';
            }
        }




        function getChkboxChecked(id) {
            var chk = document.getElementById(id);
            if (chk.checked) {
                document.getElementById("Q15other").style.display = "table-row";
            }
            else {
                document.getElementById("Q15other").style.display = "none";
                document.getElementById("txtq15x").value = "";
            }
        }



        function enable(id) {
            var val = document.getElementById(id).value;
            if (id == 'txtq31') {
                if (val != "" && val == 1) {
                    document.getElementById("divQ32").style.display = 'block';
                }
                else if (val == "" || val != "1") {
                    document.getElementById("divQ32").style.display = 'none';
                }
            }

            if (id == 'txtq15') {
                if (val != "" && val == 9) {
                    document.getElementById("Q15other").style.display = 'table-row';
                }
                else if (val == "" || val != "9") {
                    document.getElementById("txtq15x").value = "";
                    document.getElementById("Q15other").style.display = 'none';
                }
            }
        }




        function clicknext() {



            //if (Q1501.checked == false && Q1502.checked == false && Q1503.checked == false && Q1504.checked == false && Q1505.checked == false && Q1506.checked == false && Q1507.checked == false && Q1508.checked == false && Q1509.checked == false) {
            //    alert("Select Q15 checks from 1 to 9")
            //    document.getElementById("chk01").focus();
            //    return false;
            //}
            if (document.getElementById("txtq15").value == '' || document.getElementById("txtq15").value < 1) {
                alert("Enter Value between 1 to 9!")
                document.getElementById("txtq15").focus();
                return false;
            }
            else if (document.getElementById("txtq15").value == '9' && (document.getElementById("txtq15x").value == '' || document.getElementById("txtq15x").value.length < 2)) {
                alert("Enter Code Specify!")
                document.getElementById("txtq15x").focus();
                return false;
            }
            else if (document.getElementById("txtq16").value == '' || (document.getElementById("txtq16").value != '1' && document.getElementById("txtq16").value != '2' && document.getElementById("txtq16").value != '3')) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtq16").value = '';
                document.getElementById("txtq16").focus();
                return false;
            }
            else if (document.getElementById("txtq17").value == '' || (document.getElementById("txtq17").value != '1' && document.getElementById("txtq17").value != '2')) {
                alert("Enter Value between 1 to 2")
                document.getElementById("txtq17").value = '';
                document.getElementById("txtq17").focus();
                return false;
            }
            else if (document.getElementById("txtq18").value == '' || (document.getElementById("txtq18").value != '1' && document.getElementById("txtq18").value != '2' && document.getElementById("txtq18").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq18").value = '';
                document.getElementById("txtq18").focus();
                return false;
            }

            else if (document.getElementById("txtq19").value == '' || (document.getElementById("txtq19").value != '1' && document.getElementById("txtq19").value != '2' && document.getElementById("txtq19").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq19").value = '';
                document.getElementById("txtq19").focus();
                return false;
            }
            else if (document.getElementById("txtq20").value == '' || (document.getElementById("txtq20").value != '1' && document.getElementById("txtq20").value != '2' && document.getElementById("txtq20").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq20").value = '';
                document.getElementById("txtq20").focus();
                return false;
            }
            else if (document.getElementById("txtq21").value == '' || (document.getElementById("txtq21").value != '1' && document.getElementById("txtq21").value != '2' && document.getElementById("txtq21").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq21").value = '';
                document.getElementById("txtq21").focus();
                return false;
            }
            else if (document.getElementById("txtq22").value == '' || (document.getElementById("txtq22").value != '1' && document.getElementById("txtq22").value != '2' && document.getElementById("txtq22").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq22").value = '';
                document.getElementById("txtq22").focus();
                return false;
            }
            else if (document.getElementById("txtq23").value == '' || (document.getElementById("txtq23").value != '1' && document.getElementById("txtq23").value != '2' && document.getElementById("txtq23").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq23").value = '';
                document.getElementById("txtq23").focus();
                return false;
            }
            else if (document.getElementById("txtq24").value == '' || (document.getElementById("txtq24").value != '1' && document.getElementById("txtq24").value != '2' && document.getElementById("txtq24").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq24").value = '';
                document.getElementById("txtq24").focus();
                return false;
            }
            else if (document.getElementById("txtq25").value == '' || (document.getElementById("txtq25").value != '1' && document.getElementById("txtq25").value != '2' && document.getElementById("txtq25").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq25").value = '';
                document.getElementById("txtq25").focus();
                return false;
            }
            else if (document.getElementById("txtq26").value == '' || (document.getElementById("txtq26").value != '1' && document.getElementById("txtq26").value != '2' && document.getElementById("txtq26").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq26").value = '';
                document.getElementById("txtq26").focus();
                return false;
            }
            else if (document.getElementById("txtq27").value == '' || (document.getElementById("txtq27").value != '1' && document.getElementById("txtq27").value != '2' && document.getElementById("txtq27").value != '8')) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq27").value = '';
                document.getElementById("txtq27").focus();
                return false;
            }
            else if (document.getElementById("txtq28").value != '' && document.getElementById("txtq28").value.length < 2) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq28").focus();
                return false;
            }
            else if (document.getElementById("txtq29").value != '' && document.getElementById("txtq29").value.length < 2) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq29").focus();
                return false;
            }
            else if (document.getElementById("txtq30").value != '' && document.getElementById("txtq30").value.length < 2) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq30").focus();
                return false;
            }
            else if (document.getElementById("txtq31").value == '' || (document.getElementById("txtq31").value != 8 && (document.getElementById("txtq31").value < 1 || document.getElementById("txtq31").value > 2))) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq31").value = '';
                document.getElementById("txtq31").focus();
                return false;
            }


        }







        function clicksubmit() {

            if (document.getElementById("txtq31").value == '' || (document.getElementById("txtq31").value != 8 && (document.getElementById("txtq31").value < 1 || document.getElementById("txtq31").value > 2))) {
                alert("Enter Value between 1,2 or 8")
                document.getElementById("txtq31").value = '';
                document.getElementById("txtq31").focus();
                return false;
            }
            else if (document.getElementById("txtq31").value == '1' && document.getElementById("txtQ32_1").value.length < 2) {
                alert("Enter Code, 2 digit long!")
                document.getElementById("txtQ32_1").focus();
                return false;
            }
            else if (document.getElementById("txtq31").value == '1' && (document.getElementById("txtQ32_2").value < 1 || document.getElementById("txtQ32_2").value > 3)) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtQ32_2").value = '';
                document.getElementById("txtQ32_2").focus();
                return false;
            }
            else if (document.getElementById("txtq31").value == '1' && document.getElementById("txtQ32_3").value == "") {
                alert("Enter Value!")
                document.getElementById("txtQ32_3").focus();
                return false;
            }
            else if (document.getElementById("txtq31").value == '1' && document.getElementById("txtQ32_4").value.length < 2) {
                alert("Enter Value, 2 digit long!")
                document.getElementById("txtQ32_4").focus();
                return false;
            }
            else if (document.getElementById("txtq31").value == '1' && document.getElementById("txtQ32_5").value.length < 2) {
                alert("Enter Value, 2 digit long!")
                document.getElementById("txtQ32_5").focus();
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

           <%-- <tr class="trCSS">
                <td class="TableColumn tdCSS">15. Caretaker (Relation to Newborn)</td>
                <td class="Space tdCSS" style="font-size: 15px;">
                    <asp:CheckBox ID="chk01" Text="&emsp;1.	Mother" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk02" Text="&emsp;2.	Grand Mother" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk03" Text="&emsp;3.	Aunt" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk04" Text="&emsp;4.	Sister" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk05" Text="&emsp;5.	Father" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk06" Text="&emsp;6.	Grant Father" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk07" Text="&emsp;7.	Uncle" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk08" Text="&emsp;8.	Brother" runat="server" ClientIDMode="Static" /><br />
                    <asp:CheckBox ID="chk09" Text="&emsp;9.	Other (Specify)" runat="server" ClientIDMode="Static" onclick="getChkboxChecked('chk09')" /><br />
                </td>
            </tr>--%>


            <tr class="trCSS">
                <td class="TableColumn tdCSS">15. Caretaker (Relation to Newborn)</td>
                <td class="Space tdCSS">
                    <asp:TextBox ID="txtq15" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" onkeyup="enable('txtq15')" type="text" Font-Size="Medium" Height="2.1em" MaxLength="1" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                </td>
            </tr>
            <tr id="Q15other" class="trCSS" style="display: none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox ID="txtq15x" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="others" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                </td>
            </tr>




            <tr class="trCSS">
                <td class="TableColumn tdCSS">16. Was the newborn referred by the CHW or did someone else referred or was it a self-referral?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq16" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">17. Purpose of referral</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq17" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>

            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px">History of infant’s symptoms  (Ask the Caretaker)</td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">18. Has the baby been feeding poorly?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq18" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">19. Has the baby had a fever?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq19" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">20. Has the baby felt cold to the touch?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq20" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">21. Has the baby had a runny nose recently?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq21" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">22. Does the baby have a cough?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq22" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">23. Does the baby have fast or difficult breathing?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq23" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">24. Has the baby had vomiting?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq24" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">25. Has the baby been having diarrhea?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq25" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">26. Has there been blood in the baby’s stools?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq26" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">27. Has there been discharge from the baby's umbilicus?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq27" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">28. Other,  specify</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq28" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">29. Other,  specify</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq29" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">30. Other,  specify</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq30" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
            </tr>




            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px">Medication History (Ask the Caretaker)</td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">31. Did the baby receive any medicine over the last seven days?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq31" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" onkeyup="enable('txtq31')" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS" colspan="2">32. What medicines were received by the baby? </td>
            </tr>

        </table>









        <div id="divQ32" style="text-align: center; font-size: small; background-color: #EDEDED; font-family: Tahoma; border: solid 1px;">
            <asp:Panel ID="PanelSubmit" runat="server" DefaultButton="add" ClientIDMode="Static">
                <table style="width: 100%; color: #4f5963; text-align: center;">
                    <tr class="trCSS">
                        <td><b>S No.</b></td>
                        <td><b>Name of Medicine Code</b></td>
                        <td><b>Type</b></td>
                        <td><b>Time/Day</b></td>
                        <td><b>Hours since last dose</b></td>
                        <td><b>Total day given</b></td>
                    </tr>
                    <tr class="trCSS">
                        <td class="Space">
                            <asp:Label ID="lbeRecord" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label>
                        </td>
                        <td class="Space">
                            <asp:TextBox ID="txtQ32_1" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="3" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                        <td class="Space">
                            <asp:TextBox ID="txtQ32_2" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="1" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                        <td class="Space">
                            <asp:TextBox ID="txtQ32_3" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                        <td class="Space">
                            <asp:TextBox ID="txtQ32_4" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                        <td class="Space">
                            <asp:TextBox ID="txtQ32_5" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                    </tr>
                </table>


                <div style="margin-top: 8px; margin-bottom: -10px">
                    <asp:Button ID="add" CssClass="btn btn-theme" runat="server" Text="Add" OnClientClick="return clicksubmit();" OnClick="add_Click" />
                </div>
                <hr>


                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="Linkbutton1" CommandArgument='<%#Eval("crf11_id")+ ";" +Eval("rec_id") %>' OnClick="Link_Button1" Text='Edit' runat="server" ToolTip="Edit Row"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="rec_id" HeaderText="Record no." />
                        <asp:BoundField DataField="lw_crf11_32_medi" HeaderText="Name of Medicine & Code" />
                        <asp:BoundField DataField="lw_crf11_32_type" HeaderText="Type" />
                        <asp:BoundField DataField="lw_crf11_32_tm_day" HeaderText="Time/Day" />
                        <asp:BoundField DataField="lw_crf11_32_dose" HeaderText="Hours since last dose" />
                        <asp:BoundField DataField="lw_crf11_32_tot_day" HeaderText="Total day given" />
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <FooterStyle Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Gray" ForeColor="white" Font-Bold="True" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </asp:Panel>
        </div>





        <br />
        <div class="buttonWeb">
            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-theme btn-lg btn-block" OnClick="next_Click" OnClientClick="return clicknext();" />
        </div>

        <br />
        <br />

    </asp:Panel>

</asp:Content>
