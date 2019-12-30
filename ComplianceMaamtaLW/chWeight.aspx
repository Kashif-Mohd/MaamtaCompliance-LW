<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="chWeight.aspx.cs" Inherits="ComplianceMaamtaLW.chWeight" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }

        .StylePager {
            border-radius: 5px;
            text-align: left;
        }

            .StylePager a:hover {
                background-color: #33d9b2;
                margin-right: 3px;
                padding: 3px;
                border-radius: 3px;
            }

            .StylePager a {
                padding: 3px;
                margin-right: 3px;
            }

            .StylePager span {
                background: #FF4081;
                padding: 4px;
                border-radius: 3px;
                margin-right: 3px;
            }


        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            tddd, thhh {
                margin-top: 0.8em;
                display: block;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="padding-left: 2%; margin-top: 5px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Child Weight (Maamta-LW):
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: 3px">
        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
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



        <div style="width: 100%; height: 440px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="dob" HeaderText="Date_of_Birth" />
                    <asp:BoundField DataField="dod" HeaderText="Date_of_Death" />
                    <asp:BoundField DataField="current_age" HeaderText="Current Age" />
                    <asp:BoundField DataField="gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Enrollment_Date" HeaderText="Enrollment Date" />
                    <asp:BoundField DataField="enrollment_ch_weight" HeaderText="Enrollment Weight" />
                    <asp:BoundField DataField="F1_DATE" HeaderText="F1_DATE" />
                    <asp:BoundField DataField="F1_V_Status" HeaderText="F1 Visit Status" />
                    <asp:BoundField DataField="F1_ch_weight" HeaderText="F1 Weight" />
                    <asp:BoundField DataField="F2_DATE" HeaderText="F2_DATE" />
                    <asp:BoundField DataField="F2_V_Status" HeaderText="F2 Visit Status" />
                    <asp:BoundField DataField="F2_ch_weight" HeaderText="F2 Weight" />
                    <asp:BoundField DataField="F3_DATE" HeaderText="F3_DATE" />
                    <asp:BoundField DataField="F3_V_Status" HeaderText="F3 Visit Status" />
                    <asp:BoundField DataField="F3_ch_weight" HeaderText="F3 Weight" />
                    <asp:BoundField DataField="F4_DATE" HeaderText="F4_DATE" />
                    <asp:BoundField DataField="F4_V_Status" HeaderText="F4 Visit Status" />
                    <asp:BoundField DataField="F4_ch_weight" HeaderText="F4 Weight" />
                    <asp:BoundField DataField="F5_DATE" HeaderText="F5_DATE" />
                    <asp:BoundField DataField="F5_V_Status" HeaderText="F5 Visit Status" />
                    <asp:BoundField DataField="F5_ch_weight" HeaderText="F5 Weight" />
                    <asp:BoundField DataField="F6_DATE" HeaderText="F6_DATE" />
                    <asp:BoundField DataField="F6_V_Status" HeaderText="F6 Visit Status" />
                    <asp:BoundField DataField="F6_ch_weight" HeaderText="F6 Weight" />
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





            <asp:GridView ID="GridView2" runat="server" CssClass="footable" OnRowDataBound="OnRowDataBound" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="dob" HeaderText="Date_of_Birth" />
                    <asp:BoundField DataField="dod" HeaderText="Date_of_Death" />
                    <asp:BoundField DataField="current_age" HeaderText="Current Age" />
                    <asp:BoundField DataField="gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Enrollment_Date" HeaderText="Enrollment Date" />
                    <asp:BoundField DataField="enrollment_ch_weight" HeaderText="Enrollment Weight" />
                    <asp:BoundField DataField="F1_DATE" HeaderText="F1_DATE" />
                    <asp:BoundField DataField="F1_V_Status" HeaderText="F1 Visit Status" />
                    <asp:BoundField DataField="F1_ch_weight" HeaderText="F1 Weight" />
                    <asp:BoundField DataField="F2_DATE" HeaderText="F2_DATE" />
                    <asp:BoundField DataField="F2_V_Status" HeaderText="F2 Visit Status" />
                    <asp:BoundField DataField="F2_ch_weight" HeaderText="F2 Weight" />
                    <asp:BoundField DataField="F3_DATE" HeaderText="F3_DATE" />
                    <asp:BoundField DataField="F3_V_Status" HeaderText="F3 Visit Status" />
                    <asp:BoundField DataField="F3_ch_weight" HeaderText="F3 Weight" />
                    <asp:BoundField DataField="F4_DATE" HeaderText="F4_DATE" />
                    <asp:BoundField DataField="F4_V_Status" HeaderText="F4 Visit Status" />
                    <asp:BoundField DataField="F4_ch_weight" HeaderText="F4 Weight" />
                    <asp:BoundField DataField="F5_DATE" HeaderText="F5_DATE" />
                    <asp:BoundField DataField="F5_V_Status" HeaderText="F5 Visit Status" />
                    <asp:BoundField DataField="F5_ch_weight" HeaderText="F5 Weight" />
                    <asp:BoundField DataField="F6_DATE" HeaderText="F6_DATE" />
                    <asp:BoundField DataField="F6_V_Status" HeaderText="F6 Visit Status" />
                    <asp:BoundField DataField="F6_ch_weight" HeaderText="F6 Weight" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
