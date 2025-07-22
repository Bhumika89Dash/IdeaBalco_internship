<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewIdea.aspx.cs" Inherits="IDEA_BALCO_1.NewIdea" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <section class="section" >
      <div class="row">
        <div class="column">

          <div class="card" style="top: 10px; left: 0; margin-left: 0; height:auto">
            <div class="card-body">
              <h5 class="card-title">Submit New Idea</h5>
                <asp:Label runat="server" ID="lblid" Visible="false"></asp:Label>
          <asp:Label runat="server" ID="lbladmin" Visible="false"></asp:Label>
           <asp:Label runat="server" ID="lblemail" Visible="false"></asp:Label>
                <div class="row mb-3">
                    
                    <label for="inputEmail" class="col-sm-3 col-form-label"><b>Mobile<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" InitialValue="" ForeColor="Red" ControlToValidate="txtmobile" ValidationGroup="G1"></asp:RequiredFieldValidator>
                  </b></label>
                  <div class="col-sm-9">
                        <asp:TextBox ID="txtmobile" MaxLength="10"  CssClass="form-control" runat="server"></asp:TextBox>
                       <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtmobile" ValidChars="0123456789" />

                      </div>

                </div>
               <div class="row mb-3">
                      <label for="inputEmail" class="col-sm-3 col-form-label"><b>SBU<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" InitialValue="Select" ForeColor="Red" ControlToValidate="ddlsbu" ValidationGroup="G1"></asp:RequiredFieldValidator>
                  </b></label><br />
                  <div class="col-sm-9">
                   <asp:DropDownList ID="ddlsbu" AutoPostBack="true" CssClass="form-control" DataTextField="SBU" DataValueField="SBU_ID" AppendDataBoundItems="true" OnTextChanged="ddlsbu_TextChanged" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                 </asp:DropDownList>
                      </div>
                   

                </div>

                <div class="row mb-3">
                    
                    <label for="inputEmail" class="col-sm-3 col-form-label"><b>Benefited Area<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" InitialValue="Select" ForeColor="Red" ControlToValidate="ddlarea" ValidationGroup="G1"></asp:RequiredFieldValidator>
                  </b></label>
                  <div class="col-sm-9">
                        <asp:DropDownList ID="ddlarea" AutoPostBack="true" CssClass="form-control" DataTextField="department" DataValueField="AutoID" AppendDataBoundItems="true"  runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                 </asp:DropDownList>
                      </div>

                </div>
                 <div class="row mb-3">
                      <label for="inputEmail" class="col-sm-3 col-form-label"><b>Your Idea<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" InitialValue="" ForeColor="Red" ControlToValidate="txtideas" ValidationGroup="G1"></asp:RequiredFieldValidator>
                  </b></label>
                  <div class="col-sm-9">
                      <asp:TextBox ID="txtideas" TextMode="MultiLine" placeholder="Enter your Idea"  CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                

                </div>

                <div class="row mb-3">
                      <label for="inputEmail" class="col-sm-3 col-form-label"><b>Benefits<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="" ForeColor="Red" ControlToValidate="txtbenifits" ValidationGroup="G1"></asp:RequiredFieldValidator>
                  </b></label>
                  <div class="col-sm-9">
                     <asp:TextBox ID="txtbenifits" TextMode="MultiLine" placeholder="Enter your Benifits"  CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                   

                </div>
                 
                  <div class="row mb-3">
                      <label for="inputEmail" class="col-sm-3 col-form-label"><b>Select Image for Idea
                  </b></label>
                  <div class="col-sm-9">
                      <asp:FileUpload ID="FileUpload1"  CssClass="form-control" runat="server" accept=".jpg, .jpeg, .png, .gif,.bmp,.tiff,.svg" />
                      </div>
                  

                </div>
              <div  align="right" style="font-size:12px;">
                    
                    <hr />
                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success" OnClick="LinkButton2_Click"  ValidationGroup="G1">Submit</asp:LinkButton>
                   <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" class="btn btn-danger"  ValidationGroup="G11">Cancel</asp:LinkButton>
                     <br /><br /><br />
                    </div>
                
                
                </div>
              </div>
            </div>
          </div>
           </section>
</asp:Content>
