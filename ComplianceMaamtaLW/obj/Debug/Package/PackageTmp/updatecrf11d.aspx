<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updatecrf11d.aspx.cs" Inherits="ComplianceMaamtaLW.updatecrf11d" Culture="en-GB"%>
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
             var chk07 = document.getElementById('<%= chk07.ClientID %>');
            if (chk07.checked) {
                document.getElementById("divQ64a").style.display = "table-row";
                document.getElementById("divQ64b").style.display = "table-row";
            }
            if (document.getElementById("txtq69").value == '1') {
                document.getElementById("divQ70").style.display = 'block';
            }
            if (document.getElementById("txtq71").value == '6') {
                document.getElementById("divQ71x").style.display = 'table-row';
            }
            if (document.getElementById("txtq67").value == '2') {
                document.getElementById("divQ68a").style.display = 'table-row';
                document.getElementById("divQ68b").style.display = 'table-row';
            }
        }




        function getChkboxChecked(id) {
            var chk = document.getElementById(id);
            if (chk.checked) {
                document.getElementById("divQ64a").style.display = "table-row";
                document.getElementById("divQ64b").style.display = "table-row";
            }
            else {
                document.getElementById("divQ64a").style.display = "none";
                document.getElementById("divQ64b").style.display = "none";
                document.getElementById("txtq64a").value = "";
                document.getElementById("txtq64b").value = "";
                document.getElementById("txtq64c").value = "";
                document.getElementById("txtq64d").value = "";
            }
        }







        function enable(id) {
            var val = document.getElementById(id).value;

            if (id == 'txtq65') {
                if (val == "" || val != 1) {
                    document.getElementById("divQ66").style.display = 'table-row';
                    document.getElementById("divQ67").style.display = 'table-row';
                    document.getElementById("divQ68a").style.display = 'table-row';
                    document.getElementById("divQ68b").style.display = 'table-row';
                }
                else if (val == "1") {
                    document.getElementById("divQ66").style.display = 'none';
                    document.getElementById("divQ67").style.display = 'none';
                    document.getElementById("divQ68a").style.display = 'none';
                    document.getElementById("divQ68b").style.display = 'none';
                }
            }



            if (id == 'txtq69') {
                if (val != "" && val == 1) {
                    document.getElementById("divQ70").style.display = 'block';
                }
                else if (val == "" || val != "1") {
                    document.getElementById("divQ70").style.display = 'none';
                }
            }
            if (id == 'txtq71') {
                if (val != "" && val == 7) {
                    document.getElementById("divQ71x").style.display = 'table-row';
                }
                else if (val == "" || val != "7") {
                    document.getElementById("divQ71x").style.display = 'none';
                    document.getElementById("txtq71x").value = "";
                }
            }
            if (id == 'txtq66') {
                if (val != "" && val == 1) {
                    document.getElementById("divQ67").style.display = 'table-row';
                    document.getElementById("divQ68a").style.display = 'table-row';
                    document.getElementById("divQ68b").style.display = 'table-row';
                }
                else if (val == "" || val != "1") {
                    document.getElementById("divQ67").style.display = 'none';
                    document.getElementById("divQ68a").style.display = 'none';
                    document.getElementById("divQ68b").style.display = 'none';
                    document.getElementById("txtq67").value = "";
                    document.getElementById("txtq68a").value = "";
                    document.getElementById("txtq68b").value = "";
                }
            }
            if (id == 'txtq67') {
                if (val != "" && val == 2) {
                    document.getElementById("divQ68a").style.display = 'table-row';
                    document.getElementById("divQ68b").style.display = 'table-row';
                }
                else if (val == "" || val != "2") {
                    document.getElementById("divQ68a").style.display = 'none';
                    document.getElementById("divQ68b").style.display = 'none';
                    document.getElementById("txtq68a").value = "";
                    document.getElementById("txtq68b").value = "";
                }
            }
        }










        function clicknext() {
            var Q6401 = document.getElementById('<%= chk01.ClientID %>');
            var Q6402 = document.getElementById('<%= chk02.ClientID %>');
            var Q6403 = document.getElementById('<%= chk03.ClientID %>');
            var Q6404 = document.getElementById('<%= chk04.ClientID %>');
            var Q6405 = document.getElementById('<%= chk05.ClientID %>');
            var Q6406 = document.getElementById('<%= chk06.ClientID %>');
            var Q6407 = document.getElementById('<%= chk07.ClientID %>');


            if (Q6401.checked == false && Q6402.checked == false && Q6403.checked == false && Q6404.checked == false && Q6405.checked == false && Q6406.checked == false && Q6407.checked == false) {
                alert("Select Q64 checks from 1 to 7")
                document.getElementById("chk01").focus();
                return false;
            }
            else if (Q6407.checked == true && (document.getElementById("txtq64a").value == '' || document.getElementById("txtq64a").value.length < 2)) {
                alert("Enter Value, 2 digit long !")
                document.getElementById("txtq64a").focus();
                return false;
            }
            else if (document.getElementById("txtq64b").value != '' && document.getElementById("txtq64b").value.length < 2) {
                alert("Enter Value, 2 digit long !")
                document.getElementById("txtq64b").focus();
                return false;
            }
            else if (document.getElementById("txtq64c").value != '' && document.getElementById("txtq64c").value.length < 2) {
                alert("Enter Value, 2 digit long !")
                document.getElementById("txtq64c").focus();
                return false;
            }
            else if (document.getElementById("txtq64d").value != '' && document.getElementById("txtq64d").value.length < 2) {
                alert("Enter Value, 2 digit long !")
                document.getElementById("txtq64d").focus();
                return false;
            }
            else if (document.getElementById("txtq65").value == '' || (document.getElementById("txtq65").value < 1 || document.getElementById("txtq65").value > 3)) {
                alert("Enter Value between 1 to 3")
                document.getElementById("txtq65").value = '';
                document.getElementById("txtq65").focus();
                return false;
            }
            else if (document.getElementById("txtq65").value != '1' && (document.getElementById("txtq66").value == '' || (document.getElementById("txtq66").value < 1 || document.getElementById("txtq66").value > 2))) {
                alert("Enter Value, 1 or 2")
                document.getElementById("txtq66").value = '';
                document.getElementById("txtq66").focus();
                return false;
            }
            else if (document.getElementById("txtq65").value != '1' && document.getElementById("txtq66").value != '2' && (document.getElementById("txtq67").value == '' || (document.getElementById("txtq67").value < 1 || document.getElementById("txtq67").value > 2))) {
                alert("Enter Value, 1 or 2")
                document.getElementById("txtq67").value = '';
                document.getElementById("txtq67").focus();
                return false;
            }
            else if (document.getElementById("txtq65").value != '1' && document.getElementById("txtq66").value != '2' && (document.getElementById("txtq67").value == '2' && (document.getElementById("txtq68a").value == '' || document.getElementById("txtq68a").value.length < 2))) {
                alert("Enter Value, 2 digit long !")
                document.getElementById("txtq68a").focus();
                return false;
            }
            else if (document.getElementById("txtq65").value != '1' && (document.getElementById("txtq68b").value != '' && document.getElementById("txtq68b").value.length < 2)) {
                alert("Enter Value, 2 digit long !")
                document.getElementById("txtq68b").focus();
                return false;
            }
            else if (document.getElementById("txtq69").value == '' || (document.getElementById("txtq69").value < 1 || document.getElementById("txtq69").value > 2)) {
                alert("Enter Value, 1 or 2")
                document.getElementById("txtq69").value = '';
                document.getElementById("txtq69").focus();
                return false;
            }
            else if (document.getElementById("txtq71").value == '' || (document.getElementById("txtq71").value < 1 || document.getElementById("txtq71").value > 10)) {
                alert("Enter Value between 1 to 7")
                document.getElementById("txtq71").value = '';
                document.getElementById("txtq71").focus();
                return false;
            }
            else if (document.getElementById("txtq71").value == '7' && (document.getElementById("txtq71x").value == '' || document.getElementById("txtq71x").value.length < 2)) {
                alert("Enter Value, 2 digit long !")
                document.getElementById("txtq71x").focus();
                return false;
            }
        }





        function clicksubmit() {

            if (document.getElementById("txtq69").value == '' || (document.getElementById("txtq69").value < 1 || document.getElementById("txtq69").value > 2)) {
                alert("Enter Value, 1 or 2")
                document.getElementById("txtq69").value = '';
                document.getElementById("txtq69").focus();
                return false;
            }
            else if (document.getElementById("txtq69").value == '1' && document.getElementById("txtQ70_1").value.length < 2) {
                alert("Enter Code, 2 digit long!")
                document.getElementById("txtQ70_1").focus();
                return false;
            }
            else if (document.getElementById("txtq69").value == '1' && (document.getElementById("txtQ70_2").value < 1 || document.getElementById("txtQ70_2").value > 7)) {
                alert("Enter Value between 1 to 7")
                document.getElementById("txtQ70_2").value = '';
                document.getElementById("txtQ70_2").focus();
                return false;
            }
            else if (document.getElementById("txtq69").value == '1' && document.getElementById("txtQ70_3").value.length < 3) {
                alert("Enter Value, 3 digit long!")
                document.getElementById("txtQ70_3").focus();
                return false;
            }
            else if (document.getElementById("txtq69").value == '1' && document.getElementById("txtQ70_4").value.length < 2) {
                alert("Enter Value, 2 digit long!")
                document.getElementById("txtQ70_4").focus();
                return false;
            }
            else if (document.getElementById("txtq69").value == '1' && document.getElementById("txtQ70_5").value.length < 2) {
                alert("Enter Value, 2 digit long!")
                document.getElementById("txtQ70_5").focus();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit" Visible="true">
                <table style="width: 100%; color: #4f5963; text-align: left;">
                    <tr class="trCSS">
                        <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px">Patient Management</td>
                    </tr>
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">64. Physician’s diagnosis </td>
                        <td class="Space tdCSS" style="font-size: 15px;">
                            <asp:CheckBox ID="chk01" Text="&emsp;1.	Well baby" runat="server" ClientIDMode="Static" /><br />
                            <asp:CheckBox ID="chk02" Text="&emsp;2.	Improved" runat="server" ClientIDMode="Static" /><br />
                            <asp:CheckBox ID="chk03" Text="&emsp;3.	Sepsis" runat="server" ClientIDMode="Static" /><br />
                            <asp:CheckBox ID="chk04" Text="&emsp;4.	Pneumonia" runat="server" ClientIDMode="Static" /><br />
                            <asp:CheckBox ID="chk05" Text="&emsp;5.	Umbilical infection" runat="server" ClientIDMode="Static" /><br />
                            <asp:CheckBox ID="chk06" Text="&emsp;6.	Diarrhea " runat="server" ClientIDMode="Static" /><br />
                            <asp:CheckBox ID="chk07" Text="&emsp;7.	Other (Specify)" runat="server" ClientIDMode="Static" onclick="getChkboxChecked('chk07')" /><br />
                        </td>
                    </tr>
                    <tr class="trCSS" id="divQ64a" style="display: none">
                        <td class="TableColumn tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq64a" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq64b" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS" id="divQ64b" style="display: none">
                        <td class="TableColumn tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq64c" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq64d" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                    </tr>




                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">65. If this is first visit of baby for well baby assessment before LW enrollment, physician’s decision related to that?</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq65" ClientIDMode="Static" onkeyup="enable('txtq65')" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS" id="divQ66">
                        <td class="TableColumn tdCSS">66. Physician’s recommendation?</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq66" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" onkeyup="enable('txtq66')" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="trCSS" id="divQ67">
                        <td class="TableColumn tdCSS">67. Did the caregiver accept referral?</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq67" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" onkeyup="enable('txtq67')" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr id="divQ68a" class="trCSS">
                        <td class="TableColumn tdCSS">68. Why did the caregiver refuse referral?</td>
                        <td class="Space tdCSS">
                            <asp:TextBox ID="txtq68a" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="code" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="divQ68b" class="trCSS">
                        <td class="TableColumn tdCSS"></td>
                        <td class="Space tdCSS">
                            <asp:TextBox ID="txtq68b" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="code" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                    </tr>

                    <tr class="trCSS" id="divQ69">
                        <td class="TableColumn tdCSS">69. Medicines given by a physician (If yes, then provide details below)</td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq69" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" onkeyup="enable('txtq69')" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="1" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr class="trCSS">
                        <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px">PHYSICIAN PRESCRIPTION</td>
                    </tr>
                </table>









                <div id="divQ70" style="text-align: center; font-size: small; background-color: #EDEDED; font-family: Tahoma; border: solid 1px;">
                    <asp:Panel ID="PanelSubmit" runat="server" DefaultButton="add" ClientIDMode="Static">
                        <table style="width: 100%; color: #4f5963; text-align: center;">
                            <tr class="trCSS">
                                <td><b>Q70) S No.</b></td>
                                <td><b>Name of Medicine Code</b></td>
                                <td><b>Route of administration</b></td>
                                <td><b>Dose in milligram</b></td>
                                <td><b>Frequency</b></td>
                                <td><b>Duration</b></td>
                            </tr>
                            <tr class="trCSS">
                                <td class="Space">
                                    <asp:Label ID="lbeRecord" runat="server" Text="" ForeColor="Black" Font-Size="14px"></asp:Label>
                                </td>
                                <td class="Space">
                                    <asp:TextBox ID="txtQ70_1" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="3" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                                </td>
                                <td class="Space">
                                    <asp:TextBox ID="txtQ70_2" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="1" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                                </td>
                                <td class="Space">
                                    <asp:TextBox ID="txtQ70_3" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="5" placeholder="99.9 or 999" ></asp:TextBox>
                                </td>
                                <td class="Space">
                                    <asp:TextBox ID="txtQ70_4" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                                </td>
                                <td class="Space">
                                    <asp:TextBox ID="txtQ70_5" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
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
                                <asp:BoundField DataField="lw_crf11_70_medi" HeaderText="Name of Medicine" />
                                <asp:BoundField DataField="lw_crf11_70_route" HeaderText="Route of administration" />
                                <asp:BoundField DataField="lw_crf11_70_dose" HeaderText="Dose in milligram" />
                                <asp:BoundField DataField="lw_crf11_70_freq" HeaderText="Frequency" />
                                <asp:BoundField DataField="lw_crf11_70_duration" HeaderText="Duration" />
                            </Columns>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <FooterStyle Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="Gray" ForeColor="white" Font-Bold="True" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </asp:Panel>
                </div>





                <table style="width: 100%; color: #4f5963; text-align: left;">
                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">71. If the baby is referred, what is the referral point </td>
                        <td class="Space tdCSS">
                            <asp:TextBox CssClass="form-control input-lg" ID="txtq71" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" onkeyup="enable('txtq71')" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr id="divQ71x" class="trCSS" style="display: none">
                        <td class="TableColumn tdCSS"></td>
                        <td class="Space tdCSS">
                            <asp:TextBox ID="txtq71x" CssClass="form-control input-lg" ClientIDMode="Static" runat="server" type="text" Font-Size="Medium" Height="2.1em" MaxLength="2" placeholder="others" onkeypress="return OnlyNumeric(event)"></asp:TextBox>
                        </td>
                    </tr>



                    <tr class="trCSS">
                        <td class="TableColumn tdCSS">72. Remarks/Comments by physician</td>
                        <td class="Space tdCSS">
                            <textarea id="txtq72" runat="server"></textarea></td>
                    </tr>
                </table>



                <br />
                <div class="buttonWeb">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" OnClientClick="return clicknext();" />
                </div>

                <br />
                <br />

            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
