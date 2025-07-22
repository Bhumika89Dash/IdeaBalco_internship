<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IdeaSummaryReport.aspx.cs" Inherits="IDEA_BALCO_1.IdeaSummaryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="section" >
      <div class="row">
        <div class="col-lg-12">

          <div class="card" style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
            <div class="card-body">
                 <h5 class="card-title">Idea Summary Report</h5><asp:TextBox ID="txtsearch" runat="server" Width="300px" placeholder="Search here..." AutoPostBack="true"></asp:TextBox><br /><br />
                <div class="ibox-content">
                    <div class="row mb-2" >
                  <label for="inputText" class="col-sm-2 col-form-label"><b>Date From
                      
                                                                         </b></label>
                  <div class="col-sm-3">
                    
                         <asp:TextBox ID="txtFromDate" TextMode="Date" runat="server" Class="form-control" required="required"></asp:TextBox>
                  </div>
                        <label for="inputText" class="col-sm-2 col-form-label"><b>To
                      
                                                                         </b></label>
                  <div class="col-sm-3">
                     <asp:TextBox ID="txtToDate" TextMode="Date" runat="server" Class="form-control" required="required"></asp:TextBox>
                  </div>
                        <div class="col-sm-2">
                            <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" Text="Approve" runat="server" ToolTip="Approve" ><i class="btn btn-primary fa fa-trash">Search</i></asp:LinkButton>
                           </div></div>
                    <div>
                    <div class="panel-body">
                               <asp:GridView ID="gvMISReport" runat="server" CssClass="grid" Font-Size="10px" AllowPaging="True" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EmptyDataText="No Record Found!" OnPageIndexChanging="gvMISReport_PageIndexChanging" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4">
                            <Columns>
                                <asp:BoundField DataField="AutoID" HeaderText="#ID" />
                                <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" />
                                <asp:BoundField DataField="Emp_Name" HeaderText="Emp_Name" />
                                <asp:BoundField DataField="Emp_Dept" HeaderText="Emp_Dept" />
                                <asp:BoundField DataField="Employee_Type" HeaderText="Employee_Type" />
                                <asp:BoundField DataField="IdeaDate" HeaderText="Date" />
                                <asp:BoundField DataField="Benefited_Area" HeaderText="Benefited_Area" />
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
                                <asp:BoundField DataField="implementedDate" HeaderText="implementedDate" />
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
                        <br />
                                               <asp:LinkButton ID="LinkButton1" OnClick="Export_To_Excel" Text="Approve" runat="server" ToolTip="Approve" ><i class="btn btn-success fa fa-trash">Export To Excel</i></asp:LinkButton>

                                <!-- End Grid Section -->
                            </div>
                   <br />
                     
                      
                        </div>
                </div>
              </div>
            </div>
          </div>
         </section>
</asp:Content>
