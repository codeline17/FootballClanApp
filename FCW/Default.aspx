﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FCW.Default" %>

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
            <div class="span4 logo pull-left">
                <a href="#">
                    <img src="style/images/logo.png" /></a>
            </div>
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
                <li content-type="unlock">
                    <a class="meanclose"><i class="icon-lock-open-1 icn"></i>Unlocks</a>
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
                    <p class="pull-left">
                        ©
                        <script type="text/javascript">
                            now = new Date;
                            theYear = now.getYear();
                            if (theYear < 1900)
                                theYear = theYear + 1900;
                            document.write(theYear);
                        </script>
                        Football Clans. All rights reserved.
                    </p>
                    <ul class="social pull-right">
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
    <script id="RulesLiteral" type="text/plain">
        <h5>Joninig the game</h5>
        <p>To join the game of FootballClans you must have registered and obtained a username and</p>
        <p>pasword. After this process you must fill your profile and choose your avatar to represent you.</p>
        <h5>Predicting the games</h5>
        <p>All the games in today&rsquo;s tab that are coloured in light green colour are available for prediction.</p>
        <p>You can predict games up to 5 minutes before the official start time of every match. Users have</p>
        <p>option to predict who wins out of the daily matches.</p>
        <p>Users that want to predict more can unlock other types of predictions and &lsquo;extra daily&rsquo; matches.</p>
        <p>You can change your predictions up to 5 minutes before match start for every single match.</p>
        <h5>Winning points</h5>
        <p>After every succesful match prediction there are points given according to FootballClans</p>
        <p>regulation. With these points you compete in Competitions and win prizes. Users points are</p>
        <p>never reduced they just keep growing. This is a proPositive game so users unsuccessful</p>
        <p>predictions do not reduce points they just equal to 0, instead unsuccesful predictions do</p>
        <p>influence the form bar. (please see Managing &lsquo;My Details&rsquo; )</p>
        <p>For every win/draw/loose prediction  5 points</p>
        <p>For every over/under prediction  4 points</p>
        <p>For every Total Goals prediction  7 points</p>
        <p>For every Exact Score  12 points</p>
        <p>For guessing player who will score  5 points</p>
        <p>Bonus points: during special matches like champions leagues or competitions like the Euro2016,</p>
        <p>FootballClans might choose to offer 2 times or 3 times more points. Meaning that the points</p>
        <p>users accumulate will be 2 or 3 times more than the above for every correct prediction.</p>
        <h5>Winning Balls</h5>
        <p>Balls are used to unlock unlockables and to aquire players in other stages of the game. There</p>
        <p>are 2 types of Balls, &lsquo;GoldenBalls&rsquo; and &lsquo;Footballs&rsquo;</p>
        <p>GoldenBalls are won in 2 ways:</p>
        <p>1) Every 250 points you get one GoldenBall</p>
        <p>2) Every 100 Footballs you get 1 GoldenBall</p>
        <p>Footballs are won in 2 ways.</p>
        <p>1) for every correct prediction you get one Football</p>
        <p>2) For every time you predict 4/4 predictions in one game right you get 50 Footballs</p>
        <h5>Creating Clan</h5>
        <p>All users can create their own clan. Clan size must be from 1 to 11 a full squad size. Users can</p>
        <p>create open clans where everyone can join or private clans where joining requests need</p>
        <p>approval by clan Captain.</p>
        <p>You can invite friends to your clan or friend can send a joining request.</p>
        <p>Clan Captain is the person that creates the clan, he/she can choose wheather to accept/reject</p>
        <p>keep/throw out users in the clan. In case this person decides to leave the clan all the Captain</p>
        <p>bedge will go to the person second in global rank or &lsquo;vice Captain&rsquo;.</p>
        <h5>Partecipating in Competitions</h5>
        <p>All users are automatically registered in open competitions. All points users win during the</p>
        <p>competition period reflect in the competition points ranking of a single user, whereas all</p>
        <p>individually accumulated points of users in a clan for the competition period reflect the clan</p>
        <p>competition points ranking. There are different kind of competitions for more please see</p>
        <p>information about competitions on Leagues menu on our website.</p>
        <p>If users tie in points during a competition there is an automatic formula calculating the winner</p>
        <p>and all users must accept FootballClans decision as final.</p>
        <h5>Managing &lsquo;My Details&rsquo;</h5>
        <p>The &lsquo;My Details&rsquo; tab is automatically genereated acording to users performance. The more</p>
        <p>points and correct predictions the user gets the better the &lsquo;my details&rsquo; tab will look.</p>
        <p>Form: is related to user performance in the last 30 days. Its a complicated formulae that shows</p>
        <p>to user and to other users how your prediction form has been in the last 30 days. It users</p>
        <p>predict correctly 50% of matches they are in 100% form.</p>
        <p>Level: level is measured according to how much users have played. Every 500 predictions level</p>
        <p>goes up and so on, it is not neccesary to be a correct prediction for level to go up. For every</p>
        <p>prediction users make regardless of the result the level counter is on. FootballClans stats show</p>
        <p>that a regular user should get leveled up every 15-20 days.</p>
        <p>Global Rank: Global Rank is the current rank in the clobal measurement. The best performers</p>
        <p>will be top in global leaderboards.</p>
        <p>Clan Rank: is the global rank of the clan you are registered to.</p>
        <p>Favourites: is a tab where users direcrtly compete with their favourite friends. Users must find</p>
        <p>their friends in the global rank and STAR them so that htey appear in the Favpurites tab.</p>
        <p>Trophies: is a Trophy closet filled with trophies of different leagues user win during their playing</p>
    </script>

    <script id="TermsAndConditionsLiteral" type="text/plain">
        <p>By agreeing to register in the FootballClans game governed by these terms and conditions and the Game Rules you agree to be bound by and to abide by the following terms and conditions.</p>
        <h5>Applications and Registration</h5>
        <ol>
            <li>Applications to participate in the Game must be made online on the FootballClans website at <a href="http://www.premierleague.com/" onclick="__gaTracker('send', 'event', 'outbound-article', 'http://www.premierleague.com/', 'www.FootballClans.com');">www.FootballClans.com</a> (“the WebSite”) and strictly in accordance with the relevant instructions. Where your application is accepted, you will become known as a ‘USER’ in the terms below.</li>
            <li>Entry into the Game is open to residents from all countries. Employees (and their immediate families) of football players and football teams are ineligible to win any prizes. If such person would win a prize, it shall be awarded to the next placed Player. Please see terms 31-35 if you are under 18 years of age, as these are extra terms which will apply to you when playing the Game.</li>
            <li>No purchase of any item or service is necessary in order to enter the Game and no payment is required from you to enter the Game. The sole consideration required from you is that you agree to be bound by these terms and conditions and by the Game Rules as defined below at terms 10-11.</li>
            <li>Entries must not be submitted by agents or third parties. No responsibility can be accepted for lost, delayed or incomplete entries or entries not received by FootballClans for any reason. Any such entries will be deemed void.</li>
            <li>While there is no limit on the number of entries per household or organization only one entry in respect of the Game per unique registered user of the Site is permitted.</li>
            <li>FootballClans reserves the right to suspend and delete teams or leagues that contain team names or league names which are deemed to be inappropriate or offensive. Depending on the seriousness of the situation, the user’s account may be deleted in its entirety without notice.</li>
            <li>Any personal information which you submit will be controlled in accordance with FootballClans privacy policy and legislation governing the same. For the avoidance of doubt, we will not disclose your personal information to any other Player unless we are required to do so by a competent authority or court within the European Union</li>
            <li>All users entering the Game are subject to their accounts being automatically entered into “Free Competitions”. FootballClans may choose to offer a prize to the overall winner/winners of such competitions. The nature of the prizes are to the sole discretion of FootballClans and are explained in competition prizes section of the game. There is no opt-out from a Competition but participation in no way obligates the Player to receive marketing communications from the the game unless otherwise indicated during Registration.</li>
            <li>FootballClans doesn’t condone users setting up/joining private competitions charging for entry and cannot be held responsible for their management or any loss suffered through users’ involvement.</li>
        </ol>
        <p><strong>The Game Rules</strong></p>
        <ol start="10">
            <li>The Game will be governed by the Game Rules from time to time published on the Site by FootballClans (“Game Rules”). FootballClans reserves the right to alter, amend or supplement the Game Rules from time to time in its absolute discretion in the event of any circumstances beyond its reasonable control arising or where it considers it desirable to do so. You agree that no liability shall attach FootballClans as a result of any such change and so are advised to check the Game Rules regularly from time to time. The Game Rules form part of these terms and conditions.</li>
            <li>FootballClans will be the sole decision-maker of any matter of interpretation of the Game Rules and any aspect of the content of, or playing of, the Game. FootbaClans will not enter into correspondence relating to such matters and its decision as to any matter arising out of or in connection with the Game Rules including but not limited to the allocation of points to any Player and/or the award of any Prize and/or any ranking or league table shall be final and conclusive.</li>
        </ol>
        <p>&nbsp;</p>
        <h5>Prizes and Winner’s</h5>
        <ol start="12">
            <li>The prizes awarded in respect of the Game (“Prizes”) will be at the discretion of FootballClans from time to time and FootballClans reserves the right to alter and amend the Prizes where circumstances beyond its reasonable control require it to do so.</li>
            <li>All the Prizes (“Winner’s Prize”) will be awarded to the Player who according to FootballClans determination is at the top of the leaderboard of the competition at the end of the duration of a competition. Proof of age will be required for the Winner’s Prize.</li>
            <li>Subject to any unforeseen changes, all the Winner’s Prizes will be listed in the Prize Section (for every competition) and they will not change after the competition has started. The Winner’s Prizes with trips include travel and hotel accommodation on a minimum 3 Stars hotel.</li>
            <li>The Yearly Prizes will be awarded to the Player who according to the FootballClans’s determination is at the top of the yearly leaderboard published by the game at the end of each year period. The exact timing of this is at the discretion of the FootballClans Administration.</li>
            <li>If more than one player is equal points at the top winning positions of the competitions, then the winner will be chosen at random by a computer-generated, independent process. FootballClans decision will be final and no correspondence will be entered into.</li>
            <li>The Golden Ball Competition will be awarded to the Player who according to FootballClans determination wins the most points at the end of the season.</li>
            <li>Prizes are not transferable and are non-exchangeable and no cash alternative will be offered in any circumstances.</li>
            <li>Winners will be notified of their success by email in respect of the Monthly Prizes before the 10th day of the month following the month in respect of which such Prize is awarded.</li>
            <li>The winners’ names will be published on the Site before the 10th day of the month following the month in respect of which the Monthly Prize is awarded in respect of winners of Monthly Prizes</li>
            <li>Subject always to term 34, Players’ names and addresses and the winners’ photographic images and their comments relating to any Prize may be used without limitation for future promotional, marketing and publicity purposes of FootballClans in any and all media worldwide without notice to them and without any fee being paid.</li>
            <li>If you are under 18, then the above Prizes information will apply differently to you should you win a Prize. Please see terms 31-35 below.</li>
        </ol>
        <p>&nbsp;</p>
        <h5>Message Boards</h5>
        <ol start="23">
            <li>Through the Game, FootballClans is seeking to facilitate a self-moderated discussion group and message board facility for football fans. FootballClans does not pre-screen any content posted or disseminated through the message boards.</li>
            <li>Because the message boards are self-moderated, you should understand that when using the Game, you might come across some content which you find offensive or objectionable. If you do come across such content then you are free to register a complaint in relation to this. You should note that the views expressed on message boards are the views of the individual concerned, which may be different to those of the FootballClans.</li>
            <li>If you post any message on a message board then you are confirming that:
                <ul>
                    <li>Message includes nothing which would be a breach of these terms;</li>
                    <li>Message is non-confidential and non-proprietary and that the Premier League may make use of that message in any way it sees fit and without acknowledgement; and</li>
                    <li>Users of the message board may access the message on terms similar to these.</li>
                </ul>
            </li>
        </ol>
        <p>If you wish to restrict the use of any message, then you are advised not to submit it.</p>
        <ol start="26">
            <li>You are entirely responsible for any messages which you post. You shall be entirely responsible for any losses that FootballClans, or any other users may suffer as a result of any messages you post, or otherwise as a result of your use of the Game.</li>
            <li>Generally, you must ensure that you only use the message boards in order to post messages which are (in the reasonable opinion of FootballClans) legal, decent, proper and relevant.</li>
            <li>By way of example, and without limiting your obligation under term 25, you must ensure that you:
                <ul>
                    <li>comply with any instructions from FootballClans;</li>
                    <li>do not defame, threaten, harass, abuse, or otherwise violate the rights of others (whether they are users of FootballClans or not);</li>
                    <li>do not post messages which are unlawful, defamatory, obscene, objectionable, or inappropriate;</li>
                    <li>do not bring FootballClans or any member Club of FootballClans, or the game of football into disrepute;</li>
                    <li>do not promote or provide unlawful instructions to others;</li>
                    <li>do not post any messages which could interfere with the intellectual property rights or confidential information of others;</li>
                    <li>do not post messages containing commercial messages or advertising;</li>
                    <li>do not impersonate anyone else;</li>
                    <li>do not use the message boards to harvest personal information about others;</li>
                    <li>do not contain personal information of others in any messages, unless that use is lawful, or you have their consent; and</li>
                    <li>do not transmit any viruses or other harmful code.</li>
                </ul>
            </li>
        </ol>
        <p>Please note that FootballClans will seek to use these terms to prohibit all such behavior. However, FootballClans cannot guarantee that you will not be exposed to such behavior. If you should encounter it, please feel free to make a complaint accordingly by emailing support@football-clans.com</p>
        <ol start="29">
            <li>FootballClans advises that you exercise caution in revealing any personal information about yourself on any message boards.</li>
            <li>FootballClans reserves the right at any time and for any reason to:
                <ul>
                    <li>temporarily or permanently suspend your access to the message boards;</li>
                    <li>delete any of your messages;</li>
                    <li>require any of your future messages to be pre-vetted;</li>
                    <li>take any other action against your account as it sees fit.</li>
                </ul>
            </li>
        </ol>
        <p>&nbsp;</p>
        <h5>Applicants Under 18 Years of Age</h5>
        <ol start="31">
            <li>If you are under 18 years of age, then you are welcome to enter the Game, but you should carefully read these terms, and ensure that your parent or responsible guardian also does so, before submitting your application.</li>
            <li>You will be eligible to win the Monthly Prizes provided:
                <ul>
                    <li>that they do not contain cash, and they will in no circumstances be substituted for cash; and</li>
                    <li>we receive a note of written consent from your parent or guardian confirming that they were happy for you to play the Game and to receive the Prize.</li>
                </ul>
            </li>
            <li>You will only be eligible for the Winner’s Prize if we receive a note of written consent from your parent or guardian confirming that:
                <ul>
                    <li>they were happy for you to play the Game;</li>
                    <li>that they are happy for you to receive the winner’s Prize; and</li>
                    <li>they will accompany you at all times on the trip.</li>
                </ul>
            </li>
            <li>If you do win a Prize, and if FootballClans wishes to use any comments, details, or photographs of you, then we will always seek the express written consent of your parent or guardian before doing so.</li>
            <li>If when using the message boards you feel at any time harassed, distressed, or bullied by any of the messages, please immediately email <a href="mailto:support@mail.fantasy.premierleague.com">support@football-clans.com</a> and also inform your parent or guardian.</li>
        </ol>
        <p>&nbsp;</p>
        <h5>Responsibility and Remedies</h5>
        <ol start="36">
            <li>The extent of FootballClans responsibility to you has been determined in the context of the following:
                <ul>
                    <li>the Game is provided to you free of charge;</li>
                    <li>message boards are not checked or verified by FootballClans;</li>
                    <li>you are responsible for any action you do or do not take as a result of the Game and the information therein;</li>
                    <li>you are responsible for ensuring that your equipment is enabled with appropriate up-to-date virus checking software.</li>
                </ul>
            </li>
            <li>While FootballClans will do all possible to ensure that the Game is available to you at all times and that the contents are correct and accurate, it cannot make any legal commitment to you that this will be the case. However, FootballClans will exercise reasonable skill and care in providing any service to you.</li>
            <li>FootballClans cannot accept any liability to you for any of the following types of loss which you may suffer as a result of your entry to the Game:
                <ul>
                    <li>loss which was not foreseeable to you and FootballClans when you first applied for the Game (even if that loss results from FootballClans failure to comply with these terms or its negligence);</li>
                    <li>any business loss you may suffer, including loss of revenue, profits, or anticipated savings (whether those losses are the direct or indirect result of FootballClans default);</li>
                    <li>loss which you suffer other than as a result of our failure to comply with these terms or our negligence or breach of statutory duty;</li>
                    <li>any loss which you may suffer as a result of or in connection with or arising out of any Prize.</li>
                </ul>
            </li>
            <li>Nothing in these terms will limit FootballClans liability for death or personal injury arising from its negligence or if they deliberately lied to you before you entered.</li>
            <li>Any breach by you of the Game Rules from time to time shall also be a breach of these terms and conditions.</li>
            <li>In the event of any breach by you of these terms and conditions FootballClans reserves the right to:
                <ul>
                    <li>take any action described in terms above;</li>
                    <li>refuse entry to the Game;</li>
                    <li>disqualify you from the Game;</li>
                    <li>require any reasonable amendment to your application or entry.</li>
                </ul>
            </li>
        </ol>
        <p>If you are barred or disqualified from entry, you shall not be eligible to participate in the Game under any other identity or team name. Any such decision by FootballClans shall be final.</p>
        <ol start="42">
            <li>If any of these terms are determined to be illegal, invalid, or otherwise enforceable then the remaining terms shall continue in full force and effect.</li>
            <li>These terms and conditions shall be governed by and construed in accordance with the laws of European Union and the parties agree to submit to the exclusive jurisdiction of the Courts of European Union member countries.</li>
        </ol>
    </script>

    <script id="PrizesLiteral" type="text/plain">
        <h5>Euro 2016 individual</h5>
        <p>Position 200-101 -&gt; 50 golden balls</p>
        <p>Position 100 - 51 -&gt; Smartphone Cases + 60 golden balls</p>
        <p>Position 50 &ndash; 26 -&gt; FootballClans Bracelets + 80 golden balls</p>
        <p>Position 25 - 21 -&gt; Euro2016 winner Football Jearsey + 90 golden balls</p>
        <p>Position 20 &ndash; 11 -&gt; Original ADIDAS Euro2016 Ball + 100 golden balls</p>
        <p>Position 10 &ndash; 4 -&gt; Portable Media Player + 100 golden balls</p>
        <p>Position 5 &ndash; 4 -&gt; Footballclans Golden Bracelet in real gold+ 150 golden balls</p>
        <p>Position 3 -&gt; Smartphone + 100 golden balls</p>
        <p>Position 2 -&gt; 2 European Super Cup Final, Tickets, traveling + accommodation included + 150</p>
        <p>golden balls</p>
        <p>Position 1 -&gt; a REAL GOLDEN BALL + 200 golden balls</p>
        <h5>Euro 2016 clans</h5>
        <p>Clan 50 &ndash; 31 -&gt; Euro2016 Winner HATS + 50 golden balls</p>
        <p>Clan 30 &ndash; 11 -&gt; Stylish Footballclans Bracelets + 60 golden balls</p>
        <p>Clan 10 &ndash; 4 -&gt; Footballclans Golden Bracelet + 80 golden balls</p>
        <p>Clan 3 -&gt; Original ADIDAS Euro2016 Ball + 100 golden balls</p>
        <p>Clan 2 -&gt; Smartphone + 100 golden balls</p>
        <p>Clan 1 -&gt; a Wonderful GREEK ISLAND Vacation EXPERIENCE, accommodation + travel + 200</p>
        <p>golden balls</p>
        <h5>Weekly single league WSL</h5>
        <p>Usually during Champions League period we will launch intense weekly leagues&hellip; These</p>
        <p>leagues will last for 7 days and they will dispose prizes as below:</p>
        <p>Position 25 - 16 -&gt; 15 golden balls</p>
        <p>Position 15 &ndash; 11 -&gt; Smartphones Cases + 15 golden balls</p>
        <p>Position 10 &ndash; 6 -&gt; Football Jearsey + 15 golden balls</p>
        <p>Position 5 &ndash; 3 -&gt; Football Shoes + 20 golden balls</p>
        <p>Position 2 -&gt; Smartphone + 25 golden balls</p>
        <p>Position 1 -&gt; Tablet + 35 golden balls</p>
        <h5>Monthly single league MSL</h5>
        <p>Every month From August to June there will be a monthly League starting on the 1st of the</p>
        <p>month and ending on the last day of the month.</p>
        <p>People who accumulate most points during this period will win prizes as below:</p>
        <p>Position 40 &ndash; 26 -&gt; 10 golden balls</p>
        <p>Position 25 - 16 -&gt; 15 golden balls</p>
        <p>Position 15 &ndash; 11 -&gt; Smartphone cases + 20 golden balls</p>
        <p>Position 10 &ndash; 6 -&gt; Football Jearsey + 25 golden balls</p>
        <p>Position 5 &ndash; 4 -&gt; Football Shoes + 30 golden balls</p>
        <p>Position 3 -&gt; Smartphone + 35 golden balls</p>
        <p>Position 2 -&gt; Tablet + 40 golden balls</p>
        <p>Position 1 -&gt; Notebook + 50 goldeballs</p>
        <h5>Season single leagues SSL</h5>
        <p>Every season starting from 1st of August until 31st of June there will be a season League which</p>
        <p>every user will be automatically registered.</p>
        <p>Whoever accumulates the most points during this period will be winner of the SEASON. The</p>
        <p>Season winner will receive high publicity and will receive a REAL GOLDEN BALL: All other</p>
        <p>players will get prizes as below:</p>
        <p>Position 200-101 -&gt; 50 golden balls</p>
        <p>Position 100 - 51 -&gt; Smartphone Cases + 60 golden balls</p>
        <p>Position 50 &ndash; 41 -&gt; HATS + 70 golden balls</p>
        <p>Position 40 &ndash; 26 -&gt; Bracelets + 80 golden balls</p>
        <p>Position 25 - 21 -&gt; Football Jearsey + 90 golden balls</p>
        <p>Position 20 &ndash; 16 -&gt; Original Champions League Football + 100 golden balls</p>
        <p>Position 15 &ndash; 11 -&gt; Football Shoes + 100 golden balls</p>
        <p>Position 10 &ndash; 6 -&gt; Smartphone + 100 golden balls</p>
        <p>Position 5 &ndash; 4 -&gt; Footballclans Golden Bracelet + 150 golden balls</p>
        <p>Position 3 -&gt; 2 European Super Cup Final + 150 golden balls</p>
        <p>Position 2 -&gt; 2 Champions League Final Tickets + 175 golden balls</p>
        <p>Position 1 -&gt; a REAL GOLDEN BALL, more than 1.5 KG in Pure Gold + 200 golden balls</p>
        <p>Clan league prizes</p>
        <h5>Season clan leagues SSL</h5>
        <p>This league lasts about 3 months and is a long clan competition for who gets to be the best clan</p>
        <p>on the Game&hellip; The Points accumulated from all players of the clan will be summed together to</p>
        <p>make clan points&hellip;</p>
        <p>Coalition with your friends in this competition in order to become the best Clan and win fantastic</p>
        <p>prizes below:</p>
        <p>Clan 50 &ndash; 41 -&gt; HATS + 50 golden balls</p>
        <p>Clan 40 &ndash; 21 -&gt; Stylish Bracelets + 60 golden balls</p>
        <p>Clan 20 - 11 -&gt; Favourite Team Football Jearsey + 70 golden balls</p>
        <p>Clan 10 &ndash; 4 -&gt; Footballclans Golden Bracelet + 80 golden balls</p>
        <p>Clan 3 - 2 -&gt; Smartphone + 100 golden balls</p>
        <p>Clan 1 -&gt; a Wonderful IBIZA Vacation EXPERIENCE + 200 golden balls</p>
        <h5>Yearly clan competition YCC</h5>
        <p>Clan 200 &ndash;51 -&gt; 70 golden balls</p>
        <p>Clan 50 &ndash; 41 -&gt; HATS + 50 golden balls</p>
        <p>Clan 40 &ndash; 26 -&gt; Stylish Bracelets + 60 golden balls</p>
        <p>Clan 25 - 16 -&gt; Favourite Team Football Jearsey + 70 golden balls</p>
        <p>Clan 15 &ndash; 6 -&gt; Footballclans Golden Bracelet + 80 golden balls</p>
        <p>Clan 5 - 4 -&gt; Smartphone + 100 golden balls</p>
        <p>Clan 3 - 1 -&gt; a Wonderful Vacation EXPERIENCE + 200 golden balls</p>
    </script>

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
    <script src="js/settings.js"></script>
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
