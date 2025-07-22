<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignPendingIdea.aspx.cs" Inherits="IDEA_BALCO_1.AssignPendingIdea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="section">
        <div class="row">
            <div class="col-lg-12">

                <div class="card" style="top: 10px; left: 0; margin-left: 0; height:auto">
                    <div class="card-body">
                        <h5 class="card-title">Assigned Pending Ideas List</h5>
                        <div class="ibox-content">
                            <div class="row mb-2">
                                <label for="inputText" class="col-sm-2 col-form-label">
                                    <b>Assigned Employee ID
                      
                                    </b>
                                </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtEmployeeID" runat="server" placeholder="Enter Employee ID" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-success" />
                                </div>
                            </div>


                            <div class="panel-body">
                                <asp:GridView ID="grdPendingIdeas" runat="server" AllowPaging="true" Style="width: 100%; text-align: center"
                                    class="table table-striped table-bordered table-responsive" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkselect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Idea ID">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Bind("ideaId") %>' ID="lblID"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SBU">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Bind("SBUName") %>' ID="lblSBU"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Department">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Bind("DepartmentName") %>' ID="lblIde1a"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Idea">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Bind("idea") %>' ID="lblIdea"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Benefit">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Bind("Benefit") %>' ID="lblBenefit"></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AutoID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Bind("AutoID") %>' ID="lblAutoID"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="row mb-2">
                                <label for="inputText" class="col-sm-2 col-form-label">
                                    <b>Assign To
                      
                                    </b>
                                </label>
                                <div class="col-sm-8">
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServiceMethod="GetSearch" MinimumPrefixLength="3"
                                        CompletionInterval="6" EnableCaching="false" CompletionSetCount="8" TargetControlID="txtassignto" FirstRowSelected="false">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <asp:TextBox ID="txtassignto" onblur="showName(3); return false;" placeholder="Search Employee" runat="server" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnassign" Text="Assign To" runat="server" OnClick="btnassign_Click" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
