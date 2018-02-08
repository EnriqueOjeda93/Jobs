/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

$.controller = {};

$.controller.muestra = function(caja){
    // Para cerrar el menú cuando pulsamos una opción
    $(".navbar-collapse").collapse("hide");
    $(".panel").hide();
    $(caja).show("slow");
};


$.controller.muestra2 = function(){
    // Para cerrar el menú cuando pulsamos una opción
    $(".navbar-collapse").collapse("hide");
    $(".panel").hide();
    $("#manager").empty();
    
     $("#manager").append('<div><h3 class="titulo">Listados Alimentadores para Modificar/Borrar</h3></br></div>');
     
     for (var i = 0; i < $.canales.lista_canales.length; i++) {
        $("#manager").append('<div class="container"><div class="well"><div> '+$.canales.lista_canales[i].nombre+'\
            <div type="button" onclick="$.controller.modificarNoticia('+i+')" \n\
            class="btn btn-primary" style=background-color:green;">Modificar</div>\n\
                    \n\
                <div type="button" onclick="$.controller.borrarNoticia('+i+')" \n\
                    class="btn btn-danger" style=background-color:red;">Borrar</div></div></div></div>');
    }
        

    $("#manager").show();
};

$.controller.modificarNoticia=function(index){
   $(".navbar-collapse").collapse("hide");
    $(".panel").hide();
    $("#modificar").empty();
     $("#modificar").append('<div><h3 class="titulo" >Rellene con el nombre que desea modificar</h3></br></br></div>\n\
        <div><input type="text" class="form-control" id="nombreNuevo" placeholder="INTRODUZCA NUEVO NOMBRE"></br></br>\n\
            <div onclick="$.controller.cambiarNombre('+index+')" class="btn btn-success"> Cambiar </div></div></br></br>');
     
     $("#modificar").append('');

    $("#modificar").show();
  }
  
 
$.controller.cambiarNombre=function(index){
    
   $.canales.update(index, $("#nombreNuevo").val());  
   $.canales.save();
      //$.canales.load();
      
    $.controller.cargaCanales();
    $.controller.muestra2();
      //$("#manager").hide();
      //$("#manager").show();
  };

  

$.controller.borrarNoticia=function(index){
   $.canales.delete(index);  
   $.canales.save();
      //$.canales.load();
      
     $.controller.cargaCanales();
     $.controller.muestra2();
      //$("#manager").hide();
      //$("#manager").show();
  };

$.controller.AñadirCanalPorDefecto = function (nombre, tipo){
    // leemos del formulario y creamos el canal con esa información
    $.canal.add(nombre, tipo);
    // si el canal "funciona" lo añadimos a marcadores  
    // $.canales.create($.canal);
    $(".panel").hide();
    $("#start").show();
    
};


$.controller.addChannel = function (){
    // leemos del formulario y creamos el canal con esa información
    $.canal.add($("#nombreCanal").val(), $("#urlCanal").val());
    // si el canal "funciona" lo añadimos a marcadores  
    // $.canales.create($.canal);
    $(".panel").hide();
    $("#start").show();
    
};

$.controller.cargaCanales =  function () {
    var i=0;
    $.canales.load();
    $("#start").empty();
    $("#start").append('<h3 class="titulo2" >- Listado de los distintos canales:</h3>');
    for (i=0; i< $.canales.tam(); i++){
        // $("#start").append('<div class="col-xs-4" style=background-color:lavender;">'+$.canales.lista_canales[i].nombre+'</div>');        
        $.controller.add2rejilla(i);
    }
};

$.controller.add2rejilla = function (index) {
    $("#start").append('<div onclick="$.controller.cargaNoticias('+index+')" class="principal" ">'+$.canales.lista_canales[index].nombre+'</div>');
};

$.controller.cargaNoticias = function (index) {
    $("#news").empty();
    $("#start").hide();
    $("#news").show();
    if ($.canales.lista_canales[index].tipo==="rss") {
        $.controller.cargaRSS(index);
    } else {  
        if ($.canales.lista_canales[index].tipo==="atom") {
            $.controller.cargaATOM(index);
        }else{
            $.error.msg("Listando noticias", "Tipo de canal desconocido." );
            // ERROR tipo de canal desconocido
        }
    }
    
};


$.controller.cargaRSS =  function(index){
   // $("#news").append('<h3>RSS: '+$.canales.lista_canales[index].nombre+'</h3>');
    
 $.ajax({
        url: "http://query.yahooapis.com/v1/public/yql",
        jsonp: "callback",
        dataType: "jsonp",
        data: {
            q: "select * from rss where url=\""+$.canales.lista_canales[index].url+"\"",
            format: "json"
        },
        success: function (response) {
            // código para listar las noticias del canal RSS
             var i;
                  var caja;
                // limpiamos la caja donde van las noticias
                $("#news").empty();
                // Guardo el ARRAY de noticias de este canal
                var lista = response.query.results.item;
                
                for (i=0;i<response.query.count;i++){
                    caja = $("<div></div>");
                    caja.addClass("well well-sm");
                    caja.attr("data-title", $.canales.lista_canales[index].nombre);
                    caja.append("<h3>"+lista[i].title+"</h3><br/>");
                    
                    if (lista[i].description !== undefined){
                       
                        if(lista[i].description[1].content !== undefined){
                             caja.append("<p>"+lista[i].description[1].content+"</p>");
                        } else {
                             caja.append("<p>"+lista[i].description+"</p>");
                        }
                    }
                  
                    
                    caja.append("<p>"+lista[i].pubDate+"</p>");
                    caja.append("<p> <a href='"+lista[i].link+"'>Pulse aquí para abrir la noticia.</a></p>");
                                     
                    $("#news").append(caja);
                } 
                }  
       
    });
};

$.controller.cargaATOM = function(index){
   console.log($.canales.lista_canales[index].url);
    $.ajax({
        url: "http://query.yahooapis.com/v1/public/yql",
        jsonp: "callback",
        dataType: "jsonp",
        data: {
            q: "select * from atom where url=\""+$.canales.lista_canales[index].url+"\"",
            format: "json"
        },
        success: function (response) {
            // código para listar las noticias del canal ATOM
             var i;
                  var caja;
                // limpiamos la caja donde van las noticias
                $("#news").empty();
                // Guardo el ARRAY de noticias de este canal
                var lista = response.query.results.entry;
                
                for (i=0;i<response.query.count;i++){
                    caja = $("<div></div>");
                    caja.addClass("well well-sm");
                    caja.attr("data-title", $.canales.lista_canales[index].nombre);
                    caja.append("<h3>"+lista[i].title+"</h3><br/>");
                    if (lista[i].summary.content === undefined){
                        caja.append("<p>"+lista[i].summary+"</p>");
                    }else{
                         caja.append("<p>"+lista[i].summary.content+"</p>");
                        
                    }
                    caja.append("<p>"+lista[i].updated+"</p>");
                    caja.append("<p> <a href='"+lista[i].link+"'>Pulse aquí para abrir la noticia.</a></p>");
                                     
                    $("#news").append(caja);
                } 
                } 
    });
}
    