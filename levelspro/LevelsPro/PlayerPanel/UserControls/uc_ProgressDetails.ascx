﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ProgressDetails.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_ProgressDetails" %>

	<div class="box pd-popup">
<div class="in-cont" id="scrollbar1">
<div class="scrollbar"><div class="track"><div class="thumb"><div class="end"></div></div></div></div>
		<div class="viewport read-msg">
			 <div class="overview">
            <h2><asp:Label ID="lblheading" runat="server"></asp:Label>
                <%--Process 20 credit card applications--%></h2>
            <p id="pdesc" runat="server">
              <%--  Getting customers to use our own “AcmeCard” is a great way to build loyalty and
                to increase customer spend. Whenever you are serving a customer, don’t forget to
                ask them “Will this be on your AcmeCard today?”. If they say no, remind them that
                if they use their AcmeCard, they will not have to pay for their purchase for a month
                and that there is no interest if it is paid in full. Hand them the application that
                they can complete. And remember, for every application that is accepted, you get
                an extra $3.--%>
            </p>
        </div>
        </div>
        <div class="green-wrapper fl pd-close">
<asp:Button ID="btnClose" class="green" Text="<%$ Resources:TestSiteResources, Close %>" 
    runat="server" onclick="btnClose_Click" />
    </div>
        </div>
  


      </div>
    
<%--<div class="green-btn btn close-p m0 ps">
    Close</div>--%>
