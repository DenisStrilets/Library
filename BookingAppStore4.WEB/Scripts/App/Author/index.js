

$(document).ready(function () {
    dataSource = new kendo.data.DataSource({

        transport: {
            read:
            {
                url: "author/getall",
                dataType: "json",
            },
        },

        schema:
        {
            model:
            {
                id: "AuthorId",
                fields: {
                    AuthorId: { editable: false, nullable: true, type: "number" },
                    AuthorName: { editable: true, nullable: true, type: "string" },
                    Country: { editable: true, nullable: true, type: "string" },
                    YearOfBirth: { editable: true, nullable: true, type: "number" },
                }
            }
        }


    });

    $("#authors-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: "inline",
        toolbar: [{
            template:
            '<a href="Author/Create">Add new Author</a>',

        }],

        columns: [
            {
                field: "AuthorName",
                title: "Author",
                sortable: true
            },
            {
                field: "Country",
                title: "Country",
                sortable: true
            },

            {
                field: "YearOfBirth",
                title: "Year of Birth",
                sortable: true
            },

            {
                field: "RedactionId",
                title: "Actions", sortable: false,
                template:
                '<a href="Author/Edit/#= AuthorId #" >Edit</a>',
            },

            {
                template:
                '<a href="Author/Delete/#= AuthorId #" >Edit</a>'
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
