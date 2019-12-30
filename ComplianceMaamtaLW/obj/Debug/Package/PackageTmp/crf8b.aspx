<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="crf8b.aspx.cs" Inherits="ComplianceMaamtaLW.crf8b" Culture="ar-DZ" %>

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
            if ($('#<%= txtq27.ClientID %> input:checked').val() == '5') {
                document.getElementById("TR_Q27").style.display = 'table-row';
            }         
        }



      




        function RadioButton(id) {

            var selectedvalue = $('#<%= txtq27.ClientID %> input:checked').val();
            if (id == 'txtq27') {
                if (selectedvalue != "" && selectedvalue == "5") {
                    document.getElementById("TR_Q27").style.display = 'table-row';
                }
                else if (selectedvalue == "" || selectedvalue != "5") {
                    document.getElementById("TR_Q27").style.display = 'none';
                    document.getElementById("txtq27_other").value = "";
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

            if (Validate(document.getElementById("<%=txtq26.ClientID%>")) == false) {
                alert("Select Q26 Value")
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq27.ClientID%>")) == false) {
                alert("Select Q27 Value")
                return false;
            }
            else if ($('#<%= txtq27.ClientID %> input:checked').val() == '5' && (document.getElementById("txtq27_other").value == '' || document.getElementById("txtq27_other").value.length < 2)) {
               alert("Enter Other Code, 2 digit long!")
               document.getElementById("txtq27_other").focus();
               return false;
             }
            else if (document.getElementsByName("txtq27").text == 5 && (document.getElementById("txtq27_other").value == '' || document.getElementById("txtq27_other").value.length < 2)) {
                alert("Enter Other Code, 2 digit long!")
                document.getElementById("txtq27_other").focus();
                return false;
            }
            else if (Validate(document.getElementById("<%=txtq28.ClientID%>")) == false) {
                alert("Select Q28 Value")
                return false;
            }
            else if (document.getElementById("txtq29_min").value == '' || document.getElementById("txtq29_min").value.length < 2) {
                alert("Enter Minutes, 2 digit long!")
                document.getElementById("txtq29_min").focus();
                return false;
            }
            else if (document.getElementById("txtq29_hr").value == '' || document.getElementById("txtq29_hr").value.length < 2) {
                alert("Enter Hours, 2 digit long!")
                document.getElementById("txtq29_hr").focus();
                return false;
            }
            else if (document.getElementById("txtq29_day").value == '' || document.getElementById("txtq29_day").value.length < 2) {
                alert("Enter Days, 2 digit long!")
                document.getElementById("txtq29_day").focus();
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
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 18px">ADVERSE EVENT</td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">26. Who is affected by the adverse event?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq26" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp LW" Value="1" />
                        <asp:ListItem Text="&nbsp Infant" Value="2" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">27. Who reported the adverse event?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq27" runat="server" ClientIDMode="Static" onclick="RadioButton('txtq27')">
                        <asp:ListItem Text="&nbsp LW herself" Value="1" />
                        <asp:ListItem Text="&nbsp Research Team Member" Value="2" />
                        <asp:ListItem Text="&nbsp Any other member of the family" Value="3" />
                        <asp:ListItem Text="&nbsp Healthcare provider" Value="4" />
                        <asp:ListItem Text="&nbsp Others" Value="5" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="trCSS" id="TR_Q27" style="display:none">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq27_other" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="other" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">28. According to LW, is this adverse event occurs after intervention?</td>
                <td class="Space tdCSS">
                    <asp:RadioButtonList ID="txtq28" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="&nbsp After LNS" Value="1" />
                        <asp:ListItem Text="&nbsp After Azithromycin (only applicable infant)" Value="2" />
                        <asp:ListItem Text="&nbsp Don’t know " Value="3" />
                        <asp:ListItem Text="&nbsp No" Value="4" />
                        <asp:ListItem Text="&nbsp Not applicable" Value="5" />
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr class="trCSS">
                <td class="TableColumn tdCSS">29. How soon after having the intervention, the adverse event occurred?</td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq29_min" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="minutes" MaxLength="2" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq29_hr" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="hours" MaxLength="2" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS"></td>
                <td class="Space tdCSS">
                    <asp:TextBox CssClass="form-control input-lg" ID="txtq29_day" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" type="text" Font-Size="Medium" Height="2.1em" placeholder="days" MaxLength="2" runat="server"></asp:TextBox></td>
            </tr>





            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 16px">Q30a. Details of adverse event reported and actions which were taken
                    <br />
                    (Either observed by the research team or information given by trial participant or someone else)
                    <br />
                    What were the initial and series of symptoms or complain which appeared – follow the sequence?
                </td>
            </tr>

            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a1dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(1)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a1dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a1" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(1)"></textarea></td>
            </tr>




            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a2dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(2)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a2dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a2" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(2)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a3dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(3)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a3dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a3" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(3)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a4dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(4)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a4dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a4" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(4)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a5dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(5)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a5dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a5" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(5)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a6dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(6)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a6dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a6" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(6)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a7dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(7)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a7dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a7" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(7)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a8dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(8)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a8dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a8" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(8)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a9dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(9)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender17" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a9dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a9" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(9)"></textarea></td>
            </tr>




            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30a10dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30a-(10)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender18" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30a10dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30a10" runat="server" style="height: 50px; width: 80%;" placeholder="Q30a-(10)"></textarea></td>
            </tr>










            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="background-color: gray; color: white; text-align: center; font-size: 16px">Q30b. What action/s was taken after suspected adverse event.                    
                </td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b1dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(1)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b1dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b1" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(1)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b2dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(2)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b2dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b2" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(2)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b3dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(3)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b3dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b3" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(3)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b4dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(4)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b4dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b4" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(4)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b5dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(5)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b5dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b5" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(5)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b6dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(6)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b6dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b6" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(6)"></textarea></td>
            </tr>


            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b7dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(7)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b7dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b7" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(7)"></textarea></td>
            </tr>



            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b8dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(8)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b8dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b8" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(8)"></textarea></td>
            </tr>


             <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b9dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(9)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender19" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b9dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b9" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(9)"></textarea></td>
            </tr>



             <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <asp:TextBox CssClass="form-control input" ID="txtq30b10dt" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date Q30b-(10)" runat="server"></asp:TextBox></td>
                <cc1:MaskedEditExtender ID="MaskedEditExtender20" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq30b10dt" />
            </tr>
            <tr class="trCSS">
                <td class="tdCSS" colspan="2" style="text-align: center;">
                    <textarea id="txtq30b10" runat="server" style="height: 50px; width: 80%;" placeholder="Q30b-(10)"></textarea></td>
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
