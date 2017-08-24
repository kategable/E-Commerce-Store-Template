var urlPath = "/api/Data"; 

$(function () {
    var vm= new updateVM();
    ko.applyBindings(vm);
    vm.loadData();
});
function Buyer(data) {
    var self = this;
    self.Id = data.Id;
    self.BuyerName = data.BuyerName;
}
var updateVM =function() {
    var self = this;
    self.Pencils= ko.observableArray([]);
    self.availableBuyers = ko.observableArray([]);
    
    self.selectedPencil = ko.observable();
    self.delete = function () {
       // could do a modal  
        if (confirm("Are you sure you want to delete " + self.selectedPencil().Title + "?")) {
            $.ajax({
                type: "Delete",
                url: urlPath + "/Delete/" + self.selectedPencil().Id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",               
                success: function (data) {
                    self.loadDataToScreen(data);
                },
                error: function (err) {
                    alert(err.status + " : " + err.statusText);
                }
            });
        }
    }
    self.loadDataToScreen = function (data) {
        if (data.pencils.length > 0) {
            self.selectedPencil(data.pencils[0]);
        }
        for (var i = 0; i < data.pencils.length; i++) {
            data.pencils[i].BuyersList = ko.observableArray();
            for (var j = 0; j < data.pencils[i].Buyers.length; j++) {
                data.pencils[i].BuyersList.push(data.pencils[i].Buyers[j].Id);
            }
        }
        self.availableBuyers(ko.utils.arrayMap(data.buyers, function (item) { return new Buyer(item); }));
        self.Pencils(data.pencils); //Put the response in ObservableArray    
    }
    self.save = function () {
        var updatedItem = self.selectedPencil();
        $.ajax({
            type: "Put",
            url: urlPath + "/Put/" + updatedItem.Id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(updatedItem),
            success: function (data) {              
                self.loadDataToScreen(data);
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    }
    self.loadData= function () {
        var self = this;
        //Ajax Call Get All Articles
        $.ajax({
            type: "GET",
            url: urlPath,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.loadDataToScreen(data);
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });

    }
};

