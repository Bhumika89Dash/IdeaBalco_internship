<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IDEA_BALCO_1.Home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
        .card{
            width: auto;
            top: 0;
            left: 0; 
            margin:auto;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="section">
        <div class="row">
            <div class="col-lg-12">

                <div class="card" style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
                    <div>
            <iframe title="IDEA_BALCO" width="1140" height="541.25" src="https://app.powerbi.com/reportEmbed?reportId=9c840052-fa26-4fb4-9b8d-185cdd45b83c&autoAuth=true&ctid=4273e6e9-aed1-40ab-83a3-85e0d43de705" frameborder="0" allowFullScreen="true"></iframe>
        </div>
                    <div class="card-body">
                        <h5 class="card-title">User Dashboard</h5>
                        <asp:Label runat="server" ID="lblid" Visible="false"></asp:Label>



                        <div class="col-lg-12" id="User" runat="server">
                            <table width="100%">
                                <tr>

                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card revenue-card">

                                            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="MySubmittedIdea.aspx" ToolTip="My Submitted Idea...">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 35px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="lblMySubmitted" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">My Submitted</div>
                                                </div>
                                            </asp:LinkButton>

                                        </div>

                                    </td>
                                     <td width="1%"></td>
                                    <td width="18%">
                                        <div class="card info-card revenue-card" >

                                            <asp:LinkButton ID="lnkAssigned" runat="server" PostBackUrl="AssignedIdea.aspx" ToolTip="assigned idea for implementation...">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 35px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="lblAssigned" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Total Assigned</div>
                                                </div>
                                            </asp:LinkButton>

                                        </div>
                                    </td>
                                     <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="lnkPending" runat="server" PostBackUrl="" ToolTip="assigned idea for implementation which are still pending...">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 35px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="lblPending" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Pending</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="lnkImplemented" runat="server" PostBackUrl="ImplementedIdea.aspx" ToolTip="implemented ideas in your department">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 35px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="lblImplemented" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Implemented</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                </tr>
                            </table>





                        </div>



                    </div>

                </div>
                <div class="card" id="HOD" visible="false" runat="server" style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
                    <div class="card-body">
                        <h5 class="card-title">HOD Dashboard</h5>
                        <asp:Label runat="server" ID="Label4" Visible="false"></asp:Label>





                        <div class="col-lg-12">
                            <table width="100%">
                                <tr>

                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card revenue-card">

                                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="PendingIdeaHOD.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label9" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Pending</div>
                                                </div>
                                            </asp:LinkButton>

                                        </div>

                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">
                                        <div class="card info-card revenue-card">

                                            <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="AcceptedIdea.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label10" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Accepted</div>
                                                </div>
                                            </asp:LinkButton>

                                        </div>
                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="AssignedIdeaHOD.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label11" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Assigned</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="LinkButton12" runat="server" PostBackUrl="ImplementedIdeaHOD.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label12" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Implemented</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="RejectedIdea.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label13" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Rejected</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                </tr>
                            </table>





                        </div>

                    </div>

                </div>
                <div class="card" id="Admin" visible="false" runat="server" style="height: auto; width: auto; top: 0; left: 0; margin-left: 0">
                    <div class="card-body">
                        <h5 class="card-title">Admin Dashboard</h5>
                        <asp:Label runat="server" ID="Label1" Visible="false"></asp:Label>





                        <div class="col-lg-12">
                            <table width="100%">
                                <tr>

                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card revenue-card">

                                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="PendingIdeaAdmin.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Pending</div>
                                                </div>
                                            </asp:LinkButton>

                                        </div>

                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">
                                        <div class="card info-card revenue-card">

                                            <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="AcceptedIdeaAdmin.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Accepted</div>
                                                </div>
                                            </asp:LinkButton>

                                        </div>
                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="AssignIdeaAdmin.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Assigned</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="ImplementedIdeaAdmin.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label6" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Implemented</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                    <td width="1%"></td>
                                    <td width="18%">

                                        <div class="card info-card customers-card">

                                            <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="RejectedIdeaAdmin.aspx">
                                                <div class="countDiv">
                                                    <div style="color: #9bc93b; font-size: 25px !important; text-align: center; font-weight: 400">
                                                        <asp:Label ID="Label7" runat="server" Text="0"></asp:Label>
                                                    </div>
                                                    <div style="text-align: center; padding-top: 5px; margin-bottom: 10px !important; color: black">Rejected</div>
                                                </div>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                </tr>
                            </table>





                        </div>

                    </div>

                </div>
            </div>

        </div>
        

    </section>
</asp:Content>
