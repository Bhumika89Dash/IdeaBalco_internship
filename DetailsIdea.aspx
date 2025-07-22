<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetailsIdea.aspx.cs" Inherits="IDEA_BALCO_1.DetailsIdea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section" >
      <div class="row">
        <div class="col-lg-12">

          <div class="card" style="top: 10px; left: 0; margin-left: 0; height:auto">
            <div class="card-body">
                 <div style=" border-color: #d6e9c6;">
                             <h5 class="card-title">Details of Idea</h5>
                            <div class="panel-body">
                                <table width="100%" border="0" cellpadding="10" class="tbl">
                                    <tr>
                                        <td width="15%"><strong>Idea ID</strong></td>
                                        <td width="85%">#<asp:Label ID="lblIdeaID" runat="server" Font-Bold="true"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="top"><strong>Idea</strong></td>
                                        <td><asp:Label ID="lblIdea" runat="server" style="word-break:break-all;word-wrap:hyphenate;text-align:justify"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="top"><strong>Benefit</strong></td>
                                        <td><asp:Label ID="lblBenefit" runat="server" style="word-break:break-all;word-wrap:hyphenate;text-align:justify"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Date</strong></td>
                                        <td><asp:Label ID="lblDate" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Status</strong></td>
                                        <td><asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Department</strong></td>
                                        <td><asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Submitted By</strong></td>
                                        <td><asp:Label ID="lblSubmittedBy" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="top"><strong>Assigned To</strong></td>
                                        <td><asp:Label ID="lblAssignedTo" runat="server"></asp:Label></td>
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
