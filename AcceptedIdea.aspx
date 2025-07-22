<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AcceptedIdea.aspx.cs" Inherits="IDEA_BALCO_1.AcceptedIdea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="section" >
      <div class="row">
        <div class="col-lg-12">

          <div class="card" style="top: 10px; left: 0; margin-left: 0; height:auto">
            <div class="card-body">
                 <h5 class="card-title">Accepted Ideas</h5><asp:TextBox ID="txtsearch" runat="server" Width="300px" placeholder="Search here..." AutoPostBack="true" OnTextChanged="txtsearch_TextChanged"></asp:TextBox><br /><br />
                <div class="ibox-content">

                    <div class="panel-body">
                                <asp:GridView ID="GridView1" runat="server" CssClass="grid" AllowPaging="True"  AutoGenerateColumns="False" GridLines="Horizontal" Width="100%" EmptyDataText="No Data Found" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                        <asp:BoundField DataField="EmpNo" HeaderText="Emp No" />
                                        <asp:BoundField DataField="Name" HeaderText="Emp Name" />
                                        <asp:BoundField DataField="Emp Dept" HeaderText="Emp Dept." />    
                                        <asp:BoundField DataField="SBU" HeaderText="SBU" Visible="false" />
                                        <asp:BoundField DataField="departmentname" HeaderText="Department"  Visible="false" />
                                        <asp:BoundField DataField="Idea" HeaderText="Idea" />
                                        <asp:BoundField DataField="Benefit" HeaderText="Benefits" />                                        
                                        <asp:BoundField DataField="IdeaDate" HeaderText="Date" DataFormatString="{0:dd/MM/yy}" />
                                        
                                       
                                    </Columns>
                                    <EmptyDataRowStyle CssClass="alert  alert-warning" />
                                </asp:GridView>
                                <!-- End Grid Section -->
                            </div>
                   <br />
                     
                       <div class="row mb-2" >
                  <label for="inputText" class="col-sm-2 col-form-label"><b>Please select your employees to assign idea:
                      
                                                                         </b></label>
                  <div class="col-sm-8">
                     <asp:CheckBoxList ID="chkDrList" runat="server" RepeatColumns="4" Font-Size="12px" RepeatDirection="Horizontal" ></asp:CheckBoxList>   
                  </div>
                           </div>
                    
                      
                    
                    <div class="row mb-2" >
                  <label for="inputText" class="col-sm-2 col-form-label"><b>Remarks
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="" ForeColor="Red" ControlToValidate="txtremarks" ValidationGroup="G"></asp:RequiredFieldValidator>
                                                                         </b></label>
                  <div class="col-sm-4">
                      <asp:TextBox ID="txtremarks" Font-Size="Small" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>
                    
                  
                </div>
                     

                      <br />
               
                  <div class="row mb-2">
                  <label class="col-sm-2 col-form-label"></label>
                  <div class="col-sm-2">

                        
                      <asp:LinkButton ID="btnsubmit" OnClick="btnsubmit_Click" ValidationGroup="G"  Text="Approve" runat="server" ToolTip="Approve" ><i class="btn btn-primary fa fa-trash">Submit</i></asp:LinkButton>
                     
                  </div>
                      
              
                      </div>
                    </div>
                </div>
              </div>
            </div>
          </div>
         </section>
</asp:Content>
