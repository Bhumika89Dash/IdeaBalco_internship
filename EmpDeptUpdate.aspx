<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmpDeptUpdate.aspx.cs" Inherits="IDEA_BALCO_1.EmpDeptUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <section class="section" >
      <div class="row">
        <div class="col-lg-12">

          <div class="card" style="top: 10px; left: 0; margin-left: 0; height:auto;width:auto">
            <div class="card-body">
                 <h5 class="card-title"> Update Employee Department</h5>
                <div class="ibox-content">
                    <div class="panel-body">
                       <div style="margin-top: 95px; max-height: 510px; overflow-y: scroll; padding-left: 55px;">
            <div class="space10"></div>
            <div class="RoundedCorners" style="margin-bottom: 30px;">
                <div class="alert alert-danger alert-dismissible fade in" role="alert" id="Error" runat="server" visible="false">
                    <button type="button" class="close pull-right" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>
                        <asp:Label ID="lblErrorHead" runat="server"></asp:Label></strong>
                    <asp:Label ID="lblSubHead" runat="server"></asp:Label>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" style="font-weight: bold">Update Employee Departmnet</div>
                    <div class="panel-body">
                        <table width="100%" border="0" cellpadding="10" id="notificationDiv" class="tbl">
                            <tr>
                                <td style="width: 200px;">Employee ID</td>
                                <td>
                                    <asp:TextBox ID="txtEmpID" runat="server" ToolTip="Enter Employee ID"></asp:TextBox>
                                </td>
                                <td>SBU</td>
                                <td>
                                    <asp:DropDownList ID="ddlSBU" runat="server" AutoPostBack="True" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddlSBU_SelectedIndexChanged">
                                    </asp:DropDownList>
                                  
                                </td>
                                <td>Department</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                           <asp:DropDownList ID="drpDepartment" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="">---- Select Department ----</asp:ListItem>
                                    </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlSBU" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="text-align: center;">
                                    <asp:Button ID="btnupddepartment" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="btnupddepartment_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
                    </div>
                     </div>
                </div>
              </div>
            </div>
          </div>
          </section>
</asp:Content>
