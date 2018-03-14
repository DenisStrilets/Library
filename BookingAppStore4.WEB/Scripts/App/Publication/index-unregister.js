$(document).ready(function () {
    dataSource = new kendo.data.DataSource({

        transport: {
            read:
            {
                url: "publication/getall",
                dataType: "json",
            },

        },

        schema:
        {
            model:
            {
                id: "PublicationId",
                fields: {
                    PublicationId: { editable: false, nullable: true, type: "number" },
                    Name: { editable: true, nullable: true, type: "string" },
                    Title: { editable: true, nullable: true, type: "string" },

                    RedactionName: { editable: true, nullable: true, type: "string" },
                    AuthorName: { editable: true, nullable: true, type: "string" },

                    Tome: { editable: false, nullable: true, type: "number" },
                    Pages: { editable: true, nullable: true, type: "number" },
                    Price: { editable: true, nullable: true, type: "number" },
                }
            }
        }
    });

    $("#publications-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: "inline",

        columns: [
            {
                field: "Name",
                title: "Publiction",
                sortable: true
            },
            {
                field: "Price",
                title: "Price",
                sortable: true
            },
            {

                title: "Image",
                template: '<img style="width: 80px; height: 60px;" src="data:image/gif;base64,#=Image64#" />'
            },

        ],
        height: "500px",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
    }).data("kendoGrid");
});