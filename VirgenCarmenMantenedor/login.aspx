<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VirgenCarmenMantenedor.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login-Sistema de ventas</title>
    <link href="css/login.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />    
    <link href="css/alertify.min.css" rel="stylesheet" />
    <script src="JavaScript/jquery.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script src="Scripts/alertify.min.js"></script>
    <script src="Scripts/frmLogin.js"></script>
</head>
<body>
    <div class="container-fluid desktop">
        <div class="panel">            
            <div class="contener-formulario">
                <div class="izquierda">
                    <img src="imagenes/logo.jpg" class="imagen" alt="logo_virgen_del_carmen"/>   
               </div>
               <div class="derecha">
                     <!-- ESTE SERA EL TITULO GENERAL DEL MANTENEDOR -->
 
                        <div class="box-header">
                            <h3 class="box-title">SISTEMA DE VENTAS </h3>
                        </div>

                        <!-- ESTE SERA EL SUB TITULO GENERAL DE LO QUE SE QUIERE HACER -->
                        <div class="form-group subtitulo">
                            <h4 class="box-filtros">Virgen del carmen</h4>
                        </div>
                            <!-- -----         --->

                        <!-- Formulario Vertical-->
                        <form class="formulario" id="form">
                            <div class="form-group">
                                <label class="col-sm-2 label label-default"  for="exampleInputEmail1">Sucursal</label>
                               <select id="sucursal" class="form-control">
                                   <option value="0">-SELECCIONE SUCURSAL-</option>
                               </select>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 label label-default"  for="exampleInputEmail1">Usuario</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" placeholder="Email" />
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 label label-default"  for="exampleInputPassword1">Password</label>
                                <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" />
                            </div>
                            <!-- Botones -->
                        <div class="form-group class botones">
                                <button type="button" class="btn btn-success btn-block" id="ingresar">Ingresar</button>
                                <button type="button" class="btn btn-primary btn-block" id="recuperarCont">Recuperar contraseña</button>
                        </div>
                         
                        </form>
                                   
               </div>
                
            </div>
        </div>
    </div>
</body>
</html>
