<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoleAssignment.aspx.cs" Inherits="IDEA_BALCO_1.RoleAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section class="section" >
      <div class="row">
        <div class="col-lg-12">

          <div class="card" style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
            <div class="card-body">
                 <h5 class="card-title">Role Assignment</h5>
                <div class="ibox-content">
                    <div class="panel-body">
                        <table class="col-md-12">
                            <tr>
                                <td class="col-md-5">
                                    <strong>Employee ID</strong>
                                    <asp:TextBox ID="txtEmployeeID" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="col-md-1">
                                    <asp:Button ID="btnProceed" runat="server" Class="btn btn-primary" Style="margin-top: 20px;" OnClick="btnProceed_Click" Text="Proceed" />
                                </td>
                                <td class="col-md-5">
                                    <strong>Role</strong>
                                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" required="required">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>HOD</asp:ListItem>
                                        <asp:ListItem>Department Representative</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="col-md-1">
                                    <asp:Button ID="btnsubmit" runat="server" Class="btn btn-primary" Style="margin-top: 20px;" OnClick="btnSubmit_Click" Text="Assign" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="panel-body">
                        <table class="col-md-12">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmployeeID" runat="server" CssClass="form-control"></asp:Label>
                                    <asp:Label ID="lblEmployeeName" runat="server" CssClass="form-control"></asp:Label>
                                    <asp:Label ID="lblDepartment" runat="server" CssClass="form-control"></asp:Label>
                                    <asp:Label ID="lblDesignation" runat="server" CssClass="form-control"></asp:Label>
                                    <asp:Label ID="lblCurrentRole" runat="server" CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                     </div>
                </div>
              </div>
            </div>
          </div>
          </section>
</asp:Content>
