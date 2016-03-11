<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FCW.LoginNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style/css/logincss.css" rel="stylesheet" />
    <link href="style/css/login.min.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>Football Clan Login</title>
    <style>
        img.logo {
            display: block;
            margin: auto;
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

        .alert-success {
            background-color: #dff0d8;
            border-color: #d6e9c6;
            color: #468847;
        }
    </style>
</head>
<body>
    <div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <img src="style/images/logo.png" class="logo" alt="" />
                </div>
                <div class="modal-body">
                    <div id="frmLogin" class="form col-md-12 center-block">
                        <div class="form-group">
                            <label for="username" class="control-label">Username</label>
                            <input type="text" class="form-control input-lg" id="username" name="username" value="" required="" title="Please enter you username" placeholder="example@email.com" />
                            <span id="userError" class="help-block"></span>
                        </div>
                        <div class="form-group">
                                <label for="password" class="control-label">Password</label>
                                <input type="password" class="form-control input-lg" id="password" name="password" value="" required="" title="Please enter your password" />
                                <span id="passError" class="help-block"></span>
                        </div>
                        <div class="form-group">
                            <button id="btnLogin" class="btn btn-success btn-lg btn-block">Sign In</button>
                            <br/>
                            <p class="text-center"> Not a member?</p>
                            <button id="btnGotoRegister" class="btn btn-primary btn-lg btn-block">Register</button>
                        </div>
                    </div>
                    <div id="frmRegister" class="form col-md-12 center-block hidden">
                        <div class="form-group">
                                <label for="regUsername" class="control-label">Username</label>
                                <input type="text" class="form-control input-lg" id="regUsername"
                                    name="regUsername" value="" required="" title="Please enter your new username"
                                    placeholder="username" />
                            </div>
                            <div class="form-group">
                                <label for="regEmail" class="control-label">E-mail</label>
                                <input type="text" class="form-control input-lg" id="regEmail"
                                    name="regEmail" value="" required="" title="Please enter your email"
                                    placeholder="e-mail" />
                            </div>
                            <div class="form-group">
                                <label for="regPassword" class="control-label">Choose a password</label>
                                <input type="password" class="form-control input-lg" id="regPassword"
                                    name="regPassword" value="" required="" title="Choose a password"
                                    placeholder="" />
                            </div>
                            <div class="form-group">
                                <label for="regConfirmPassword" class="control-label">Confirm password</label>
                                <input type="password" class="form-control input-lg" id="regConfirmPassword"
                                    name="regConfirmPassword" value="" required="" title="Confirm your password"
                                    placeholder="" />
                            </div>
                            <div class="form-group">
                                <input id="termsAndConditions" type="checkbox"/> I agree to the <a href="http://footballclans.com/term-conditions/" target="_new">terms and conditions</a> <br/>
                            </div>
                            <div id="regForm" class="form-group">
                                
                            </div>
                        <div class="form-group">
                            <button id="btnRegister" class="btn btn-primary btn-lg btn-block">Register</button>
                        </div>
                        <div class="form-group">
                            <button id="btnGotoLogin" class="btn btn-success btn-lg btn-block">Login</button>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="col-md-12">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="style/js/jquery.js"></script>
<script src="style/js/login.min.js"></script>
<script src="js/prototype.js"></script>
<script src="style/js/login.js"></script>
</html>
