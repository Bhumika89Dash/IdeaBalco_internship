<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PointSummary.aspx.cs" Inherits="IDEA_BALCO_1.PointSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="section" >
      <div class="row">
        <div class="col-lg-12">

          <div class="card" style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
            <div class="card-body">
                
                 <h5 class="card-title" >Point Summary</h5>
                <div class="ibox-content">
                    <div class="panel-body">
                                <div class="row">
                                    <asp:GridView ID="GridView1" runat="server" CssClass="grid" AllowPaging="True" AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EmptyDataText="No Data Found" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing" ShowFooter="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4">
                                        <Columns>
                                            <asp:BoundField DataField="Ref_Number" HeaderText="#ID" />
                                            <asp:BoundField DataField="Trans_Type" HeaderText="Type" />
                                            <asp:BoundField DataField="Trans_Date" HeaderText="Date" />
                                            <asp:BoundField DataField="Points" HeaderText="Points" DataFormatString="{0:N2}"/>
                                            <asp:BoundField DataField="Redeemed" HeaderText="Redeemed" DataFormatString="{0:N2}"/>
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
                                <!-- End Grid Section -->
                            </div>
                    </div>
                </div>
              </div>
            </div>
          </div>
        </section>
</asp:Content>
