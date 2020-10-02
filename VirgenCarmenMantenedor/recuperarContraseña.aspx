<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperarContraseña.aspx.cs" Inherits="VirgenCarmenMantenedor.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Recuperar Contraseña - Sistema de ventas</title>
    <link href="css/login.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />    
    <link href="css/alertify.min.css" rel="stylesheet" />
    <script src="Scripts/alertify.min.js"></script>
    <script src="JavaScript/jquery.js"></script>
    <script src="JavaScript/bootstrap.min.js"></script>
    <script src="Scripts/frmRecuperarContr.js"></script>
</head>
<body>
    <div class="container-fluid desktop">
        <div class="row">
            
            <div class="contener-formulario">
                <div class="izquierda">
                    <img src="imagenes/logo.jpg" alt="logo_virgen_del_carmen"/>   
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
                                <label class="col-sm-2 label label-default"  for="exampleInputEmail1">Usuario</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" placeholder="Usuario" />
                            </div>
                            
                            <!-- Botones -->
                        <div class="form-group class botones">
                                <button type="button" class="btn btn-success btn-block" id="ingresar">Enviar correo</button>
                                
                        </div>
                            <!-- -----         --->
                        <div class="mensajes" id="mensajes">

                        </div>
                        </form>
                                   
               </div>
                
            </div>
        </div>
    </div>
</body>
</html>
