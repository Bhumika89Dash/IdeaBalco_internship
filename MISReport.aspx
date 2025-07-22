<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MISReport.aspx.cs" Inherits="IDEA_BALCO_1.MISReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="section">
        <div class="row">
            <div class="col-lg-12">

                <div class="card" style="top: 0px; margin-left: 0; left: auto; width: auto; height: auto;">
                    <div class="card-body">
                        <h5 class="card-title">Master Report</h5>
                        <div class="ibox-content">
                            <div class="panel panel-default">
                                <div class="panel-heading" style="font-weight: bold; font-size: 14px;">Search Records</div>
                                <div class="panel-body">
                                    <table width="100%" border="0" cellpadding="10" class="tbl">
                                        <tr>
                                            <td width="15%"><strong>Date From</strong> </td>
                                            <td width="35%">
                                                <asp:TextBox ID="txtDateFrom" runat="server" autocomplete="off" Width="260"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td width="15%"><strong>Idea Submitted:</strong> </td>
                                            <td style="font-weight: bold" width="35%">
                                                <asp:Label ID="lblIdeaSubmitted" runat="server" Text="0" CssClass="lbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                <strong>To</strong>
                                            </td>
                                            <td width="35%">
                                                <asp:TextBox ID="txtDateTo" runat="server" autocomplete="off" Width="260"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo"></ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td width="15%">
                                                <strong>Pending ideas:</strong>
                                            </td>
                                            <td width="35%" style="font-weight: bold">
                                                <asp:Label ID="lblPendingideas" runat="server" Text="0" CssClass="lbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                <strong>SBU</strong>
                                            </td>
                                            <td width="35%">
                                                <asp:DropDownList ID="ddlSBU" runat="server" Width="272" AutoPostBack="True" OnSelectedIndexChanged="ddlSBU_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                <strong>
                                                    <asp:Label ID="lblDepartment" runat="server" Text="Department" Visible="false"></asp:Label></strong>
                                            </td>
                                            <td width="35%">
                                                <asp:DropDownList ID="ddlDepartment" runat="server" Width="272" required="required" Visible="false"></asp:DropDownList>
                                            </td>
                                            <td width="15%">
                                                <strong>Assigned ideas:</strong>
                                            </td>
                                            <td width="35%" style="font-weight: bold">
                                                <asp:Label ID="lblAssignedideas" runat="server" Text="0" CssClass="lbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                <strong>Status</strong>&nbsp;</td>
                                            <td width="35%">
                                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" Width="272" required="required">
                                                    <asp:ListItem Text="---- Select Status ----" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                                    <asp:ListItem Text="Accepted" Value="Accepted"></asp:ListItem>
                                                    <asp:ListItem Text="Assigned" Value="Assigned"></asp:ListItem>
                                                    <asp:ListItem Text="Implemented" Value="Implemented"></asp:ListItem>
                                                    <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td width="15%">
                                                <strong>Approved ideas:</strong>
                                            </td>
                                            <td width="35%" style="font-weight: bold">
                                                <asp:Label ID="lblApprovedideas" runat="server" CssClass="lbl" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">&nbsp;</td>
                                            <td width="35%">

                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" OnClick="btnSubmit_Click" Text="Submit" />
                                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" OnClick="btnCancel_Click" Text="Cancel" />
                                                <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" OnClick="btnExportToExcel_Click" Text="Export to Excel" />

                                            </td>
                                            <td width="15%"><strong>Implemeted ideas:</strong> </td>
                                            <td style="font-weight: bold" width="35%">
                                                <asp:Label ID="lblImplemetedideas" runat="server" CssClass="lbl" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>&nbsp;</td>
                                            <td width="15%">
                                                <strong>Rejected ideas:</strong>
                                            </td>
                                            <td width="35%" style="font-weight: bold">
                                                <asp:Label ID="lblRejectedideas" runat="server" Text="0" CssClass="lbl"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td></td>
                                            <td>&nbsp;</td>
                                            <td width="15%">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server" Text="No. of Idea Given (Dept):"></asp:Label></strong>
                                            </td>
                                            <td width="35%" style="font-weight: bold">
                                                <asp:Label ID="lblIdeaGivenBy" runat="server" Text="0" CssClass="lbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>&nbsp;</td>
                                            <td width="15%">
                                                <strong>
                                                    <asp:Label ID="Label2" runat="server" Text="No. of Idea Getting (Dept):"></asp:Label></strong>
                                            </td>
                                            <td width="35%" style="font-weight: bold">
                                                <asp:Label ID="lblIdeaFor" runat="server" Text="0" CssClass="lbl"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <asp:GridView ID="gvMISReport" runat="server" CssClass="grid" Font-Size="10px" AllowPaging="True" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EmptyDataText="No Record Found!" OnPageIndexChanging="gvMISReport_PageIndexChanging" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AutoID" HeaderText="ID" />
                                    <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" />
                                    <asp:BoundField DataField="Emp_Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Emp_Dept" HeaderText="Dept" />
                                    <asp:BoundField DataField="Employee_Type" HeaderText="Type" />
                                    <asp:BoundField DataField="IdeaDate" HeaderText="IdeaDate" />
                                    <asp:BoundField DataField="Benefited_Area" HeaderText="Area" />
                                    <asp:BoundField DataField="Idea" HeaderText="Idea" />
                                    <asp:BoundField DataField="Benefit" HeaderText="Benefit" />
                                    <asp:TemplateField ItemStyle-Height="50" ItemStyle-Width="50" HeaderText="Image" Visible="false">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server"
                                                ImageUrl='<%# Eval("Image") %>' Height="100" Width="100" />
                                        </ItemTemplate>

                                        <ItemStyle Height="50px" Width="50px"></ItemStyle>
                                    </asp:TemplateField>

                                    <%--<asp:BoundField DataField="Image" HeaderText="Image" />   --%>
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="implementedDate" HeaderText="Date" />
                                    <asp:BoundField DataField="AssignTo" HeaderText="Assign To" />
                                    <asp:BoundField DataField="processText" HeaderText="Team Remark" />
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
