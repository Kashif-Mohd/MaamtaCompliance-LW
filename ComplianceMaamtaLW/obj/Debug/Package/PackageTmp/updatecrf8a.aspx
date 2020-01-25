﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updatecrf8a.aspx.cs" Inherits="ComplianceMaamtaLW.updatecrf8a"  Culture="ar-DZ" %>
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

            .tdCSS {
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
        function clicknext() {

            if (document.getElementById("txtq2").value == '__-__-____' || document.getElementById("txtq2").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq2").focus();
                return false;
            }
            else if (document.getElementById("txtq3").value == '' || document.getElementById("txtq3").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq3").focus();
                return false;
            }
            else if (document.getElementById("txtq4").value == '' || document.getElementById("txtq4").value.length < 3) {
                alert("Enter Research Associate Code!")
                document.getElementById("txtq4").focus();
                return false;
            }
            else if (document.getElementById("txtq5").value == '' || document.getElementById("txtq5").value.length < 3) {
                alert("Enter Research Staff Code!")
                document.getElementById("txtq5").focus();
                return false;
            }
            else if ((document.getElementById("txtq15").value == '' || document.getElementById("txtq15").value.length < 2) || document.getElementById("txtq15").value < 1) {
                alert("Enter Age greater than 1 day!")
                document.getElementById("txtq15").focus();
                return false;
            }

            else if (document.getElementById("txtq16").value == '__-__-____' || document.getElementById("txtq16").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq16").focus();
                return false;
            }
            else if (document.getElementById("txtq17").value == '' || document.getElementById("txtq17").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq17").focus();
                return false;
            }
            else if (document.getElementById("txtq18").value == '__-__-____' || document.getElementById("txtq18").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq18").focus();
                return false;
            }
            else if (document.getElementById("txtq19").value == '' || document.getElementById("txtq19").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq19").focus();
                return false;
            } else if (document.getElementById("txtq20").value == '__-__-____' || document.getElementById("txtq20").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq20").focus();
                return false;
            }
            else if (document.getElementById("txtq21").value == '' || document.getElementById("txtq21").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq21").focus();
                return false;
            } else if (document.getElementById("txtq22").value == '__-__-____' || document.getElementById("txtq22").value == '') {
                alert("Enter Date!")
                document.getElementById("txtq22").focus();
                return false;
            }
            else if (document.getElementById("txtq23").value == '' || document.getElementById("txtq23").value == '__:__') {
                alert("Enter Time!")
                document.getElementById("txtq23").focus();
                return false;
            }


        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="padding-left: 2%; margin-top: 5px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Adverse Events Reporting Form (CRF-8):
        </div>
        <hr style="border-top: 1px solid #ccc; margin-top: 3px">

        <%--Search Woman by DSSID--%>


        <%--Entry Forms--%>
        <div runat="server" id="forEntry" >

            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnNext">

                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">


                         <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q1. Study ID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtStudyID" ClientIDMode="Static" Style="text-transform: uppercase" type="text" Font-Size="Medium" Height="2.1em" placeholder="study id" MaxLength="15" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q2. Date</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq2" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq2" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q3. Time</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq3" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq3" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q4. Research Associate code</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq4" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q5. Reported by Research staff code</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq5" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q6. Woman Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq6WomanNm" ReadOnly="true" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="woman name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q7. Husband Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq7HusbandNm" ReadOnly="true" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="husband name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">DSS Address</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtdssidQ8toQ13" ReadOnly="true" ClientIDMode="Static" Font-Size="Medium" Height="2.1em" placeholder="dssid" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q14. Date of Enrollment</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtq14" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="DOE" runat="server"></asp:TextBox></td>
                        </tr>



                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q16. Date when adverse event was observed / start date</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq16" ReadOnly="true" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq16" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q17. Time of event observed (24 hr clock) / start time</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq17" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq17" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q18. Date when adverse event was stopped</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq18" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq18" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q19. Time of event stopped</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq19" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq19" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q20. Date when adverse event was reported</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq20" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq20" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q21. Time of event reported</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq21" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq21" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q22. Date of informing Research specialist</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq22" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtq22" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q23. Time of informing  Research specialist (24 hr clock)</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq23" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtq23" />
                        </tr>

                    </table>
                    <br />
                    <div class="buttonWeb">

                        <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-theme btn-lg btn-block" OnClick="next_Click" OnClientClick="return clicknext();" />
                    </div>

                    <br />
                    <br />
                </div>
            </asp:Panel>

        </div>
    </div>

</asp:Content>
