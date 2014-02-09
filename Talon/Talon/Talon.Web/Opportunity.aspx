<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Opportunity.aspx.cs" Inherits="Talon.Web.Opportunity" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid opportunity">

      <div class="row main-graphs">
        <div class="col-md-12">

          <div class="textCenter">
            <img src="/flat-icons/apscience.png" style="width:50%; margin: 40px 0;" alt="">
          </div>

          <div class="row">
            <div class="col-md-12">
              <h3><span>Opportunity : </span><%= OpportunityName %></h3>
            </div>  
            <div class="col-md-12 marginTopXL marginBottomL">
               <div class="percentage-call-out">
                  <div class="big"><%= FormattedCalculatedProbabilityOfClose %>%</div>
                </div>

            </div>

           <!--  <div class="col-md-6 col-md-offset-3 marginBottomM">
              <div class="progress progress-striped active marginTopL marginBottomL">
                <div class="progress-bar"  role="progressbar" aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 45%">
                  <span class="sr-only">45% Complete</span>
                </div>
              </div>
            </div> -->



            <div class="row marginBottomXL">
              <div class="col-md-4 col-md-offset-2">
                <h2>Action Steps</h2>
                <div class="person-info"><span>Email:</span> It's been 2 weeks since you've emailed Loberg. Perhaps it's time to see what they're up to?</div>
                <div class="person-info"><span>Phone:</span> Tom at Lorberg's birthday is coming up. Give him a call and wish him a happy birthday.</div>
                <div class="person-info"><span>Meeting:</span> If you meet in person with Lorberg 2 more times, you increase your chance of landing this deal by 39%!</div>
              </div>
              <div class="col-md-4">
                <h2>Salesman</h2>
                <div class="person-info"><span>Name:</span> Christopher Paul Hilton</div>
                <div class="person-info"><span>Location:</span> St. Louis, MO</div>
                <div class="person-info"><span>Phone Number:</span> 713.542.4446</div>
                <div class="person-info"><span>Region:</span> Mid-West</div>
                <div class="person-info"><span>Email:</span> chilton@enlivenhq.com</div>
              </div>
            </div>

          </div>




        </div>
      </div>



      <div class="row sales-stage">
        <div class="row good">

            <div class="col-md-10 col-md-offset-1">
              <h1>Sales Stages</h1>
              <h2>Looks like we have a <%= FormattedCalculatedProbabilityOfClose %>% chance of landing this client.</h2>


              <div class="stage qualifying complete">
                <div class="row">
                  <div class="score floatLeft">1</div>
                  <div class="opportunity">Stage - Qualifying</div>
                  <div class="date-of-close"><i class="fa fa-check-square"></i> 2/2 Complete</div>
                  <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
                </div>

                <div class="row">
                  <div class="more-info closed">
                    <div class="row">
                      <div class="col-md-6 pain-rating">
                        <div class="textCenter">
                          <span class="active">1</span>
                           - 
                          <span>2</span>
                           - 
                          <span>3</span>
                        </div>
                        <span class="title">Pain Rating</span>
                      </div>
                      <div class="col-md-6 fit ">
                          <div>Excellent Fit</div>
                          <div class="active">It Could Work</div>
                          <div>Bad Fit.</div>
                      </div>
                    </div>
                  </div>
                </div>

              </div><!-- stage -->

              <div class="stage qualifying">
                <div class="row">
                  <div class="score floatLeft">2</div>
                  <div class="opportunity">Stage - Developing</div>
                  <div class="date-of-close"> 1/2 Complete</div>
                  <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
                </div>

                <div class="row">
                  <div class="more-info">
                    <div class="row">
                      <div class="col-md-6 demo-rating">
                        <div class="textCenter">
                          <span class="active">A</span>
                           - 
                          <span>B</span>
                           - C
                        </div>
                        <span class="title">Demo Rating</span>
                      </div>
                      <div class="col-md-6 competitor">
                        <div class="textCenter">
                          <span >A</span>
                           - 
                          <span class="active">B</span>
                           - C
                        </div>
                        <span class="title">Competitor Comparison</span>
                      </div>
                      
                    </div>
                  </div>
                </div>

              </div><!-- stage -->
              
              
              <div class="stage qualifying">
                <div class="row">
                  <div class="score floatLeft">3</div>
                  <div class="opportunity">Stage - Qualifying</div>
                  <div class="date-of-close"> 0/2 Complete</div>
                  <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
                </div>

                <div class="row">
                  <div class="more-info">
                    <div class="row">
                      <div class="col-md-6 proposal">
                          <div class="active"><i class="fa fa-inbox"></i> Submitted</div>
                          <div class="title">Proposal</div>
                      </div>
                      <div class="col-md-6 pricing ">
                          <div ><i class="fa fa-money"> Not Accepted</i></div>
                          <div class="title">Pricing</div>
                      </div>
                    </div>
                  </div>
                </div>

              </div><!-- stage -->


              <div class="stage qualifying">
                <div class="row">
                  <div class="score floatLeft">4</div>
                  <div class="opportunity">Stage - Negotiation</div>
                  <div class="date-of-close"> 1/2 Complete</div>
                  <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
                </div>

                <div class="row">
                  <div class="more-info">
                    <div class="row">
                      <div class="col-md-6 executive">
                          <span class="active"><i class="fa fa-briefcase"></i>&nbsp;Completed</span>
                        <span class="title">Executive Sign Off</span>
                      </div>
                      <div class="col-md-6 legal ">
                          <span><i class="fa fa-gavel"></i>&nbsp;----------</span>
                          <span class="title">Legal Sign Off</span>
                      </div>
                    </div>
                  </div>
                </div>

              </div><!-- stage -->

              

              <div class="stage qualifying">
                <div class="row">
                  <div class="score floatLeft">5</div>
                  <div class="opportunity">Stage - Won / Lost</div>
                  <a href="#" onclick="return false" class="caret-icon"><i class="fa fa-caret-down"></i></a>
                </div>

                <div class="row">
                  <div class="more-info">
                    <div class="row">
                      <div class="col-md-12 won">

                        <div class="title">Project Won!</div>

                          $50,000
                          

                      </div>
                      <div class="col-md-12 fit ">
                          <div>Project Went To: Acme Brick Company</div>
                          <div>Project Amount: $53,382</div>
                          <div class="active">Looks like we lost this one.</div>
                      </div>
                    </div>
                  </div>
                </div>

              </div><!-- stage -->


            </div>
        </div>

        

      </div>

    
    </div>
</asp:Content>
