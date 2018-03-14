$(document).ready(function () {

    dataSource = new kendo.data.DataSource({


        transport: {
            read:
            {
                url: "gournal/getall",
                dataType: "json",
            },
        },

        schema:
        {
            model:
            {
                id: "GournalId",
                fields: {
                    GournalId: { editable: false, nullable: true, type: "number" },
                    Name: { editable: true, nullable: true, type: "string" },
                    Genre: { editable: true, nullable: true, type: "string" },
                    RedactionName: { editable: true, nullable: true, type: "string" },
                    MainEditor: { editable: true, nullable: true, type: "string" },
                    Price: { editable: false, nullable: true, type: "number" },
                    Circulation: { editable: false, nullable: true, type: "number" },
                }
            }
        }

    });

    $("#gournals-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: "inline",


        columns: [
            {
                field: "Name",
                title: "Gournal",
                sortable: true
            },
            {
                field: "Genre",
                title: "Genre",
                sortable: true
            },
            {
                field: "RedactionName",
                title: "Redaction",
                sortable: true
            },
            {
                field: "MainEditor",
                title: "MainEditor",
                sortable: true
            },
            {
                field: "Price",
                title: "Price",
                sortable: true
            },
            {
                field: "Circulation",
                title: "Circulation",
                sortable: true
            },

            {

                title: "Image",
                template: '<img style="width: 80px; height: 60px;" src="data:image/gif;base64,#=Image64#" />'
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