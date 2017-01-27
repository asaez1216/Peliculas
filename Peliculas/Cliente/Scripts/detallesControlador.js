app.controller("detallesController", DetallesController);

function DetallesController($scope, peliculasServicio,$routeParams) {

    var id = $routeParams.id;

    // ojo que recupera la película seleccionada en la lista
    // tiene sentido porque se pudo actualizar mientras se estaba viendo

    peliculasServicio.getById(id).success(function (data) {

       
        $scope.pelicula = data;


    });

    // copia los datos actuales de la pelicula

    $scope.edit=function(){
        $scope.edit.pelicula=angular.copy($scope.pelicula);
    };
    
}