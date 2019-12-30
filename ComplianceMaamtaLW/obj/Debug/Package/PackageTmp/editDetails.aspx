﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="editDetails.aspx.cs" Inherits="ComplianceMaamtaLW.editDetails" Culture="en-GB" %>

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

            th, .tdCSS {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="text-align: center">



        <div style="text-align: center">

            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit" Visible="true">
                <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
                    <h2 style="text-align: center; margin-top: 10px; font-size: 26px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 6px; padding-bottom: 5px; font-family: Arial">
                        <b>Compliance (Empty Sachet)</b></h2>
                </div>

                <br />
                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Randomization ID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtrandid" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="random id" MaxLength="6" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Study ID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtStudyID" ClientIDMode="Static" Style="text-transform: uppercase" type="text" Font-Size="Medium" Height="2.1em" placeholder="study id" MaxLength="15" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">DSSID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtDSSID" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="dssid" MaxLength="11" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Woman Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtWomanNm" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="woman name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Date of Birth</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtDOB" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="DOB" MaxLength="25" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDOB" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Date of Previous Visit </td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtLastDOV" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="" MaxLength="25" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtLastDOV" />

                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Date of Visit</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtDOV" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="DOV" MaxLength="25" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDOV" />
                        </tr>

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Empty Sachet</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtEmptySac" type="tel" ClientIDMode="Static" Font-Size="Medium"  MaxLength="5" Height="2.1em" placeholder="eg. 05" runat="server"></asp:TextBox></td>
                        </tr>
                          <tr class="trCSS">
                            <td class="TableColumn tdCSS">Actual Empty Sachet</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtActualEmptySac" type="tel" onkeypress="return OnlyNumeric(event)" ClientIDMode="Static" Font-Size="Medium"  MaxLength="3" Height="2.1em" placeholder="eg. 12" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Remarks</td>
                            <td class="Space tdCSS">
                                <textarea id="txtremarks" runat="server"></textarea></td>
                        </tr>


                    </table>
                    <br />
                    <br />
                    <div class="buttonWeb">

                        <asp:Button ID="btnSubmit" runat="server" Text="UPDATE" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" />
                    </div>

                    <br />
                    <br />
                </div>
            </asp:Panel>


        </div>
    </div>
</asp:Content>
