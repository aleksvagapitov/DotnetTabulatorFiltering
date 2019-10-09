var baseUrl = document.location.origin;
var apiEndpoint = "/Home/GetTabulatorData";

var table = new Tabulator("#example-table", {
    pagination: "remote",
    ajaxURL: baseUrl + apiEndpoint,
    paginationSize: 10,
    paginationSizeSelector: [10, 20, 30, 50],
    ajaxFiltering: true,
    ajaxSorting: true,
    columns: [
        { title: "FirstName", field: "firstName", sorter: "string", headerFilter: "input" },
        { title: "LastName", field: "lastName", sorter: "string", headerFilter: "input" },
        { title: "Age", field: "age", sorter: "number", headerFilter: "input" },
        { title: "Gender", field: "gender", sorter: "string", headerFilter: "input" },
        { title: "Email", field: "email", sorter: "string", headerFilter: "input" },
        { title: "ZipCode", field: "zipCode", sorter: "number", headerFilter: "input" },
        { title: "About", field: "about", sorter: "string", headerFilter: "input", width: 500 }
    ]
});