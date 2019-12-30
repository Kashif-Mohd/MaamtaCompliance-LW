<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="crf11a.aspx.cs" Inherits="ComplianceMaamtaLW.crf11a" Culture="en-GB" %>
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
            if (document.getElementById("txtDOV").value == '__/__/____' || document.getElementById("txtDOV").value == '') {
                alert("Enter Date of Visit!")
                document.getElementById("txtDOV").focus();
                return false;
            }
            else if (document.getElementById("txtTOV").value == '' || document.getElementById("txtTOV").value == '__:__') {
                alert("Enter Time of Visit!")
                document.getElementById("txtTOV").focus();
                return false;
            }
                //else if (document.getElementById("txtq5aPhyNm").value == '' ) {
                //    alert("Enter Physician Name!")
                //    document.getElementById("txtq5aPhyNm").focus();
                //    return false;
                //}
            else if (document.getElementById("txtq5bPhyCode").value == '' || document.getElementById("txtq5bPhyCode").value.length < 3) {
                alert("Enter Physician Code, 3 digit long!")
                document.getElementById("txtq5bPhyCode").focus();
                return false;
            }
            else if (document.getElementById("txtq6ChldNm").value == '') {
                alert("Enter Child Name!")
                document.getElementById("txtq6ChldNm").focus();
                return false;
            }
            else if (document.getElementById("txtq7WomanNm").value == '') {
                alert("Enter Woman Name!")
                document.getElementById("txtq7WomanNm").focus();
                return false;
            }
            else if (document.getElementById("txtq8HusbndNm").value == '') {
                alert("Enter Husband Name!")
                document.getElementById("txtq8HusbndNm").focus();
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
            Physician Assessment (CRF-11):
        </div>
        <hr style="border-top: 1px solid #ccc; margin-top: 3px">

        <%--Search Woman by DSSID--%>

        <div runat="server" id="forSearch">


            <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: -10px;">
                <div id="imaginary_container" style="margin-top: 10px">
                    <div class="input-group stylish-input-group">
                        <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                        <span class="input-group-addon">
                            <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>




            <div style="width: 100%; height: 440px; overflow: scroll; margin-top: 40px">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="assis_id" HeaderText="Assessment ID" />
                        <asp:BoundField DataField="study_id" HeaderText="Study ID" />
                        <asp:BoundField DataField="rand_id" HeaderText="Randomization ID" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="Link_id" OnClick="Link_OpenForm" Text='Open Form' runat="server" ToolTip="Add Physician Form" CommandArgument='<%#Eval("assis_id")+","+ Eval("study_id")+","+ Eval("rand_id")+","+ Eval("dssid")+","+ Eval("woman_nm")+","+ Eval("husband_nm")+","+ Eval("dob")+","+ Eval("site")+","+ Eval("para")+","+ Eval("block")+","+ Eval("struct")+","+ Eval("HH")+","+ Eval("wm_no")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                    <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                    <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>



        <%--Entry Forms--%>
        <div runat="server" id="forEntry" visible="false">

            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnNext">

                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Randomization ID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtRandomid" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="random id" MaxLength="6" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Date of Birth</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtDOB" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="dob"  runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q1. Assisment ID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtAssisid" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="Assisment id" MaxLength="6" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q2. Study ID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtStudyID" ClientIDMode="Static" Style="text-transform: uppercase" type="text" Font-Size="Medium" Height="2.1em" placeholder="study id" MaxLength="15" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q3. Date of Visit</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtDOV" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Date" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDOV" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q4. Time of Visit</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtTOV" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="Time" runat="server"></asp:TextBox></td>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtTOV" />
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">DSS Address</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtDSSComplete" ClientIDMode="Static" Font-Size="Medium" Height="2.1em" placeholder="dssid" ReadOnly="true" runat="server"></asp:TextBox></td>
                        </tr>
                        <%--                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q5a. Physician Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq5aPhyNm" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>--%>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q5. Physician Code</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq5bPhyCode" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="code" MaxLength="3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q6. Child Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq6ChldNm" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="child name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q7. Woman Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq7WomanNm" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="woman name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Q8. Husband Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtq8HusbndNm" Style="text-transform: uppercase" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" onkeypress="return onlyAlphabets()" placeholder="husband name" MaxLength="25" runat="server"></asp:TextBox></td>
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
