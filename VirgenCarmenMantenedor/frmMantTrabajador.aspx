<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Loyout.Master" AutoEventWireup="true" CodeBehind="frmMantTrabajador.aspx.cs" Inherits="VirgenCarmenMantenedor.frmMantTrabajador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link rel="stylesheet" href="Scripts/DataTable/datatables.min.css" />
    <link rel="stylesheet" href="css/web_general.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="icon/style.css" />
    <link rel="stylesheet" href="css/mant_trabajador.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.structure.min.css" />
    <link rel="stylesheet" href="Scripts/jqueryui/jquery-ui.theme.min.css" />

    <script src="Scripts/DataTable/datatables.min.js"></script>     
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/jqueryui/jquery-ui.min.js"></script>
    <script src="Scripts/frmTrabajador_ajax.js"></script>

    <title>Mantenedor de trabajador</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row"> <!-- Filtro -->
            <div class="col-xs-12">
                <div class="box-header">
                    <h3 class="box-title" id="tituloID">Trabajadores</h3>
                </div>  

                <div class="form-group">
                    <h4 class="box-filtros">Ingrese opcion de busqueda</h4>
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">
                        <label for="" class="col-sm-2 label label-default horizontal"> Cargo </label>
                        <select id="idEstado" class="form-control horizontal">
                            <option value="">--Seleccionar--</option>                        
                        </select>
                    </div>    
                    <div class="form-group col-xs-6">    
                        <label class="col-sm-2 label label-default horizontal" for="idInput2"> Documento/Nombre </label>
                        <input type="form-control" class="form-control horizontal" id="id_lblNombres" placeholder="Ingrese Nombre o Nº documento" />
                    </div>  
                </div>

                <div class="form-group col-xs-12">
                    <div class="form-group col-xs-6">    
                        <label for="" class="col-sm-2 label label-default horizontal"> Estado </label>
                        <select id="idEstado" class="form-control horizontal">
                            <option value="">--Seleccionar--</option>                           
                        </select>  
                    </div> 

                    <div class="form-group col-xs-6">
                        <button type="submit" class="btn btn-primary" id = "id_btnBuscar"> Buscar </button>
                     </div>
                </div>   
                
                <div class="form-group">
                    <h4 class="box-filtros">Listado de trabajadores</h4>
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
                                <th scope="col">NOMBRE</th>
                                <th scope="col">DNI</th>
                                <th scope="col">DIRECCION</th>                            
                                <th scope="col">SUCURSAL</th>
                                <th scope="col">CORREO</th>
                                <th scope="col">CELULAR</th>
                                <th scope="col">CARGO</th>
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
                                <th scope="col">NOMBRE</th>
                                <th scope="col">DNI</th>
                                <th scope="col">DIRECCION</th>                            
                                <th scope="col">SUCURSAL</th>
                                <th scope="col">CORREO</th>
                                <th scope="col">CELULAR</th>
                                <th scope="col">CARGO</th>
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

        <!-- Modal-->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" > 
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">

                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#menu1">DATOS PERSONALES</a></li>
                            <li><a data-toggle="tab" href="#menu2">DATOS LABORALES</a></li>
                            <li><a data-toggle="tab" href="#menu3">CONTRATO</a></li>
                        </ul>      
                    
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                        </button>
                            <div class="form-group" id="Mmensaje">
                                 <p id="Mpmensaje"></p>
                            </div>

                        <div class="tab-content" >
                            <div id="menu1" class="tab-pane fade active in "> 

                                    <div class="row form-group col-xs-12" >
                                         <div class="col-xs-5 form-group" id="msjAlert" hidden="">                     
                                            <p id="msjAlertp"></p>
                                         </div>
                                    </div>

                                    <div class="form-group">
                                         <label for="inputName"> TIPO PERSONA </label> 
                                          <select  class="form-control" id="tipPer" >
                                              <option value="">Seleccione Tipo de Persona</option>
                                          </select> 
                                    </div>

                                    <div class="form-group">
                                         <label for="inputName"> TIPO DOCUMENTO </label> 
                                          <select  class="form-control" id="tipDoc" >
                                              <option value="">Seleccione Documento</option>
                                          </select> 
                                    </div>                                    

                                    <div class="form-group">
                                            <label for="inputName"> NUMERO DE DOCUMENTO </label> 
                                            <input type="text" class="form-control" id="docPer" maxlength="10" />   
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> NOMBRE </label> 
                                            <input type="text" class="form-control" id="nomPer"  />
                                            <input type="hidden" class="form-control" id="nom_User" disabled="disabled"/> 
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> APELLIDO PATERNO </label> 
                                            <input type="text" class="form-control" id="appPer"  />
                                            <input type="hidden" class="form-control" id="app_Per" disabled="disabled"/> 
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> APELLIDO PATERNO </label> 
                                            <input type="text" class="form-control" id="apmPer"  />
                                            <input type="hidden" class="form-control" id="apm_Per" disabled="disabled"/> 
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> FECHA DE NACIMIENTO</label> 
                                            <input type="date" class="form-control" id="fecPer"  />
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> ESTADO CIVIL </label> 
                                            <select  class="form-control" id="etcPer" >
                                                <option value="">Seleccione Estado Civil</option>
                                            </select> 
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> DIRECCION </label> 
                                            <input type="text" class="form-control" id="dirPer"  />
                                            <input type="hidden" class="form-control" id="dir_Per" disabled="disabled"/>
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> EMAIL </label> 
                                            <input type="text" class="form-control" id="emaPer"  />
                                            <input type="hidden" class="form-control" id="ema_Per" disabled="disabled"/>
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> ASIGNACION FAMILIAR </label> 
                                            <select  class="form-control" id="asfPer" >
                                                <option value="">Seleccione Estado</option>
                                            </select> 
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> TELEFONO </label> 
                                            <input type="text" class="form-control" id="telPer"  />
                                            <input type="hidden" class="form-control" id="tel_Per" disabled="disabled"/>
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> CELULAR </label> 
                                            <input type="text" class="form-control" id="celPer"  />
                                            <input type="hidden" class="form-control" id="cel_Per" disabled="disabled"/>
                                    </div>

                                    <div class="form-group">
                                            <label for="inputName"> RUC </label> 
                                            <input type="text" class="form-control" id="rucPer" maxlength="11" />   
                                    </div>
                             </div>

                             <div id="menu2" class="tab-pane fade">                        
                                    <div class="form-group">
                                        <label for="inputName"> AREA  </label> 
                                        <select  class="form-control" id="areaTrab" >
                                            <option value="">Seleccione Area</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> TIPO TRABAJADOR  </label> 
                                        <select  class="form-control" id="tipoTrab" >
                                            <option value="">Seleccione Tipo de Trabajador</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> ESTADO TRABAJADOR  </label> 
                                        <select  class="form-control" id="estaTrab" >
                                            <option value="">Seleccione Estado</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> CARGO  </label> 
                                        <select  class="form-control" id="cargTrab" >
                                            <option value="">Seleccione Cargo</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> FORMA DE PAGO  </label> 
                                        <select  class="form-control" id="fpagTrab" >
                                            <option value="">Seleccione Forma de Pago</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> NUMERO DE CUENTA </label> 
                                        <input type="text" class="form-control" id="ncueTrab"  />
                                        <input type="hidden" class="form-control" id="ncue_Trab" disabled="disabled"/> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> TIPO DE REGIMEN </label> 
                                        <select  class="form-control" id="tregTrab" >
                                            <option value="">Seleccione Tipo</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> REGIMEN PENSIONARIO </label> 
                                        <select  class="form-control" id="rpenTrab" >
                                            <option value="">Seleccione Entidad</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> INICIO DE REGIMEN PENSIONARIO  </label> 
                                        <input type="date" class="form-control" id="irpeTrab"  />
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> BANCO DE REMUNERACION  </label> 
                                        <select  class="form-control" id="bremTrab" >
                                            <option value="">Seleccione Entidad Bancaria</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> ESTADO PLANILLA  </label> 
                                        <select  class="form-control" id="eplaTrab" >
                                            <option value="">Seleccione Estado</option>
                                        </select> 
                                    </div>
                              </div>

                             <div id="menu3" class="tab-pane fade"> 
                                    <div class="form-group">
                                        <label for="inputName"> MODALIDAD DE CONTRATRO  </label> 
                                        <select  class="form-control" id="modcTrab" >
                                            <option value="">Seleccione Modalidad</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> PERIODICIDAD  </label> 
                                        <select  class="form-control" id="periTrab" >
                                            <option value="">Seleccione Periodo</option>
                                        </select> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> INICIO DE CONTRATRO  </label> 
                                        <input type="date" class="form-control" id="inicTrab"  /> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> FIN DE CONTRATRO  </label> 
                                        <input type="date" class="form-control" id="fincTrab"  /> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> FECHA DE INGRESO A TRABAJAR  </label> 
                                        <input type="date" class="form-control" id="finiTrab"  /> 
                                    </div>

                                    <div class="form-group">
                                        <label for="inputName"> SUELDO  </label> 
                                        <input type="text" class="form-control" id="suelTrab"  />
                                        <input type="hidden" class="form-control" id="suel_Trab" disabled="disabled"/> 
                                    </div>
                              </div>

                              <div class="modal-footer">
                                         <button type="submit" class="btn btn-primary" id="btnGuardar">Guardar</button>
                                         <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCancelar">Cancelar</button>                                      
                              </div>  
                        </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
