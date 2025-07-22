<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddingValue.aspx.cs" Inherits="IDEA_BALCO_1.AddingValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .auto-style1 {
            width: 6%;
        }
        .auto-style2 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: var(--bs-body-color);
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            background-clip: padding-box;
            border-radius: var(--bs-border-radius);
            transition: none;
            background-color: var(--bs-body-bg);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section class="section">
        <div class="row">
            <div class="column">

                <div class="card" style="top: 0px; margin-left: 0; left: auto; width: auto; height: auto;">
                    <div class="card-body">
                        <h6 class="card-title">Adding new SBU</h6>

                        <table Width="100%" border="0" CellPadding="10" class="tbl">
                            <tr>
                                <td class="auto-style1">
                                     <strong>SBU :</strong>
                                </td>
                                <td width="35%">
                                      <asp:TextBox ID="txt_Sbu" CssClass="form-control" runat="server"></asp:TextBox>

                                   </td>

                            </tr>

                            <tr>
                                <td class="auto-style1">
                                    <asp:LinkButton Width="100px" ID="LinkButton3" runat="server" class="btn btn-success" OnClick="AddSBU_Click" ValidationGroup="G1">Add SBU</asp:LinkButton>

                                </td>
                                <td width="35%">                                     <asp:Label ID="lblmessage1" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</td>

                            </tr>
                            

                        </table>
                        <hr />
                        <h6 class="card-title">Adding new Department</h6>
                        <table>


                            <tr>
                                <td width="15%">
                          <strong>SBU : </strong>
                                </td>
                                <td width="35%">
                                    <asp:DropDownList ID="ddlsbu" runat="server" Width="272" AutoPostBack="True" OnSelectedIndexChanged="ddlSBU_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                             <tr>
                                <td width="15%">
                                    <strong>Department : </strong>
                                </td>
                                <td width="35%">
                                    <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                             <tr>
                                <td width="15%">
                                    <asp:LinkButton  Width="100px" ID="LinkButton4" runat="server" class="btn btn-success" OnClick="AddDept_Click" ValidationGroup="G1">Add</asp:LinkButton>

                                </td>
                                <td width="35%">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Green" Visible="false"></asp:Label>

                                </td>
                            </tr>

                        </table>

                        </div>




























                       
    </section>
</asp:Content>
