$(document).ready(function () {
    dataSource = new kendo.data.DataSource({

        transport: {
            read:
            {
                url: "redaction/getall",
                dataType: "json",
            },
        },

        schema:
        {
            model:
            {
                id: "RedactionId",
                fields: {
                    RedactionId: { editable: false, nullable: true, type: "number" },
                    RedactionName: { editable: true, nullable: true, type: "string" },
                    Country: { editable: true, nullable: true, type: "string" },
                }
            }
        }

    });

    $("#redactions-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: "inline",
        toolbar: [{
            template:
            '<a href="Redaction/Create">Add new Redaction</a>',

        }],

        columns: [
            {
                field: "RedactionName",
                title: "Redaction",
                sortable: true
            },
            {
                field: "Country",
                title: "Country",
                sortable: true
            },

            {
                field: "RedactionId",
                title: "Actions", sortable: false,
                template:
                '<a href="Redaction/Edit/#= RedactionId #" >Edit</a>',
            },

            {
                template:
                '<a href="Redaction/Delete/#= RedactionId #" >Delete</a>'
            }

        ],
        height: "500px",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
    }).data("kendoGrid");
});