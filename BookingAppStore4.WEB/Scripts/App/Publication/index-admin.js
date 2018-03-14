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
        toolbar: [{
            template:
            '<a href="Publication/Create">Add new Publication</a>',

        }],

        columns: [
            {
                field: "Name",
                title: "Publiction",
                sortable: true
            },
            {
                field: "RedactionName",
                title: "Redaction",
                sortable: true
            },
            {
                field: "AuthorName",
                title: "Author",
                sortable: true
            },
            {
                field: "Title",
                title: "Title",
                sortable: true
            },
            {
                field: "Tome",
                title: "Tome",
                sortable: true
            },
            {
                field: "Pages",
                title: "Page",
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

            {
                field: "PublicationId",
                title: "Actions", sortable: false,
                template:
                '<a href="Publication/Edit/#= PublicationId #" >Edit</a>',
            },

            {
                template:
                '<a href="Publication/Delete/#= PublicationId #" >Delete</a>'
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