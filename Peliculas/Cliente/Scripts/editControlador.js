app.controller("editControlador",["$scope","peliculasServicio",EditControlador]);

function EditControlador($scope, peliculasServicio) {
    $scope.esEditable = function () {

        return $scope.edit && $scope.edit.pelicula;
    };

    $scope.cancel = function () {

        $scope.edit.pelicula = null;
    };

    $scope.save = function () {
        if ($scope.edit.pelicula.PeliculaId) {

            actualizarPelicula();
        } else {
            crearPelicula();
        }
    };

    var actualizarPelicula = function () {

        peliculasServicio.update($scope.edit.pelicula).success(function () {
            angular.extend($scope.pelicula, $scope.edit.pelicula);
            $scope.edit.pelicula = null;
         });
    };
    // al crear una película se agrega a la lista 
    var crearPelicula = function () {
        console.log("inicio crear")
        peliculasServicio.create($scope.edit.pelicula).then(function (pelicula) {

            console.log(pelicula);

            $scope.peliculas.push(pelicula);
            $scope.edit.pelicula = null;

        }, function (error) {

            console.log(error);

        });

    };
}