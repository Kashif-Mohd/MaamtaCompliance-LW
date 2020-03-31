<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="dashSecondPhysician.aspx.cs" Inherits="ComplianceMaamtaLW.dashSecondPhysician" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding-left: 2%; margin-top: 25px;">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Physician Form (CRF11) 2nd Entry:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px; background-color: green" onserverclick="btnExport_Click">
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





        <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="Link_id" OnClick="LinkDetail_id" Text='Edit' runat="server" ToolTip="Edit Details" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="assist_id" HeaderText="assist_id" />
                    <asp:BoundField DataField="study_id" HeaderText="study_id" />
                    <asp:BoundField DataField="random_id" HeaderText="random_id" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="age" HeaderText="age" />
                    <asp:BoundField DataField="dob" HeaderText="dob" />
                    <asp:BoundField DataField="lw_crf11_03dt" HeaderText="lw_crf11_03dt" />
                    <asp:BoundField DataField="lw_crf11_04tm" HeaderText="lw_crf11_04tm" />
                    <asp:BoundField DataField="lw_crf11_05" HeaderText="lw_crf11_05" />
                    <asp:BoundField DataField="lw_crf11_06" HeaderText="lw_crf11_06" />
                    <asp:BoundField DataField="lw_crf11_07" HeaderText="lw_crf11_07" />
                    <asp:BoundField DataField="lw_crf11_08" HeaderText="lw_crf11_08" />
                    <asp:BoundField DataField="lw_crf11_09" HeaderText="lw_crf11_09" />
                    <asp:BoundField DataField="lw_crf11_10" HeaderText="lw_crf11_10" />
                    <asp:BoundField DataField="lw_crf11_11" HeaderText="lw_crf11_11" />
                    <asp:BoundField DataField="lw_crf11_12" HeaderText="lw_crf11_12" />
                    <asp:BoundField DataField="lw_crf11_13" HeaderText="lw_crf11_13" />
                    <asp:BoundField DataField="lw_crf11_14" HeaderText="lw_crf11_14" />
                    <asp:BoundField DataField="lw_crf11_15" HeaderText="lw_crf11_15" />
                    <asp:BoundField DataField="lw_crf11_15x" HeaderText="lw_crf11_15x" />
                    <asp:BoundField DataField="lw_crf11_16" HeaderText="lw_crf11_16" />
                    <asp:BoundField DataField="lw_crf11_17" HeaderText="lw_crf11_17" />
                    <asp:BoundField DataField="lw_crf11_18" HeaderText="lw_crf11_18" />
                    <asp:BoundField DataField="lw_crf11_19" HeaderText="lw_crf11_19" />
                    <asp:BoundField DataField="lw_crf11_20" HeaderText="lw_crf11_20" />
                    <asp:BoundField DataField="lw_crf11_21" HeaderText="lw_crf11_21" />
                    <asp:BoundField DataField="lw_crf11_22" HeaderText="lw_crf11_22" />
                    <asp:BoundField DataField="lw_crf11_23" HeaderText="lw_crf11_23" />
                    <asp:BoundField DataField="lw_crf11_24" HeaderText="lw_crf11_24" />
                    <asp:BoundField DataField="lw_crf11_25" HeaderText="lw_crf11_25" />
                    <asp:BoundField DataField="lw_crf11_26" HeaderText="lw_crf11_26" />
                    <asp:BoundField DataField="lw_crf11_27" HeaderText="lw_crf11_27" />
                    <asp:BoundField DataField="lw_crf11_28" HeaderText="lw_crf11_28" />
                    <asp:BoundField DataField="lw_crf11_29" HeaderText="lw_crf11_29" />
                    <asp:BoundField DataField="lw_crf11_30" HeaderText="lw_crf11_30" />
                    <asp:BoundField DataField="lw_crf11_31" HeaderText="lw_crf11_31" />
                    <asp:BoundField DataField="lw_crf11_33" HeaderText="lw_crf11_33" />
                    <asp:BoundField DataField="lw_crf11_34" HeaderText="lw_crf11_34" />
                    <asp:BoundField DataField="lw_crf11_35" HeaderText="lw_crf11_35" />
                    <asp:BoundField DataField="lw_crf11_36a" HeaderText="lw_crf11_36a" />
                    <asp:BoundField DataField="lw_crf11_36b" HeaderText="lw_crf11_36b" />
                    <asp:BoundField DataField="lw_crf11_37" HeaderText="lw_crf11_37" />
                    <asp:BoundField DataField="lw_crf11_38a" HeaderText="lw_crf11_38a" />
                    <asp:BoundField DataField="lw_crf11_38b" HeaderText="lw_crf11_38b" />
                    <asp:BoundField DataField="lw_crf11_39" HeaderText="lw_crf11_39" />
                    <asp:BoundField DataField="lw_crf11_40" HeaderText="lw_crf11_40" />
                    <asp:BoundField DataField="lw_crf11_41a" HeaderText="lw_crf11_41a" />
                    <asp:BoundField DataField="lw_crf11_41b" HeaderText="lw_crf11_41b" />
                    <asp:BoundField DataField="lw_crf11_42" HeaderText="lw_crf11_42" />
                    <asp:BoundField DataField="lw_crf11_43" HeaderText="lw_crf11_43" />
                    <asp:BoundField DataField="lw_crf11_44" HeaderText="lw_crf11_44" />
                    <asp:BoundField DataField="lw_crf11_45" HeaderText="lw_crf11_45" />
                    <asp:BoundField DataField="lw_crf11_46" HeaderText="lw_crf11_46" />
                    <asp:BoundField DataField="lw_crf11_47" HeaderText="lw_crf11_47" />
                    <asp:BoundField DataField="lw_crf11_48" HeaderText="lw_crf11_48" />
                    <asp:BoundField DataField="lw_crf11_49" HeaderText="lw_crf11_49" />
                    <asp:BoundField DataField="lw_crf11_50" HeaderText="lw_crf11_50" />
                    <asp:BoundField DataField="lw_crf11_51" HeaderText="lw_crf11_51" />
                    <asp:BoundField DataField="lw_crf11_52" HeaderText="lw_crf11_52" />
                    <asp:BoundField DataField="lw_crf11_53" HeaderText="lw_crf11_53" />
                    <asp:BoundField DataField="lw_crf11_54" HeaderText="lw_crf11_54" />
                    <asp:BoundField DataField="lw_crf11_55" HeaderText="lw_crf11_55" />
                    <asp:BoundField DataField="lw_crf11_56" HeaderText="lw_crf11_56" />
                    <asp:BoundField DataField="lw_crf11_57" HeaderText="lw_crf11_57" />
                    <asp:BoundField DataField="lw_crf11_58" HeaderText="lw_crf11_58" />
                    <asp:BoundField DataField="lw_crf11_59_01" HeaderText="lw_crf11_59_01" />
                    <asp:BoundField DataField="lw_crf11_59_02" HeaderText="lw_crf11_59_02" />
                    <asp:BoundField DataField="lw_crf11_59_03" HeaderText="lw_crf11_59_03" />
                    <asp:BoundField DataField="lw_crf11_59_04" HeaderText="lw_crf11_59_04" />
                    <asp:BoundField DataField="lw_crf11_60" HeaderText="lw_crf11_60" />
                    <asp:BoundField DataField="lw_crf11_61" HeaderText="lw_crf11_61" />
                    <asp:BoundField DataField="lw_crf11_62" HeaderText="lw_crf11_62" />
                    <asp:BoundField DataField="lw_crf11_63" HeaderText="lw_crf11_63" />
                    <asp:BoundField DataField="lw_crf11_64_01" HeaderText="lw_crf11_64_01" />
                    <asp:BoundField DataField="lw_crf11_64_02" HeaderText="lw_crf11_64_02" />
                    <asp:BoundField DataField="lw_crf11_64_03" HeaderText="lw_crf11_64_03" />
                    <asp:BoundField DataField="lw_crf11_64_04" HeaderText="lw_crf11_64_04" />
                    <asp:BoundField DataField="lw_crf11_64_05" HeaderText="lw_crf11_64_05" />
                    <asp:BoundField DataField="lw_crf11_64_06" HeaderText="lw_crf11_64_06" />
                    <asp:BoundField DataField="lw_crf11_64_07" HeaderText="lw_crf11_64_07" />
                    <asp:BoundField DataField="lw_crf11_64_07x1" HeaderText="lw_crf11_64_07x1" />
                    <asp:BoundField DataField="lw_crf11_64_07x2" HeaderText="lw_crf11_64_07x2" />
                    <asp:BoundField DataField="lw_crf11_64_07x3" HeaderText="lw_crf11_64_07x3" />
                    <asp:BoundField DataField="lw_crf11_64_07x4" HeaderText="lw_crf11_64_07x4" />
                    <asp:BoundField DataField="lw_crf11_65" HeaderText="lw_crf11_65" />
                    <asp:BoundField DataField="lw_crf11_66" HeaderText="lw_crf11_66" />
                    <asp:BoundField DataField="lw_crf11_67" HeaderText="lw_crf11_67" />
                    <asp:BoundField DataField="lw_crf11_68a" HeaderText="lw_crf11_68a" />
                    <asp:BoundField DataField="lw_crf11_68b" HeaderText="lw_crf11_68b" />
                    <asp:BoundField DataField="lw_crf11_69" HeaderText="lw_crf11_69" />
                    <asp:BoundField DataField="lw_crf11_71" HeaderText="lw_crf11_71" />
                    <asp:BoundField DataField="lw_crf11_72" HeaderText="lw_crf11_72" />
                    <asp:BoundField DataField="status" HeaderText="status" />
                    <asp:BoundField DataField="entry_dt" HeaderText="entry_dt" />
                    <asp:BoundField DataField="entry_nm" HeaderText="entry_nm" />
                    <asp:BoundField DataField="update_dt" HeaderText="update_dt" />
                    <asp:BoundField DataField="update_nm" HeaderText="update_nm" />
                </Columns>

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="30px" HorizontalAlign="Center" />
                <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>




            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
					 <asp:BoundField DataField="id" HeaderText="crf11_id" />
                    <asp:BoundField DataField="assist_id" HeaderText="assist_id" />
                    <asp:BoundField DataField="study_id" HeaderText="study_id" />
                    <asp:BoundField DataField="random_id" HeaderText="random_id" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="age" HeaderText="age" />
                    <asp:BoundField DataField="dob" HeaderText="dob" />
                    <asp:BoundField DataField="lw_crf11_03dt" HeaderText="lw_crf11_03dt" />
                    <asp:BoundField DataField="lw_crf11_04tm" HeaderText="lw_crf11_04tm" />
                    <asp:BoundField DataField="lw_crf11_05" HeaderText="lw_crf11_05" />
                    <asp:BoundField DataField="lw_crf11_06" HeaderText="lw_crf11_06" />
                    <asp:BoundField DataField="lw_crf11_07" HeaderText="lw_crf11_07" />
                    <asp:BoundField DataField="lw_crf11_08" HeaderText="lw_crf11_08" />
                    <asp:BoundField DataField="lw_crf11_09" HeaderText="lw_crf11_09" />
                    <asp:BoundField DataField="lw_crf11_10" HeaderText="lw_crf11_10" />
                    <asp:BoundField DataField="lw_crf11_11" HeaderText="lw_crf11_11" />
                    <asp:BoundField DataField="lw_crf11_12" HeaderText="lw_crf11_12" />
                    <asp:BoundField DataField="lw_crf11_13" HeaderText="lw_crf11_13" />
                    <asp:BoundField DataField="lw_crf11_14" HeaderText="lw_crf11_14" />
                    <asp:BoundField DataField="lw_crf11_15" HeaderText="lw_crf11_15" />
                    <asp:BoundField DataField="lw_crf11_15x" HeaderText="lw_crf11_15x" />
                    <asp:BoundField DataField="lw_crf11_16" HeaderText="lw_crf11_16" />
                    <asp:BoundField DataField="lw_crf11_17" HeaderText="lw_crf11_17" />
                    <asp:BoundField DataField="lw_crf11_18" HeaderText="lw_crf11_18" />
                    <asp:BoundField DataField="lw_crf11_19" HeaderText="lw_crf11_19" />
                    <asp:BoundField DataField="lw_crf11_20" HeaderText="lw_crf11_20" />
                    <asp:BoundField DataField="lw_crf11_21" HeaderText="lw_crf11_21" />
                    <asp:BoundField DataField="lw_crf11_22" HeaderText="lw_crf11_22" />
                    <asp:BoundField DataField="lw_crf11_23" HeaderText="lw_crf11_23" />
                    <asp:BoundField DataField="lw_crf11_24" HeaderText="lw_crf11_24" />
                    <asp:BoundField DataField="lw_crf11_25" HeaderText="lw_crf11_25" />
                    <asp:BoundField DataField="lw_crf11_26" HeaderText="lw_crf11_26" />
                    <asp:BoundField DataField="lw_crf11_27" HeaderText="lw_crf11_27" />
                    <asp:BoundField DataField="lw_crf11_28" HeaderText="lw_crf11_28" />
                    <asp:BoundField DataField="lw_crf11_29" HeaderText="lw_crf11_29" />
                    <asp:BoundField DataField="lw_crf11_30" HeaderText="lw_crf11_30" />
                    <asp:BoundField DataField="lw_crf11_31" HeaderText="lw_crf11_31" />
                    <asp:BoundField DataField="lw_crf11_33" HeaderText="lw_crf11_33" />
                    <asp:BoundField DataField="lw_crf11_34" HeaderText="lw_crf11_34" />
                    <asp:BoundField DataField="lw_crf11_35" HeaderText="lw_crf11_35" />
                    <asp:BoundField DataField="lw_crf11_36a" HeaderText="lw_crf11_36a" />
                    <asp:BoundField DataField="lw_crf11_36b" HeaderText="lw_crf11_36b" />
                    <asp:BoundField DataField="lw_crf11_37" HeaderText="lw_crf11_37" />
                    <asp:BoundField DataField="lw_crf11_38a" HeaderText="lw_crf11_38a" />
                    <asp:BoundField DataField="lw_crf11_38b" HeaderText="lw_crf11_38b" />
                    <asp:BoundField DataField="lw_crf11_39" HeaderText="lw_crf11_39" />
                    <asp:BoundField DataField="lw_crf11_40" HeaderText="lw_crf11_40" />
                    <asp:BoundField DataField="lw_crf11_41a" HeaderText="lw_crf11_41a" />
                    <asp:BoundField DataField="lw_crf11_41b" HeaderText="lw_crf11_41b" />
                    <asp:BoundField DataField="lw_crf11_42" HeaderText="lw_crf11_42" />
                    <asp:BoundField DataField="lw_crf11_43" HeaderText="lw_crf11_43" />
                    <asp:BoundField DataField="lw_crf11_44" HeaderText="lw_crf11_44" />
                    <asp:BoundField DataField="lw_crf11_45" HeaderText="lw_crf11_45" />
                    <asp:BoundField DataField="lw_crf11_46" HeaderText="lw_crf11_46" />
                    <asp:BoundField DataField="lw_crf11_47" HeaderText="lw_crf11_47" />
                    <asp:BoundField DataField="lw_crf11_48" HeaderText="lw_crf11_48" />
                    <asp:BoundField DataField="lw_crf11_49" HeaderText="lw_crf11_49" />
                    <asp:BoundField DataField="lw_crf11_50" HeaderText="lw_crf11_50" />
                    <asp:BoundField DataField="lw_crf11_51" HeaderText="lw_crf11_51" />
                    <asp:BoundField DataField="lw_crf11_52" HeaderText="lw_crf11_52" />
                    <asp:BoundField DataField="lw_crf11_53" HeaderText="lw_crf11_53" />
                    <asp:BoundField DataField="lw_crf11_54" HeaderText="lw_crf11_54" />
                    <asp:BoundField DataField="lw_crf11_55" HeaderText="lw_crf11_55" />
                    <asp:BoundField DataField="lw_crf11_56" HeaderText="lw_crf11_56" />
                    <asp:BoundField DataField="lw_crf11_57" HeaderText="lw_crf11_57" />
                    <asp:BoundField DataField="lw_crf11_58" HeaderText="lw_crf11_58" />
                    <asp:BoundField DataField="lw_crf11_59_01" HeaderText="lw_crf11_59_01" />
                    <asp:BoundField DataField="lw_crf11_59_02" HeaderText="lw_crf11_59_02" />
                    <asp:BoundField DataField="lw_crf11_59_03" HeaderText="lw_crf11_59_03" />
                    <asp:BoundField DataField="lw_crf11_59_04" HeaderText="lw_crf11_59_04" />
                    <asp:BoundField DataField="lw_crf11_60" HeaderText="lw_crf11_60" />
                    <asp:BoundField DataField="lw_crf11_61" HeaderText="lw_crf11_61" />
                    <asp:BoundField DataField="lw_crf11_62" HeaderText="lw_crf11_62" />
                    <asp:BoundField DataField="lw_crf11_63" HeaderText="lw_crf11_63" />
                    <asp:BoundField DataField="lw_crf11_64_01" HeaderText="lw_crf11_64_01" />
                    <asp:BoundField DataField="lw_crf11_64_02" HeaderText="lw_crf11_64_02" />
                    <asp:BoundField DataField="lw_crf11_64_03" HeaderText="lw_crf11_64_03" />
                    <asp:BoundField DataField="lw_crf11_64_04" HeaderText="lw_crf11_64_04" />
                    <asp:BoundField DataField="lw_crf11_64_05" HeaderText="lw_crf11_64_05" />
                    <asp:BoundField DataField="lw_crf11_64_06" HeaderText="lw_crf11_64_06" />
                    <asp:BoundField DataField="lw_crf11_64_07" HeaderText="lw_crf11_64_07" />
                    <asp:BoundField DataField="lw_crf11_64_07x1" HeaderText="lw_crf11_64_07x1" />
                    <asp:BoundField DataField="lw_crf11_64_07x2" HeaderText="lw_crf11_64_07x2" />
                    <asp:BoundField DataField="lw_crf11_64_07x3" HeaderText="lw_crf11_64_07x3" />
                    <asp:BoundField DataField="lw_crf11_64_07x4" HeaderText="lw_crf11_64_07x4" />
                    <asp:BoundField DataField="lw_crf11_65" HeaderText="lw_crf11_65" />
                    <asp:BoundField DataField="lw_crf11_66" HeaderText="lw_crf11_66" />
                    <asp:BoundField DataField="lw_crf11_67" HeaderText="lw_crf11_67" />
                    <asp:BoundField DataField="lw_crf11_68a" HeaderText="lw_crf11_68a" />
                    <asp:BoundField DataField="lw_crf11_68b" HeaderText="lw_crf11_68b" />
                    <asp:BoundField DataField="lw_crf11_69" HeaderText="lw_crf11_69" />
                    <asp:BoundField DataField="lw_crf11_71" HeaderText="lw_crf11_71" />
                    <asp:BoundField DataField="lw_crf11_72" HeaderText="lw_crf11_72" />
                    <asp:BoundField DataField="status" HeaderText="status" />
                    <asp:BoundField DataField="entry_dt" HeaderText="entry_dt" />
                    <asp:BoundField DataField="entry_nm" HeaderText="entry_nm" />
                    <asp:BoundField DataField="update_dt" HeaderText="update_dt" />
                    <asp:BoundField DataField="update_nm" HeaderText="update_nm" />
                </Columns>


            </asp:GridView>
        </div>
    </div>
</asp:Content>