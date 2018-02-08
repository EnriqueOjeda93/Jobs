
$.canales = {};

/* 
 * Lista de $.canales. No hay repetidos (con URL repetida).
 * Sí se puede tener dos con el mismo nombre.
 * @type Array
 */

// se va a machacar con el load()
$.canales.lista_canales = [
    {nombre:"Ideal Jaén", url:"http://www.ideal.es/jaen/rss/atom/portada", tipo:"atom"},
    {nombre:"Slashdot", url:"http://rss.slashdot.org/Slashdot/slashdotLinuxAtom", tipo:"atom"},
    {nombre:"CNN", url:"http://rss.cnn.com/rss/edition.rss", tipo:"rss"}
];

/**
 * Esta función añade un canal a la lista y si existe la URL, 
 * lo actualiza
 * @param {canal} nuevo_canal El canal a añadir
 */
$.canales.create = function(nuevo_canal) {
    var url = nuevo_canal.url;
    var existe = false;
    for (var i=0; i<$.canales.lista_canales.length; i++) {
        if ($.canales.lista_canales[i].url === url){
            existe = true;
            $.canales.lista_canales[i]=nuevo_canal;
            $.canales.save(); // Actualizar (nombre)
        }
    }
    if (existe === false) {
        $.canales.lista_canales.push(nuevo_canal);
        console.log(nuevo_canal);
        $.controller.add2rejilla($.canales.lista_canales.length-1);
        $.canales.save(); // Añadir nuevo canal
    }
    
    
};

$.canales.read = function( index ) {
    if (!isNaN(index) && (index >= 0) && ( index < $.canales.lista_canales.length)) {
        return($.canales.lista_canales[index]);
    } else {
        return(null);
    }
};

/*
 * Devuelve el canal que tenga esa misma URL.
 */
$.canales.findByURL = function ( url ){
    var encontrado = null;
    for (var i=0; i< $.canales.lista_canales.length; i++){
        if ($.canales.lista_canales[i].getUrl() === url) {
            return ($.canales.lista_canales[i]);
        }
    }
    return (encontrado);
};

/*
 * Devuelve en un Array los canales que tenga ese mismo tipo.
 */
$.canales.findByTipo = function ( tipo ){
    var lista = new Array(0);
    for (var i=0; i< $.canales.lista_canales.length; i++){
        if ($.canales.lista_canales[i].getTipo() === tipo) {
            lista.push($.canales.lista_canales[i]);
        }
    }
    return (lista);
};


/*
 * Devuelve en un Array los canales que tenga ese mismo tipo.
 */
$.canales.findByNombre = function ( nombre ){
    var lista = new Array(0);
    for (var i=0; i< $.canales.lista_canales.length; i++){
        if ($.canales.lista_canales[i].getNombre() === nombre) {
            lista.push($.canales.lista_canales[i]);
        }
    }
    return (lista);
};


$.canales.update = function ( index, nuevoNombre) {    
    if (!isNaN(index)) {
        if (index>=0 && index <$.canales.lista_canales.length){
            $.canales.lista_canales[index].nombre = nuevoNombre;
        }
    }
};

$.canales.delete = function ( index ) {
    for (var i = 0; i < $.canales.lista_canales.length; i++) {
        console.log($.canales.lista_canales[i].nombre);
    }
    $.canales.lista_canales.splice(index,1);
    for (var i = 0; i < $.canales.lista_canales.length; i++) {
        console.log($.canales.lista_canales[i].nombre);
    }
};

$.canales.tam = function (){
    return $.canales.lista_canales.length;
};


/**
 * Guarda a localStorage la lista de marcadores
 * @returns {undefined}
 */
$.canales.save =  function(){
    localStorage.setItem('canales', JSON.stringify($.canales.lista_canales));
};

/**
 * Carga de localStorage la lista de marcadores
 * @returns {undefined}
 */
$.canales.load =  function(){
    $.canales.lista_canales = JSON.parse(localStorage.getItem('canales'));
    
    if ($.canales.lista_canales === null) {
        $.canales.lista_canales = new Array(0);
    }
};