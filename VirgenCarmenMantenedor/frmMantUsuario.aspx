<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantUsuario.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantUsuario1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="css/mant_usuario.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />
    
    <!-- <script src="Scripts/DataTable/Buttons-1.6.1/js/dataTables.buttons.min.js"></script> -->
   <!-- <script src="Scripts/DataTable/Buttons-1.6.1/js/buttons.flash.min.js"></script> -->
    <script src="Scripts/DataTable/datatables.min.js"></script>     
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/Plantilla.js"></script>
    <script src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/frmUsuario_ajax.js"></script>
    

    <title>Mantenedor de Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row"> <!-- Filtro -->
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Usuarios</h3>
                </div>  

                <div class="form-group">
                    <h4 class="box-filtros">Ingrese opcion de busquedad</h4>
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">
                        <label class="col-sm-2 label label-default horizontal" for="idInput1">N° Documento </label>
                        <input type="form-control" class="form-control horizontal" id="id_lblNumDoc" placeholder="Numero de documento" disabled/>
                    </div>    
                    <div class="form-group col-xs-6">    
                        <label class="col-sm-2 label label-default horizontal" for="idInput2">Nombre/Usuario </label>
                        <input type="form-control" class="form-control horizontal" id="id_lblNombres" placeholder="Ingrese nombre, apellido materno , apellido paterno o usuario" />
                    </div>  
                </div>

            <!--   <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">    
                        <label class="col-sm-2 label label-default horizontal" for="idInput3">Usuario </label>
                        <input type="form-control" class="form-control horizontal" id="id_lblUser" placeholder="Ingrese usuario" />
                    </div>  
                </div>    --> 

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">    
                        <label for="" class="col-sm-2 label label-default horizontal">Estado </label>
                        <select id="idEstado" class="form-control horizontal">
                            <option value="">--Seleccionar--</option>
                            
                        </select>  
                    </div> 

                    <div class="form-group col-xs-6">
                        <button type="submit" class="btn btn-primary" id = "id_btnBuscar">Buscar</button>
                     </div>
                </div>   
                
                <div class="form-group">
                    <h4 class="box-filtros">Listar Usuario</h4>
                </div>

             </div>
        </div> <!-- Termina Filtro -->
        
        <div class="row">  <!-- Tabla -->
            <div class="col-xs-12"> 
                <div class="box-body table-responsive">
                    <table id="tbl_usuario" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th scope="col">COD PERSONA</th>
                                <th scope="col">COD USUARIO</th>
                                <th scope="col">NUMERO DOCUMENTO</th>
                                <th scope="col">USUARIO</th>
                                <th scope="col">COD SUCURSAL</th>                            
                                <th scope="col">SUCURSAL</th>
                                <th scope="col">NOMBRES</th>
                                <th scope="col">CORREO</th>
                                <th scope="col">CELULAR</th>
                                <th scope="col">TELEFONO</th>
                                <th scope="col">COD PERFIL</th>
                                <th scope="col">PERFIL</th>
                                <th scope="col">COD ESTADO</th>
                                <th scope="col">ESTADO</th>
                                <th scope="col">OPERACION</th>


                            </tr>
                        <!-- aqui traeremos la data por medio de ajax -->
                        </thead>

                        <tbody id="tbl_body_table" class="ui-sortable">

                        </tbody>
                        <!-- aqui traeremos la data por medio de ajax -->
                        <tfoot>
                            <tr>
                                <th scope="col">COD PERSONA</th>
                                <th scope="col">COD USUARIO</th>
                                <th scope="col">NUMERO DOCUMENTO</th>
                                <th scope="col">USUARIO</th>
                                <th scope="col">COD SUCURSAL</th>                            
                                <th scope="col">SUCURSAL</th>
                                <th scope="col">NOMBRES</th>
                                <th scope="col">CORREO</th>
                                <th scope="col">CELULAR</th>
                                <th scope="col">TELEFONO</th>
                                <th scope="col">COD PERFIL</th>
                                <th scope="col">PERFIL</th>
                                <th scope="col">COD ESTADO</th>
                                <th scope="col">ESTADO</th>
                                <th scope="col">OPERACION</th>

                            </tr>
                        </tfoot>

                    </table>
                </div>  
            </div>   
        </div> <!-- termina tabla -->

        <!---- Tigger Boton Modal Agregar-->
        <button type="submit" class="btn btn-primary" id="buttonModal" data-toggle="modal" data-target="#exampleModal">Agregar</button>
       <!--  <div class="form-group col-xs-12"> -->  
           <!--   <div class="form-group col-xs-6"> -->
         <button type="submit" class="btn btn-primary horizontal" id ="id_btnRepote">Reporte</button>
          <!-- </div>    --> 
       <!-- </div> -->
         

         <!-- Modal-->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" > 
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                            
                         <h5 class="modal-title" id="exampleModalLabel_editar">Editar Usuario</h5>
                         <h5 class="modal-title" id="exampleModalLabel_detalle">Detalle de Usuario</h5>
                         <h5 class="modal-title" id="exampleModalLabel_agregar">Agregar Usuario</h5>
                            
                        
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                         </button>
                             <div class="form-group" id="Mmensaje">
                                 <p id="Mpmensaje"></p>
                             </div>
                    </div>
                <!-- Cuerpo de mi modal editar y agregar-->  
                    <div class="modal-body"> 
                        <form role="form" onsubmit="return false;">
                            <div class="row form-group col-xs-12" >
                                <div class="col-xs-5 form-group" id="msjAlert" hidden="">
                                 <!--                        
                                     <div class="form-group" id="Mmensaje">
                                        <p id="Mpmensaje"></p>
                                    </div>    
                                    -->
                                    <p id="msjAlertp"></p>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="inputName"> DNI </label> 
                                <input type="text" class="form-control" id="dniPer" disabled="disabled" maxlength="8"  /> 
                               <!--  <input type="hidden" class="form-control" id="dniPer" disabled="disabled"/> -->

                            <div class="form-group">
                                    <label for="inputName"> Perfil </label> 
                                    <select  class="form-control" id="Perfiles" >
                                        <option value="">Seleccione un Perfil</option>
                                    </select> 
                            </div>

                            <div class="form-group">
                                    <label for="inputName"> Usuario </label> 
                                    <input type="text" class="form-control" id="nomUser"  />
                                    <input type="hidden" class="form-control" id="nom_User" disabled="disabled"/> 
                            </div>
                            <div class="form-group">
                                    <label for="inputName"> Contraseña </label>
                                        <div class="form-group">
                                            <button type="submit" class="btn btn-primary" id="btnGeneraPass">
                                                Generar  Contraseña  Aleatoria                             
                                            </button>
                                        </div>    
                                    <input type="text" class="form-control" id="pass" disabled="disabled" />
                            </div>

                            <div class="form-group">
                                <label for="inputName"> Sucursal </label> 
                                <select  class="form-control" id="id_sucursal" >
                                    <option value="">Seleccione una Sucursal</option>
                                </select> 
                            </div>

                                <div class="form-group">
                                    <label for="inputName"> Estado </label> 
                                    <select  class="form-control" id="id_Estado" >
                                        <option value="">Seleccione un Estado</option>
                                    </select> 
                                </div>
                                
                                <div class="form-group">
                                    <label for="inputName"> Nombre </label> 
                                    <input type="text" class="form-control" id="nomPer"  />
                                    <input type="hidden" class="form-control" id="nom_Per" disabled="disabled"/>
                                </div>
                                <!--
                                <div class="form-group">
                                    <label for="inputName"> Apellido M </label> 
                                    <input type="text" class="form-control" id="apellM"  />
                                    <input type="hidden" class="form-control" id="apellM" disabled="disabled"/>
                                </div>

                                <div class="form-group">
                                    <label for="inputName"> Apellido P </label> 
                                    <input type="text" class="form-control" id="apellP"  />
                                    <input type="hidden" class="form-control" id="apellP" disabled="disabled"/>
                                </div>
                             -->
                                <div class="form-group">
                                    <label for="inputName"> Telefono </label> 
                                    <input type="text" class="form-control" id="telPer" maxlength="9" />
                                   <!-- <input type="hidden" class="form-control" id="tel_Per" disabled="disabled"/> -->
                                </div>

                                <div class="form-group">
                                    <label for="inputName"> Celular </label> 
                                    <input type="text" class="form-control" id="celPer" maxlength="9" />
                                    <input type="hidden" class="form-control" id="cel_Per" disabled="disabled"/>
                                </div>

                                <div class="modal-footer">
                                    <button type="submit" class="btn btn-primary" id="btnActivar">Activar</button>
                                    <button type="submit" class="btn btn-primary" id="btnBloquear">Bloquear</button>
                                    <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>
                                    <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                                    <button type="submit" class="btn btn-primary" id="btnActualizar">Actualizar</button>
                                    
                                </div>

                        </form>
                            

                    </div>
                    <!-- Termina Cuerpo de mi modal editar y agregar-->       


                </div> 
            </div>
        </div>
        <!-- Termina cuerpo Modal-->
    </div> 
</asp:Content>
