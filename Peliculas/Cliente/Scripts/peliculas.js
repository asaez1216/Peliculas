var app = angular.module("peliculas", ["ngRoute"]);
app.config(Rutas);
app.constant("urlApiPeliculas", "/api/pelicula/");

function Rutas($routeProvider) {

    $routeProvider.when("/lista", { templateUrl: "/cliente/vistas/lista.html" })
    .when("/detalles/:id", { templateUrl: "/cliente/vistas/detalles.html" })
    .otherwise(
    {redirecto:"/lista"})

}

