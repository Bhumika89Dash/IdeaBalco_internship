<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MySubmittedIdea.aspx.cs" Inherits="IDEA_BALCO_1.MySubmittedIdea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section class="section">
        <div class="row">
            <div class="col-lg-12">

                <div class="card" style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
                    <div class="card-body">
                        <h5 class="card-title">My Submitted Ideas</h5>
                        <asp:TextBox ID="txtsearch" runat="server" Width="300px" placeholder="Search here..." AutoPostBack="true" OnTextChanged="txtsearch_TextChanged"></asp:TextBox><br />
                        <br />
                        <div class="i">

                            <div class="panel-body">
                                <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EmptyDataText="No Data Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4">
                                    <Columns>

                                        <asp:TemplateField HeaderText="#ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAutoID" runat="server" Text='<%# Eval("AutoID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SBU" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSBU" runat="server" Text='<%# Eval("SBU") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Department">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Departmentname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Idea">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdea" runat="server" Text='<%# Eval("Idea") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Benefit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBenefit" runat="server" Text='<%# Eval("Benefit") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="EmpNo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpNo" runat="server" Text='<%# Eval("EmpNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Submitted On">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubmittedOn" runat="server" DataFormatString="{0:dd/MM/yy}" Text='<%# Eval("IdeaDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnAction" CssClass="btn-success" CommandName="Action" CommandArgument='<%# Eval("AutoID") %>' runat="Server" Text="Revalidate" Visible='<%# Eval("Status").ToString() == "Rejected"? true:false %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                  
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
