<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FCW.Default" %>

<!DOCTYPE html>

<html lang="en">
<head>
<meta charset="utf-8">
<title>Football Clan Web</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta name="description" content="">
<meta name="author" content="">
<link rel="shortcut icon" type="image/x-icon" href="style/images/favicon.png" />
<link href="style/css/bootstrap.min.css" rel="stylesheet">
<link href="style/css/bootstrap.css" rel="stylesheet">
<link href="style/css/settings.css" rel="stylesheet">
<link href="style/css/datepicker.css" rel="stylesheet">
<link href="style/js/google-code-prettify/prettify.css" rel="stylesheet">
<link href="style/js/fancybox/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
<link href="style/js/fancybox/helpers/jquery.fancybox-thumbs.css?v=1.0.2" rel="stylesheet" type="text/css" />
<link href="style.css" rel="stylesheet">
<link href="style/css/custom.css" rel="stylesheet">
<link href="style/css/select2.css" rel="stylesheet">
<link href="style/css/toggle.css" rel="stylesheet">
<link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,300,600,700' rel='stylesheet' type='text/css'>
<link href="style/type/fontello.css" rel="stylesheet">
<!-- Table CSS -->
<link href="style/css/jquery.bdt.css" type="text/css" rel="stylesheet">
<link href="style/css/style.css" type="text/css" rel="stylesheet">
<!-- End Table CSS -->

<!--[if IE 8]>
<link rel="stylesheet" type="text/css" href="style/css/ie8.css" media="all" />
<![endif]-->
<!--[if lt IE 9]>
<script src="style/js/html5shiv.js"></script>
<![endif]-->
</head>
<body>
<header>
    <div class="row">
        <div class="span4 logo pull-left"> <a href="#"><img src="style/images/logo.png"/></a> </div>
        <div class="span4 pull-right" id="mainHeader">
        </div>
    </div>
</header>
<!-- /header -->
<div class="body-wrapper">
  <nav id="menu" class="menu">
    <ul id="tiny">
      <li class="active" content-type="matches">
          <a class="meanclose"><i class="icon-dribbble-circled icn"></i>My Matches</a>        
      </li>
      <li content-type="leaderboard">
          <a class="meanclose"><i class="icon-users-1 icn"></i>My Details</a>
      </li>
      <li content-type="clans">
          <a class="meanclose"><i class="icon-users icn"></i>My Clans</a>
      </li>
      <li content-type="leagues">
          <a class="meanclose"><i class="icon-users-1 icn"></i>My Leagues</a>
      </li>
      <li content-type="predictions">
          <a class="meanclose"><i class="icon-magic icn"></i>Past Predictions</a>
      </li>
      <li content-type="chat">
          <a class="meanclose"><i class="icon-comment icn"></i>Message Board</a>
      </li>
      <li content-type="store">
          <a class="meanclose"><i class="icon-basket icn"></i>My Store</a>
      </li>
    </ul>
  </nav>
  <!-- /.menu -->
  
  <div class="box pull-left">
    <div class="light-wrapper">
      <div id="mainContainer" class="container inner">
             
      </div>
      <!--/.container--> 
    </div>
    <!--/.light-wrapper-->
    
    <!-- /footer -->
    
    <div class="subfooter">
      <div class="container inner">
        <p class="pull-left">© <script type="text/javascript">
                                   now = new Date;
                                   theYear = now.getYear();
                                   if (theYear < 1900)
                                       theYear = theYear + 1900;
                                   document.write(theYear);
                               </script> Football Clans. All rights reserved.</p>
        <ul class="social pull-right">
          <li><a href="#"><i class="icon-s-twitter"></i></a></li>
          <li><a href="#"><i class="icon-s-facebook"></i></a></li>
          <li><a href="#"><i class="icon-s-instagram"></i></a></li>
        </ul>
      </div>
      <!-- /.container --> 
    </div>
    <!-- /.subfooter --> 
  </div>
  <!--/.box--> 
</div>
<!--/.body-wrapper--> 
<script src="js/prototype.js"></script> 
<script src="style/js/jquery.js"></script> 
<script src="style/js/bootstrap.min.js"></script> 
<script src="style/js/twitter-bootstrap-hover-dropdown.min.js"></script> 
<script src="style/js/ddsmoothmenu.js"></script> 
<script src="style/js/jquery.themepunch.plugins.min.js"></script> 
<script src="style/js/jquery.themepunch.revolution.min.js"></script> 
<script src="style/js/jquery.themepunch.showbizpro.min.js"></script> 
<script src="style/js/jquery.fancybox.pack.js"></script> 
<script src="style/js/fancybox/helpers/jquery.fancybox-thumbs.js?v=1.0.2"></script> 
<script src="style/js/fancybox/helpers/jquery.fancybox-media.js?v=1.0.0"></script> 
<script src="style/js/jquery.meanmenu.2.0.min.js"></script> 
<script src="style/js/jquery.fitvids.js"></script> 
<script src="style/js/jquery.slickforms.js"></script> 
<script src="style/js/jquery.isotope.min.js"></script> 
<script src="style/js/google-code-prettify/prettify.js"></script> 
<script src="style/js/jquery.easytabs.min.js"></script> 
<script src="style/js/jquery.hoverdir.min.js"></script> 
<script src="style/js/scripts.js"></script>
<script src="style/js/moment.js"></script>
<script src="style/js/tooltip.js"></script>
<script src="style/js/transitions.js"></script>
<script src="style/js/confirmation.js"></script>
<script src="style/js/bootstrap-tooltip.js"></script>
<script src="style/js/bootstrap-datepicker.js"></script>
<script src="style/js/select2.js"></script>
<script src="style/js/toggle.js"></script>
    <!-- Table JS -->
<script src="style/js/jquery.sortelements.js"></script>
<script src="style/js/jquery.bdt.js"></script>
    <!-- End Table JS -->
<script src="js/user.js"></script>
<script src="js/helpers.js"></script>
<script src="js/genTable.js"></script>
<script src="js/genClans.js"></script>
<script src="js/genLiveScore.js"></script>
<script src="js/genLeagues.js"></script>
<script src="js/genMatches.js"></script>
<script src="js/genLeaderboard.js"></script>
<script src="js/genBase.js"></script>
</body>
</html>
