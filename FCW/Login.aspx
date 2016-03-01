<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FCW.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Football Clan Login</title>

    <link href="style/css/bslogin.css" rel="stylesheet" />
    <link href="style/css/settings.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" />
    <style>
        img.logo {
            margin-bottom: 30px;
        }

        .alert-danger,
        .alert-error {
            background-color: #f2dede;
            border-color: #eed3d7;
            color: #b94a48;
        }

            .alert-danger h4,
            .alert-error h4 {
                color: #b94a48;
            }

        .modal-dialog {
            width: 768px;
            margin: 30px auto;
        }

        .alert-success {
            background-color: #dff0d8;
            border-color: #d6e9c6;
            color: #468847;
        }
    </style>
</head>
<body>
    <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row">
                    <div class="col-xs-12">
                        <img src="style/images/logo.png" class="logo" alt="" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <div class="well">
                            <p class="lead">Login and play</p>
                            <div class="form-group">
                                <label for="username" class="control-label">Username</label>
                                <input type="text" class="form-control" id="username" name="username" value="" required="" title="Please enter you username" placeholder="example@gmail.com" />
                                <span id="userError" class="help-block"></span>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Password</label>
                                <input type="password" class="form-control" id="password" name="password" value="" required="" title="Please enter your password" />
                                <span id="passError" class="help-block"></span>
                            </div>
                            <div id="loginErrorMsg" class="alert alert-error hide">Wrong username or password</div>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" name="remember" id="remember" />
                                    Remember login
                                </label>
                                <p class="help-block">(if this is a private computer)</p>
                            </div>
                            <button type="submit" id="btnLogin" class="btn btn-success btn-block">Login</button>
                        </div>
                    </div>
                    <div class="col-xs-6">
                        <div class="well" id="regForm">
                            <p class="lead">Register now for <span class="text-success">FREE</span></p>
                            <div class="form-group">
                                <label for="regUsername" class="control-label">Username</label>
                                <input type="text" class="form-control" id="regUsername"
                                    name="regUsername" value="" required="" title="Please enter your new username"
                                    placeholder="username" />
                            </div>
                            <div class="form-group">
                                <label for="regEmail" class="control-label">E-mail</label>
                                <input type="text" class="form-control" id="regEmail"
                                    name="regEmail" value="" required="" title="Please enter your email"
                                    placeholder="e-mail" />
                            </div>
                            <div class="form-group">
                                <label for="regPassword" class="control-label">Choose a password</label>
                                <input type="password" class="form-control" id="regPassword"
                                    name="regPassword" value="" required="" title="Choose a password"
                                    placeholder="" />
                            </div>
                            <div class="form-group">
                                <label for="regConfirmPassword" class="control-label">Confirm password</label>
                                <input type="password" class="form-control" id="regConfirmPassword"
                                    name="regConfirmPassword" value="" required="" title="Confirm your password"
                                    placeholder="" />
                            </div>
                            <!--ul class="list-unstyled" style="line-height: 2">
                          <li><span class="fa fa-check text-success"></span> Have a unique playing experience</li>
                          <li><span class="fa fa-check text-success"></span> Play with your friends</li>
                          <li><span class="fa fa-check text-success"></span> New gaiming concept</li>
                          <li><span class="fa fa-check text-success"></span> Real everyday football matches</li>
                          <li><span class="fa fa-check text-success"></span> All the leagues</li>
                          <li><a href="#"><u>Learn more</u></a></li>
                      </ul -->
                            <p><a href="#" id="btnRegister" class="btn btn-info btn-block">Register now!</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="style/js/jquery.js"></script>
    <script src="style/js/bootstrap.min.js"></script>
    <script src="js/prototype.js"></script>
    <script src="style/js/login.js"></script>
</body>
</html>
