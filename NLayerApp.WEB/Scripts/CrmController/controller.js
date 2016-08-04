(function () {

var app = angular.module("CrmApp", []);

$(function () {
    
    $.connection.hub.logging = true;
    $.connection.hub.start();

});
app.value('crm',$.connection.crmHub);

app.controller("CrmController", function ($scope,$http,crm) {

    $scope.id_object = 0;
    
    crm.client.UpdateClient = function (id) {

        $http({ method: 'GET', url: '/Home/GetClients' }).
             success(function (data) {
                 $scope.clients = data;
             });
        
        $scope.$apply();
    };

    crm.client.UpdateCours = function (id) {

        $http({ method: 'GET', url: '/Home/GetCourses' }).
             success(function (data) {
                 $scope.courses = data;
             });

        $scope.$apply();
    };

    crm.client.UpdateEvent = function (id) {

        $http({ method: 'GET', url: '/Home/GetEvents' }).
             success(function (data) {
                 $scope.events = data;
             });

        $scope.$apply();
    };

    $scope.deleteClient = function (id) {

        $http({ method: 'GET', url: '/Home/DeleteClient', params: { 'id': id } }).
            success(function () {
                crm.server.deleteClient();
            });
    };
    $scope.deleteCours = function (id) {

        $http({ method: 'GET', url: '/Home/DeleteCours', params: { 'id': id } }).
            success(function () {
                crm.server.deleteCours();
            });
    };
    $scope.deleteEvent = function (id) {

        $http({ method: 'GET', url: '/Home/DeleteEvent', params: { 'id': id } }).
            success(function () {
                crm.server.deleteEvent();
            });
    };

    $scope.createClient = function (client, clientForm) {
        if (clientForm.$valid) {
            
            $http({ method: 'POST', url: '/Home/CreateClient', params: { 'name': client.name ,'sname':client.sname, 'email':client.email} }).
            success(function () {
                crm.server.deleteClient();
                $scope.getClients();
            });

        } else {
            alert("Ввели неправильные данные");
        }
    }
    $scope.updateClient = function (user, clientForm2) {
        if (clientForm2.$valid) {
            $http({ method: 'POST', url: '/Home/UpdateClient', params: { 'Id':$scope.id_object,'name': user.name, 'sname': user.sname, 'email': user.email } }).
            success(function () {
                crm.server.deleteClient();
                $scope.getClients();
            });

        } else {
            alert("Ввели неправильные данные");
        }
    }

    $scope.updateClientForm = function (id) {
        $scope.id_object = id;
        $http({ method: 'GET', url: '/Home/GetClient', params: { 'id': id } }).
            success(function (data) {
                $scope.user = data;
            });
        $scope.value = 5;
    }
    $scope.createCours = function (cours,coursForm) {
        if (coursForm.$valid) {

            $http({ method: 'POST', url: '/Home/CreateCours', params: { 'cname': cours.cname, 'duration': cours.duration } }).
            success(function () {
                crm.server.deleteCours();
                $scope.getCourses();
            });

        } else {
            alert("Ввели неправильные данные");
        }
    }

    $scope.updateCoursForm = function (id) {
        $scope.id_object = id;
        $http({ method: 'GET', url: '/Home/GetCours', params: { 'id': id } }).
            success(function (data) {
                $scope.crs = data;
            });
        $scope.value = 7;
    }
    $scope.updateCours = function (crs, coursForm2) {
        if (coursForm2.$valid) {
            $http({ method: 'POST', url: '/Home/UpdateCours', params: { 'Id':$scope.id_object,'cname': crs.cname, 'duration': crs.duration } }).
            success(function () {
                crm.server.deleteCours();
                $scope.getCourses();
            });

        } else {
            alert("Ввели неправильные данные");
        }
    }
    $scope.createEvent = function (event, eventForm) {
        if (eventForm.$valid) {
            
            $http({ method: 'GET', url: '/Home/CreateEvent', params: { 'client_id': event.client_id, 'cours_id': event.cours_id, 'date': event.date, 'time': event.time } }).
            success(function () {
                
                crm.server.deleteEvent();
                $scope.getEvents();
            });

        } else {
            alert("Ввели неправильные данные");
        }
    }
    $scope.getEventForm = function () {
        $http({ method: 'GET', url: '/Home/GetClients' }).
              success(function (data) {
                  $scope.client_objects = data;
              });
        $http({ method: 'GET', url: '/Home/GetCourses' }).
              success(function (data) {
                  $scope.cours_objects = data;
              });
        $scope.value = 8;
    }

    $scope.updateEventForm = function (id) {
        $scope.id_object = id;

        $http({ method: 'GET', url: '/Home/GetClients' }).
              success(function (data) {
                  $scope.client_objects = data;
              });
        $http({ method: 'GET', url: '/Home/GetCourses' }).
              success(function (data) {
                  $scope.cours_objects = data;
              });

        $http({ method: 'GET', url: '/Home/GetEvent', params: { 'id': id } }).
            success(function (data) {
                $scope.ev = data;
            });
        $scope.value = 9;
    }

    $scope.updateEvent = function (ev, eventForm2) {
        if (eventForm2.$valid) {
            $http({ method: 'GET', url: '/Home/UpdateEvent', params: { 'Id': $scope.id_object, 'client_id': ev.client_id, 'cours_id': ev.cours_id, 'date': ev.date, 'time': ev.time } }).
            success(function () {
                crm.server.deleteEvent();
                $scope.getEvents();
            });

        } else {
            alert("Ввели неправильные данные");
        }
    }

    $scope.value = 1;
    $http({ method: 'GET', url: '/Home/GetClients' }).
             success(function (data) {
                 $scope.clients = data;
             });
    
    $scope.getClients = function () {
        $http({ method: 'GET', url: '/Home/GetClients' }).
              success(function (data) {
                  $scope.clients = data;
              });
        $scope.value = 1;
    }
    $scope.getCourses = function () {
        $http({ method: 'GET', url: '/Home/GetCourses' }).
              success(function (data) {
                  $scope.courses = data;
              });
        $scope.value = 2;
    }
    $scope.getEvents = function () {
        $http({ method: 'GET', url: '/Home/GetEvents' }).
              success(function (data) {
                  $scope.events = data;
              });
        $scope.value = 3;
    }

    $scope.isClients = function () {
        if ($scope.value == 1) {
            return true;
        }
            return false;
    }
    $scope.isCourses = function () {
        if ($scope.value == 2) {
            return true;
        } 
            return false;
    }
    $scope.isEvents = function () {
        if ($scope.value == 3) {
            return true;
        }
            return false;
    };
    $scope.isClientAddForm = function () {
        if ($scope.value == 4) {
            return true;
        }
        return false;
    }
    $scope.isClientUpdateForm = function () {
        if ($scope.value == 5) {
            return true;
        }
        return false;
    }
    $scope.isCoursAddForm = function () {
        if ($scope.value == 6) {
            return true;
        }
        return false;
    }
    $scope.isCoursUpdateForm = function(){
        if($scope.value == 7){
        return true;
        }
        return false;
    }
    $scope.isEventAddForm = function () {
        if ($scope.value == 8) {
            return true;
        }
        return false;
    }
    $scope.isEventUpdateForm = function () {
        if($scope.value == 9){
         return true;
        }
        return false;
    }

});

}());