<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="VirgenCarmenMantenedor.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/perfil.css" rel="stylesheet" />
    <link href="css/alertify.min.css" rel="stylesheet" />
    <script src="Scripts/alertify.min.js"></script>
     <script src="Scripts/perfil.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="tarjeta">
            <form  class="panel panel-default" id="formulario">
                <div class="panel-heading header">
                    <h3>Modificacion de datos</h3>
                </div>
                <div class="panel-body">                
                    <div class="datos_persona">
                        
                        <div class="form-group col-md-12">
                            <h4>Datos personales</h4>
                            <hr>
                        </div>
                        <div class="form-group col-md-12">
                            <label for="nombres">Nombres</label>
                            <input type="text" class="form-control" id="nombres" placeholder="Nombres">
                        </div>
                        <div class="form-group col-md-6">
                            <label for="app">Apellido paterno</label>
                            <input type="text" class="form-control" id="app" placeholder="Apellido paterno">
                        </div>
                        <div class="form-group col-md-6">
                            <label for="apm">Apellido materno</label>
                            <input type="text" class="form-control" id="apm" placeholder="Apellido materno">
                        </div>
                        <div class="form-group col-sm-12 col-md-6">
                            <label for="tlfn">Telefono</label>
                            <input type="text" class="form-control" id="tlfn" placeholder="Telefono">
                        </div>
                        <div class="form-group  col-sm-12 col-md-6">
                            <label for="email">Correo</label>
                            <input type="email" class="form-control" id="email" placeholder="Correo">
                        </div>
                    </div>  
                    
                    <div class="form-group col-md-12">
                        <h4>Datos de usuario</h4>
                    <hr>
                    </div>
                    <div class="datos_usuario">
                        <div class="form-group col-sm-12 col-md-6">
                            <label for="usuario">Usuario</label>
                            <input type="text" class="form-control" disabled id="usuario" placeholder="Correo">
                        </div>
                        <div class="form-group col-sm-12 col-md-6">
                            <label for="contraseñaAnterior">Contraseña anterior</label>
                            <input type="password" class="form-control" id="contraseñaAnterior" placeholder="Correo">
                        </div>
                        <div class="form-group col-sm-12 col-md-6">
                            <label for="nuevaContraseña">Nueva contraseña</label>
                            <input type="password" class="form-control" id="nuevaContraseña" placeholder="Correo">
                        </div>
                        <div class="form-group col-sm-12 col-md-6 ">
                            <label for="confirmarContraseña">ConfirmarContraseña</label>
                            <input type="password" class="form-control" id="confirmarContraseña" placeholder="confirmar contraseña">
                        </div>
                       
                    </div>
                    <div class="botonera">                        
                        <button class="btn-guardar" type="submit" id="guardar" ><span class="glyphicon glyphicon-ok"></span> Guardar cambios</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
