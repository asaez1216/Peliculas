
app.factory("peliculasServicio", PeliculasServicio);

function PeliculasServicio($http,urlApiPeliculas) {


        var getAll = function () {

            return $http.get(urlApiPeliculas);

        };

        var getById = function (id) {

            return $http.get(urlApiPeliculas + id);
        }

        var update = function (pelicula) {
            return $http.put(urlApiPeliculas, pelicula);
        }

        var create = function (pelicula) {

            return $http.post(urlApiPeliculas, pelicula);
        }

        var destroy = function (pelicula) {
            return $http.delete(urlApiPeliculas + pelicula.PeliculaId);
        }

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy

        };

    }

