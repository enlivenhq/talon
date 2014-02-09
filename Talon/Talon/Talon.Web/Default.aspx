<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Talon.Web._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid dashboard">

			<div class="row main-graphs">
				<div class="col-md-12">

					<div class="textCenter">
						<img src="/flat-icons/apscience.png" style="width:50%; margin: 40px 0;" alt="">
					</div>

					<div class="row ">
						<div class="col-xs-6 col-sm-12 placeholder">
								<h2>FY2014 Project Forcast</h2>
								<div id="mainGraphProjects" ></div>
						</div>
					</div>

					<div class="row">
						<div class="col-xs-6 col-sm-6">
							<h2>FY2014 Projected Revenue</h2>
							<div id="mainGraphQuarters" style="width:100%;"></div>
						</div>
						<div class="col-xs-6 col-sm-6">
							<h2>FY2014 Projected Revenue</h2>
							<div id="mainGraphPercentage" style="width:100%;"></div>
						</div>
					</div>
				</div>
			</div>

			<div class="row info">

				<div class="col-md-4 ">
					<div class="total-projects">
						<%= TotalOpportunites %>
						<div class="subtitle">Total Projects</div>
					</div>
				</div>
				<div class="col-md-4">
					<div class="estimated-revenue">
						<%= EstimatedRevenue %>M
						<div class="subtitle">Estimated Revenue FY2014</div>
					</div>
				</div>
				<div class="col-md-4">
					<div class="forcast-accuracy">
						78%
						<div class="subtitle">Forcast Accuracy FY2013</div>
					</div>
				</div>


			</div>

			<div class="row opportunities">
				<div class="row good">

					<div class="col-md-10 col-md-offset-1">
						<h1>Hot Leads</h1>
						<h2>Great Job! These opportunites are in the bag.</h2>

                        <asp:Repeater runat="server" ID="HotOpportunites">
                            <ItemTemplate>
						        <div class="rating">
							        <div class="row">
								        <div class="score floatLeft"><%# Eval("FormattedCalculatedProbabilityOfClose") %></div>
								        <div class="opportunity"><%# Eval("OpportunityName") %></div>
								        <div class="date-of-close"><i class="fa fa-clock-o"></i> <%# ((DateTime) Eval("CalculatedCloseDate")).ToString("M/dd/yy") %></div>
								        <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
							        </div>

							        <div class="row">
								        <div class="more-info">
									        <div class="stage <%# ((int) Eval("CurrentStageId") >= 1) ? "complete" : "" %>">1. Qualifying Stage</div>
									        <div class="stage <%# ((int) Eval("CurrentStageId") >= 2) ? "complete" : "" %>">1. Developing Stage</div>
									        <div class="stage <%# ((int) Eval("CurrentStageId") >= 3) ? "complete" : "" %>">1. Negotiations Stage</div>
									        <div class="stage <%# ((int) Eval("CurrentStageId") >= 4) ? "complete" : "" %>">1. Pending Stage</div>
									        <div class="stage <%# ((int) Eval("CurrentStageId") >= 5) ? "complete" : "" %>">1. Closed Stage</div>
								        </div>
							        </div>
						        </div>
                            </ItemTemplate>
                        </asp:Repeater>
					</div>
				</div>

				<div class="row medium">
					 <div class="col-md-10 col-md-offset-1">
							<h1>They Need Some Work</h1>
							<h2>With some elbow grease, we might just close.</h2>
							
                            <asp:Repeater runat="server" ID="MediumOpportunities">
                                <ItemTemplate>
							        <div class="rating">
								        <div class="row">
									        <div class="score floatLeft"><%# Eval("FormattedCalculatedProbabilityOfClose") %></div>
									        <div class="opportunity"><%# Eval("OpportunityName") %></div>
									        <div class="date-of-close"><i class="fa fa-clock-o"></i> <%# ((DateTime) Eval("CalculatedCloseDate")).ToString("M/dd/yy") %></div>
									        <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
								        </div>

								        <div class="row">
									        <div class="more-info">
										        <div class="stage <%# ((int) Eval("CurrentStageId") >= 1) ? "complete" : "" %>">1. Qualifying Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 2) ? "complete" : "" %>">1. Developing Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 3) ? "complete" : "" %>">1. Negotiations Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 4) ? "complete" : "" %>">1. Pending Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 5) ? "complete" : "" %>">1. Closed Stage</div>
									        </div>
								        </div>
							        </div>
                                </ItemTemplate>
                            </asp:Repeater>
						</div>
				</div>


				<div class="row medium">
					 <div class="col-md-10 col-md-offset-1">
							<h1>Cold as Ice</h1>
							<h2>Lorem ipsum somehint.</h2>
							
                            <asp:Repeater runat="server" ID="ColdOpportunities">
                                <ItemTemplate>
							        <div class="rating">
								        <div class="row">
									        <div class="score floatLeft"><%# Eval("FormattedCalculatedProbabilityOfClose") %></div>
									        <div class="opportunity"><%# Eval("OpportunityName") %></div>
									        <div class="date-of-close"><i class="fa fa-clock-o"></i> <%# ((DateTime) Eval("CalculatedCloseDate")).ToString("M/dd/yy") %></div>
									        <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
								        </div>

								        <div class="row">
									        <div class="more-info">
										        <div class="stage <%# ((int) Eval("CurrentStageId") >= 1) ? "complete" : "" %>">1. Qualifying Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 2) ? "complete" : "" %>">1. Developing Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 3) ? "complete" : "" %>">1. Negotiations Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 4) ? "complete" : "" %>">1. Pending Stage</div>
									            <div class="stage <%# ((int) Eval("CurrentStageId") >= 5) ? "complete" : "" %>">1. Closed Stage</div>
									        </div>
								        </div>
							        </div>
                                </ItemTemplate>
                            </asp:Repeater>
						</div>
				</div>

			

			</div>

			<div class="row bad">
				<div class="col-sm-3 col-md-3 sidebar" style="display:none;">
					<ul class="nav nav-sidebar">
						<li class="active"><a href="#">Overview</a></li>
						<li><a href="#">Reports</a></li>
						<li><a href="#">Analytics</a></li>
						<li><a href="#">Export</a></li>
					</ul>
					<ul class="nav nav-sidebar">
						<li><a href="#">Nav item</a></li>
						<li><a href="#">Nav item again</a></li>
						<li><a href="#">One more nav</a></li>
						<li><a href="#">Another nav item</a></li>
						<li><a href="#">More navigation</a></li>
					</ul>
					<ul class="nav nav-sidebar">
						<li><a href="#">Nav item again</a></li>
						<li><a href="#">One more nav</a></li>
						<li><a href="#">Another nav item</a></li>
					</ul>

					<div class="info-box">
						Hello
					</div>

					<div class="info-box gold">
						Hello
					</div>

				</div>
			
			</div>
		</div>

</asp:Content>
