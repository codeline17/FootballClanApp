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
<link href="style/css/bootstrap.css" rel="stylesheet">
<link href="style/css/settings.css" rel="stylesheet">
<link href="style/js/google-code-prettify/prettify.css" rel="stylesheet">
<link href="style/js/fancybox/jquery.fancybox.css" rel="stylesheet" type="text/css" media="all" />
<link href="style/js/fancybox/helpers/jquery.fancybox-thumbs.css?v=1.0.2" rel="stylesheet" type="text/css" />
<link href="style.css" rel="stylesheet">
<link href="style/css/custom.css" rel="stylesheet">
<link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,400,300,600,700' rel='stylesheet' type='text/css'>
<link href="style/type/fontello.css" rel="stylesheet">
<!--[if IE 8]>
<link rel="stylesheet" type="text/css" href="style/css/ie8.css" media="all" />
<![endif]-->
<!--[if lt IE 9]>
<script src="style/js/html5shiv.js"></script>
<![endif]-->
</head>
<body>
<header>
  <div class="logo pull-left"> <a href="index.html"><img src="style/images/logo.png" alt="" /></a> </div>
  <ul class="contact-info pull-right">
    <li><i class="icon-user"></i><a href="#">Filan Fisteku</a></li>
    <!--li><i class="icon-phone-1"></i>+00 (123) 456 78 90</li -->
  </ul>
</header>
<!-- /header -->
<div class="body-wrapper">
  <nav id="menu" class="menu">
    <ul id="tiny">
      <li class="active" content-type="matches">
          <a href="#"><i class="icon-dribbble-circled icn"></i>My Matches</a>        
      </li>
      <li content-type="predictions">
          <a href="#"><i class="icon-magic icn"></i>My Predictions</a>
      </li>
      <li content-type="clans">
          <a href="#"><i class="icon-users icn"></i>My Clans</a>
      </li>
      <li content-type="leagues">
          <a href="#"><i class="icon-users-1 icn"></i>My Leagues</a>
      </li>
      <li content-type="leadboard">
          <a href="#"><i class="icon-users-1 icn"></i>Leader Board</a>
      </li>
      <li content-type="livescore">
          <a href="#"><i class="icon-info-circled icn"></i>Livescore</a>
      </li>
      <li content-type="account">
          <a href="#"><i class="icon-user icn"></i>My Account</a>
      </li>
    </ul>
  </nav>
  <!-- /.menu -->
  
  <div class="box box-border pull-left">
    <div class="light-wrapper">
      <div id="mainContainer" class="container inner">
             
      </div>
      <!--/.container--> 
    </div>
    <!--/.light-wrapper-->
    
    <!-- /footer -->
    
    <div class="subfooter">
      <div class="container inner">
        <p class="pull-left">© <script language="JavaScript" type="text/javascript"> 
                                   now = new Date
                                   theYear = now.getYear()
                                   if (theYear < 1900)
                                       theYear = theYear + 1900
                                   document.write(theYear)
                               </script> Football Clans. All rights reserved.</p>
        <ul class="social pull-right">
          <li><a href="#"><i class="icon-s-rss"></i></a></li>
          <li><a href="#"><i class="icon-s-twitter"></i></a></li>
          <li><a href="#"><i class="icon-s-facebook"></i></a></li>
          <li><a href="#"><i class="icon-s-dribbble"></i></a></li>
          <li><a href="#"><i class="icon-s-pinterest"></i></a></li>
        </ul>
      </div>
      <!-- /.container --> 
    </div>
    <!-- /.subfooter --> 
  </div>
  <!--/.box--> 
</div>
<!--/.body-wrapper--> 
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
<script src="js/genBase.js"></script>
</body>
</html>
