  
    app.controller("listController",["$scope","peliculasServicio",ListController]);

    function ListController($scope, peliculasServicio) {

        peliculasServicio.getAll()
        .success(function (data) {

            $scope.peliculas = data;

         })

        $scope.create = function () {

            $scope.edit = {
                pelicula: {
                    NombrePelicula: "",
                    NombreDirector: "",
                    AcnoEstreno: 0

                }
            }
        };// fin create

        $scope.delete = function (pelicula) {

            peliculasServicio.delete(pelicula).success(function () {

                eliminaPeliculaPorId(pelicula.PeliculaId)

            });

        };// fin delete


        var eliminaPeliculaPorId = function (id) {

            // busca la película en la lista y la elimina. el uso de for obliga a un break para salir del ciclo
            // lo anterior será una buena practica?

            for (var i = 0; i < $scope.peliculas.length; i++) {

                if ($scope.peliculas[i].PeliculaId == id) {
                    $scope.peliculas.splice(i, 1); // remueve 1 elemento de la posición i 
                    break;

                }//fin if

            }//fin for

        }

    }// fin listacontroller
