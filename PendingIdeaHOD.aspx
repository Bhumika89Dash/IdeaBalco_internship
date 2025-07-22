<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PendingIdeaHOD.aspx.cs" Inherits="IDEA_BALCO_1.PendingIdeaHOD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section class="section">
        <div class="row">
            <div class="col-lg-12">

                <div class="card"  style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
                    <div class="card-body">
                        <h5 class="card-title">Pending Ideas</h5>
                        <asp:TextBox ID="txtsearch" runat="server" Width="300px" placeholder="Search here..." AutoPostBack="true" OnTextChanged="txtsearch_TextChanged"></asp:TextBox><br />
                        <br />
                        <div class="ibox-content">

                            <div class="panel-body">
                                <asp:GridView ID="GridView1" runat="server" CssClass="grid" AllowPaging="True" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EmptyDataText="No Data Found" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkCntrl1" runat="server" AutoPostBack="True" OnCheckedChanged="ChkCntrl_CheckedChanged1" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkCntrl" runat="server" OnCheckedChanged="ChkCntrl_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="AutoID" HeaderText="#ID" />--%>
                                        <asp:TemplateField HeaderText="#ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblid" Text='<%# Eval("AutoID") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpNo" Text='<%# Eval("EmpNo") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Emp Name" />
                                        <asp:BoundField DataField="Emp Dept" HeaderText="Emp Dept." />
                                        <asp:BoundField DataField="Idea" HeaderText="Idea" />
                                        <asp:BoundField DataField="Benefit" HeaderText="Benefits" />
                                        <asp:BoundField DataField="departmentname" HeaderText="Benifitted Area" Visible="false" />
                                        <asp:HyperLinkField DataTextField="Filename" DataNavigateUrlFields="Filename" HeaderText="Attachment" ItemStyle-Width="50px" >

<ItemStyle Width="50px"></ItemStyle>
                                        </asp:HyperLinkField>

                                        <asp:BoundField DataField="IdeaDate" HeaderText="Date" DataFormatString="{0:dd/MM/yy}" />


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
                            <br />

                            <div class="row mb-2">
                                <label for="inputText" class="col-sm-2 col-form-label">
                                    <b>Select Type
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" InitialValue="Select" ForeColor="Red" ControlToValidate="ddltype" ValidationGroup="G"></asp:RequiredFieldValidator>
                                    </b>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddltype" AutoPostBack="true" CssClass="form-control" AppendDataBoundItems="true" OnTextChanged="ddltype_TextChanged" runat="server">
                                        <asp:ListItem Value="Select">Select</asp:ListItem>
                                        <asp:ListItem Value="accept">Accept</asp:ListItem>
                                        <asp:ListItem Value="forward">Forward</asp:ListItem>
                                        <asp:ListItem Value="reject">Reject</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row mb-2" id="fwd" runat="server" visible="false">
                                <label for="inputText" class="col-sm-2 col-form-label">
                                    <b>Select Department
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" InitialValue="Select" ForeColor="Red" ControlToValidate="ddldept" ValidationGroup="G"></asp:RequiredFieldValidator>
                                    </b>
                                </label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddldept" AutoPostBack="true" DataValueField="AutoID" DataTextField="Department" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="Select">Select</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <label for="inputText" class="col-sm-2 col-form-label">
                                    <b>Remarks
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="" ForeColor="Red" ControlToValidate="txtremarks" ValidationGroup="G"></asp:RequiredFieldValidator>
                                    </b>
                                </label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtremarks" Font-Size="Small" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>


                            </div>


                            <br />

                            <div class="row mb-2">
                                <label class="col-sm-2 col-form-label"></label>
                                <div class="col-sm-2">


                                    <asp:LinkButton ID="btnsubmit" ValidationGroup="G" OnClick="btnsubmit_Click" Text="Approve" runat="server" ToolTip="Approve"><i class="btn btn-primary fa fa-trash">Submit</i></asp:LinkButton>

                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
