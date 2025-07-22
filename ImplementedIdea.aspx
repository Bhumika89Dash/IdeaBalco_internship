<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ImplementedIdea.aspx.cs" Inherits="IDEA_BALCO_1.ImplementedIdea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section class="section">
        <div class="row">
            <div class="col-lg-12">

                <div class="card" style="height: auto; top: 0; left: 0; margin-left: 0">
                    <div class="card-body">
                        <h5 class="card-title">Implemented Ideas</h5>
                        <asp:TextBox ID="txtsearch" runat="server" Width="300px" placeholder="Search here..." AutoPostBack="true" OnTextChanged="txtsearch_TextChanged"></asp:TextBox><br />
                        <br />
                        <div class="ibox-content">

                            <div class="panel-body">
                                <asp:GridView ID="GridView1" runat="server" CssClass="grid" AllowPaging="True" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EmptyDataText="No Data Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4">
                                    <Columns>
                                        <asp:BoundField DataField="AutoId" HeaderText="ID" />
                                        <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" />
                                        <asp:BoundField DataField="Name" HeaderText="Emp Name" />
                                        <asp:BoundField DataField="SBU_Name" HeaderText="SBU" />
                                        <asp:BoundField DataField="departmentname" HeaderText="Department" />
                                        <asp:BoundField DataField="Idea" HeaderText="Idea" />
                                        <asp:BoundField DataField="Benefit" HeaderText="Benefit" />
                                        <asp:BoundField DataField="IdeaDate" HeaderText="Submited On" DataFormatString="{0:dd/MM/yy}" />
                                        <asp:BoundField DataField="ImplementedDate" HeaderText="Implemented On" DataFormatString="{0:dd/MM/yy}" />
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="alert  alert-warning" />
                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                </asp:GridView>
                                <!-- End Grid Section -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
