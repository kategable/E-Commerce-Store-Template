var urlPath = "/api/Data/Buyers";
var defaultItem = { Buyers: ko.observableArray([]),  Name: "", Description: "",  Price: "" };


var indexVM = function() {
    var self = this;

    self.Buyers= ko.observableArray([]);
    self.Title= "Create New Item"; 
    self.AddBuyers = function (id, name) {
        self.Buyers.push({Id:id,BuyerName:name});
    }
    self.loadData = function () {
        var self = this;
        //Ajax Call Get All Articles
        $.ajax({
            type: "GET",
            url: urlPath ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Buyers(data); //Put the response in ObservableArray             
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });

    }
};

var vm = new indexVM();

$(function () {
    ko.applyBindings(vm);
   // vm.loadData();
});