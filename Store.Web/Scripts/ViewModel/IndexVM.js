var urlPath = "/api/Data";
var urlViewPath = "/Pencil/Index/";

$(function () {
    var vm = new indexVM();
    ko.applyBindings(vm);
    vm.loadData();
});
var indexVM =function() {
    var self = this;
    self.Pencils =  ko.observableArray([]);    
    self.loadData= function () {
        var self = this;
        //Ajax Call Get All Articles
        $.ajax({
            type: "GET",
            url: urlPath ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                for (var i = 0; i < data.pencils.length; i++) {
                    data.pencils[i].url = urlViewPath + data.pencils[i].Id;
                }
                self.Pencils(data.pencils); //Put the response in ObservableArray             
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });

    }
};

 